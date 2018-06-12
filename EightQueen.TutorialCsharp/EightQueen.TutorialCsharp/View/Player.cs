using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using EightQueen.TutorialCsharp.View;

namespace EightQueen.TutorialCsharp.View
{
    public partial class Player : Form
    {
        private ArrayList coordinates = new ArrayList();
        private int totalQueens = 0;
        private bool hints = false;
       public Player()
        {
            InitializeComponent();
          
       }
       private void Player_Load(object sender, EventArgs e)
       {
           for (int i = 0; i < 8; i++)
           {
               for (int j = 0; j < 8; j++)
               {
                   int y = (40 * i + 100);
                   int x = (40 * j + 100);
                    space boardSpace = new space(x, y, i, j);
                   coordinates.Add(boardSpace);
               }
           }
       }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Image newimage = Image.FromFile("queen-icon.png");
            g.DrawString("Queen Count: " + totalQueens, Font, Brushes.Black, 140, 17);
            for(int i = 0; i < 64; i++)
            {
                space drawSpace = ((space)coordinates[i]);
                Rectangle rect = drawSpace.getRect();
                int X = drawSpace.getX();
                int Y = drawSpace.getY();
                if ((i / 8) % 2 == 0)
                {
                    if (i % 2 == 0)
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.Black, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                g.DrawImage(newimage,new RectangleF(X,Y,40,40));
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Black, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.White, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.Black, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.Black, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!hints)
                        {
                            g.FillRectangle(Brushes.White, rect);
                            g.DrawRectangle(Pens.Black, rect);
                            if (drawSpace.isOccupied())
                            {
                                g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                            }
                        }
                        else
                        {
                            if (!drawSpace.isValid(coordinates))
                            {
                                g.FillRectangle(Brushes.Red, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                            else
                            {
                                g.FillRectangle(Brushes.White, rect);
                                g.DrawRectangle(Pens.Black, rect);
                                if (drawSpace.isOccupied())
                                {
                                    g.DrawImage(newimage, new RectangleF(X, Y, 40, 40));
                                }
                            }
                        }
                    }
                }
            }
            if (totalQueens == 8)
            {
                for (int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    drawSpace.setOccupied(false);
                    totalQueens = 0;
                }
                MessageBox.Show("Bạn đã thắng!");
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                for(int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    if(drawSpace.isClicked(e.X, e.Y))
                    {
                        if(drawSpace.isValid(coordinates))
                        {
                            drawSpace.setOccupied(true);
                            totalQueens++;
                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                    }
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < 64; i++)
                {
                    space drawSpace = ((space)coordinates[i]);
                    if (drawSpace.isClicked(e.X, e.Y))
                    {
                        if (drawSpace.isOccupied())
                        {
                            drawSpace.setOccupied(false);
                            totalQueens--;
                        }
                    }
                }
            }
            Invalidate();
        }
        private void Clear_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 64; i++)
            {
                space drawSpace = ((space)coordinates[i]);
                drawSpace.setOccupied(false);
                totalQueens = 0;
            }
            Invalidate();
        }
    
        private void Hint_CheckedChanged_1(object sender, EventArgs e)
        {
            hints = !hints;
            Invalidate();
        }
    }
}
