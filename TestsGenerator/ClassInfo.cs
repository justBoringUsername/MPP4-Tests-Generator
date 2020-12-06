using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGenerator
{
    public class ClassInfo
    {
        public string name { get; }
        private string body;
        public string Body { get => body; set => body = value; }
        public ClassInfo(string name, string body)
        {
            this.name = name;
            this.body = body;
        }

       
    }
}
