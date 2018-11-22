using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace nuwel
{
    static class Program
    {
        static void Main()
        { 
            Application.Run(new Scherm());
            
        }
    }
    class Scherm : Form
    {
        DateTime t1;
        DateTime t2;

        int i = 1;
        int count = 1;

        Button button1;
        Button button2;

        public Scherm()
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
            this.button1.Click += this.Reactie_knop;
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
            
            this.Name = "Scherm";
            this.RightToLeftLayout = true;
            this.Text = "Wet van Fitt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

            //this.Controls.Add();
        }

        public void Reactie_knop(object sender, EventArgs e)
        {
            t1 = DateTime.Now;
            Random rnd = new Random();
            //int x1 = rnd.Next(40, 300);
            int x1 = rnd.Next();
            int y1 = rnd.Next();
            int x2 = rnd.Next(40, 300);
            Size schermgrootte = this.ClientSize;
            int button2xpos = schermgrootte.Width;
            int button2ypos = schermgrootte.Height;
            int xpos = rnd.Next(1, button2xpos);
            int ypos = rnd.Next(1, button2ypos);
            this.button2.Location = new Point((int)xpos - x2 / 2, (int)ypos - x2 / 2);
            this.button2.Size = new System.Drawing.Size(x2, x2);
            this.button1.Visible = false;
            this.button2.Visible = true;
            this.button2.Click += this.Begin_knop;
            //this.Controls.Remove();
        }

        public void Begin_knop(object sender, EventArgs e)
        {
            //this.Controls.Remove();

            t2 = DateTime.Now;
            Size schermgrootte = this.ClientSize;
            int button1xpos = schermgrootte.Width / 2 - 50;
            int button1ypos = schermgrootte.Height / 2 - 50;
            this.button1.Name = "Begin knop";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.Location = new System.Drawing.Point(button1xpos, button1ypos);
            this.button1.Text = "Klik Hier";
            this.button1.Visible = true;
            this.button2.Visible = false;
            long Tijdverschil = (t2.Ticks - t1.Ticks)/10000;
            count++;
            while (i < count)
            {
                Console.WriteLine("Meting " + i + ". Reactietijd (ms) = " + Tijdverschil);
                i++;
            }
            this.button1.Visible = true;
            this.button2.Visible = true;
            
            //this.Controls.Add();
        }

    }
}


