using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSortFiles.Models.Entities
{
    internal class Folder
    {
        public int Id { get; set; }
        public int IdCategories { get; set; }
        public int IdPathSendFiles { get; set; }
    }
}
