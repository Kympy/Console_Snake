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

        public bool first = false; // 처음 꼬리를 먹는지
        public void Awake()
        {
            InitWindow();
        }
        public void Start()
        {
            //render.CreateTile();
        }
        public void Update()
        {
            Input.Instance.GetKey();
            CheckItem();
            player.Movement();
            render.RenderTile();
            GameWin();
        }
        private void CheckItem()
        {
            if (player.currentX == item.x && player.currentY == item.y)
            {
                player.count++;
                item.ResetPos();
            }
        }
        private void InitWindow() // 윈도우 설정
        {
            Console.CursorVisible = false;
            int w = Setting.Instance.GetWidth();
            int h = Setting.Instance.GetHeight();
            Console.SetWindowSize(w, h);
            Console.BufferWidth = w;
            Console.BufferHeight = h;
            Console.Title = "SNAKE GAME";
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public bool GameWin()
        {
            if (player.count >= 15)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\tGame Win");
                return true;
            }
            else return false;
        }
    }
}
