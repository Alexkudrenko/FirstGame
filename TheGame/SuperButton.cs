using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace TheGame
{
    public partial class SuperButton : Button
    {
        public SuperButton()
        {
            InitializeComponent();
            this.Font = new Font("Trebuchet MS", 14);
            this.Paint += Button_Paint;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Color c1 = Color.FromArgb
            (35, Color.Turquoise);
            Color c2 = Color.FromArgb
                (64, Color.Black);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }
        private void Button_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = (sender as Button).ClientRectangle;
            newRectangle.Inflate(-4, -4);
            buttonPath.AddEllipse(newRectangle);
            (sender as Button).Region = new Region(buttonPath);
        }
    }
}
