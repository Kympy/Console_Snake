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
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    for (int k = 0; k < GameManager.Instance.player.tail.Count - 1; k++)
                    {
                        if (i == GameManager.Instance.player.tail[k].x && j == GameManager.Instance.player.tail[k].y)
                        {
                            tile[i, j] = '■';
                        }
                    }
                    if (i == GameManager.Instance.player.x && j == GameManager.Instance.player.y)
                    {
                        tile[i, j] = '■';
                    }
                    else if (i == GameManager.Instance.item.x && j == GameManager.Instance.item.y)
                    {
                        tile[i, j] = '★';
                    }
                    else
                    {
                        tile[i, j] = '□';
                    }
                    Console.Write(tile[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
