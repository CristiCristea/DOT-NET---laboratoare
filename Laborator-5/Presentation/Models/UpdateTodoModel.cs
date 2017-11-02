using System;

namespace Presentation.Models
{
    public class UpdateTodoModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsElectric { get; set; }
    }
}
