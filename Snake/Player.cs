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
        public int[] tailX = new int[17];
        public int[] tailY = new int[17];
        private int[] tempX = new int[17];
        private int[] tempY = new int[17];

        private int state = (int)Move.start;

        public int currentX;
        public int currentY;

        public int count = 0;

        public Player()
        {
            Awake();
        }
        public void Awake() // 초기 위치
        {
            currentX = Setting.Instance.GetWidth() / 2;
            currentY = Setting.Instance.GetHeight() / 2;
        }
        public void Movement()
        {
            tailX[0] = currentX;
            tailY[0] = currentY;

            for (int i = 0; i < count; i++)
            {
                tempX[i] = tailX[i];
                tempY[i] = tailY[i];
            }
            for(int i = 1; i < count; i++)
            {
                tailX[i] = tempX[i - 1];
                tailY[i] = tempY[i - 1];
            }
            switch (state) // 상태에 따른 이동
            {
                case (int)Move.up:{ currentY -= 1;break; }
                case (int)Move.down:{currentY += 1;break;}
                case (int)Move.left: { currentX -= 1;break; }
                case (int)Move.right: { currentX += 1; break; }
                case (int)Move.start: { break; }
            }
            // 범위 제한
            if (currentX < 0) { currentX = 0; }
            else if (currentX > Setting.Instance.GetWidth() - 1) { currentX = Setting.Instance.GetWidth() - 1; }
            else if (currentY < 0) { currentY = 0; }
            else if (currentY > Setting.Instance.GetHeight() - 1) { currentY = Setting.Instance.GetHeight() - 1; }
        }
        public void SetState(int dir) // 이동 방향 설정
        {
            state = dir;
        }
    }
}
