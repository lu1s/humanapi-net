﻿using System;

namespace HumanAPI.DataModel
{
    public class HeartRate
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime timestamp { get; set; }
        public int value { get; set; }
        public string unit { get; set; }
    }
}