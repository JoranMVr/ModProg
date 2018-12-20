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
        private PictureBox Mantelbrot;

        public Mandelbrot()
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
            this.herhalingen.Text = ("2");
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

            this.Mantelbrot = new System.Windows.Forms.PictureBox();
            //mandelbrottekening
            this.Mantelbrot.Location = new System.Drawing.Point(10, 80);
            this.Mantelbrot.Margin = new System.Windows.Forms.Padding(0);
            this.Mantelbrot.Name = "pictureBox1";
            this.Mantelbrot.Size = new System.Drawing.Size(400, 400);
            this.Mantelbrot.TabIndex = 0;
            this.Mantelbrot.TabStop = false;
            this.Controls.Add(Mantelbrot);

            //Scherm
            //this.AutoScaleDimensions = new System.Drawing.SizeF(500, 600);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Mantelbrot);
            this.Name = "Mantelbrot";
            this.Text = "Mantelbrot";
            this.Shown += new System.EventHandler(this.Mandelbrot_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Mantelbrot)).EndInit();
            this.ResumeLayout(false);
        }
        
        public void knop_Click(object sender, EventArgs e)
        {
            this.Controls.Add(Mantelbrot);
            double middenx = double.Parse(this.middenx.Text);
            double middeny = double.Parse(this.middeny.Text);
            double schaal = double.Parse(this.schaal.Text);
            double herhalingen = double.Parse(this.herhalingen.Text);
            double aantalherhalingen = Convert.ToDouble(this.herhalingen.Text);
            ((System.ComponentModel.ISupportInitialize)(this.Mantelbrot)).BeginInit();
            for (int x = 0; x < Mantelbrot.Width; x++)
            {
                for (int y = 0; y < Mantelbrot.Height; y++)
                {
                    //double middenx = double.Parse(this.middenx.Text);
                    //double middeny = double.Parse(this.middeny.Text);
                    Complex c = new Complex(middenx, middeny);
                    Complex z = new Complex(0, 0);
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    while (it < 100);
                    this.Controls.Add(Mantelbrot);
                }
            }
        }
        //double herhalingen = double.Parse(this.herhalingen.Text);
        private void Mandelbrot_Shown(object sender, EventArgs e)
        {
            double aantalherhalingen = Convert.ToDouble(this.herhalingen.Text);
            Console.WriteLine(aantalherhalingen);
            double herhalingen = double.Parse(this.herhalingen.Text);
            Bitmap bm = new Bitmap(400, 400);
                for (int x = 0; x < 400; x++)
            {
                for (int y = 0; y < 400; y++)
                {
                    double middenx = (double)(x - (400 / 2)) / (double)(400 / 4);
                    double middeny = (double)(y - (400 / 2)) / (double)(400 / 4);
                    Complex c = new Complex(middenx, middeny);
                    Complex z = new Complex(middenx, middeny);
                    int it = 0;
                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0) break;
                    }
                    //int herhaling = double herhalingen
                    while (it < herhalingen);
                    bm.SetPixel(x, y, it < 100 ? Color.Black : Color.White);
                }
            }
            Mantelbrot.Image = bm;
        }
        

    }

    public class Complex
    {
        public double middenx; //real
        public double middeny; //imaginary
        //private int v1;
        //private int v2;

        /*public Complex(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }*/

        public Complex(double a, double b)
        {
            this.middenx = a;
            this.middeny = b;
        }

        public void Square()
        {
            double temp = (middenx * middenx) - (middeny * middeny);
            middeny = 2.0 * middenx * middeny;
            middenx = temp;
        }
        public double Magnitude()
        {
            return Math.Sqrt((middenx * middenx) + (middeny * middeny));
        }
        public void Add(Complex c)
        {
            middenx += c.middenx;
            middeny += c.middeny;
        }
    }
}

