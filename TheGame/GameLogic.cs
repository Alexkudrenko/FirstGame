using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace TheGame
{
    enum standState { standingLeft, standingRight };
    class GameLogic
    {
        private bool _win;
        private bool _fail;
        private GameForm _gameForm;
        public bool isWin
        {
            get { return _win; }
            private set { _win = value; }
        }
        public bool isFail
        {
            get { return _fail; }
            private set { _fail = value; }
        }
        private struct levelData
        {
            public Point startPoint;
            public Point endPoint;
            public standState charState;
            public List<Point> barriersPtsList;
            public levelData(Point p1, Point p2, standState state) 
            {
                startPoint = p1;
                endPoint = p2;
                charState = state;
                barriersPtsList = new List<Point>();
            }
        }
        private List<PictureBox> _barriersList = new List<PictureBox>();
        private Bitmap _levelBitmap;
        private PictureBox _characterPBox;
        private PictureBox _levelEndPBox;
        private Random rnd = new Random();
        private List<levelData> _dataList = new List<levelData>();
        private sbyte _levelCounter = -1;
        #region для анимации
        private sbyte _dX;// для перемещения по вертикали
        private sbyte _dY;// для перемещения по горизонтали
        private int _imageCount;
        private sbyte _dimageCount; 
        #endregion
        #region sprites
        private List<Image> _charSpritesRight = new List<Image>();
        private List<Image> _charSpritesLeft = new List<Image>();
        private List<Image> _barriersSprites = new List<Image>();
        private Image _charDiesSprite = Image.FromFile("./pict/dies.png");
        #endregion
        public GameLogic(PictureBox charBox, PictureBox endBox, Bitmap bmp, GameForm gameForm)
        {
            _gameForm = gameForm;
            _characterPBox = charBox;
            _levelEndPBox = endBox;
            _levelBitmap = bmp;
            InitSprites();
            InitLevels();
            SetLevel(true);
        }
        private void InitLevels()
        {
            List<Point> charPoints = new List<Point>(new Point[] { new Point(30, 30), new Point(600, 100) });
            List<Point> lvlEndPoints = new List<Point>(new Point[] { new Point(800, 200), new Point(20, 100) });
            
            _dataList.Add(new levelData(charPoints[0], lvlEndPoints[0],
                standState.standingRight));
            _dataList.Add(new levelData(charPoints[1], lvlEndPoints[1],
                standState.standingLeft));
            
            InitBarriersPts(_dataList[0]);
            InitBarriersPts(_dataList[1]);
        }
        private void InitBarriersPts(levelData ld)
        {
            int barCounter = rnd.Next(1, 5);
            List<Point> barPtsList = new List<Point>();
            for (int i = 0; i < barCounter; ++i)
            {
                ld.barriersPtsList.Add(new Point(rnd.Next(200, _levelBitmap.Width - 300),
                    rnd.Next(200, _levelBitmap.Height - 200)));
            }
        }
        private void InitSprites()
        {
            string[] files = Directory.GetFiles("./pict");
            foreach (string file in files)
            {
                if (file.Contains("left"))
                    _charSpritesLeft.Add(Image.FromFile(file));
                if (file.Contains("right"))
                    _charSpritesRight.Add(Image.FromFile(file));
                if (file.Contains("bar"))
                    _barriersSprites.Add(Image.FromFile(file));
            }
        }
        private void SetCharImage(standState charState)
        {
            switch (charState)
            {
                case standState.standingLeft:
                    _characterPBox.Image = _charSpritesLeft[4];
                    break;
                case standState.standingRight:
                    _characterPBox.Image = _charSpritesRight[4];
                    break;
            }
        }
        public void SetLevel(bool newLvl = false)
        {
            isWin = isFail = false;
            
            if (newLvl)
                _levelCounter++;
            if (_levelCounter >= _dataList.Count)
            {
                MessageBox.Show(String.Format("В демо версии доступно только {0} уровня!", _dataList.Count));
                _levelCounter = 0;
                DisposeBarriers();
                _gameForm.MainPictureBox.CreateGraphics().Clear(System.Drawing.Color.CornflowerBlue);
                ShowBarriers(_dataList[0].barriersPtsList);
                return;
            }
            if (newLvl)
                DisposeBarriers();
            _characterPBox.Location = _dataList[_levelCounter].startPoint;
            _levelEndPBox.Location = _dataList[_levelCounter].endPoint;
            SetCharImage(_dataList[_levelCounter].charState);
            if (newLvl)
                ShowBarriers(_dataList[_levelCounter].barriersPtsList);
            _dX = 0;
            _dY = 0;
        }
        private void ShowBarriers(List<Point> pointsList)
        {
            foreach (Point pt in pointsList)
            {
                PictureBox newBar = new PictureBox();
                newBar.Size = new Size(32, 32);
                newBar.Location = pt;
                newBar.Image = _barriersSprites[rnd.Next(_barriersSprites.Count)];
                _barriersList.Add(newBar);
                _gameForm.MainPictureBox.Controls.Add(newBar);
            }
        }
        private void DisposeBarriers()
        {
            try
            {
                foreach (PictureBox bar in _barriersList)
                    bar.Dispose();
                _barriersList.Clear();
            }
            catch { }
        }
        public void Move()
        {
            if (!CheckGame())
            {
                if (CheckClash())
                {
                    isFail = true;
                }
                isWin = CheckPosition(_levelEndPBox);
                if (IsOnGround())
                {
                    RunForward();
                    AnimateCharRunning();
                    if (_dX < 10)
                        _dX++;
                }
                else// падение
                {
                    FallDown();
                    if (_dY < 15)
                        _dY++;
                }
            }
            else
            {
                isFail = true;
            }
        }
        private bool CheckGame()
        {
            int x = _characterPBox.Location.X, y = _characterPBox.Location.Y, width = _characterPBox.Image.Width,
                height = _characterPBox.Image.Height;
            for (int i = 0; i <= 15; ++i)
            {
                if (x + width + i >= _levelBitmap.Width || y + height + i + 4 >= _levelBitmap.Height || x < i || y < i)
                    return true;
            }
            return false;
        }
        private bool CheckClash()
        {
            foreach (PictureBox barrier in _barriersList)
            {
                if (CheckPosition(barrier))
                    return true;
            }
            return false;
        }
        private bool CheckPosition(PictureBox mapElement)
        {
            int x1 = _characterPBox.Location.X, width1 = _characterPBox.Image.Width, 
                y1 = _characterPBox.Location.Y, height1 = _characterPBox.Image.Height,
                
                x2 = mapElement.Location.X, widht2 = mapElement.Image.Width,
                y2 = mapElement.Location.Y, height2 = mapElement.Image.Height;

            for (int i = x1; i < x1 + widht2; ++i)
            {
                for (int j = y1; j < y1 + height1; ++j)
                {
                    if (i >= x2 && i <= x2 + widht2 &&
                        j >= y2 && j < y2 + height2)
                        return true;
                }
            }
            return false;
        }
        private void RunForward()
        {
            _dY = 0;
            int x1 = _characterPBox.Location.X, width1 = _characterPBox.Image.Width,
                y1 = _characterPBox.Location.Y, height1 = _characterPBox.Image.Height;
            for (int i = y1; i < y1 + height1; ++i)
            {
                for (int j = 0; j <= 9; ++j)
                {
                    try
                    {
                        if (CheckGame()) return;
                        if (_levelBitmap.GetPixel(x1 + (_dataList[_levelCounter].charState == standState.standingRight ?
                            width1 + 10 + j : -10 - j), i) == Color.FromArgb(255, 0, 0, 0) &&
                            i < y1 + (2 * height1) / 3)  // преграда мешает бегу
                            return;
                        if (_levelBitmap.GetPixel(x1 + (_dataList[_levelCounter].charState == standState.standingRight ?
                        width1 + 12 + j : -10 - j), i) == Color.FromArgb(255, 0, 0, 0) &&
                        i > y1 + height1 / 2)
                        {
                            _characterPBox.Location = new Point(
                               x1 + (_dataList[_levelCounter].charState == standState.standingRight ?
                               _dX : -_dX), i - height1 - 5
                               );
                            return;
                        }
                    }
                    catch { }
                }
            }
            _characterPBox.Location = new Point(
                       _characterPBox.Location.X + (_dataList[_levelCounter].charState == standState.standingRight ?
                       _dX : -_dX), _characterPBox.Location.Y
                       );
        }
        private void FallDown()
        {
            _characterPBox.Image = (_dataList[_levelCounter].charState == standState.standingLeft ?
                    _charSpritesLeft[0] : _charSpritesRight[0]);
            _characterPBox.Location = new Point(
                   _characterPBox.Location.X + (_dataList[_levelCounter].charState == standState.standingRight ? _dX : -_dX),
                   _characterPBox.Location.Y + _dY
                   );
        }
        private void AnimateCharRunning()
        {
            if (_imageCount == 0)
                _characterPBox.Image = (_dataList[_levelCounter].charState == standState.standingLeft ? 
                    _charSpritesLeft[1] : _charSpritesRight[1]);
            if (_imageCount == 1)
                _characterPBox.Image = (_dataList[_levelCounter].charState == standState.standingLeft ? 
                    _charSpritesLeft[2] : _charSpritesRight[2]);
            if (_imageCount == 2)
                _characterPBox.Image = (_dataList[_levelCounter].charState == standState.standingLeft ? 
                    _charSpritesLeft[3] : _charSpritesRight[3]);
         
            if (_imageCount == 0) _dimageCount = 1;
            if (_imageCount == 2) _dimageCount = -1;
            _imageCount += _dimageCount;
        }
        private bool IsOnGround()
        {
            int x1 = _characterPBox.Location.X, width1 = _characterPBox.Image.Width,
                y1 = _characterPBox.Location.Y, height1 = _characterPBox.Image.Height;
            if (y1 + height1 < _levelBitmap.Height && 
                x1 + width1 < _levelBitmap.Width && 
                x1 > 0 && y1 > 0
                )
            {
                for (int i = x1; i < x1 + width1; ++i)
                {
                    for (int j = 2; j <= 11; ++j)
                    {
                        if (_levelBitmap.GetPixel(i, y1 + height1 + j) ==
                            Color.FromArgb(255, 0, 0, 0))
                            return true;
                    }
                        
                }
            }
            return false;
        }
    }
}