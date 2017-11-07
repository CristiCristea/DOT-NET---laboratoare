using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Presentation.DTOs
{
    public class UpdateCategoryModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public virtual List<Product> Products { get; set; }

        public string DistributorName { get; set; }
    }
}
