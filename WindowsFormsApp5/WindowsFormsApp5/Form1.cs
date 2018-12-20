using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Reversi : Form 
    {
        private Button NieuwKnop;
        private Button Help;
        private Label Aandebeurt;
        private Label BlauweStenen;
        private Label RodeStenen;
        private int[] x1, y1;
        int n = 1;
        const int nMax = 36;
        int[,] Vakje = new int[6, 6]
         {
                {0,0,0,0,0,0 },
                {0,0,0,0,0,0 },
                {0,0,1,2,0,0 },
                {0,0,2,1,0,0 },
                {0,0,0,0,0,0 },
                {0,0,0,0,0,0 },
         };

        public Reversi()
        {
            this.x1 = new int[nMax];
            this.y1 = new int[nMax];
            this.Text = "Reversi";
            this.ClientSize = new System.Drawing.Size(400, 400);

            this.NieuwKnop = new Button();
            this.NieuwKnop.Text = "Nieuw Spel";
            this.NieuwKnop.Location = new Point(20, 20);
            this.NieuwKnop.Size = new Size(100, 25);

            this.Help = new Button();
            this.Help.Text = "Help";
            this.Help.Location = new Point(200, 20);
            this.Help.Size = new Size(100, 25);
            
            this.Aandebeurt = new Label();
            this.Aandebeurt.Text = "Rood is aan de beurt";
            this.Aandebeurt.Location = new Point(20, 360);
            this.Aandebeurt.Size = new Size(150, 25);

            this.BlauweStenen = new Label();
            this.BlauweStenen.Text = ("Aantal blauwe stenen: ");
            this.BlauweStenen.Location = new Point(20, 375);
            this.BlauweStenen.Size = new Size(150, 25);

            this.RodeStenen = new Label();
            this.RodeStenen.Text = ("Aantal rode stenen: ");
            this.RodeStenen.Location = new Point(20, 390);
            this.RodeStenen.Size = new Size(150, 25);

            this.Controls.Add(RodeStenen);
            this.Controls.Add(Help);
            this.Controls.Add(BlauweStenen);
            this.Controls.Add(Aandebeurt);
            this.Controls.Add(NieuwKnop);
            this.Help.Click += new System.EventHandler(this.Help_Click);
            this.NieuwKnop.Click += new System.EventHandler(this.NieuwKnop_Click);
            this.Paint += this.tekenScherm;
            this.MouseClick += klik;

        }

        public void tekenScherm(object obj, PaintEventArgs pea)
        {
            this.tekenBegin(pea.Graphics);
            Graphics gr = pea.Graphics;

            for (int t = 1; t < n; t++)
            {
                int x = Convert.ToInt32(x1[t]);
                int y = Convert.ToInt32(y1[t]);
                if (t % 2 == 0)
                {
                    this.Aandebeurt.Text = "Blauw is aan de beurt";
                    Vakje[y, x] = 1;
                    //Vakje[2, 2] = 1;
                }

                else
                {
                    this.Aandebeurt.Text = "Rood is aan de beurt";
                    Vakje[y, x] = 2;

                }

                if (Vakje[y, x] == 1)
                { Rood(gr, x, y); }
                if (Vakje[y, x] == 2)
                { Blauw(gr, x, y); }


            }


        }

        void tekenBegin(Graphics gr)
        {
            Pen pen = new Pen(Color.Black, 2);
            gr.DrawLine(pen, 20, 50, 20, 350);
            gr.DrawLine(pen, 70, 50, 70, 350);
            gr.DrawLine(pen, 120, 50, 120, 350);
            gr.DrawLine(pen, 170, 50, 170, 350);
            gr.DrawLine(pen, 220, 50, 220, 350);
            gr.DrawLine(pen, 270, 50, 270, 350);
            gr.DrawLine(pen, 320, 50, 320, 350);
            gr.DrawLine(pen, 20, 50, 320, 50);
            gr.DrawLine(pen, 20, 100, 320, 100);
            gr.DrawLine(pen, 20, 150, 320, 150);
            gr.DrawLine(pen, 20, 200, 320, 200);
            gr.DrawLine(pen, 20, 250, 320, 250);
            gr.DrawLine(pen, 20, 300, 320, 300);
            gr.DrawLine(pen, 20, 350, 320, 350);

            this.Blauw(gr, 2, 3);
            this.Blauw(gr, 3, 2);
            this.Rood(gr, 3, 3);
            this.Rood(gr, 2, 2);
        }

        public void NieuwKnop_Click(object sender, EventArgs e)
        {
            Array.Clear(x1, 0, 36);
            Array.Clear(y1, 0, 36);
            this.Refresh();
        }

        public void Help_Click(object sender, EventArgs e)
        {
            int blauwteller = 0;
            foreach (int aantalblauw in Vakje)
            {
                if (aantalblauw == 2)
                {
                    blauwteller++;
                }
            }
            this.BlauweStenen.Text = ("Aantal blauwe stenen: " + blauwteller);

            int roodteller = 0;
            foreach (int aantalrood in Vakje)
            {
                if (aantalrood == 1)
                {
                    roodteller++;
                }
            }
            this.RodeStenen.Text = ("Aantal rode stenen: " + roodteller);
        }


        public void Regels()
        {
            //één voor één een zet doen

            /*methode maken om te kijken of het een legale zet is.
            staat er al een steen?
            gaat de steen over stenen van een andere kleur?
            gaat de steen niet over lege vakken?

            help knop, die laat zien waar de geldige zetten zijn voor de speler aan beurt.
            */

            //als er al een steen staat, ongeldige zet

            /*
             text met blauw of rood is winnaar of gelijkspel.
             knop nieuw spel updaten, help knop toevoegen
             veld resizable maken
             */
        }

        public void Kleuren()
        {
            //int n = 1;

        }

        void Blauw(Graphics gr, int x, int y)
        {
            gr.FillEllipse(Brushes.Blue, (x * 50) + 20, (y * 50) + 50, 50, 50);
        }

        void Rood(Graphics gr, int x, int y)
        {
            gr.FillEllipse(Brushes.Red, (x * 50) + 20, (y * 50) + 50, 50, 50);
        }


        public void klik(object sender, MouseEventArgs mea)
        {

            try
            {
                x1[n] = (mea.X - 20) / 50;
                y1[n] = (mea.Y - 50) / 50;
                n++;
                this.Invalidate();
            }
            
            catch(IndexOutOfRangeException e)
            { }            
        }
    }
}