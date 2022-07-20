using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Item
    {
        private int X; // 아이템 x
        public int x { get { return X; } }

        private int Y; // 아이템 y
        public int y { get { return Y; } }

        private Random random = new Random();

        public Item()
        {
            ResetPos();
        }
        public void ResetPos()
        {
            X = random.Next(1, Setting.Instance.GetWidth() / 2 - 1);
            Y = random.Next(1, Setting.Instance.GetHeight() / 2 - 1);
        }
    }
}
