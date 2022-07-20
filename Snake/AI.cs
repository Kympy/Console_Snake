using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class AI : Player
    {
        private int xDistance;
        private int yDistance;

        public AI()
        {
            currentX = 3;
            currentY = 3;
            tailX = new int[15];
            tailY = new int[15];
            count = 0;
        }
        public void FindItem()
        {
            xDistance = (GameManager.Instance.item.x - currentX); // x 거리
            yDistance = (GameManager.Instance.item.y - currentY); // y 거리
        }
        public void StartAI()
        {
            tailX[0] = currentX; // 플레이어랑 똑같이 꼬리 만들기
            tailY[0] = currentY;
            for (int i = count - 1; i > 0; i--)
            {
                tailX[i] = tailX[i - 1];
                tailY[i] = tailY[i - 1];
            }
            FindItem();
            if(xDistance < 0 && xDistance != 0) // 아이템이 위에 있다.
            {
                currentX -= 1; // 위로 이동
            }
            else if(xDistance > 0 && xDistance != 0) //  아이템이 아래에 있다.
            {
                currentX += 1; // 아래로 이동
            }
            else if(yDistance < 0 && yDistance != 0) // 아이템이 왼쪽에 있다.
            {
                currentY -= 1; // 왼쪽으로 이동
            }
            else if(yDistance > 0 && yDistance != 0) // 아이템이 아래에 있다.
            {
                currentY += 1; // 오른쪽으로 이동
            }
        }
    }
}
