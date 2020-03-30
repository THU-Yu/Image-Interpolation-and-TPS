namespace PictureDistortion
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NewImage = new System.Windows.Forms.Button();
            this.RotationGroup = new System.Windows.Forms.GroupBox();
            this.Angle = new System.Windows.Forms.TrackBar();
            this.AngleLabel = new System.Windows.Forms.Label();
            this.Bicubic1 = new System.Windows.Forms.CheckBox();
            this.Bilinear1 = new System.Windows.Forms.CheckBox();
            this.Nearest1 = new System.Windows.Forms.CheckBox();
            this.ConvexConcavoGroup = new System.Windows.Forms.GroupBox();
            this.Radius = new System.Windows.Forms.TrackBar();
            this.RadiusLabel = new System.Windows.Forms.Label();
            this.Bicubic2 = new System.Windows.Forms.CheckBox();
            this.Type = new System.Windows.Forms.ComboBox();
            this.Bilinear2 = new System.Windows.Forms.CheckBox();
            this.Nearest2 = new System.Windows.Forms.CheckBox();
            this.Rotation = new System.Windows.Forms.CheckBox();
            this.ConcavoConvex = new System.Windows.Forms.CheckBox();
            this.OriginImage = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.RotationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).BeginInit();
            this.ConvexConcavoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radius)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(512, 512);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // NewImage
            // 
            this.NewImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewImage.Location = new System.Drawing.Point(571, 498);
            this.NewImage.Name = "NewImage";
            this.NewImage.Size = new System.Drawing.Size(107, 60);
            this.NewImage.TabIndex = 1;
            this.NewImage.Text = "显示新图像";
            this.NewImage.UseVisualStyleBackColor = true;
            this.NewImage.Click += new System.EventHandler(this.NewImage_Click);
            // 
            // RotationGroup
            // 
            this.RotationGroup.Controls.Add(this.Angle);
            this.RotationGroup.Controls.Add(this.AngleLabel);
            this.RotationGroup.Controls.Add(this.Bicubic1);
            this.RotationGroup.Controls.Add(this.Bilinear1);
            this.RotationGroup.Controls.Add(this.Nearest1);
            this.RotationGroup.Enabled = false;
            this.RotationGroup.Location = new System.Drawing.Point(571, 74);
            this.RotationGroup.Name = "RotationGroup";
            this.RotationGroup.Size = new System.Drawing.Size(350, 200);
            this.RotationGroup.TabIndex = 2;
            this.RotationGroup.TabStop = false;
            this.RotationGroup.Text = "旋转扭曲";
            this.RotationGroup.EnabledChanged += new System.EventHandler(this.RotationGroup_EnabledChanged);
            // 
            // Angle
            // 
            this.Angle.Location = new System.Drawing.Point(168, 112);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(159, 69);
            this.Angle.TabIndex = 4;
            this.Angle.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Angle.Value = 5;
            this.Angle.Scroll += new System.EventHandler(this.Angle_Scroll);
            // 
            // AngleLabel
            // 
            this.AngleLabel.AutoSize = true;
            this.AngleLabel.Location = new System.Drawing.Point(185, 67);
            this.AngleLabel.Name = "AngleLabel";
            this.AngleLabel.Size = new System.Drawing.Size(106, 18);
            this.AngleLabel.TabIndex = 3;
            this.AngleLabel.Text = "扭曲角度：0";
            // 
            // Bicubic1
            // 
            this.Bicubic1.AutoSize = true;
            this.Bicubic1.Location = new System.Drawing.Point(23, 145);
            this.Bicubic1.Name = "Bicubic1";
            this.Bicubic1.Size = new System.Drawing.Size(124, 22);
            this.Bicubic1.TabIndex = 2;
            this.Bicubic1.Text = "双三次插值";
            this.Bicubic1.UseVisualStyleBackColor = true;
            this.Bicubic1.Click += new System.EventHandler(this.Bicubic1_Click);
            // 
            // Bilinear1
            // 
            this.Bilinear1.AutoSize = true;
            this.Bilinear1.Location = new System.Drawing.Point(23, 97);
            this.Bilinear1.Name = "Bilinear1";
            this.Bilinear1.Size = new System.Drawing.Size(124, 22);
            this.Bilinear1.TabIndex = 1;
            this.Bilinear1.Text = "双线性插值";
            this.Bilinear1.UseVisualStyleBackColor = true;
            this.Bilinear1.Click += new System.EventHandler(this.Bilinear1_Click);
            // 
            // Nearest1
            // 
            this.Nearest1.AutoSize = true;
            this.Nearest1.Location = new System.Drawing.Point(23, 48);
            this.Nearest1.Name = "Nearest1";
            this.Nearest1.Size = new System.Drawing.Size(124, 22);
            this.Nearest1.TabIndex = 0;
            this.Nearest1.Text = "最近邻插值";
            this.Nearest1.UseVisualStyleBackColor = true;
            this.Nearest1.Click += new System.EventHandler(this.Nearest1_Click);
            // 
            // ConvexConcavoGroup
            // 
            this.ConvexConcavoGroup.Controls.Add(this.Radius);
            this.ConvexConcavoGroup.Controls.Add(this.RadiusLabel);
            this.ConvexConcavoGroup.Controls.Add(this.Bicubic2);
            this.ConvexConcavoGroup.Controls.Add(this.Type);
            this.ConvexConcavoGroup.Controls.Add(this.Bilinear2);
            this.ConvexConcavoGroup.Controls.Add(this.Nearest2);
            this.ConvexConcavoGroup.Enabled = false;
            this.ConvexConcavoGroup.Location = new System.Drawing.Point(571, 280);
            this.ConvexConcavoGroup.Name = "ConvexConcavoGroup";
            this.ConvexConcavoGroup.Size = new System.Drawing.Size(350, 200);
            this.ConvexConcavoGroup.TabIndex = 0;
            this.ConvexConcavoGroup.TabStop = false;
            this.ConvexConcavoGroup.Text = "畸变";
            this.ConvexConcavoGroup.EnabledChanged += new System.EventHandler(this.ConvexConcavoGroup_EnabledChanged);
            // 
            // Radius
            // 
            this.Radius.Location = new System.Drawing.Point(168, 114);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(159, 69);
            this.Radius.TabIndex = 6;
            this.Radius.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.Radius.Scroll += new System.EventHandler(this.Radius_Scroll);
            // 
            // RadiusLabel
            // 
            this.RadiusLabel.AutoSize = true;
            this.RadiusLabel.Location = new System.Drawing.Point(185, 80);
            this.RadiusLabel.Name = "RadiusLabel";
            this.RadiusLabel.Size = new System.Drawing.Size(122, 18);
            this.RadiusLabel.TabIndex = 5;
            this.RadiusLabel.Text = "球体半径：362";
            // 
            // Bicubic2
            // 
            this.Bicubic2.AutoSize = true;
            this.Bicubic2.Location = new System.Drawing.Point(23, 149);
            this.Bicubic2.Name = "Bicubic2";
            this.Bicubic2.Size = new System.Drawing.Size(124, 22);
            this.Bicubic2.TabIndex = 7;
            this.Bicubic2.Text = "双三次插值";
            this.Bicubic2.UseVisualStyleBackColor = true;
            this.Bicubic2.Click += new System.EventHandler(this.Bicubic2_Click);
            // 
            // Type
            // 
            this.Type.FormattingEnabled = true;
            this.Type.Items.AddRange(new object[] {
            "凸",
            "凹"});
            this.Type.Location = new System.Drawing.Point(188, 38);
            this.Type.Name = "Type";
            this.Type.Size = new System.Drawing.Size(121, 26);
            this.Type.TabIndex = 6;
            // 
            // Bilinear2
            // 
            this.Bilinear2.AutoSize = true;
            this.Bilinear2.Location = new System.Drawing.Point(23, 101);
            this.Bilinear2.Name = "Bilinear2";
            this.Bilinear2.Size = new System.Drawing.Size(124, 22);
            this.Bilinear2.TabIndex = 6;
            this.Bilinear2.Text = "双线性插值";
            this.Bilinear2.UseVisualStyleBackColor = true;
            this.Bilinear2.Click += new System.EventHandler(this.Bilinear2_Click);
            // 
            // Nearest2
            // 
            this.Nearest2.AutoSize = true;
            this.Nearest2.Location = new System.Drawing.Point(23, 52);
            this.Nearest2.Name = "Nearest2";
            this.Nearest2.Size = new System.Drawing.Size(124, 22);
            this.Nearest2.TabIndex = 5;
            this.Nearest2.Text = "最近邻插值";
            this.Nearest2.UseVisualStyleBackColor = true;
            this.Nearest2.Click += new System.EventHandler(this.Nearest2_Click);
            // 
            // Rotation
            // 
            this.Rotation.AutoSize = true;
            this.Rotation.Location = new System.Drawing.Point(594, 46);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(106, 22);
            this.Rotation.TabIndex = 3;
            this.Rotation.Text = "旋转扭曲";
            this.Rotation.UseVisualStyleBackColor = true;
            this.Rotation.Click += new System.EventHandler(this.Rotation_Click);
            // 
            // ConcavoConvex
            // 
            this.ConcavoConvex.AutoSize = true;
            this.ConcavoConvex.Location = new System.Drawing.Point(759, 46);
            this.ConcavoConvex.Name = "ConcavoConvex";
            this.ConcavoConvex.Size = new System.Drawing.Size(70, 22);
            this.ConcavoConvex.TabIndex = 4;
            this.ConcavoConvex.Text = "畸变";
            this.ConcavoConvex.UseVisualStyleBackColor = true;
            this.ConcavoConvex.Click += new System.EventHandler(this.ConcavoConvex_Click);
            // 
            // OriginImage
            // 
            this.OriginImage.Location = new System.Drawing.Point(693, 498);
            this.OriginImage.Name = "OriginImage";
            this.OriginImage.Size = new System.Drawing.Size(107, 60);
            this.OriginImage.TabIndex = 5;
            this.OriginImage.Text = "显示原图";
            this.OriginImage.UseVisualStyleBackColor = true;
            this.OriginImage.Click += new System.EventHandler(this.OriginImage_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(814, 498);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(107, 60);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存图片";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 593);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.OriginImage);
            this.Controls.Add(this.NewImage);
            this.Controls.Add(this.ConcavoConvex);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.ConvexConcavoGroup);
            this.Controls.Add(this.RotationGroup);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "必做任务";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.RotationGroup.ResumeLayout(false);
            this.RotationGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).EndInit();
            this.ConvexConcavoGroup.ResumeLayout(false);
            this.ConvexConcavoGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Radius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NewImage;
        private System.Windows.Forms.GroupBox RotationGroup;
        private System.Windows.Forms.GroupBox ConvexConcavoGroup;
        private System.Windows.Forms.CheckBox Rotation;
        private System.Windows.Forms.CheckBox ConcavoConvex;
        private System.Windows.Forms.Button OriginImage;
        private System.Windows.Forms.CheckBox Bicubic1;
        private System.Windows.Forms.CheckBox Bilinear1;
        private System.Windows.Forms.CheckBox Nearest1;
        private System.Windows.Forms.TrackBar Angle;
        private System.Windows.Forms.Label AngleLabel;
        private System.Windows.Forms.CheckBox Bicubic2;
        private System.Windows.Forms.ComboBox Type;
        private System.Windows.Forms.CheckBox Bilinear2;
        private System.Windows.Forms.CheckBox Nearest2;
        private System.Windows.Forms.TrackBar Radius;
        private System.Windows.Forms.Label RadiusLabel;
        private System.Windows.Forms.Button Save;
    }
}

