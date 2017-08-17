namespace DNA_HUE
{
    partial class Form1
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
            this.txtHide = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtSimple = new System.Windows.Forms.RichTextBox();
            this.lblCurrent = new System.Windows.Forms.ListBox();
            this.lblAfter = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextAfterConvert = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtHide
            // 
            this.txtHide.Location = new System.Drawing.Point(24, 60);
            this.txtHide.Name = "txtHide";
            this.txtHide.Size = new System.Drawing.Size(100, 20);
            this.txtHide.TabIndex = 1;
            this.txtHide.Text = "HUE";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(173, 57);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(24, 108);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(173, 8);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 5;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtSimple
            // 
            this.txtSimple.Location = new System.Drawing.Point(24, 5);
            this.txtSimple.Name = "txtSimple";
            this.txtSimple.Size = new System.Drawing.Size(100, 49);
            this.txtSimple.TabIndex = 6;
            this.txtSimple.Text = "DANG THI HUE VIET NAM TRUYEN  GIAO";
            // 
            // lblCurrent
            // 
            this.lblCurrent.FormattingEnabled = true;
            this.lblCurrent.Location = new System.Drawing.Point(12, 154);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(120, 95);
            this.lblCurrent.TabIndex = 7;
            // 
            // lblAfter
            // 
            this.lblAfter.FormattingEnabled = true;
            this.lblAfter.Location = new System.Drawing.Point(152, 154);
            this.lblAfter.Name = "lblAfter";
            this.lblAfter.Size = new System.Drawing.Size(120, 95);
            this.lblAfter.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Chu sau khi ma hoa";
            // 
            // txtTextAfterConvert
            // 
            this.txtTextAfterConvert.Location = new System.Drawing.Point(347, 154);
            this.txtTextAfterConvert.Name = "txtTextAfterConvert";
            this.txtTextAfterConvert.Size = new System.Drawing.Size(100, 96);
            this.txtTextAfterConvert.TabIndex = 10;
            this.txtTextAfterConvert.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 261);
            this.Controls.Add(this.txtTextAfterConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAfter);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.txtSimple);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtHide);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHide;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.RichTextBox txtSimple;
        private System.Windows.Forms.ListBox lblCurrent;
        private System.Windows.Forms.ListBox lblAfter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtTextAfterConvert;
    }
}

