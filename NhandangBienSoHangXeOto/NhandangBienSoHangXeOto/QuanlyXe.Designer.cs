namespace NhandangBienSoHangXeOto
{
    partial class QuanlyXe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanlyXe));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtHangXe = new System.Windows.Forms.TextBox();
            this.txtDongXe = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDXeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotenChuxeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenHangXeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDongXeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namSXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biensoxeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mauxeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlImageChuXeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblXeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carInfoDataSet = new NhandangBienSoHangXeOto.CarInfoDataSet();
            this.tblXeTableAdapter = new NhandangBienSoHangXeOto.CarInfoDataSetTableAdapters.tblXeTableAdapter();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenChuXe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUrlPic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowsePic = new System.Windows.Forms.Button();
            this.txtMauXe = new System.Windows.Forms.TextBox();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.picChuXe = new System.Windows.Forms.PictureBox();
            this.txtNamSX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblXeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carInfoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuXe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên hãng xe:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên dòng xe:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Năm sản xuất:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(756, 65);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(812, 65);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(49, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtHangXe
            // 
            this.txtHangXe.Location = new System.Drawing.Point(88, 66);
            this.txtHangXe.Name = "txtHangXe";
            this.txtHangXe.Size = new System.Drawing.Size(55, 20);
            this.txtHangXe.TabIndex = 5;
            // 
            // txtDongXe
            // 
            this.txtDongXe.Location = new System.Drawing.Point(228, 67);
            this.txtDongXe.Name = "txtDongXe";
            this.txtDongXe.Size = new System.Drawing.Size(100, 20);
            this.txtDongXe.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.iDXeDataGridViewTextBoxColumn,
            this.hotenChuxeDataGridViewTextBoxColumn,
            this.diachiDataGridViewTextBoxColumn,
            this.tenHangXeDataGridViewTextBoxColumn,
            this.tenDongXeDataGridViewTextBoxColumn,
            this.namSXDataGridViewTextBoxColumn,
            this.biensoxeDataGridViewTextBoxColumn,
            this.mauxeDataGridViewTextBoxColumn,
            this.urlImageChuXeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblXeBindingSource;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(984, 435);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            this.dataGridView1.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView1_RowStateChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // iDXeDataGridViewTextBoxColumn
            // 
            this.iDXeDataGridViewTextBoxColumn.DataPropertyName = "IDXe";
            this.iDXeDataGridViewTextBoxColumn.HeaderText = "IDXe";
            this.iDXeDataGridViewTextBoxColumn.Name = "iDXeDataGridViewTextBoxColumn";
            this.iDXeDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDXeDataGridViewTextBoxColumn.Visible = false;
            // 
            // hotenChuxeDataGridViewTextBoxColumn
            // 
            this.hotenChuxeDataGridViewTextBoxColumn.DataPropertyName = "HotenChuxe";
            this.hotenChuxeDataGridViewTextBoxColumn.HeaderText = "Chủ xe";
            this.hotenChuxeDataGridViewTextBoxColumn.Name = "hotenChuxeDataGridViewTextBoxColumn";
            this.hotenChuxeDataGridViewTextBoxColumn.Width = 150;
            // 
            // diachiDataGridViewTextBoxColumn
            // 
            this.diachiDataGridViewTextBoxColumn.DataPropertyName = "Diachi";
            this.diachiDataGridViewTextBoxColumn.HeaderText = "Địa chỉ";
            this.diachiDataGridViewTextBoxColumn.Name = "diachiDataGridViewTextBoxColumn";
            this.diachiDataGridViewTextBoxColumn.Width = 170;
            // 
            // tenHangXeDataGridViewTextBoxColumn
            // 
            this.tenHangXeDataGridViewTextBoxColumn.DataPropertyName = "TenHangXe";
            this.tenHangXeDataGridViewTextBoxColumn.HeaderText = "Hãng xe";
            this.tenHangXeDataGridViewTextBoxColumn.Name = "tenHangXeDataGridViewTextBoxColumn";
            // 
            // tenDongXeDataGridViewTextBoxColumn
            // 
            this.tenDongXeDataGridViewTextBoxColumn.DataPropertyName = "TenDongXe";
            this.tenDongXeDataGridViewTextBoxColumn.HeaderText = "Dòng xe";
            this.tenDongXeDataGridViewTextBoxColumn.Name = "tenDongXeDataGridViewTextBoxColumn";
            // 
            // namSXDataGridViewTextBoxColumn
            // 
            this.namSXDataGridViewTextBoxColumn.DataPropertyName = "NamSX";
            dataGridViewCellStyle2.Format = "yyyy";
            this.namSXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.namSXDataGridViewTextBoxColumn.HeaderText = "Năm SX";
            this.namSXDataGridViewTextBoxColumn.Name = "namSXDataGridViewTextBoxColumn";
            this.namSXDataGridViewTextBoxColumn.Width = 70;
            // 
            // biensoxeDataGridViewTextBoxColumn
            // 
            this.biensoxeDataGridViewTextBoxColumn.DataPropertyName = "Biensoxe";
            this.biensoxeDataGridViewTextBoxColumn.HeaderText = "Biển số xe";
            this.biensoxeDataGridViewTextBoxColumn.Name = "biensoxeDataGridViewTextBoxColumn";
            // 
            // mauxeDataGridViewTextBoxColumn
            // 
            this.mauxeDataGridViewTextBoxColumn.DataPropertyName = "Mauxe";
            this.mauxeDataGridViewTextBoxColumn.HeaderText = "Màu xe";
            this.mauxeDataGridViewTextBoxColumn.Name = "mauxeDataGridViewTextBoxColumn";
            this.mauxeDataGridViewTextBoxColumn.Width = 70;
            // 
            // urlImageChuXeDataGridViewTextBoxColumn
            // 
            this.urlImageChuXeDataGridViewTextBoxColumn.DataPropertyName = "UrlImageChuXe";
            this.urlImageChuXeDataGridViewTextBoxColumn.HeaderText = "Url ảnh chủ xe";
            this.urlImageChuXeDataGridViewTextBoxColumn.Name = "urlImageChuXeDataGridViewTextBoxColumn";
            this.urlImageChuXeDataGridViewTextBoxColumn.Width = 120;
            // 
            // tblXeBindingSource
            // 
            this.tblXeBindingSource.DataMember = "tblXe";
            this.tblXeBindingSource.DataSource = this.carInfoDataSet;
            // 
            // carInfoDataSet
            // 
            this.carInfoDataSet.DataSetName = "CarInfoDataSet";
            this.carInfoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblXeTableAdapter
            // 
            this.tblXeTableAdapter.ClearBeforeFill = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(271, 21);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(213, 20);
            this.txtDiaChi.TabIndex = 12;
            // 
            // txtTenChuXe
            // 
            this.txtTenChuXe.Location = new System.Drawing.Point(88, 21);
            this.txtTenChuXe.Name = "txtTenChuXe";
            this.txtTenChuXe.Size = new System.Drawing.Size(126, 20);
            this.txtTenChuXe.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tên chủ xe:";
            // 
            // txtUrlPic
            // 
            this.txtUrlPic.Location = new System.Drawing.Point(571, 21);
            this.txtUrlPic.Name = "txtUrlPic";
            this.txtUrlPic.Size = new System.Drawing.Size(152, 20);
            this.txtUrlPic.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(491, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ảnh chủ xe:";
            // 
            // btnBrowsePic
            // 
            this.btnBrowsePic.Location = new System.Drawing.Point(740, 19);
            this.btnBrowsePic.Name = "btnBrowsePic";
            this.btnBrowsePic.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePic.TabIndex = 15;
            this.btnBrowsePic.Text = "Chọn ảnh...";
            this.btnBrowsePic.UseVisualStyleBackColor = true;
            this.btnBrowsePic.Click += new System.EventHandler(this.btnBrowsePic_Click);
            // 
            // txtMauXe
            // 
            this.txtMauXe.Location = new System.Drawing.Point(687, 67);
            this.txtMauXe.Name = "txtMauXe";
            this.txtMauXe.Size = new System.Drawing.Size(56, 20);
            this.txtMauXe.TabIndex = 19;
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(545, 67);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(87, 20);
            this.txtBienSo.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(639, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Màu xe:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(498, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Biển số:";
            // 
            // picChuXe
            // 
            this.picChuXe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picChuXe.Image = ((System.Drawing.Image)(resources.GetObject("picChuXe.Image")));
            this.picChuXe.Location = new System.Drawing.Point(865, 3);
            this.picChuXe.Name = "picChuXe";
            this.picChuXe.Size = new System.Drawing.Size(100, 109);
            this.picChuXe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picChuXe.TabIndex = 20;
            this.picChuXe.TabStop = false;
            // 
            // txtNamSX
            // 
            this.txtNamSX.Location = new System.Drawing.Point(415, 67);
            this.txtNamSX.Name = "txtNamSX";
            this.txtNamSX.Size = new System.Drawing.Size(69, 20);
            this.txtNamSX.TabIndex = 21;
            // 
            // QuanlyXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.txtNamSX);
            this.Controls.Add(this.picChuXe);
            this.Controls.Add(this.txtMauXe);
            this.Controls.Add(this.txtBienSo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBrowsePic);
            this.Controls.Add(this.txtUrlPic);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenChuXe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtDongXe);
            this.Controls.Add(this.txtHangXe);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QuanlyXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ THÔNG TIN PHƯƠNG TIỆN";
            this.Load += new System.EventHandler(this.HangXe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblXeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carInfoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuXe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtHangXe;
        private System.Windows.Forms.TextBox txtDongXe;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CarInfoDataSet carInfoDataSet;
        private System.Windows.Forms.BindingSource tblXeBindingSource;
        private CarInfoDataSetTableAdapters.tblXeTableAdapter tblXeTableAdapter;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenChuXe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUrlPic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowsePic;
        private System.Windows.Forms.TextBox txtMauXe;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox picChuXe;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDXeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotenChuxeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenHangXeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDongXeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namSXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn biensoxeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mauxeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlImageChuXeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtNamSX;
    }
}