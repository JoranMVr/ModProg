using System.Windows.Forms;
using System.Drawing;

class HalloForm : Form
{
    public HalloForm()
    {
        this.Text = "Hallo";
        this.BackColor = Color.Black;
        this.Size = new Size(1000, 1000);
        this.Paint += this.tekenScherm;
       // this.Resize += ((e,s) => { this.Invalidate(); });
        this.ResizeRedraw = true;
    }

    void tekenScherm(object obj, PaintEventArgs pea)
    {
        Size hoofdsize = this.ClientSize;
        int headpos = 0;
        int eyex = hoofdsize.Width / 5;
        int eyey = hoofdsize.Height / 5;
        int eyerx = (int)(eyex + 0.4 * hoofdsize.Width);
        int eyesizex = hoofdsize.Width / 5;
        int eyesizey = hoofdsize.Height / 5;
        int pupx = (int)(hoofdsize.Width / 3.33);
        int puprx = pupx + (int)(hoofdsize.Width * 0.4);
        int pupy = (int)(hoofdsize.Height * 0.25);
        int pupsizex = (int)(hoofdsize.Width * 0.1);
        int pupsizey = (int)(hoofdsize.Height * 0.1);
        int mondx = (int)(hoofdsize.Width * 0.4);
        int mondy = (int)(hoofdsize.Height * 0.4) + (int)(hoofdsize.Height * 0.25);
        int mondwidth = (int)(hoofdsize.Width * 0.2);
        int mondbroad = (int)(hoofdsize.Height * 0.1);
        
        pea.Graphics.FillEllipse(Brushes.Yellow, headpos,headpos, hoofdsize.Width,hoofdsize.Height);
        pea.Graphics.FillEllipse(Brushes.White, eyex,eyey, eyesizex,eyesizey);
        pea.Graphics.FillEllipse(Brushes.White, eyerx,eyey, eyesizex,eyesizey);
        pea.Graphics.FillEllipse(Brushes.Black, pupx, pupy, pupsizex, pupsizey);
        pea.Graphics.FillEllipse(Brushes.Black, puprx, pupy, pupsizex, pupsizey);
        pea.Graphics.FillEllipse(Brushes.PaleVioletRed, mondx, mondy, mondwidth, mondbroad);
    }
}

class HalloWin3
{
    static void Main()
    {
        HalloForm scherm;
        scherm = new HalloForm();
        Application.Run(scherm);
    }
}