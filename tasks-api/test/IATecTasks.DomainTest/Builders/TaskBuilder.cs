using IATecTasks.Domain;

namespace IATecTasks.DomainTest.Builders
{
    public class TaskBuilder
    {
        private string _title;
        private string _description;
        private string _userId;
        private bool _isInProgress;
        private bool _isDone;

        public static TaskBuilder New()
        {
            return new TaskBuilder();
        }
        public Task Build()
        {
            return new Task(_title, _description, _userId, _isInProgress, _isDone);
        }

        public TaskBuilder WithTitle(string title) {
            _title = title;
            return this;
        }
    }
}
