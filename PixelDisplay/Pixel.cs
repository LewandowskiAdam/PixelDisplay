using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace PixelDisplay
{
    public partial class Pixel : Component
    {
        public Pixel()
        {
            InitializeComponent();
        }

        public Pixel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
