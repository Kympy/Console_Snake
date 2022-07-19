using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Tail
    {
        private int X; // 꼬리 x
        public int x { get { return X; } }

        private int Y; // 꼬리 y
        public int y { get { return Y; } }

        private int Count; // 꼬리 갯수
        public int count { get { return Count; } }

        public void SetX(int pos) { X = pos; }
        public void SetY(int pos) { Y = pos; }
        public void SetCount(int count) { Count = count; }
    }
}
