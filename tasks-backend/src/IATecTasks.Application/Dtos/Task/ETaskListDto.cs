using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IATecTasks.Application.Dtos
{
    public class ETaskListDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
