
namespace QuanLyKyTucXa
{
    partial class frmQuanLyPhong
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
            this.dgvThongTin = new System.Windows.Forms.DataGridView();
            this.btnTroVe = new System.Windows.Forms.Button();
            this.btnChuyenPhong = new System.Windows.Forms.Button();
            this.cmbKhu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClearText = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.txtSoLuongMax = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtMaKhu = new System.Windows.Forms.TextBox();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.flpDanhSachPhong = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvThongTin
            // 
            this.dgvThongTin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongTin.Location = new System.Drawing.Point(7, 242);
            this.dgvThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.dgvThongTin.Name = "dgvThongTin";
            this.dgvThongTin.ReadOnly = true;
            this.dgvThongTin.Size = new System.Drawing.Size(530, 261);
            this.dgvThongTin.TabIndex = 1;
            // 
            // btnTroVe
            // 
            this.btnTroVe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTroVe.Image = global::QuanLyKyTucXa.Properties.Resources.Back32;
            this.btnTroVe.Location = new System.Drawing.Point(13, 13);
            this.btnTroVe.Margin = new System.Windows.Forms.Padding(4);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(46, 42);
            this.btnTroVe.TabIndex = 2;
            this.btnTroVe.UseVisualStyleBackColor = true;
            this.btnTroVe.Click += new System.EventHandler(this.btnTroVe_Click);
            // 
            // btnChuyenPhong
            // 
            this.btnChuyenPhong.Location = new System.Drawing.Point(17, 165);
            this.btnChuyenPhong.Margin = new System.Windows.Forms.Padding(4);
            this.btnChuyenPhong.Name = "btnChuyenPhong";
            this.btnChuyenPhong.Size = new System.Drawing.Size(122, 69);
            this.btnChuyenPhong.TabIndex = 3;
            this.btnChuyenPhong.Text = "Chuyển Phòng";
            this.btnChuyenPhong.UseVisualStyleBackColor = true;
            this.btnChuyenPhong.Click += new System.EventHandler(this.btnChuyenPhong_Click);
            // 
            // cmbKhu
            // 
            this.cmbKhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhu.FormattingEnabled = true;
            this.cmbKhu.Location = new System.Drawing.Point(419, 42);
            this.cmbKhu.Name = "cmbKhu";
            this.cmbKhu.Size = new System.Drawing.Size(224, 27);
            this.cmbKhu.TabIndex = 5;
            this.cmbKhu.SelectedIndexChanged += new System.EventHandler(this.cmbKhu_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(364, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "KHU:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClearText);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThemPhong);
            this.panel1.Controls.Add(this.txtSoLuongMax);
            this.panel1.Controls.Add(this.txtSoLuong);
            this.panel1.Controls.Add(this.txtMaKhu);
            this.panel1.Controls.Add(this.txtMaPhong);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnChuyenPhong);
            this.panel1.Controls.Add(this.dgvThongTin);
            this.panel1.Location = new System.Drawing.Point(650, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 580);
            this.panel1.TabIndex = 7;
            // 
            // btnClearText
            // 
            this.btnClearText.Location = new System.Drawing.Point(462, 195);
            this.btnClearText.Name = "btnClearText";
            this.btnClearText.Size = new System.Drawing.Size(75, 40);
            this.btnClearText.TabIndex = 15;
            this.btnClearText.Text = "Xoá chữ";
            this.btnClearText.UseVisualStyleBackColor = true;
            this.btnClearText.Click += new System.EventHandler(this.btnClearText_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(462, 76);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 58);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(462, 13);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(75, 58);
            this.btnThemPhong.TabIndex = 13;
            this.btnThemPhong.Text = "Thêm";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // txtSoLuongMax
            // 
            this.txtSoLuongMax.Location = new System.Drawing.Point(351, 83);
            this.txtSoLuongMax.Name = "txtSoLuongMax";
            this.txtSoLuongMax.Size = new System.Drawing.Size(58, 26);
            this.txtSoLuongMax.TabIndex = 12;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(145, 83);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.ReadOnly = true;
            this.txtSoLuong.Size = new System.Drawing.Size(45, 26);
            this.txtSoLuong.TabIndex = 11;
            // 
            // txtMaKhu
            // 
            this.txtMaKhu.Location = new System.Drawing.Point(309, 30);
            this.txtMaKhu.Name = "txtMaKhu";
            this.txtMaKhu.ReadOnly = true;
            this.txtMaKhu.Size = new System.Drawing.Size(100, 26);
            this.txtMaKhu.TabIndex = 10;
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(107, 30);
            this.txtMaPhong.MaxLength = 9;
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(83, 26);
            this.txtMaPhong.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số lượng tối đa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số lượng hiện tại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã Khu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã Phòng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(750, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(335, 42);
            this.label6.TabIndex = 8;
            this.label6.Text = "QUẢN LÝ PHÒNG";
            // 
            // flpDanhSachPhong
            // 
            this.flpDanhSachPhong.AutoScroll = true;
            this.flpDanhSachPhong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpDanhSachPhong.Location = new System.Drawing.Point(2, 77);
            this.flpDanhSachPhong.Margin = new System.Windows.Forms.Padding(4);
            this.flpDanhSachPhong.Name = "flpDanhSachPhong";
            this.flpDanhSachPhong.Size = new System.Drawing.Size(641, 580);
            this.flpDanhSachPhong.TabIndex = 0;
            // 
            // frmQuanLyPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1200, 593);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKhu);
            this.Controls.Add(this.btnTroVe);
            this.Controls.Add(this.flpDanhSachPhong);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLyPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phòng";
            this.Load += new System.EventHandler(this.frmQuanLyPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongTin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvThongTin;
        private System.Windows.Forms.Button btnTroVe;
        private System.Windows.Forms.Button btnChuyenPhong;
        private System.Windows.Forms.ComboBox cmbKhu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearText;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.TextBox txtSoLuongMax;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtMaKhu;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachPhong;
    }
}