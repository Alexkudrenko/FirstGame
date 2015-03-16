using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TheGame
{
    public partial class NextLevelForm : Form
    {
        private string[] _phrases = new string[] { "Математично!", "Великолепно!", "Фантастично!",
            "Идеально!", "Лучший!!" };
        private Random rnd = new Random();
        public NextLevelForm()
        {
            InitializeComponent();
        }
        public void setImage(Image img)
        {
            pictureBox1.Image = img;
            label1.Text = _phrases[rnd.Next(_phrases.Length)];
        }

        private void superButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}