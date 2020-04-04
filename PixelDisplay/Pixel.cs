using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;


namespace PixelDisplay
{
    public enum PixelType
    {
        Oval, Round, Square, Rectangle
    }
    public partial class Pixel : UserControl
    {
        private PixelType pixelType;
        public Pixel()
        {
            InitializeComponent();
        }
        public Pixel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        [Category("Pixel"),
         Description("Defines pixel geometric type")]
        public PixelType pixel
        {
            get
            {
                return pixelType;
            }
            set
            {
                pixelType = value;
            }
        }
        
    }
}
