﻿namespace BuildJapanAIHandsonDay1_1.Data
{
    public class ChatMessage
    {
        public string? Name { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
