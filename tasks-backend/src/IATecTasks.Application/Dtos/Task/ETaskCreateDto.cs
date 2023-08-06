using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IATecTasks.Application.Dtos
{
    public class ETaskCreateDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
