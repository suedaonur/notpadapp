using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDefteri.Models
{
    public class Kategori
    {
        public string CategoryName { get; set; }
        public List<Not> Notlar { get; set; }
        public Kategori() 
        {
            Notlar = new List<Not>();
        }
    }
}
