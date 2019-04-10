using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Paint_Update
{
    public partial class Form1 : Form
    {
        #region Biến toàn cục
        private Point _p1;
        private Point _p2;
        private bool isDown;
        private Bitmap _bmp;
        private Graphics _gp;
        private Graphics g;
        private int x = -1;
        private int y = -1;
        #endregion
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            _bmp = new Bitmap(this.Width,this.Height);
            _gp = Graphics.FromImage(_bmp);
            _gp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
        }
        

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void btnClr_Click(object sender, EventArgs e)
        {
            DialogResult rs = colorDialog1.ShowDialog();
            if(rs==DialogResult.OK)
            {
                btnClr.BackColor = colorDialog1.Color;
            }
        }
        #region Sự kiện
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (isDown)
            //{
            //    x = e.X;
            //    y = e.Y;
            //    _p1 = new Point(e.Location.X, e.Location.Y);
            //}
            isDown = true;
            _p1 = new Point(e.Location.X, e.Location.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isDown)
            {
                _p2 = new Point(e.Location.X, e.Location.Y);
                //Pen nPen = new Pen(btnClr.BackColor, Convert.ToInt16(numericUpDown1.Value));
                //nPen.StartCap = nPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                //g.DrawLine(nPen, new Point(x, y), e.Location);

                //x = e.X;
                //y = e.Y;
                this.Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            Pen nPen = new Pen(btnClr.BackColor, Convert.ToInt16(numericUpDown1.Value));
            _gp.DrawLine(nPen, _p1,_p2);
            this.BackgroundImage = (Bitmap)_bmp.Clone();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (isDown)
            {
                Pen nPen = new Pen(btnClr.BackColor, Convert.ToInt16(numericUpDown1.Value));
                nPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                e.Graphics.DrawLine(nPen, _p1, _p2);
            }
        }

        private void btnRe_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDLine_Click(object sender, EventArgs e)
        {
            this.isDown = true;
        }

        private void howToUseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chỉ cần bấm chọn vào các chức năng vẽ hình mà bạn muốn vẽ thôi thằng gà !!!");

        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _bmp.Save(@"C:\Users\DuongCoKhanh\Desktop\Hình Game\bmp.jpg");
        }
        #endregion
    }

}
