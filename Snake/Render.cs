using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Render
    {
        private char[,] tile;
        private int row;
        private int column;
        
        public void CreateTile()
        {
            row = Setting.Instance.GetWidth() / 2;
            column = Setting.Instance.GetHeight() / 2;

            tile = new char[row, column];

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    tile[i, j] = '　';
                }
            }
        }
        
        
        public void RenderTile()
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.WriteLine("SCORE :  " + GameManager.Instance.score);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if(i == GameManager.Instance.player.currentX && j == GameManager.Instance.player.currentY)
                    {
                        tile[i, j] = '■';
                    }
                    else if (i == GameManager.Instance.item.x && j == GameManager.Instance.item.y)
                    {
                        tile[i, j] = '◈';
                    }
                    else
                    {
                        tile[i, j] = '　';
                        for (int k = 0; k < GameManager.Instance.player.count; k++)
                        {
                            if (i == GameManager.Instance.player.tailX[k] && j == GameManager.Instance.player.tailY[k])
                            {
                                tile[i, j] = '◆';
                            }
                        }
                    }
                    Console.Write(tile[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
