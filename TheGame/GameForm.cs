using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace TheGame
{
    public partial class GameForm : Form
    {
        #region Define 
        private List<Image> _nextLevelImageList = new List<Image>();
        private Random rnd = new Random();
        private NextLevelForm nextLevelForm = new NextLevelForm();
        public Label lbl1;
        public PictureBox MainPictureBox;
        GameLogic character;
        private MediaPlayer mediaPlayer = new MediaPlayer();
        private Uri uri = new Uri("./sound/MainTheme.mp3", UriKind.Relative);
        private System.Drawing.Pen currentPen = new System.Drawing.Pen(System.Drawing.Color.Black, 6);
        private BufferedGraphicsContext _currentContext;
        private System.Drawing.BufferedGraphics _myBuffer;
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Rectangle _maximizedWindowRect; 
        private bool isMouseDown;
        private int left, top, savedX, savedY;
        private bool playGame = false;
        #endregion

        public GameForm()
        {
            #region graphics
            InitializeComponent();
            _maximizedWindowRect = new Rectangle(0, 0, MainPBox.Width, MainPBox.Height);
            _bitmap = new Bitmap(
                MainPBox.Width, MainPBox.Height
            );

            _graphics = Graphics.FromImage(_bitmap);
            MainPBox.Image = _bitmap;
            _currentContext = BufferedGraphicsManager.Current;
            _myBuffer = _currentContext.Allocate(_graphics, _maximizedWindowRect);
            _myBuffer.Graphics.Clear(MainPBox.BackColor);
            _graphics = MainPBox.CreateGraphics();
            #endregion

            string[] imagesPath = Directory.GetFiles("./pict/nextlvlimgs/");
            foreach (string imgPath in imagesPath)
                _nextLevelImageList.Add(Image.FromFile(imgPath));
            MainPictureBox = MainPBox;
            lbl1 = label1;
            character = new GameLogic(CharacterImg, LevelEnd, _bitmap, this);
            mediaPlayer.Open(uri);
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (playGame)
            {
                left = savedX = e.X;
                top = savedY = e.Y;
                isMouseDown = true;
            }
        }
        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (playGame)
            {
                if (isMouseDown)
                {
                    _graphics.DrawLine(currentPen, savedX, savedY, e.X, e.Y);
                    _myBuffer.Graphics.DrawLine(currentPen, savedX, savedY, e.X, e.Y);
                    savedX = e.X;
                    savedY = e.Y;
                }
            }
        }
        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (playGame)
                isMouseDown = false;
        }
        private void ClearGrButton_Click(object sender, EventArgs e)
        {
            _graphics.Clear(System.Drawing.Color.CornflowerBlue);
            _myBuffer.Graphics.Clear(System.Drawing.Color.CornflowerBlue);
            _myBuffer.Render();
        }
        private void GameButton_Click(object sender, EventArgs e)
        {
            ClearGrButton.Enabled = CloseButton.Enabled = !ClearGrButton.Enabled;
            switch (playGame = !playGame)
            {
                case true:
                    GameButton.Text = "Stop!";
                    mediaPlayer.Open(uri);
                    mediaPlayer.Play();
                    MoveTimer.Start();
                    break;
                case false:
                    GameButton.Text = "Start!";
                    mediaPlayer.Stop();
                    MoveTimer.Stop();
                    character.SetLevel();
                    isMouseDown = false;
                    break;
            }
        }
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            if (!character.isWin)
            {
                if (character.isFail)
                {
                    mediaPlayer.Open(new Uri("./sound/dies.wav", UriKind.Relative));
                    mediaPlayer.Play();
                    GameButton.Enabled = false;
                    Thread.Sleep(3000);
                    GameButton.Enabled = true;
                    GameButton_Click(sender, e);
                }
                character.Move();
            }
            else
            {
                MoveTimer.Stop();
                mediaPlayer.Open(new Uri("./sound/stage clear.wav", UriKind.Relative));
                mediaPlayer.Play();
                nextLevelForm.setImage(_nextLevelImageList[rnd.Next(_nextLevelImageList.Count)]);
                nextLevelForm.ShowDialog();
                mediaPlayer.Stop();
                character.SetLevel(true);
                GameButton_Click(sender, e);
                ClearGrButton_Click(sender, e);
                isMouseDown = false;
            }
        }
        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            _myBuffer.Render();
        }
    }
}