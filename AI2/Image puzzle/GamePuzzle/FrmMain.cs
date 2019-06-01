using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GamePuzzle
{
    public partial class FrmMain : Form
    {
        private int CrrentPictureNumber;
        private Bitmap CurrentBitmapImage;
        private Point EmptyLocation;
        private MyButton[] ButtonArray;
        private bool YouWin;
        private int NumberOfMoves;
        private FrmShowCurrentImage MyFrmShowCurrentImage;
        public event EventHandler CurrentImageChanged;

        public FrmMain()
        {
            InitializeComponent();
            this.CrrentPictureNumber = 0;
            this.CurrentImageChanged += new EventHandler(FrmMain_CurrentImageChanged);
        }

        private void FrmMain_CurrentImageChanged(object sender, EventArgs e)
        {
            if (this.MyFrmShowCurrentImage != null)
                this.MyFrmShowCurrentImage.Img = this.CurrentBitmapImage;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAboutBox F = new FrmAboutBox();
            F.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.LoadNewGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void myButton_LocationChanged(object sender, EventArgs e)
        {
            MyButton A = sender as MyButton;
            YouWin = true;
            int ButtonNumber;
            this.NumberOfMoves++;
            for (int i = 0; i < 5; i++)
            {
                if (YouWin == false)
                    break;
                else for (int j = 0; j < 5; j++)
                    {
                        ButtonNumber = i * 5 + j;
                        if (i == 4 && j == 4)
                            break;
                        else if (GetNumber(ButtonArray[ButtonNumber].Location.X, ButtonArray[ButtonNumber].Location.Y) == ButtonArray[ButtonNumber].Number)
                            continue;
                        else
                        {
                            YouWin = false;
                            break;
                        }
                    }
            }
            if (YouWin)
            {

                if (MessageBox.Show("You Win This Game in " + this.NumberOfMoves.ToString() + " Moves\n\rDo You Want To Play Another Game ?", "Congratulation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    this.LoadNewGame();
                else
                    this.Close();
            }
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if ((b.Location.X - 75 == EmptyLocation.X) && (b.Location.Y == EmptyLocation.Y))
            {
                b.Location = EmptyLocation;
                EmptyLocation.X += 75;
                this.Focus();
            }
            else if (b.Location.X + 75 == EmptyLocation.X && (b.Location.Y == EmptyLocation.Y))
            {
                b.Location = EmptyLocation;
                EmptyLocation.X -= 75;
                this.Focus();
            }
            else if (b.Location.Y - 75 == EmptyLocation.Y && (b.Location.X == EmptyLocation.X))
            {
                b.Location = EmptyLocation;
                EmptyLocation.Y += 75;
                this.Focus();
            }

            else if (b.Location.Y + 75 == EmptyLocation.Y && (b.Location.X == EmptyLocation.X))
            {
                b.Location = EmptyLocation;
                EmptyLocation.Y -= 75;
                this.Focus();
            }
        }

        private void LoadNewGame()
        {
            this.myButton1.Location = new System.Drawing.Point(20, 40);
            this.myButton2.Location = new System.Drawing.Point(95, 40);
            this.myButton3.Location = new System.Drawing.Point(170, 40);
            this.myButton4.Location = new System.Drawing.Point(245, 40);
            this.myButton5.Location = new System.Drawing.Point(320, 40);
            this.myButton6.Location = new System.Drawing.Point(20, 115);
            this.myButton7.Location = new System.Drawing.Point(95, 115);
            this.myButton8.Location = new System.Drawing.Point(170, 115);
            this.myButton9.Location = new System.Drawing.Point(245, 115);
            this.myButton10.Location = new System.Drawing.Point(320, 115);
            this.myButton11.Location = new System.Drawing.Point(20, 190);
            this.myButton12.Location = new System.Drawing.Point(95, 190);
            this.myButton13.Location = new System.Drawing.Point(170, 190);
            this.myButton14.Location = new System.Drawing.Point(245, 190);
            this.myButton15.Location = new System.Drawing.Point(320, 190);
            this.myButton16.Location = new System.Drawing.Point(20, 265);
            this.myButton17.Location = new System.Drawing.Point(95, 265);
            this.myButton18.Location = new System.Drawing.Point(170, 265);
            this.myButton19.Location = new System.Drawing.Point(245, 265);
            this.myButton20.Location = new System.Drawing.Point(320, 265);
            this.myButton21.Location = new System.Drawing.Point(20, 340);
            this.myButton22.Location = new System.Drawing.Point(95, 340);
            this.myButton23.Location = new System.Drawing.Point(170, 340);
            this.myButton24.Location = new System.Drawing.Point(245, 340);

            if (this.CrrentPictureNumber == 7)
                this.CrrentPictureNumber = 1;
            else
                this.CrrentPictureNumber++;
            switch (this.CrrentPictureNumber)
            {
                case 1: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._1, new Size(375, 375));
                    break;
                case 2: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._2, new Size(375, 375));
                    break;
                case 3: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._3, new Size(375, 375));
                    break;
                case 4: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._4, new Size(375, 375));
                    break;
                case 5: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._5, new Size(375, 375));
                    break;
                case 6: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._6, new Size(375, 375));
                    break;
                case 7: CurrentBitmapImage = new Bitmap(GamePuzzle.Properties.Resources._7, new Size(375, 375));
                    break;
            }
            this.EmptyLocation = new Point(320, 340);
            this.NumberOfMoves = 0;
            this.ButtonArray = new MyButton[24];

            this.ButtonArray[0] = this.myButton1;
            this.ButtonArray[1] = this.myButton2;
            this.ButtonArray[2] = this.myButton3;
            this.ButtonArray[3] = this.myButton4;
            this.ButtonArray[4] = this.myButton5;
            this.ButtonArray[5] = this.myButton6;
            this.ButtonArray[6] = this.myButton7;
            this.ButtonArray[7] = this.myButton8;
            this.ButtonArray[8] = this.myButton9;
            this.ButtonArray[9] = this.myButton10;
            this.ButtonArray[10] = this.myButton11;
            this.ButtonArray[11] = this.myButton12;
            this.ButtonArray[12] = this.myButton13;
            this.ButtonArray[13] = this.myButton14;
            this.ButtonArray[14] = this.myButton15;
            this.ButtonArray[15] = this.myButton16;
            this.ButtonArray[16] = this.myButton17;
            this.ButtonArray[17] = this.myButton18;
            this.ButtonArray[18] = this.myButton19;
            this.ButtonArray[19] = this.myButton20;
            this.ButtonArray[20] = this.myButton21;
            this.ButtonArray[21] = this.myButton22;
            this.ButtonArray[22] = this.myButton23;
            this.ButtonArray[23] = this.myButton24;

            Random r = new Random();
            int[] a = new int[24];
            int i = 0;
            int b;
            bool exist;
            while (i != a.Length)
            {
                exist = false;
                b = (r.Next(24) + 1);
                for (int j = 0; j < a.Length; j++)
                    if (a[j] == b) exist = true;
                if (!exist) a[i++] = b;
            }
            for (int j = 0; j < a.Length; j++)
                ButtonArray[j].Number = a[j];
            // set picture pieces as the background image
            int Number;
            int Row, Column;
            for (int k = 0; k < 5; k++)
                for (int j = 0; j < 5; j++)
                {
                    if (k == 4)
                        if (j == 4) break;
                    Number = ButtonArray[k * 5 + j].Number; //Get The Number Of Button
                    Row = (Number - 1) / 5;
                    Column = (Number - 1) - (Row * 5);
                    ButtonArray[k * 5 + j].Image = CurrentBitmapImage.Clone(new Rectangle(new Point(Column * 75, Row * 75), new Size(75, 75)), System.Drawing.Imaging.PixelFormat.DontCare);

                }
            if (this.CurrentImageChanged != null)
                this.CurrentImageChanged(this, EventArgs.Empty);
        }

        private int GetNumber(int x, int y)
        {
            int a, b;
            if (y == 40) // y-->Row
                a = 0;
            else
                a = (y - 40) / 75;

            if (x == 20) // x-->Column
                b = 0;
            else
                b = (x - 20) / 75;
            int Number = a * 5 + b + 1;
            return Number;
        }

        private void ToolStripMenuItemShowCurrntImagr_Click(object sender, EventArgs e)
        {
            if (this.MyFrmShowCurrentImage == null)
                this.MyFrmShowCurrentImage = new FrmShowCurrentImage(this.CurrentBitmapImage);
            else
                this.MyFrmShowCurrentImage.Img = this.CurrentBitmapImage;
            this.MyFrmShowCurrentImage.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MyFrmShowCurrentImage != null)
                this.MyFrmShowCurrentImage.Dispose();
        }
    }

    public class MyButton : Button
    {
        private int number;

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.Text = value.ToString();
                this.number = value;
            }
        }

        public MyButton()
        {
        }
    }
}
