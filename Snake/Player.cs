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
        public int[] tailX = new int[15];
        public int[] tailY = new int[15];

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
            currentX = Setting.Instance.GetWidth() / 2 - 3;
            currentY = Setting.Instance.GetHeight() / 2 - 3;
        }
        public void Movement() // 플레이어의 이동
        {
            tailX[0] = currentX; // 첫 꼬리의 좌표
            tailY[0] = currentY;
            for (int i = count - 1; i > 0; i--)
            {
                tailX[i] = tailX[i - 1];
                tailY[i] = tailY[i - 1];
            }
            switch (state) // 상태에 따른 이동
            {
                case (int)Move.up:{ currentX -= 1;break; }
                case (int)Move.down:{currentX += 1;break;}
                case (int)Move.left: { currentY -= 1;break; }
                case (int)Move.right: { currentY += 1; break; }
                case (int)Move.start: { break; }
            }
            // 이동 범위 제한 ( 맵의 끝 체크)
            if (currentX < 0 || currentX > Setting.Instance.GetWidth() / 2 - 1 || currentY < 0 || currentY > Setting.Instance.GetHeight() / 2 - 1)
            { GameManager.Instance.over = true; }
        }
        public void SetState(int dir) // 이동 방향 설정
        {
            state = dir;
        }
    }
}
