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
                myKey = GetAsyncKeyState((int)ConsoleKey.RightArrow);
                if ((myKey & 0x8000) == 0x8000)
                {

                }
                myKey = GetAsyncKeyState((int)ConsoleKey.LeftArrow);
                if ((myKey & 0x8000) == 0x8000)
                {

                }
                myKey = GetAsyncKeyState((int)ConsoleKey.UpArrow);
                if ((myKey & 0x8000) == 0x8000)
                {

                }
                myKey = GetAsyncKeyState((int)ConsoleKey.DownArrow);
                if ((myKey & 0x8000) == 0x8000)
                {

                }
            }
        }
    }
}
