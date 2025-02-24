using e_CommerceSystem_.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_CommerceSystem.Bll.DTOs
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }
    }
}
