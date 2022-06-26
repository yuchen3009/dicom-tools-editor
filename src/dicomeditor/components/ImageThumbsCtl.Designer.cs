namespace dicomeditor.components
{
    partial class ImageThumbsCtl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_pat = new System.Windows.Forms.Label();
            this.lbl_acc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_pat
            // 
            this.lbl_pat.AutoEllipsis = true;
            this.lbl_pat.Location = new System.Drawing.Point(9, 169);
            this.lbl_pat.Name = "lbl_pat";
            this.lbl_pat.Size = new System.Drawing.Size(145, 17);
            this.lbl_pat.TabIndex = 2;
            this.lbl_pat.Text = "Anonymous^Thomas^Tom";
            // 
            // lbl_acc
            // 
            this.lbl_acc.AutoEllipsis = true;
            this.lbl_acc.Location = new System.Drawing.Point(9, 147);
            this.lbl_acc.Name = "lbl_acc";
            this.lbl_acc.Size = new System.Drawing.Size(145, 17);
            this.lbl_acc.TabIndex = 3;
            this.lbl_acc.Text = "ACC0000005   F";
            // 
            // ImageThumbsCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbl_acc);
            this.Controls.Add(this.lbl_pat);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ImageThumbsCtl";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(158, 197);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Label lbl_pat;
        private Label lbl_acc;
    }
}
