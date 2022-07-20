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
        public bool over = false;
        public bool win = false;
        public int score = 0;
        public void Awake()
        {
            InitWindow();
        }
        public void Start()
        {
            render.CreateTile();
        }
        public bool Update()
        {
            Input.Instance.GetKey();
            player.Movement();
            CheckItem();
            render.RenderTile();
            if (over == true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t--Game Over--");
                return false;
            }
            GameWin();
            if (win == true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t--Game Win--");
                return false;
            }
            return true;
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
            Console.SetWindowSize(w, h / 2 + 2);
            Console.BufferWidth = w;
            Console.BufferHeight = h / 2 + 2;
            Console.Title = "SNAKE GAME";
        }
        public bool GameWin()
        {
            if (player.count >= 15)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t--Game Win--");
                return true;
            }
            else return false;
        }
    }
}
