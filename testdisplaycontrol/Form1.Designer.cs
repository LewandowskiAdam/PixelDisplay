namespace testdisplaycontrol
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
            this.pixel1 = new PixelDisp.Pixel(this.components);
            this.pixel2 = new PixelDisp.Pixel(this.components);
            this.pixel3 = new PixelDisp.Pixel(this.components);
            this.SuspendLayout();
            // 
            // pixel1
            // 
            this.pixel1.Location = new System.Drawing.Point(385, 85);
            this.pixel1.Name = "pixel1";
            this.pixel1.newPixelColor = System.Drawing.Color.Red;
            this.pixel1.newPixelState = PixelDisp.PixelState.Off;
            this.pixel1.newPixelType = PixelDisp.PixelType.Oval;
            this.pixel1.Size = new System.Drawing.Size(22, 32);
            this.pixel1.TabIndex = 0;
            // 
            // pixel2
            // 
            this.pixel2.Location = new System.Drawing.Point(414, 85);
            this.pixel2.Name = "pixel2";
            this.pixel2.newPixelColor = System.Drawing.Color.Red;
            this.pixel2.newPixelState = PixelDisp.PixelState.Off;
            this.pixel2.newPixelType = PixelDisp.PixelType.Oval;
            this.pixel2.Size = new System.Drawing.Size(27, 32);
            this.pixel2.TabIndex = 1;
            // 
            // pixel3
            // 
            this.pixel3.Location = new System.Drawing.Point(448, 85);
            this.pixel3.Name = "pixel3";
            this.pixel3.newPixelColor = System.Drawing.Color.Red;
            this.pixel3.newPixelState = PixelDisp.PixelState.Off;
            this.pixel3.newPixelType = PixelDisp.PixelType.Oval;
            this.pixel3.Size = new System.Drawing.Size(35, 32);
            this.pixel3.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pixel3);
            this.Controls.Add(this.pixel2);
            this.Controls.Add(this.pixel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PixelDisp.Pixel pixel1;
        private PixelDisp.Pixel pixel2;
        private PixelDisp.Pixel pixel3;
    }
}

