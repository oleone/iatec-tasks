using System;
using System.ComponentModel.DataAnnotations;

namespace IATecTasks.Application.Dtos
{
    public class ETaskUpdateDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }

        [Required]
        public DateTimeOffset CreatedDate { get; set; }

    }
}
