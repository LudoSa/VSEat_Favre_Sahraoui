﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Cities
    {
        public int IdCity { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int Code { get; set; }

        public override string ToString()
        {
            return $"{IdCity}|{Name}";
        }

    }
}
