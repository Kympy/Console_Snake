using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Player
    {
        public enum Move // 이동 상태
        {
            up,
            down,
            left,
            right,
            start,
        }
        public List<Tail> tail = new List<Tail>();
        private int X; // 플레이어 x
        public int x { get { return X; } }

        private int Y; // 플레이어 y
        public int y { get { return Y; } }

        private int state = (int)Move.start;
        public Player()
        {
            Awake();
        }
        public void Awake() // 초기 위치
        {
            X = Setting.Instance.GetWidth() / 2 / 2;
            Y = Setting.Instance.GetHeight() / 2 / 2;
        }
        public void Movement()
        {
            switch(state) // 상태에 따른 이동
            {
                case (int)Move.up: { X -= 1; break; }
                case (int)Move.down: { X += 1; break; }
                case (int)Move.left: { Y -= 1; break; }
                case (int)Move.right: { Y += 1; break; }
                case (int)Move.start: { break; }
            }
            // 범위 제한
            if(X < 0) { X = 0; }
            if (X > Setting.Instance.GetHeight() / 2) { X = Setting.Instance.GetHeight() / 2 - 1; }
            if(Y < 0) { Y = 0; }
            if(Y > Setting.Instance.GetWidth() / 2) { Y = Setting.Instance.GetWidth() / 2 - 1; }
        }
        public void GetTail()
        {
            if(X == GameManager.Instance.item.x && Y == GameManager.Instance.item.y)
            {
                if (GameManager.Instance.first == false) GameManager.Instance.first = true;
                GameManager.Instance.item.ResetPos();
                Tail t = new Tail();
                tail.Add(t);
            }
        }
        public void SetTailPos()
        {
            for(int i = 0; i < tail.Count - 1; i++)
            {
                if(i == 0)
                {
                    tail[0].SetX(X + 1);
                    tail[0].SetY(Y);
                }
                tail[i].SetX(tail[i - 1].x);
                tail[i].SetY(tail[i - 1].y);
            }
        }
        public void SetState(int dir) // 이동 방향 설정
        {
            state = dir;
        }
    }
}
