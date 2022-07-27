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
        public void GetKey()
        {
            myKey = 0;
            if (Console.KeyAvailable) // 키입력이 존재한다면
            {
                myKey = GetAsyncKeyState((int)ConsoleKey.RightArrow); // 오른쪽
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.right);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.LeftArrow); // 왼쪽
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.left);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.UpArrow); // 위
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.up);
                }
                myKey = GetAsyncKeyState((int)ConsoleKey.DownArrow); // 아래
                if ((myKey & 0x8000) == 0x8000)
                {
                    GameManager.Instance.player.SetState((int)Player.Move.down);
                }
            }
            
        }
    }
}
