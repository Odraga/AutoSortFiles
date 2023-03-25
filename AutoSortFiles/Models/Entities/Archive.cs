using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFiles.Models.Entities
{
    internal class Archive
    {
        public int Id { get; set; }
        public int IdFormat { get; set; }
        public int IdCategories { get; set; }
        public string? Format { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
    }
}
