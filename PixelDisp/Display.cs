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
    public partial class Display : UserControl
    {
        //pixel display variables

        //matrix for holding pixel components
        private Pixel[,] displayMatrix;
        //matrix for image to be displayed - not used atm
        private char[,] displayMatrixData;
        //vector containing size of display; resolution[1] contains Y axis pixel number while resolution[0] containg X axis pixel number
        private int[] resolution = new int[2];
        //enum type variable containing information about pixel geometric shape
        private PixelType pixelType;
        //pixel color class
        private Color pixelColor;
        //string variable for displaying text
        private string text;
        //font class for text to be displayed in
        private Font textFont;

        //control-specific variables of matrix display

        //column pointer
        private int columnPointer;
        //to add
        //iteration time - defines scrolling speed

        private System.ComponentModel.Container myContainer = new System.ComponentModel.Container();
        public Display()
        {
            initDisplay();
            InitializeComponent();
        }
        
        public Display(IContainer container)
        {
            container.Add(this);
            initDisplay();
            InitializeComponent();
        }

        private void initDisplay()
        {
            /*method for setting some default values
             this method will called one in contructing process*/
            resolution[0] = 32;
            resolution[1] = 8;
            displayMatrixData = new char[resolution[0], resolution[1]];
            displayMatrix = new Pixel[resolution[0], resolution[1]];
            pixelType = PixelType.Oval;
            pixelColor = Color.Red;
            textFont = new Font(new FontFamily("Times New Roman"),8,FontStyle.Regular);
            int winheight = Size.Height / resolution[1];
            int winwidth = Size.Width / resolution[0];
            for (int i = 0; i < resolution[0]; i++)
            {
                for (int j = 0; j < resolution[1]; j++)
                {
                    displayMatrix[i,j] = new Pixel(this.myContainer);
                    displayMatrix[i,j].newPixelState = PixelState.Off;
                    displayMatrix[i,j].newPixelType = pixelType;
                    displayMatrix[i,j].newPixelColor = pixelColor;
                    displayMatrix[i,j].SetBounds(ClientRectangle.Left, ClientRectangle.Top, 15, 15);
                    displayMatrix[i, j].Location = new System.Drawing.Point(i * winwidth,  j * winheight);
                    this.Controls.Add(displayMatrix[i, j]);
                }
            }
        }
        //method for reinitializing display - it changes pixel count
        //it resizes pixel count managing (destroying) old objects
        private void reInitDisplay(int oldResX, int oldResY)
        {
            int winheight = Size.Height / resolution[1];
            int winwidth = Size.Width / resolution[0];
            int pitch = winheight < winwidth ? winheight : winwidth;
            displayMatrixData = new char[resolution[0], resolution[1]];
            //destroying old pixel matrix
            for(int i=0;i<oldResX; i++)
            {
                for (int j=0; j<oldResY; j++)
                {
                    this.Controls.Remove(displayMatrix[i, j]);
                    myContainer.Remove(displayMatrix[i, j]);
                    displayMatrix[i, j].Dispose();
                }
            }
            //creating new pixel matrix
            for(int i=0; i<resolution[0]; i++)
            {
                for(int j = 0; j < resolution[1]; j++)
                {
                    displayMatrix[i, j] = new Pixel(this.myContainer);
                    displayMatrix[i, j].newPixelState = PixelState.Off;
                    displayMatrix[i, j].newPixelType = pixelType;
                    displayMatrix[i, j].newPixelColor = pixelColor;
                    displayMatrix[i, j].SetBounds(ClientRectangle.Left, ClientRectangle.Top, pitch - 1, pitch - 1);
                    displayMatrix[i, j].Location= new System.Drawing.Point(i * pitch, j * pitch);
                    this.Controls.Add(displayMatrix[i, j]);
                }
            }
        }
        //method for reinitializing display without changes in pixel count
        //basically only for object changes in display size
        private void reInitDisplay()
        {
            int winheight = Size.Height / resolution[1];
            int winwidth = Size.Width / resolution[0];
            int pitch = winheight < winwidth ? winheight : winwidth;
            for (int i = 0; i < resolution[0]; i++)
            {
                for (int j = 0; j < resolution[1]; j++)
                {
                    displayMatrix[i, j].newPixelState = PixelState.Off;
                    displayMatrix[i, j].newPixelType = pixelType;
                    displayMatrix[i, j].newPixelColor = pixelColor;
                    displayMatrix[i, j].SetBounds(ClientRectangle.Left, ClientRectangle.Top, pitch - 1, pitch - 1);
                    displayMatrix[i, j].Location = new System.Drawing.Point(i * pitch, j * pitch);
                }
            }
            putA();

        }
        //something to display
        private void putA()
        {
            displayMatrix[0, 7].newPixelState = PixelState.On;
            displayMatrix[0, 6].newPixelState = PixelState.On;
            displayMatrix[0, 5].newPixelState = PixelState.On;
            displayMatrix[0, 4].newPixelState = PixelState.On;
            displayMatrix[0, 3].newPixelState = PixelState.On;
            displayMatrix[0, 2].newPixelState = PixelState.On;
            displayMatrix[0, 1].newPixelState = PixelState.On;
            displayMatrix[1, 0].newPixelState = PixelState.On;
            displayMatrix[2, 0].newPixelState = PixelState.On;
            displayMatrix[3, 0].newPixelState = PixelState.On;
            displayMatrix[4, 7].newPixelState = PixelState.On;
            displayMatrix[4, 6].newPixelState = PixelState.On;
            displayMatrix[4, 5].newPixelState = PixelState.On;
            displayMatrix[4, 4].newPixelState = PixelState.On;
            displayMatrix[4, 3].newPixelState = PixelState.On;
            displayMatrix[4, 2].newPixelState = PixelState.On;
            displayMatrix[4, 1].newPixelState = PixelState.On;
            displayMatrix[2, 3].newPixelState = PixelState.On;
            displayMatrix[3, 3].newPixelState = PixelState.On;
            displayMatrix[1, 3].newPixelState = PixelState.On;

        }
        //Event handlers
        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            reInitDisplay();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            reInitDisplay();
        }
        //adding category A_Display - just to not look all of properties for it
        [Category("A_Display"),
            Description ("Defines display pixel types")]
        public PixelType DisplayPixelType
        {
            //changes in new_pixelType requires display reinitialization
            get
            {
                return pixelType;
            }
            set
            {
                pixelType = value;
                reInitDisplay();
                Invalidate();
            }
        }
        [Category("A_Display"),
         Description("Defines display pixel colour")]
        public Color DisplayPixelColor
        {
            //changes in new_pixelType requires display reinitialization
            get
            {
                return pixelColor;
            }
            set
            {
                pixelColor = value;
                reInitDisplay();
                Invalidate();
            }
        }
        [Category("A_Display"),
        Description("Defines display pixel colour")]
        public string DisplayText
        {
            get
            {
                return text;
            }
            set
            {

                //need to be added updateDisplay method (not prototyped yet)
                text = value;
                Invalidate();
            }
        }
        [Category("A_Display"),
        Description("Defines display font")]
        public Font DisplayFont
        {
            get
            {
                return textFont;
            }
            set
            {

                //need to be added updateDisplay method (not prototyped yet)
                textFont = value;
                Invalidate();
            }
        }
    }
}
