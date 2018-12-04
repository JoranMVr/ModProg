using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MandelBrot
{
    public class Mandelbrot : Form1
    {
        private TextBox middenx;
        private TextBox middeny;
        private TextBox schaal;
        private TextBox herhalingen;
        private Label middenxlabel;
        private Label middenylabel;
        private Label schaallabel;
        private Label herhalingenlabel;
        private Button knop;
        //private PictureBox Mantelbrot;
        private System.Windows.Forms.PictureBox pictureBox1;
        
        public double currentmaxr = 0;
        public double currentminr = 0;
        public double currentmaxi = 0;
        public double currentmini = 0;

        public  Mandelbrot()
        {
        
          
            //Middenx textbox
            this.middenx = new TextBox();
            this.middenx.Location = new Point(100, 10);
            this.middenx.Size = new Size(100, 100);
            this.middenx.Text = ("0");
            this.Controls.Add(middenx);

            //Middeny textbox
            this.middeny = new TextBox();
            this.middeny.Location = new Point(100, 40);
            this.middeny.Size = new Size(100, 100);
            this.middeny.Text = ("0");
            this.Controls.Add(middeny);

            //schaal textbox
            this.schaal = new TextBox();
            this.schaal.Location = new Point(400, 10);
            this.schaal.Size = new Size(100, 100);
            this.schaal.Text = ("0.01");
            this.Controls.Add(schaal);

            //herhalingen textbox
            this.herhalingen = new TextBox();
            this.herhalingen.Location = new Point(400, 40);
            this.herhalingen.Size = new Size(100, 100);
            this.herhalingen.Text = ("100");
            this.Controls.Add(herhalingen);

            //middenxlabel
            this.middenxlabel = new Label();
            this.middenxlabel.Location = new Point(10, 10);
            this.middenxlabel.Text = ("Midden x:");
            this.Controls.Add(middenxlabel);

            //middenylabel
            this.middenylabel = new Label();
            this.middenylabel.Location = new Point(10, 40);
            this.middenylabel.Text = ("Midden y:");
            this.Controls.Add(middenylabel);

            //schaallabel
            this.schaallabel = new Label();
            this.schaallabel.Location = new Point(300, 10);
            this.schaallabel.Text = ("Schaal:");
            this.Controls.Add(schaallabel);

            //herhalingenlabel
            this.herhalingenlabel = new Label();
            this.herhalingenlabel.Location = new Point(300, 40);
            this.herhalingenlabel.Text = ("Herhalingen:");
            this.Controls.Add(herhalingenlabel);

            //knop
            this.knop = new Button();
            this.knop.Location = new Point(550, 40);
            this.knop.Size = new Size(100, 25);
            this.knop.Text = ("Doorgaan");
            this.Controls.Add(knop);
            this.knop.Click += new System.EventHandler(this.knop_Click);

            /*this.Mantelbrot = new System.Windows.Forms.PictureBox();
            //mandelbrottekening
            this.Mantelbrot.Location = new System.Drawing.Point(10, 80);
            this.Mantelbrot.Margin = new System.Windows.Forms.Padding(0);
            this.Mantelbrot.Name = "pictureBox1";
            this.Mantelbrot.Size = new System.Drawing.Size(400, 400);
            this.Mantelbrot.TabIndex = 0;
            this.Mantelbrot.TabStop = false;
            this.Controls.Add(Mantelbrot);
            */
            //Scherm
            //this.AutoScaleDimensions = new System.Drawing.SizeF(500, 600);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            //this.Controls.Add(this.Mantelbrot);
            this.Name = "Mantelbrot";
            this.Text = "Mantelbrot";
            //this.Shown += new System.EventHandler(this.Mandelbrot_Shown);
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.Form1_Load);


            //pictureBox
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1.Location = new System.Drawing.Point(10, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(704, 469);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.Controls.Add(this.pictureBox1);
        }

        public void knop_Click(object sender, EventArgs e)
        {


            Bitmap img = MandelbrotSet(pictureBox1, 2, -2, 2, -2);
            pictureBox1.Image.Dispose();
            pictureBox1.Image = img;
            
            
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Bitmap img = MandelbrotSet(pictureBox1, 2, -2, 2, -2);
            pictureBox1.Image = img;
        }
        Bitmap MandelbrotSet(PictureBox pictureBox1, double maxr, double minr, double maxi, double mini)
        {
            currentmaxr = maxr;
            currentmaxi = maxi;
            currentminr = minr;
            currentmini = mini;
            Bitmap img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            double zx = double.Parse(this.middenx.Text);
            double zy = 0;
            double cx = 0;
            double cy = 0;
            double loopmax = double.Parse(this.herhalingen.Text);
            double xjump = ((maxr - minr) / Convert.ToDouble(img.Width));
            double yjump = ((maxi - mini) / Convert.ToDouble(img.Height));
            double tempzx = 0;
           
            int loopgo = 0;
            for (int x = 0; x < img.Width; x++)
            {
                cx = (xjump * x) - Math.Abs(minr);
                for (int y = 0; y < img.Height; y++)
                {
                    zx = double.Parse(this.middenx.Text);
                    zy = double.Parse(this.middeny.Text);
                    cy = (yjump * y) - Math.Abs(mini);
                    loopgo = 0;
                    while (zx * zx + zy * zy <= 4 && loopgo < loopmax)
                    {
                        loopgo++;
                        tempzx = zx;
                        zx = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * tempzx * zy) + cy;
                    }
                    if (loopgo != loopmax)
                        img.SetPixel(x, y, Color.FromArgb(loopgo % 128 * 2, loopgo % 32 * 7, loopgo % 16 * 14));
                    else
                        img.SetPixel(x, y, Color.Black);

                }
            }
            return img;

        }





    }
    
}

