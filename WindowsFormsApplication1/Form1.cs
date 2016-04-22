using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private Bitmap origImage1;
        private Bitmap image1;
        private Bitmap origImage2;
        private Bitmap image2;
        private Boolean getImage1;
        private Boolean getImage2;
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try{
                    origImage1 = new Bitmap(ofd.FileName);

                    image1 = new Bitmap(origImage1);

                    pictureBox1.Image = origImage1;

                    getImage1 = true;

             
                }
                catch
                {
                    getImage1 = false;
                    MessageBox.Show("Can't open file.");

                }

            }

        }

        private void openButton2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    origImage2 = new Bitmap(ofd.FileName);

                    image2 = new Bitmap(origImage2);

                    pictureBox2.Image = origImage2;

                    getImage2 = true;

                }
                catch
                {
                    getImage2 = false;
                    MessageBox.Show("Can't open file.");
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (getImage1.Equals(true) && getImage2.Equals(true)) { 
          
                Bitmap newImage1 = new Bitmap(image1);
                Bitmap newImage2 = new Bitmap(image2);

               // Rectangle rect1 = new Rectangle(0, 0, newImage1.Width, newImage1.Height);
               // BitmapData bmpData1 = newImage1.LockBits(rect1, ImageLockMode.ReadWrite, newImage1.PixelFormat);
    //
              //  Rectangle rect2 = new Rectangle(0, 0, newImage2.Width, newImage2.Height);
             //   BitmapData bmpData2 = newImage1.LockBits(rect2, ImageLockMode.ReadWrite, newImage2.PixelFormat);

                int[] r1= new int[256];
                int[] b1 = new int[256];
                int[] g1 = new int[256];
                int[] r2 = new int[256];
                int[] b2 = new int[256];
                int[] g2 = new int[256];

                for (int x = 0; x < newImage1.Width;x++ ){
                    for (int y = 0; y < newImage1.Height; y++)
                    {
                        Color pixelColor= newImage1.GetPixel(x, y);
                        int redValue = Convert.ToInt32(pixelColor.R);
                        r1[redValue]++;

                        int greenValue = Convert.ToInt32(pixelColor.G);
                        g1[greenValue]++;

                        int blueValue = Convert.ToInt32(pixelColor.B);
                        b1[blueValue]++;


                    }
                }


                for (int x = 0; x < newImage2.Width; x++)
                {
                    for (int y = 0; y < newImage2.Height; y++)
                    {
                        Color pixelColor = newImage2.GetPixel(x, y);
                        int redValue = Convert.ToInt32(pixelColor.R);
                        r2[redValue]++;

                        int greenValue = Convert.ToInt32(pixelColor.G);
                        g2[greenValue]++;

                        int blueValue = Convert.ToInt32(pixelColor.B);
                        b2[blueValue]++;


                    }
                }



                double n1= newImage1.Width * newImage1.Height;
                double n2 = newImage2.Width * newImage2.Height;
                Form2 fr = new Form2();
                fr.Text = "Red";
                fr.SetDataSource(r1,r2,n1,n2);
                fr.Show();

                Form2 fg = new Form2();
                fg.Text = "Green";
                fg.SetDataSource(g1, g2, n1, n2);
                fg.Show();

                Form2 fb = new Form2();
                fb.Text= "Blue";
                fb.SetDataSource(b1, b2, n1, n2);
                fb.Show();

            }
            else
            {
                MessageBox.Show("Select Image");

            }
                


        }
    }
}
