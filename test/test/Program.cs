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
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(650, 300);
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
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
            // 
            // Scherm
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 516);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "Scherm";
            this.RightToLeftLayout = true;
            this.Text = "Wet van Fitt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            
      

        }

        public void Reactie_knop(object sender, EventArgs e)
        {
            Size schermgrootte = this.ClientSize;
            int button2xpos = schermgrootte.Width;
            int button2ypos = schermgrootte.Height;
            Random rnd = new Random();
            int x1 = rnd.Next(40, 300);
            int xpos = rnd.Next(1, button2xpos - x1);
            int ypos = rnd.Next(1, button2ypos - x1);
            this.button2.Location = new System.Drawing.Point(xpos, ypos);
            this.button2.Size = new System.Drawing.Size(x1, x1);
            this.button1.Visible = false;
            this.button2.Visible = true;
            this.button2.Click += new System.EventHandler(this.Begin_knop);


        }

        public void Begin_knop(object sender, EventArgs e)
        {
            Size schermgrootte = this.ClientSize; //omdat schermgrootte een Size met een x en een y is moet er .Width of .Height achter
            int button1xpos = schermgrootte.Width / 2 - 50;
            int button1ypos = schermgrootte.Height / 2 - 50;
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.Location = new System.Drawing.Point(button1xpos, button1ypos);
            this.button1.Text = "Klik Hier";
            this.button1.Visible = true;
            this.button2.Visible = false;
            this.button1.Click += new System.EventHandler(Reactie_knop);
        }


    }
}
