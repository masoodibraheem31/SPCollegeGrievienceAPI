using System;
using System.Collections.Generic;
using System.Text;

namespace Wiser.API.BL.Config
{
    public class Response<T>
    {
        public bool Success { get; set; } = true;
        public T Data { get; set; }
        public string Message { get; set; }
        public int? Count { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
