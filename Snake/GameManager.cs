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
            render.CreateTile();
        }
        public void Update()
        {
            Input.Instance.GetKey();
            player.Movement();
            player.GetTail();
            player.SetTailPos();
            render.RenderTile();
        }

        private void InitWindow() // 윈도우 설정
        {
            Console.CursorVisible = false;
            int w = Setting.Instance.GetWidth();
            int h = Setting.Instance.GetHeight() / 2;
            Console.SetWindowSize(w, h);
            Console.BufferWidth = w;
            Console.BufferHeight = h;
            Console.Title = "SNAKE GAME";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
