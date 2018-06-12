using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
namespace EightQueen.TutorialCsharp
{
    class space
    {
            private int x;
            private int y;
            private int row;
            private int col;
            public Rectangle rect;
            public bool occupied;


            public Rectangle getRect()
            {
                return rect;
            }
            public int getX()
            {
                return x;
            }
            public int getY()
            {
                return y;
            }
            public bool isOccupied()
            {
                return occupied;
            }
            public bool setOccupied(bool inset)
            {
                occupied = inset;
                return inset;
            }
            public int getRow()
            {
                return row;
            }
            public int getCol()
            {
                return col;
            }
            public space(int iny, int inx, int i, int j)
            {
                x = inx;
                y = iny;
                row = i;
                col = j;
                rect = new Rectangle(x, y, 40, 40);
                occupied = false;
            }
            public bool isValid(ArrayList spaces)
            {
                for (int i = 0; i < 64; i++)
                {
                    if ((((space)spaces[i]).getX() == x) && ((space)spaces[i]).isOccupied())
                    {
                        return false;
                    }
                    else if ((((space)spaces[i]).getY() == y) && ((space)spaces[i]).isOccupied())
                    {
                        return false;
                    }
                    else if (Math.Abs(((space)spaces[i]).getCol() - col) == Math.Abs(((space)spaces[i]).getRow() - row))
                    {
                        if (((space)spaces[i]).isOccupied())
                        {
                            return false;
                        }
                    }
                }
                if (occupied)
                {
                    return false;
                }
                else { return true; }
            }
            public bool isClicked(int inX, int inY)
            {
                if ((inX >= x) && (inX <= x + 40))
                {
                    if ((inY >= y) && (inY <= y + 40))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
    }

