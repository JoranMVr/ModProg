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

        int i = 1;
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
            //this.AutoSize = true;
            //this.ClientSize = new System.Drawing.Size(1008, 516);
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
            //this.button1.SizeChanged += new EventHandler(this.Begin_KnopSizeChanged);
            //this.button1.Location = new System.Drawing.Point(sizex, sizey);
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

        //public void Begin_KnopSizeChanged(object sender, EventArgs e)
        //{
        //    Size grootte = this.ClientSize;
        //    int sizex = grootte.Width;
        //    int sizey = grootte.Height;
        //    this.button1.Location = new System.Drawing.Point(sizex, sizey);
        //}

        public void Reactie_knop(object sender, EventArgs e)
        {
            t1 = DateTime.Now;
            Size schermgrootte = this.ClientSize;
            //double button2xpos = schermgrootte.Width;
            //double button2ypos = schermgrootte.Height;
            Random rnd = new Random();
            double x1 = rnd.NextDouble();
            double y1 = rnd.NextDouble();
            int x2 = rnd.Next(40, 300);
            //int xpos = rnd.Next(0, button2xpos - x1);
            //int ypos = rnd.Next(0, button2ypos - x1);
            //int xpos = Math.Floor(x1 * button2xpos);
            //int ypos = 
            double xpos = x1 * schermgrootte.Width;
            double ypos = y1 * schermgrootte.Height;
            this.button2.Location = new Point((int)xpos - x2/ 2, (int)ypos - x2 / 2);
            this.button2.Size = new System.Drawing.Size(x2, x2);
            this.button1.Visible = false;
            this.button2.Visible = true;
            this.button2.Click += new System.EventHandler(this.Begin_knop);


        }

        public void Begin_knop(object sender, EventArgs e)
        {
            t2 = DateTime.Now;
            Size schermgrootte = this.ClientSize; // Omdat schermgrootte een Size met een x en een y is moet er .Width of .Height achter
            int button1xpos = schermgrootte.Width / 2 - 50;
            int button1ypos = schermgrootte.Height / 2 - 50;
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.Location = new System.Drawing.Point(button1xpos, button1ypos);
            this.button1.Text = "Klik Hier";
            this.button1.Visible = true;
            this.button2.Visible = false;
            long Tijdverschil = (t2.Ticks - t1.Ticks) / 10000;
            count++;
            while (i < count)
            {
                Console.WriteLine("Meting " + i + ". Reactietijd (ms) = " + Tijdverschil);
                i++;
            }
            this.button1.Click += new System.EventHandler(Reactie_knop);
        }


    }
}
