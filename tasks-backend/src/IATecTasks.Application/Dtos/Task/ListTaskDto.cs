using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Application.Dtos
{
    public class ListTaskDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}
