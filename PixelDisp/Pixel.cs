using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PixelDisp
{
    public enum PixelType
    {
        Oval, Round, Square, Rectangle
    }
    public enum PixelState
    {
        Off, On
    }
    public partial class Pixel : UserControl
    {
        private PixelType pixelType;
        private PixelState pixelState;
        private Color pixelColor;
        protected Brush brushOn = new SolidBrush(Color.Red);
        protected Brush brushOff = new SolidBrush(Color.DarkRed);
        public Pixel()
        {
            InitializeComponent();
            pixelColor = Color.Red;
        }
        public Pixel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle pix = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, Size.Width - 1, Size.Height - 1);
            switch (pixelType)
            {
                
                case PixelType.Oval:
                    pix = new Rectangle(0, (int)(Size.Height / 5.3333), Size.Width - 1, (int)(Size.Height / (1.5) - 1));
                    if (pixelState==PixelState.On)
                    {
                        e.Graphics.FillEllipse(brushOn, pix);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(brushOff,pix);
                    }
                    break;
                case PixelType.Round:
                    if (pixelState == PixelState.On)
                    {
                        e.Graphics.FillEllipse(brushOn, pix);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(brushOff, pix);
                    }
                    break;
                case PixelType.Rectangle:
                    pix = new Rectangle(0, (int)(Size.Height / 5.3333), Size.Width - 1, (int)(Size.Height/(1.5) - 1));
                    if (pixelState == PixelState.On)
                    {
                        e.Graphics.FillRectangle(brushOn, pix);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(brushOff, pix);
                    }
                    break;
                case PixelType.Square:
                    if (pixelState == PixelState.On)
                    {
                        e.Graphics.FillRectangle(brushOn, pix);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(brushOff, pix);
                    }
                    break;
            }
        }
        /*Poniżej lista właściwości
         * 
         * */
        [Category("Pixel"),
         Description("Defines pixel geometric type")]
        public PixelType newPixelType
        {
            get
            {
                return pixelType;
            }
            set
            {
                pixelType = value;
                Invalidate();
            }
        }
        [Category("Pixel"),
         Description("Defines pixel color")]
        public Color newPixelColor
        {
            get
            {
                return pixelColor;
            }
            set
            {
                pixelColor = value;
                brushOn = new SolidBrush(pixelColor);
                brushOff = new SolidBrush(Color.FromArgb(90, pixelColor));
                Invalidate();
            }
        }
        [Category("Pixel"),
         Description("Defines state of pixel")]
        public PixelState newPixelState
        {
            get
            {
                return pixelState;
            }
            set
            {
                pixelState = value;
                Invalidate();
            }
        }
    }
}