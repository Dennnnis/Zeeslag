using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Zeeslag
{
    public static class Grid
    {
        private static int Nearby(int x, int y,Cell[,] grid)
        {
            int c = 0;

            int check(int x2,int y2)
            {
                if (x2 < 0 || x2 >= grid.GetLength(0) || y2 < 0 || y2 >= grid.GetLength(1)) return 0;
                if (grid[x2, y2].isShip) return 1;
                return 0;
            }

            c += check(x + 1,y + 0) + check(x - 1,y + 0) + check(x + 0,y + 1) + check(x + 0,y - 1);
            c += check(x + 1,y + 1) + check(x - 1,y - 1);
            c += check(x + 1,y - 1) + check(x - 1,y + 1);
            c += check(x, y);

            return c;
        }

        public static bool CheckSelection(PictureBox[,] visualGrid,Cell[,] grid, int x, int y, bool right, ShipCode ship)
        {
            for (int d = 0; d < Cell.GetLength(ship); d++)
            {
                if ((x < 0 || x >= visualGrid.GetLength(0)) || (y < 0 || y >= visualGrid.GetLength(1))) return false;

                if (Nearby(x, y, grid) > 0) return false;

                if (right) x++; else y++;
            }
            return true;
        }

        public static void PlaceBoat(Cell[,] grid, int x, int y, bool right,int number, ShipCode ship)
        {
            for (int d = 0; d < Cell.GetLength(ship); d++)
            {
                grid[x, y] = new Cell() { isShip = true,right = right, shipCode = ship, number = number };
                if (right) x++; else y++;
            }
        }

        public static void DrawSelection(PictureBox[,] visualGrid, int x, int y, bool right, ShipCode ship, bool good)
        {
            for (int d = 0; d < Cell.GetLength(ship); d++)
            {
                if (!((x < 0 || x >= visualGrid.GetLength(0)) || (y < 0 || y >= visualGrid.GetLength(1))))
                {
                    visualGrid[x, y].Image = good ? Properties.Resources.Selection : Properties.Resources.BadSelection;
                }
                if (right) x++; else y++;
            }
            return;
        }

        public static bool IsGameOver(Cell[,] grid)
        {
            for (int iy = 0; iy < grid.GetLength(1); iy++)
            {
                for (int ix = 0; ix < grid.GetLength(0); ix++)
                {
                    if (grid[ix, iy].isShip && !grid[ix, iy].hit)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsRip(Cell[,] grid,int x, int y)
        {
            int number = grid[x,y].number;
            int hitCounter = 0;

            for (int iy = 0; iy < grid.GetLength(1); iy++)
            {
                for (int ix = 0; ix < grid.GetLength(0); ix++)
                {
                    if (grid[ix, iy].isShip)
                    {
                        if (grid[ix,iy].number == number && grid[ix,iy].hit)
                        {
                            hitCounter++;
                        }
                    }
                }
            }

            if (hitCounter >= Cell.GetLength(grid[x,y].shipCode))
            {
                return true;
            }

            return false;
        }

        public static void Draw(PictureBox[,] visualGrid,Cell[,] grid)
        {
            Cell getCell(int x, int y)
            {
                if (x > -1 && x < visualGrid.GetLength(0) && y > -1 && y < visualGrid.GetLength(1)) return grid[x, y];
                return new Cell();
            }

            Section getSection(int x, int y)
            {
                if ((getCell(x + 1, y).isShip && getCell(x - 1, y).isShip) || (getCell(x, y + 1).isShip && getCell(x, y - 1).isShip))
                    return Section.Middle;

                if (getCell(x - 1, y).isShip || getCell(x, y - 1).isShip)
                    return Section.Front;

                return Section.Back;
            }

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (!grid[x,y].hidden)
                        visualGrid[x, y].BackgroundImage = grid[x, y].isShip ? grid[x, y].GetBitmap(getSection(x, y)) : null;

                    if (grid[x, y].hit) { visualGrid[x, y].Image = Properties.Resources.Hit; continue; }
                    if (grid[x, y].missed) { visualGrid[x, y].Image = Properties.Resources.Miss; continue; }

                    visualGrid[x, y].Image = null;     
                }
            }
        }
    }
}
