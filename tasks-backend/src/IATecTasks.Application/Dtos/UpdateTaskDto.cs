namespace IATecTasks.Application.Dtos
{
    public class UpdateTaskDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsInProgress { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }
        public string UserId { get; set; }

    }
}
