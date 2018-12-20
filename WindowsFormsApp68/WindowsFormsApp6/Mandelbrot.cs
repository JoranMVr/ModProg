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

        public Mandelbrot()
        {
            //Middenx textbox
            this.middenx = new TextBox();
            this.middenx.Location = new Point(100, 10);
            this.middenx.Size = new Size(100, 100);
            this.middenx.Text = ("Middenx");
            this.Controls.Add(middenx);

            //Middeny textbox
            this.middeny = new TextBox();
            this.middeny.Location = new Point(100, 40);
            this.middeny.Size = new Size(100, 100);
            this.middeny.Text = ("Middeny");
            this.Controls.Add(middeny);

            //schaal textbox
            this.schaal = new TextBox();
            this.schaal.Location = new Point(400, 10);
            this.schaal.Size = new Size(100, 100);
            this.schaal.Text = ("Schaal");
            this.Controls.Add(schaal);

            //herhalingen textbox
            this.herhalingen = new TextBox();
            this.herhalingen.Location = new Point(400, 40);
            this.herhalingen.Size = new Size(100, 100);
            this.herhalingen.Text = ("herhalingen");
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

        }
    }
}
