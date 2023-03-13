using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFiles.Models.Entities
{
    internal class Files
    {
        public Files(string format, string name) 
        {
            this.Format = format;
            this.Name = name;
        }

        public string Format { get; set; }
        public string Name { get; set; }
    }
}
