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
        }
        public void FindItem()
        {
            xDistance = (int)MathF.Abs(GameManager.Instance.item.x - currentX);
        }
        public void StartAI()
        {

        }
    }
}
