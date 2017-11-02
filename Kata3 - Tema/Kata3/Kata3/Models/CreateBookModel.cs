using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata3.Models
{
    public class CreateBookModel
    {
        public string Title { get;  set; }

        public int Year { get;  set; }

        public double Price { get;  set; }

        public string Genere { get;  set; }
    }
}
