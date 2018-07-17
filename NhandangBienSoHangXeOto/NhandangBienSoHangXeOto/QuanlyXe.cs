using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NhandangBienSoHangXeOto
{
    public partial class QuanlyXe : Form
    {
        public QuanlyXe()
        {
            InitializeComponent();
        }
        protected int IDXeEdit = -1;
                
        private void HangXe_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carInfoDataSet.tblXe' table. You can move, or remove it, as needed.
            this.tblXeTableAdapter.Fill(this.carInfoDataSet.tblXe);
            // TODO: This line of code loads data into the 'carInfoDataSet.tblHangXe' table. You can move, or remove it, as needed.

        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image (*.bmp; *.jpg; *.jpeg; *.png) |*.bmp; *.jpg; *.jpeg; *.png|All files (*.*)|*.*||";
            dlg.InitialDirectory = Application.StartupPath + "\\AnhChuXe";
            if (dlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            picChuXe.ImageLocation = dlg.FileName;
            txtUrlPic.Text = dlg.FileName;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            (sender as DataGridView).Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.carInfoDataSet.tblXe.AddtblXeRow(txtTenChuXe.Text, txtDiaChi.Text, txtBienSo.Text, txtMauXe.Text, txtUrlPic.Text, txtHangXe.Text, txtDongXe.Text, txtNamSX.Text);
                this.tblXeTableAdapter.Update(this.carInfoDataSet);
                MessageBox.Show("Thêm mới thành công!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi thêm mới dữ liệu!");
            }
            
            //dataGridView1.DataSource = tblXeTableAdapter;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                txtTenChuXe.Text = row.Cells[2].Value.ToString();
                txtDiaChi.Text = row.Cells[3].Value.ToString();
                txtBienSo.Text = row.Cells[7].Value.ToString();
                txtMauXe.Text = row.Cells[8].Value.ToString();
                txtUrlPic.Text = row.Cells[9].Value.ToString();
                txtHangXe.Text = row.Cells[4].Value.ToString();
                txtDongXe.Text = row.Cells[5].Value.ToString();
                txtNamSX.Text = row.Cells[6].Value.ToString();
                picChuXe.ImageLocation = txtUrlPic.Text;
                IDXeEdit = int.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.tblXeTableAdapter.Update(txtTenChuXe.Text, txtDiaChi.Text, txtHangXe.Text, txtDongXe.Text,txtBienSo.Text, txtMauXe.Text, txtUrlPic.Text,  txtNamSX.Text,IDXeEdit,IDXeEdit);
                dataGridView1.DataSource = tblXeTableAdapter.GetData();
                MessageBox.Show("Sửa dữ liệu thành công!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Lỗi sửa dữ liệu!");
            }
        }
    }
}
