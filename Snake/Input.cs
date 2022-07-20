using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Input : SingleTon<Input>
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int myKey);
        private short myKey = 0;
        //ConsoleKeyInfo myKey;
        public void GetKey()
        {
            /*
            if(Console.KeyAvailable)
            {
                myKey = Console.ReadKey();
                if(myKey.Key == ConsoleKey.RightArrow)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.right);
                }
                else if (myKey.Key == ConsoleKey.LeftArrow)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.left);
                }
                else if (myKey.Key == ConsoleKey.UpArrow)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.up);
                }
                else if (myKey.Key == ConsoleKey.DownArrow)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.down);
                }
            }
            */
            
            myKey = 0;
            if (Console.KeyAvailable) // 키입력이 존재한다면
            {
                myKey = GetAsyncKeyState((int)ConsoleKey.RightArrow);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.right);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.LeftArrow);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.left);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.UpArrow);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.up);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.DownArrow);
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.down);
                }
            }
            
        }
    }
}
