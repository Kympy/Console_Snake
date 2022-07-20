using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameManager : SingleTon<GameManager>
    {
        public Player player = new Player();
        public Item item = new Item();
        public Render render = new Render();
        public AI ai = new AI();

        public bool over = false;

        public int score1 = 0;
        public int score2 = 0;

        private const int waitTick = 1000 / 5;
        private long currentTick;
        private long lastTick = 0;
        public void Awake()
        {
            InitWindow();
        }
        public void Start()
        {
            render.CreateTile();
        }
        public void Update()
        {
            while (true)
            {
                currentTick = Environment.TickCount & Int32.MaxValue;
                if (currentTick - lastTick > waitTick)
                {
                    lastTick = currentTick;

                    Input.Instance.GetKey();
                    player.Movement();
                    ai.StartAI();
                    CheckItem();
                    render.RenderTile();
                    if (over)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t--Game Over--");
                        return;
                    }
                    if(GameWin())
                    {
                        return;
                    }
                }
            } 
        }
        private void CheckItem()
        {
            if (player.currentX == item.x && player.currentY == item.y)
            {
                player.count++;
                score1 += 20;
                item.ResetPos();
            }
            else if (ai.currentX == item.x && ai.currentY == item.y)
            {
                ai.count++;
                score2 += 20;
                item.ResetPos();
            }
        }
        private void InitWindow() // 윈도우 설정
        {
            Console.CursorVisible = false;
            int w = Setting.Instance.GetWidth();
            int h = Setting.Instance.GetHeight();
            Console.SetWindowSize(w, h / 2 + 2);
            Console.BufferWidth = w;
            Console.BufferHeight = h / 2 + 2;
            Console.Title = "SNAKE GAME";
        }
        public bool GameWin()
        {
            if (player.count >= 15)
            {
                Thread.Sleep(1000); // 잠시 대기
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t--Game Win--");
                return true;
            }
            else if(ai.count >= 15)
            {
                Thread.Sleep(1000); // 잠시 대기
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t--AI Win--");
                return true;
            }
            else return false;
        }
    }
}
