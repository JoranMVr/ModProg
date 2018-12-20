using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Wet_van_Fitt
{

    class Scherm : Form
    {
        DateTime t1;
        DateTime t2;

        int i = 0;
        int count = 1;
        
        private Button button1;
        private Button button2;

        public Scherm()
        {
            InitializeComponent();
        }
        static void Main(string[] args)
        {
            Application.Run(new Scherm());
        }

        public void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Scherm
            // 
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Scherm";
            this.RightToLeftLayout = true;
            this.Text = "Wet van Fitt";
            this.ResumeLayout(false);
            // 
            // button1
            // 
            Scherm scherm = this;
            scherm.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Size grootte = this.ClientSize;
            int sizex = grootte.Width;
            int sizey = grootte.Height;
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
            button1.Location = new Point(
                this.ClientSize.Width / 2 - button1.Size.Width / 2,
                this.ClientSize.Height / 2 - button1.Size.Height / 2);
            button1.Anchor = AnchorStyles.None;
            this.button1.TabIndex = 0;
            this.button1.Text = "Klik Hier";
            this.button1.Click += new System.EventHandler(this.Reactie_knop);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(71, 89);
            this.button2.Name = "Reactie knop";
            this.button2.Size = new System.Drawing.Size(160, 58);
            this.button2.TabIndex = 1;
            this.button2.Text = "Nee Hier!";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Begin_knop);            
        }

        public void Reactie_knop(object sender, EventArgs e)
        {
            t1 = DateTime.Now;
            Size schermgrootte = this.ClientSize;
            Random rnd = new Random();
            int x1 = rnd.Next(this.ClientSize.Width - this.button2.Size.Width);
            int y1 = rnd.Next(this.ClientSize.Height - this.button2.Size.Height);
            int x2 = rnd.Next(40, 300);
            this.button2.Location = new Point(x1, y1);
            this.button2.Size = new System.Drawing.Size(x2, x2);
            this.button1.Visible = false;
            this.button2.Visible = true;
        }

        public void Begin_knop(object sender, EventArgs e)
        {
            t2 = DateTime.Now;
            Size schermgrootte = this.ClientSize;
            int button1xpos = (schermgrootte.Width / 2) - this.button1.Size.Width;
            int button1ypos = (schermgrootte.Height / 2) - this.button1.Size.Height;
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.Location = new System.Drawing.Point(button1xpos, button1ypos);
            this.button1.Text = "Klik Hier";
            this.button1.Visible = true;
            this.button2.Visible = false;
            long Tijdverschil = (t2.Ticks - t1.Ticks) / 10000;
            count++;
            i++;
            this.button1.Click += new System.EventHandler(Reactie_knop);
            //
            //afstand en breedte naar console
            //
            double afstand = Math.Sqrt(Math.Pow(button2.Location.X + (button2.Size.Width /2) - button1.Location.X + (button1.Size.Width / 2), 2) + Math.Pow(button1.Location.Y + (button1.Size.Width /2) - button2.Location.Y + (button2.Size.Width / 2), 2));
            int d = (int)Math.Round(afstand);
            int w = button2.Size.Width;
            double id = Math.Log((afstand / w) + 1, 2);
            //Console.WriteLine("Meting " + i);
            //Console.WriteLine("Reactietijd (ms)     = " + Tijdverschil);
            //Console.WriteLine("Afstand     (pixels) = " + d);
            //Console.WriteLine("Breedte     (pixels) = " + w);
            //Console.WriteLine("ID waarde            = " + id);
            //Console.WriteLine();
            Console.WriteLine(id + "." + Tijdverschil); //Gebruikt in combinatie met >>data.csv voor excel bestandje, in excel bij 'data -> Text to columns' scheiden op de .en grafiekje plotten
        }
    }
}