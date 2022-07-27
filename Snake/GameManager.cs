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

        public bool over = false; // 게임 오버를 체크한다

        public int score1 = 0; // 플레이어1의 점수
        public int score2 = 0; // 플레이어2의 점수

        private const int waitTick = 1000 / 5; // 화면 갱신 시간
        private long currentTick;
        private long lastTick = 0;
        public void Awake()
        {
            InitWindow(); // 윈도우 기본 세팅
        }
        public void Start()
        {
            render.CreateTile(); // 게임이 진행될 맵을 생성
        }
        public void Update() // 게임을 업데이트
        {
            while (true)
            {
                currentTick = Environment.TickCount & Int32.MaxValue;
                if (currentTick - lastTick > waitTick)
                {
                    lastTick = currentTick;

                    Input.Instance.GetKey(); // 키 입력
                    player.Movement(); // 플레이어 움직임
                    ai.StartAI(); // AI 움직임
                    CheckItem(); // 아이템 체크
                    render.RenderTile(); // 화면 그리기
                    if (over) // 게임이 끝나면
                    {
                        Console.Clear(); // 화면 지우고
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t--Game Over--"); // 오버
                        return;
                    }
                    if(GameWin()) // 이기면 종료
                    {
                        return;
                    }
                }
            } 
        }
        private void CheckItem() // 플레이어나 ai 가 아이템을 먹었는지 체크
        {
            if (player.currentX == item.x && player.currentY == item.y)
            {
                player.count++; // 꼬리 갯수 증가
                score1 += 20;
                item.ResetPos(); // 아이템 재배치
            }
            else if (ai.currentX == item.x && ai.currentY == item.y)
            {
                ai.count++; // 꼬리 갯수 증가
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
