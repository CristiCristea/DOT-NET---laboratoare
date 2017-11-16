using System;

namespace MVCApplication.DTOs
{
    public class CreateStock
    {
        public string Name { get; set; }

        public int Code { get; set; }

        public DateTime Date { get; set; }

        public int EndPrice { get; set; }

        public int StartPrice { get; set; }
    }
}