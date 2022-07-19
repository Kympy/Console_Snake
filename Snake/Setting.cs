﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public  class Setting : SingleTon<Setting>
    {
        private int width = 30;
        private int height = 30;

        public int GetWidth() { return width; } // 가로 반환
        public int GetHeight() { return height; } // 세로 반환
    }
}
