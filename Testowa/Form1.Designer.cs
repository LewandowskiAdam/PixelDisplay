namespace Testowa
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
            this.components = new System.ComponentModel.Container();
            this.display1 = new PixelDisp.Display(this.components);
            this.SuspendLayout();
            // 
            // display1
            // 
            this.display1.DisplayFont = new System.Drawing.Font("Times New Roman", 8F);
            this.display1.DisplayPixelColor = System.Drawing.Color.Red;
            this.display1.DisplayPixelType = PixelDisp.PixelType.Rectangle;
            this.display1.DisplayText = null;
            this.display1.Location = new System.Drawing.Point(12, 12);
            this.display1.Name = "display1";
            this.display1.Size = new System.Drawing.Size(810, 254);
            this.display1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 596);
            this.Controls.Add(this.display1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PixelDisp.Display display1;
    }
}

