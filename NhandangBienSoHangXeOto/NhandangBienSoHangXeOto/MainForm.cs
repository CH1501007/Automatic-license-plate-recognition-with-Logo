using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using System.IO;
using System.IO.Ports;
using tesseract;
using System.Collections;
using System.Threading;
using System.Media;
using System.Runtime.InteropServices;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using NhandangBienSoHangXeOto.CarInfoDataSetTableAdapters;

namespace NhandangBienSoHangXeOto
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        #region định nghĩa
        List<Image<Bgr, byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        List<Image<Bgr, byte>> LogoImagesList = new List<Image<Bgr, byte>>();
        Rectangle LicensePlatePosition;
        Image Plate_Draw;
        Image Logo_Draw;

        Image InputImg;
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();

        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";

        //int current = 0;
        bool success = true;

        PCA pca = new PCA();
        CvSVM svm = new CvSVM();
        HaarCascade haarLogo;
        HaarCascade haarLicensePlate;
        readonly string[] imgLabelName = { "Acura", "BMW", "Honda", "Hyundai", "Kia", "Lexus", "Mazda", "Mercedes", "Mitsubishi", "Toyota" };
        readonly string[] imgFolderName = { "Acura", "BMW", "Honda", "Hyundai", "Kia", "Lexus", "Mazda", "Mercedes", "Mitsubishi", "Toyota" };
        readonly int[] imgNum = {13, 246, 266, 190, 169, 412, 300, 637, 110, 350 };
        readonly string[] imgLabelPic = { "Acura.jpg", "bmw.jpg", "honda.jpg", "hyundai.jpg", "kia.jpg", "lexus.jpg", "Mazda.jpg", "MercedesBenz.jpg", "Mitsubishi-.jpg", "toyota.jpg" };

        //string ketquaLogo = "NULL";
        //int countLogo = 0;

        #endregion
        public DataRow getCarInfo(string bienso)
        {
            tblXeTableAdapter a = new tblXeTableAdapter();
            DataRow[] rows = a.GetData().Select("Biensoxe='" + bienso + "'");
            if (rows.Length > 0)
            {
                return rows[0];
            }
            else return null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\Test";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            txtBienSoReg.Text = "";
            txtHangXe.Text = "";
            imgTachbienso.Image = null;
            imgTachbiensoBinary.Image = null;
            imgTachLogo.Image = null;
            imgLogoGray.Image = null;
            imgLogoLabel.Image = null;
            LicensePlatePosition = new Rectangle();
            string startupPath = dlg.FileName;

            Image temp1;
            string temp2, temp3;

            Recognize(startupPath, out temp1, out temp2, out temp3);
            
            if (temp1 != null)
            {
                imgInputFile.Image = temp1;
            }
            else
            {
                imgInputFile.Image = InputImg;
            }
            if (temp3 == "")
                txtBienSoReg.Text = "Không phát hiện được biển số !";
            else
            {
                txtBienSoReg.Text = temp3;
                DataRow carinfo = getCarInfo(temp3.Replace("\n",""));
                if (carinfo!=null)
                {
                    txtChuXe.Text = carinfo["HotenChuXe"].ToString();
                    txtDiachi.Text = carinfo["Diachi"].ToString();
                    txtLoaiXe.Text = carinfo["TenHangXe"].ToString();
                    txtMauxe.Text = carinfo["Mauxe"].ToString();
                    txtBienso.Text = carinfo["Biensoxe"].ToString();
                    imgProfile.ImageLocation = carinfo["UrlImageChuXe"].ToString();
                } 
                else
                {
                    txtChuXe.Text = "Xe chưa đăng ký với BQL";
                    txtDiachi.Text = "";
                    txtLoaiXe.Text = "";
                    txtMauxe.Text = "";
                    txtBienso.Text = "";
                    imgProfile.ImageLocation = "";
                }
                FindLogo((Bitmap)imgInputFile.Image, out Logo_Draw);
                if (Logo_Draw != null)
                {
                    imgInputFile.Image = Logo_Draw;
                }
            }
        }

        private string Ocr(Bitmap image_s, bool isFull, bool isNum = false)
        {
            string temp = "";
            Image<Gray, byte> src = new Image<Gray, byte>(image_s);
            double ratio = 1;
            while (true)
            {
                ratio = (double)CvInvoke.cvCountNonZero(src) / (src.Width * src.Height);
                if (ratio > 0.5) break;
                src = src.Dilate(2);
            }
            Bitmap image = src.ToBitmap();

            TesseractProcessor ocr;
            if (isFull)
                ocr = full_tesseract;
            else if (isNum)
                ocr = num_tesseract;
            else
                ocr = ch_tesseract;

            int cou = 0;
            ocr.Clear();
            ocr.ClearAdaptiveClassifier();
            temp = ocr.Apply(image);
            while (temp.Length > 3)
            {
                Image<Gray, byte> temp2 = new Image<Gray, byte>(image);
                temp2 = temp2.Erode(2);
                image = temp2.ToBitmap();
                ocr.Clear();
                ocr.ClearAdaptiveClassifier();
                temp = ocr.Apply(image);
                cou++;
                if (cou > 10)
                {
                    temp = "";
                    break;
                }
            }
            return temp;

        }
        private void Recognize(string link, out Image hinhbienso, out string bienso, out string bienso_text)
        {

            hinhbienso = null;
            bienso = "";
            bienso_text = "";
            ProcessImage(link);
            if (PlateImagesList.Count != 0)
            {
                Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                Bitmap grayframe;
                FindContours con = new FindContours();
                Bitmap color;
                int c = con.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);  // Tim chu tuyen
                //int z = con.count;
                imgTachbienso.Image = color;
                hinhbienso = Plate_Draw;

                imgTachbiensoBinary.Image = grayframe;

                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                //dst = dst.Dilate(2);
                //dst = dst.Erode(3);
                grayframe = dst.ToBitmap();
                string zz = "";

                // lọc và sắp xếp số
                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                    int cou = 0;
                    full_tesseract.Clear();
                    full_tesseract.ClearAdaptiveClassifier();
                    string temp = full_tesseract.Apply(ch);
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        temp = full_tesseract.Apply(ch);
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 12;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;
                    //ch = con.Erodetion(ch);
                    string temp;
                    if (i < 2)
                    {
                        temp = Ocr(ch, false, true); // nhan dien so
                    }
                    else
                    {
                        temp = Ocr(ch, false, false);// nhan dien chu
                    }

                    zz += temp;
                    c_x++;
                }
                zz += "-";
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                    //ch = con.Erodetion(ch);
                    string temp = Ocr(ch, false, true); // nhan dien so
                    zz += temp;
                    
                }
                bienso = zz.Replace("\n", "");
                bienso = bienso.Replace("\r", "");
                bienso_text = zz;

            }
        }

        public void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            FileStream fs = new FileStream(urlImage, FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            Bitmap image = new Bitmap(img);
            fs.Close();
            InputImg = img;
            FindLicensePlate(image, out Plate_Draw);

        }

        public void FindLicensePlate(Bitmap image, out Image plateDraw)
        {
            plateDraw = null;
            Image<Bgr, byte> frame;
            bool isbienso = false;
            Bitmap src;
            Image dst = image;
            
            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    PlateImagesList.Clear();
                    frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {
                        var dsbienso =
                        grayframe.DetectHaarCascade(haarLicensePlate, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(0, 0))[0];
                        foreach (var bienso in dsbienso)
                        {
                            Image<Bgr, byte> tmp = frame.Copy();
                            tmp.ROI = bienso.rect;

                            frame.Draw(bienso.rect, new Bgr(Color.Blue), 2);

                            PlateImagesList.Add(tmp);
                            LicensePlatePosition = bienso.rect;
                            isbienso = true;
                            Image<Bgr, byte> showimg = frame.Clone();
                            plateDraw = (Image)showimg.ToBitmap();

                            PlateImagesList[0] = PlateImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                            return;
                        }
                    }
                }
            }
        }
        public bool CheckLogoPositionOK(Rectangle logo, Rectangle licenseplate)
        {
            if (logo.X + logo.Width / 2 > licenseplate.X && logo.X + logo.Width / 2 < licenseplate.X + licenseplate.Width && logo.Y + logo.Height / 2 < licenseplate.Y)
                return true;
            else return false;
        }
        public void FindLogo(Bitmap image, out Image logoDraw)
        {
            logoDraw = null;
            Image<Bgr, byte> frame;
            bool islogo = false;
            Bitmap src;
            Image dst = image;
            for (float i = 0; i <= 20; i = i + 3)
            {
                for (float s = -1; s <= 1 && s + i != 1; s += 2)
                {
                    src = RotateImage(dst, i * s);
                    LogoImagesList.Clear();
                    frame = new Image<Bgr, byte>(src);
                    using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
                    {
                        var logos =
                        grayframe.DetectHaarCascade(haarLogo, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(0, 0))[0];
                        foreach (var logo in logos)
                        {
                            
                            if (CheckLogoPositionOK(logo.rect,LicensePlatePosition))
                            {
                                islogo = true;
                                //countLogo++;
                                Image<Bgr, byte> tmp = frame.Copy();
                                tmp.ROI = logo.rect;
                                imgTachLogo.Image = frame.Copy(logo.rect).ToBitmap();
                                Image<Gray, byte> graylogo = new Image<Gray, byte>((Bitmap)imgTachLogo.Image);
                                //CvInvoke.cvAdaptiveThreshold(new Image<Bgr, byte>((Bitmap)imgTachLogo.Image), graylogo, 255, ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C, THRESH.CV_THRESH_BINARY, 21, 2);
                                imgLogoGray.Image = graylogo.ToBitmap();
                                frame.Draw(logo.rect, new Bgr(Color.Blue), 2);

                                LogoImagesList.Add(tmp);

                                LogoRecognize(graylogo.ToBitmap());


                                Image<Bgr, byte> showimg = frame.Clone();
                                logoDraw = (Image)showimg.ToBitmap();

                                //LogoImagesList[0] = LogoImagesList[0].Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                                return;
                            }
                        }
                    }
                }
            }
        }
        public static Bitmap RotateImage(Image image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            PointF offset = new PointF((float)image.Width / 2, (float)image.Height / 2);

            Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);
            rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics g = Graphics.FromImage(rotatedBmp);

            g.TranslateTransform(offset.X, offset.Y);

            g.RotateTransform(angle);

            g.TranslateTransform(-offset.X, -offset.Y);

            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Mat pcamean = ReadMatFromFile("pcamean.txt");
            //Mat pcaeivec = ReadMatFromFile("pcaeigenvectors.txt");
            //Mat pcaeival = ReadMatFromFile("pcaeigenvalues.txt");
            //pca = new PCA()
            //svm.Load("svmdatatrained.xml");
            haarLogo = new HaarCascade(Application.StartupPath + "\\logohaarcascade.xml");
            
            haarLicensePlate = new HaarCascade(Application.StartupPath + "\\biensohaarcascade.xml");
            full_tesseract = new TesseractProcessor();
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi khởi tạo Tesseract!");
                Application.Exit();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVXYZ1234567890").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi khởi tạo Tesseract!");
                Application.Exit();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ABCDEFGHIJKLMNOPQRSTUVXYZ").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi khởi tạo Tesseract!");
                Application.Exit();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890").ToString();


            m_path = System.Environment.CurrentDirectory + "\\";

            huấnLuyệnVớiPCASVMToolStripMenuItem_Click(sender, e);

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }

        private void táchVùngLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.Filter = "Text (*.txt) |*.txt|All files (*.*)|*.*||";
            //dlg.InitialDirectory = Application.StartupPath + "\\LogoDataset";
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    string[] lines = File.ReadAllLines(dlg.FileName);
            //    string path = Application.StartupPath + "\\LogoDataset\\";
            //    string pathsave = Application.StartupPath + "\\LogoCrop\\";
            //    string infosave = Application.StartupPath + "\\LogoCrop\\info.txt";
            //    string pathn = Application.StartupPath + "\\LogoTraining\\datahaar\\";
            //    string infosaven = Application.StartupPath + "\\LogoTraining\\datahaar\\info.txt";

            //    int sl =0;
            //    int x, y, width, height;
            //    Image<Bgr, byte> frame;
            //    Image<Bgr, byte> logocrop;
            //    string[] pt;
            //    string[] output;
            //    int sologo;
            //    foreach (string line in lines)
            //    {
            //        //pt = line.Split(' ');
            //        //sologo = int.Parse(pt[1]);
            //        //for (int i = 0; i < sologo; i++ )
            //        //{
            //        //    sl++;
            //        //    //cat anh logo thu i
            //        //    x = int.Parse(pt[1 + i * 4 + 1]);
            //        //    y = int.Parse(pt[1 + i * 4 + 2]);
            //        //    width = int.Parse(pt[1 + i * 4 + 3]);
            //        //    height = int.Parse(pt[1 + i * 4 + 4]);
            //        //    Bitmap b = new Bitmap(path + pt[0]);
                        
            //        //    frame = new Image<Bgr, byte>(b);
            //        //    frame.ROI = new Rectangle(x, y, width, height);
            //        //    logocrop = frame.Copy();
            //        //    logocrop.Save(pathsave + "logo" + sl.ToString() + ".bmp");
            //        //    if (width>=24 && height >=24)
            //        //    {
            //        //        File.AppendAllText(infosave, "rawdata/logo" + sl.ToString() + ".bmp 1 0 0 " + width.ToString() + " " + height.ToString() + Environment.NewLine);

            //        //    }
            //        //    b.Dispose();
            //        //    frame.Dispose();
            //        //}
            //        Bitmap b = new Bitmap(pathn + line);

            //        frame = new Image<Bgr, byte>(b);
            //        File.AppendAllText(infosaven, "rawdata/"+ line+ " 1 0 0 " + b.Width.ToString() + " " + b.Height.ToString() + Environment.NewLine);

            //        b.Dispose();
            //        frame.Dispose();
            //    }
            //}   
            //string folderPath = "LogoDataset";
            //string[] imgfiles = Directory.GetFiles(folderPath,"*.bmp");
            //int sl =0;
            //foreach (string file in imgfiles)
            //{
            //    Image<Bgr, byte> frame;
            //    bool isface = false;
            //    Bitmap src;
            //    Image dst = Bitmap.FromFile(file);
            //    for (float i = 0; i <= 20; i = i + 3)
            //    {
            //        for (float s = -1; s <= 1 && s + i != 1; s += 2)
            //        {
            //            src = RotateImage(dst, i * s);
            //            frame = new Image<Bgr, byte>(src);
            //            using (Image<Gray, byte> grayframe = new Image<Gray, byte>(src))
            //            {
            //                var faces =
            //                grayframe.DetectHaarCascade(haarLogo, 1.1, 8, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(0, 0))[0];
            //                foreach (var face in faces)
            //                {
            //                    sl++;
            //                    Image<Bgr, byte> tmp = frame.Copy();
            //                    tmp.ROI = face.rect;
            //                    frame.Copy(face.rect).ToBitmap().Save("TachLogo\\"+sl.ToString()+".bmp");

            //                    isface = true;
            //                    break;

            //                }
                          
            //            }
            //        }
                    //if (isface)
                    //{
                    //    break;
                    //}
                //}
            //}
            
        }
        // Ghi một ma trận Mat vào file để nạp lại sau này
        void WriteMatToFile(Mat m, string fileName)
        {
	        using(StreamWriter writetext = new StreamWriter(fileName))
            {
                int nCols, nRows;
	            nCols=m.Cols;
	            nRows=m.Rows;                
                writetext.WriteLine(nRows.ToString() + " " + nCols.ToString());
                for(int i=0; i<nRows; i++)
	            {
		            for(int j=0; j<nCols; j++)
		            {
			            float tmp=m.At<float>(i,j);
                        writetext.Write(tmp.ToString() + " ");
		            }
		            writetext.WriteLine();
	            }
	            writetext.Close();
            }
	        
        }
        // Đọc một ma trận từ file (load dữ liệu PCA đã tính toán).
        Mat ReadMatFromFile(string fileName)
        {
            using(StreamReader readtext = new StreamReader(fileName))
            {
                string firstline = readtext.ReadLine();
                int nCols, nRows;
                string[] rowcol = firstline.Split(' ');
                nRows = int.Parse(rowcol[0]);
                nCols = int.Parse(rowcol[1]);
                Mat m = new Mat(nRows,nCols, MatType.CV_32FC1);
                int i = 0;
                while (!readtext.EndOfStream)
                {
                    string values = readtext.ReadLine();
                    if (values.Replace(" ","")!="")
                    {
                        string[] cols = values.Split(' ');
                        for (int j = 0; j < cols.Length; j++)
                        {
                            float tmp = 0.0f;
                            tmp = float.Parse(cols[j]);
                            m.Set<float>(i, j, tmp);
                        }
                        i++;
                    }
                    
                }
                
                readtext.Close();
                return m;
            }

	        
        }
        private void huấnLuyệnVớiPCASVMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\PCA\\";

            int num = 0;
            int imgTrainingNum =0;
            foreach (int sl in imgNum)
            {
                imgTrainingNum += sl;
            }
            Mat values = new Mat(imgTrainingNum, 1, MatType.CV_32SC1); //Ma tran luu nhan tuong ung cho moi anh dau vao
            Mat[] images = new Mat[imgTrainingNum];//Luu cac anh cho huan luyen

            string folderPath="";
            Mat src;
            for (int idx = 0; idx < imgFolderName.Length; idx++)
            {
                folderPath = path + imgFolderName[idx];
                string[] imgfiles = Directory.GetFiles(folderPath);
                foreach (string file in imgfiles)
                {
                    values.Set<int>(num, 0, idx);
                    IplImage img = Cv.LoadImage(file, LoadMode.GrayScale);
                    IplImage res = Cv.CreateImage(Cv.Size(24, 24), img.Depth, img.NChannels);
                    Cv.Resize(img, res, Interpolation.Linear);
                    images[num]= new Mat(res);
                    num++;

                }
            }

            int nEigens = 300; //Thiết lập số lượng véc tơ riêng (số thành phần chính). 
            //Load images vào ma trận (mỗi ảnh là một hàng và 24x24 cột) làm dữ liệu đầu vào cho PCA. 
            Mat desc_mat = new Mat(images.Length,images[0].Rows*images[0].Cols,MatType.CV_32FC1);
            for (int i = 0; i < images.Length; i++ )
            {
                Mat xi = new Mat(1,images[0].Rows*images[0].Cols,MatType.CV_32FC1);// Mỗi hàng của ma trận là 1 ảnh đầu vào đã reshape
                // Reshape mỗi ảnh thành ma trận 1 hàng, 24x24 cột
                if (images[i].IsContinuous())
                {
                    images[i].Reshape(1, 1).ConvertTo(xi, MatType.CV_32FC1, 1, 0);
                    desc_mat.Row[i] = xi;
                }
                else
                {
                    images[i].Clone().Reshape(1, 1).ConvertTo(xi, MatType.CV_32FC1, 1, 0);
                    desc_mat.Row[i] = xi;
                }
            }
            // Phân tích thành phần chính PCA với đầu vào ở trên và số thành phần chính là nEigens;

            pca = new PCA(desc_mat, new Mat(), PCAFlag.DataAsRow, nEigens);
            Mat pcamean = pca.Mean.Clone();
            Mat pcaeigenvectors = pca.Eigenvectors.Clone();
            Mat pcaeigenvalues = pca.Eigenvalues.Clone();
            //OpenCvSharp.CPlusPlus.HOGDescriptor
            //Ma trận đặc trưng (chiếu từng ảnh lên ma trận vector riêng đặc trưng) của các ảnh đầu vào sử dụng để huấn luyện nhận dạng SVM
	        Mat data = new Mat(desc_mat.Rows, nEigens, MatType.CV_32FC1); 
	        //chiếu các ảnh đầu vào lên không gian đặc trưng PCA 
	        for(int i=0; i<images.Length; i++) { 
		        Mat projectedMat = new Mat(1, nEigens, MatType.CV_32FC1); 
		        Mat ttt = desc_mat.Row[i];
		        pca.Project(ttt, projectedMat); 
		        data.Row[i] = projectedMat.Row[0]; 
	        }

            //Lưu ảnh trung bình, eigenvectors và eigenvalues vào file phục vụ nhận dạng sau này.
            //WriteMatToFile(pcamean, "pcamean.txt");
            //WriteMatToFile(pcaeigenvalues, "pcaeigenvalues.txt");
            //WriteMatToFile(pcaeigenvectors, "pcaeigenvectors.txt");
            //Huấn luyện nhận dạng với SVM (đặc trưng đầu vào là đặc trưng PCA)
            //https://docs.opencv.org/2.4.13.2/modules/ml/doc/support_vector_machines.html
            var criteria = TermCriteria.Both(10000,0.01);
            var param = new CvSVMParams(
                SVMType.CSvc,
                SVMKernelType.Linear,
                3.43, // degree
                5.383, // gamma
                19.6, // coeff0
                2.67, // c
                0.1, // nu
                0.0, // p
                null,
                criteria);
            svm.Train(data, values, null, null, param);
            //svm.Train(data, values, null, null, new CvSVMParams(SVMType.CSvc, SVMKernelType.Linear, 0, 0, 0, 2, 0, 0, null, new CvTermCriteria(CriteriaType.Epsilon, 100, 0.01)));
            svm.Save("svmdatatrained.xml");
            
            MessageBox.Show("Huấn luyện xong!");
            
        }

       

        void LogoRecognize(Bitmap logo)
        {
            try
            {
                txtHangXe.Text = "";
                logo.Save("logotmp.bmp");
                IplImage img = Cv.LoadImage("logotmp.bmp", LoadMode.GrayScale);
                IplImage res = Cv.CreateImage(Cv.Size(24, 24), img.Depth, img.NChannels);
                Cv.Resize(img, res, Interpolation.Linear);
                Mat src = new Mat(res);
                Mat cs = new Mat(1, 24 * 24, MatType.CV_32FC1);
                // Chuyển ảnh xám 24x24 cần nhận dạng về dạng ma trận 1 hàng 24x24 cột
                if (src.IsContinuous())
                {
                    src.Reshape(1, 1).ConvertTo(cs, MatType.CV_32FC1, 1, 0);
                }
                else
                {
                    src.Clone().Reshape(1, 1).ConvertTo(cs, MatType.CV_32FC1, 1, 0);
                }
                // Chiếu ảnh này lên không gian đặc trưng PCA đã tính toán được từ trước (load ra từ file đã tính).

                Mat projectedMat = new Mat(1, pca.Eigenvectors.Rows, MatType.CV_32FC1);
                pca.Project(cs, projectedMat);
                CvMat d3 = (CvMat)projectedMat;
                // Nhận dạng ảnh này, kết quả nhận dạng lưu vào ret.
                float ret = svm.Predict(d3);
                string ketqua = "Không nhận dạng được logo";
                if (ret >= 0)
                {
                    int idx = (int)ret;
                    ketqua = imgLabelName[idx];
                    imgLogoLabel.Image = Bitmap.FromFile("Labels\\" + imgLabelPic[idx]);
                }
                txtHangXe.Text = ketqua;
                //ketquaLogo = ketqua;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Cần phải huấn luyện nhận dạng logo trước!");
            }
            
        }

        private void thôngTinPhươngTiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanlyXe frm = new QuanlyXe();
            frm.ShowDialog(this);
        }

        //private void kiểmTraĐộChínhXácToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        
        //    string path = Application.StartupPath + "\\Test\\";;
        //    string[] fileList = Directory.GetFiles(path, "*.*");

        //    String filepath = "E:\\test2.doc";// đường dẫn của file muốn tạo
        //    FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
        //    StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 

        //    for (int i = 0; i < fileList.Length; i++)
        //    {
        //        sWriter.Write(fileList[i] + "-");
        //        Image temp1;
        //        string temp2, temp3;
        //        Recognize(fileList[i].ToString(), out temp1, out temp2, out temp3);

        //        if (temp3 == "")
        //            sWriter.Write("Không phát hiện được biển số !");
        //        else
        //        {
        //             Image imgLogo = Image.FromFile(fileList[i]);    
        //             sWriter.Write(temp3 + "-");
        //             FindLogo((Bitmap)imgLogo, out Logo_Draw);
        //             sWriter.WriteLine(ketquaLogo);
        //        }
        //    }

        //    sWriter.Flush();
        //    fs.Close();
        //    MessageBox.Show(countLogo.ToString());

        //}
    }
}
