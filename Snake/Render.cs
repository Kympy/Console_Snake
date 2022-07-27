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
            row = Setting.Instance.GetWidth() / 2; // 윈도우 크기 절반만큼
            column = Setting.Instance.GetHeight() / 2;

            tile = new char[row, column];

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    tile[i, j] = '　'; // 공백으로 초기화
                }
            }
        }
        
        public void RenderTile() // 화면 그리기
        {
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            Console.WriteLine("P1 SCORE : " + GameManager.Instance.score1 + "  P2 SCORE : " + GameManager.Instance.score2 + "  MAX : 300");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {
                    if(i == GameManager.Instance.player.currentX && j == GameManager.Instance.player.currentY) // 플레이어 머리 그리기
                    {
                        tile[i, j] = '■';
                    }
                    else if(i == GameManager.Instance.ai.currentX && j == GameManager.Instance.ai.currentY) // ai 머리 그리기
                    {
                        tile[i, j] = '●';
                    }
                    else if (i == GameManager.Instance.item.x && j == GameManager.Instance.item.y) // 아이템 그리기
                    {
                        tile[i, j] = '◈';
                    }
                    else // 꼬리 그리기
                    {
                        tile[i, j] = '　';
                        for (int k = 0; k < GameManager.Instance.player.count; k++) // 플레이어의 꼬리
                        {
                            if (i == GameManager.Instance.player.tailX[k] && j == GameManager.Instance.player.tailY[k])
                            {
                                tile[i, j] = '◆';
                            }
                        }
                        for (int k = 0; k < GameManager.Instance.ai.count; k++) // AI의 꼬리
                        {
                            if (i == GameManager.Instance.ai.tailX[k] && j == GameManager.Instance.ai.tailY[k])
                            {
                                tile[i, j] = '●';
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
