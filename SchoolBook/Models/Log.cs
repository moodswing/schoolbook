using System;
using Microsoft.Extensions.Logging;

namespace SchoolBook.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public string CategoryName { get; set; }
        public string Msg { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
