using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class MainGame
    {
        //private const int waitTick = 1000 / 5;
        static void Main()
        {
            GameManager.Instance.Awake();
            GameManager.Instance.Start();
            GameManager.Instance.Update();
        }
    }
}
