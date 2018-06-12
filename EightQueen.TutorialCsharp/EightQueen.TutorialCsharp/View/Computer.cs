using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EightQueen.TutorialCsharp.View;


namespace EightQueen.TutorialCsharp.View
{
    public partial class Computer : Form
    {
        public Computer()
        {
            InitializeComponent();
          
            _8Queen.getInstance().KhoiTao();
            _8Queen.getInstance().Try(0);

        }
        private void Computer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = Brushes.Black;
            Image newimage = Image.FromFile("queen-icon.png");
            Image newimage1 = Image.FromFile("white.png");
            //Vẽ bàn cờ
            g.DrawRectangle(new Pen(Color.Black, 2), 40, 80, 320, 320);
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0) b = Brushes.Black;
                    else b = Brushes.White;
                    g.FillRectangle(b, 40 + 40 * j, 80 + 40 * i, 40, 40);

                }
            //Vẽ hậu
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if ( _8Queen.getInstance().Banco1[i, j] == 1)
                        g.DrawImage(newimage, new RectangleF(40 + 40 * j, 80 + 40 * i, 40, 40));
        }


        private void btBack(object sender, EventArgs e)
        {
            try
            {
                _8Queen.getInstance().Count = System.Convert.ToInt32(tbNumber.Text);
                _8Queen.getInstance().Index = _8Queen.getInstance().Count * 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The input not a integer value!");
            }

            if (_8Queen.getInstance().Count < 0 || _8Queen.getInstance().Count > 91)
            {
                MessageBox.Show("You must insert a number integer between 0 and 91!");
            }
            else
            {
                // _8Queen.getInstance().count = int.Parse(tbNumber.Text);
                if (_8Queen.getInstance().Count > 0)
                {
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++) _8Queen.getInstance().Banco1[i, j] = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (_8Queen.getInstance().Vt[_8Queen.getInstance().Index].dong == i & _8Queen.getInstance().Vt[_8Queen.getInstance().Index].cot == j)
                            {
                                _8Queen.getInstance().Banco1[i, j] = 1;
                                if (_8Queen.getInstance().Index < 735)
                                    _8Queen.getInstance().Index++;
                            }
                        }
                    }

                    this.Invalidate();
                    _8Queen.getInstance().Count--;
                    tbNumber.Text = _8Queen.getInstance().Count.ToString();
                }
            }
        }
        private void btNext(object sender, EventArgs e)
        {
            try
            {

                _8Queen.getInstance().Count = System.Convert.ToInt32(tbNumber.Text);
                _8Queen.getInstance().Index = _8Queen.getInstance().Count * 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The input not a integer value!");
            }

            if (_8Queen.getInstance().Count < 0 || _8Queen.getInstance().Count > 91)
            {
                MessageBox.Show("You must insert a number integer between 0 and 91!");
            }
            else
            {
                // _8Queen.getInstance().count = int.Parse(tbNumber.Text);
                if (_8Queen.getInstance().Count < 91)
                {
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++) _8Queen.getInstance().Banco1[i, j] = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (_8Queen.getInstance().Vt[_8Queen.getInstance().Index].dong == i & _8Queen.getInstance().Vt[_8Queen.getInstance().Index].cot == j)
                            {
                                _8Queen.getInstance().Banco1[i, j] = 1;
                                _8Queen.getInstance().Index++;
                            }
                        }
                    }

                    this.Invalidate();
                    _8Queen.getInstance().Count++;
                    tbNumber.Text = _8Queen.getInstance().Count.ToString();
                }
            }
        }

        private void tbNumber_Change(object sender, EventArgs e)
        {
            int num;

            bool isNum = Int32.TryParse(tbNumber.Text, out num) ;

            if (isNum == true)
            {
                label_error.Text = "";
                if (System.Convert.ToInt32(tbNumber.Text) >= 0 && System.Convert.ToInt32(tbNumber.Text) < 92)
                {
                    _8Queen.getInstance().Count = System.Convert.ToInt32(tbNumber.Text);
                    _8Queen.getInstance().Index = _8Queen.getInstance().Count * 8;
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++) _8Queen.getInstance().Banco1[i, j] = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (_8Queen.getInstance().Vt[_8Queen.getInstance().Index].dong == i & _8Queen.getInstance().Vt[_8Queen.getInstance().Index].cot == j)
                            {
                                _8Queen.getInstance().Banco1[i, j] = 1;
                                if (_8Queen.getInstance().Index < 735)
                                _8Queen.getInstance().Index++;
                            }
                        }
                    }
                    this.Invalidate();
                }
            }
            else
            {
                tbNumber.Text = "";
                label_error.Text = "Kieu Du Lieu Nhap Khong Phai Interger";
            }
        }
    }
}
