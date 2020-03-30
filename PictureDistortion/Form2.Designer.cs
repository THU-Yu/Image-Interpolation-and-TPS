namespace PictureDistortion
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.Control = new System.Windows.Forms.Button();
            this.Target = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NearestCheckbox = new System.Windows.Forms.CheckBox();
            this.BilinearCheckbox = new System.Windows.Forms.CheckBox();
            this.ControlKeypoint = new System.Windows.Forms.Button();
            this.TargetKeypoint = new System.Windows.Forms.Button();
            this.ControlLabel = new System.Windows.Forms.Label();
            this.ControlKeyPointLabel = new System.Windows.Forms.Label();
            this.TargetLabel = new System.Windows.Forms.Label();
            this.TargetKeyPointLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(903, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "变换";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Control
            // 
            this.Control.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Control.Location = new System.Drawing.Point(12, 350);
            this.Control.Name = "Control";
            this.Control.Size = new System.Drawing.Size(166, 40);
            this.Control.TabIndex = 4;
            this.Control.Text = "选择控制图";
            this.Control.UseVisualStyleBackColor = true;
            this.Control.Click += new System.EventHandler(this.Control_Click);
            // 
            // Target
            // 
            this.Target.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Target.Location = new System.Drawing.Point(436, 350);
            this.Target.Name = "Target";
            this.Target.Size = new System.Drawing.Size(164, 40);
            this.Target.TabIndex = 5;
            this.Target.Text = "选择目标图";
            this.Target.UseVisualStyleBackColor = true;
            this.Target.Click += new System.EventHandler(this.Target_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(436, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 320);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(866, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(400, 320);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // NearestCheckbox
            // 
            this.NearestCheckbox.AutoSize = true;
            this.NearestCheckbox.Location = new System.Drawing.Point(490, 520);
            this.NearestCheckbox.Name = "NearestCheckbox";
            this.NearestCheckbox.Size = new System.Drawing.Size(124, 22);
            this.NearestCheckbox.TabIndex = 6;
            this.NearestCheckbox.Text = "最近邻插值";
            this.NearestCheckbox.UseVisualStyleBackColor = true;
            this.NearestCheckbox.Click += new System.EventHandler(this.NearestCheckbox_Click);
            // 
            // BilinearCheckbox
            // 
            this.BilinearCheckbox.AutoSize = true;
            this.BilinearCheckbox.Location = new System.Drawing.Point(680, 520);
            this.BilinearCheckbox.Name = "BilinearCheckbox";
            this.BilinearCheckbox.Size = new System.Drawing.Size(124, 22);
            this.BilinearCheckbox.TabIndex = 7;
            this.BilinearCheckbox.Text = "双线性插值";
            this.BilinearCheckbox.UseVisualStyleBackColor = true;
            this.BilinearCheckbox.Click += new System.EventHandler(this.BilinearCheckbox_Click);
            // 
            // ControlKeypoint
            // 
            this.ControlKeypoint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ControlKeypoint.Location = new System.Drawing.Point(195, 350);
            this.ControlKeypoint.Name = "ControlKeypoint";
            this.ControlKeypoint.Size = new System.Drawing.Size(218, 40);
            this.ControlKeypoint.TabIndex = 9;
            this.ControlKeypoint.Text = "选择控制图关键点";
            this.ControlKeypoint.UseVisualStyleBackColor = true;
            this.ControlKeypoint.Click += new System.EventHandler(this.ControlKeypoint_Click);
            // 
            // TargetKeypoint
            // 
            this.TargetKeypoint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TargetKeypoint.Location = new System.Drawing.Point(620, 350);
            this.TargetKeypoint.Name = "TargetKeypoint";
            this.TargetKeypoint.Size = new System.Drawing.Size(218, 40);
            this.TargetKeypoint.TabIndex = 10;
            this.TargetKeypoint.Text = "选择目标图关键点";
            this.TargetKeypoint.UseVisualStyleBackColor = true;
            this.TargetKeypoint.Click += new System.EventHandler(this.TargetKeypoint_Click);
            // 
            // ControlLabel
            // 
            this.ControlLabel.AutoSize = true;
            this.ControlLabel.Location = new System.Drawing.Point(12, 402);
            this.ControlLabel.Name = "ControlLabel";
            this.ControlLabel.Size = new System.Drawing.Size(116, 18);
            this.ControlLabel.TabIndex = 11;
            this.ControlLabel.Text = "控制图图片：";
            // 
            // ControlKeyPointLabel
            // 
            this.ControlKeyPointLabel.AutoSize = true;
            this.ControlKeyPointLabel.Location = new System.Drawing.Point(12, 434);
            this.ControlKeyPointLabel.Name = "ControlKeyPointLabel";
            this.ControlKeyPointLabel.Size = new System.Drawing.Size(170, 18);
            this.ControlKeyPointLabel.TabIndex = 12;
            this.ControlKeyPointLabel.Text = "控制图关键点文件：";
            // 
            // TargetLabel
            // 
            this.TargetLabel.AutoSize = true;
            this.TargetLabel.Location = new System.Drawing.Point(12, 464);
            this.TargetLabel.Name = "TargetLabel";
            this.TargetLabel.Size = new System.Drawing.Size(116, 18);
            this.TargetLabel.TabIndex = 13;
            this.TargetLabel.Text = "目标图图片：";
            // 
            // TargetKeyPointLabel
            // 
            this.TargetKeyPointLabel.AutoSize = true;
            this.TargetKeyPointLabel.Location = new System.Drawing.Point(12, 490);
            this.TargetKeyPointLabel.Name = "TargetKeyPointLabel";
            this.TargetKeyPointLabel.Size = new System.Drawing.Size(170, 18);
            this.TargetKeyPointLabel.TabIndex = 14;
            this.TargetKeyPointLabel.Text = "目标图关键点文件：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(1079, 350);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 40);
            this.button2.TabIndex = 15;
            this.button2.Text = "保存图片";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1278, 555);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TargetKeyPointLabel);
            this.Controls.Add(this.TargetLabel);
            this.Controls.Add(this.ControlKeyPointLabel);
            this.Controls.Add(this.ControlLabel);
            this.Controls.Add(this.TargetKeypoint);
            this.Controls.Add(this.ControlKeypoint);
            this.Controls.Add(this.BilinearCheckbox);
            this.Controls.Add(this.NearestCheckbox);
            this.Controls.Add(this.Target);
            this.Controls.Add(this.Control);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "选做任务";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Control;
        private System.Windows.Forms.Button Target;
        private System.Windows.Forms.CheckBox NearestCheckbox;
        private System.Windows.Forms.CheckBox BilinearCheckbox;
        private System.Windows.Forms.Button ControlKeypoint;
        private System.Windows.Forms.Button TargetKeypoint;
        private System.Windows.Forms.Label ControlLabel;
        private System.Windows.Forms.Label ControlKeyPointLabel;
        private System.Windows.Forms.Label TargetLabel;
        private System.Windows.Forms.Label TargetKeyPointLabel;
        private System.Windows.Forms.Button button2;
    }
}