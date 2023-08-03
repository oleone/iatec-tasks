using IATecTasks.Domain;
using System;

namespace IATecTasks.DomainTest.Builders
{
    public class TaskBuilder
    {
        private string _title;
        private string _description;
        private string _userId;
        private bool _isInProgress;
        private bool _isDone;
        private bool _isDeleted;

        public static TaskBuilder New()
        {
            return new TaskBuilder();
        }

        public TaskBuilder()
        {
            _title = "Title";
            _description = "Description";
            _userId = Guid.NewGuid().ToString();
            _isInProgress = false;
            _isDone = false;
        }

        public Task Build()
        {
            return new Task(_title, _description, _userId, _isInProgress, _isDone, _isDeleted);
        }

        public TaskBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public TaskBuilder WithUserId(string userId)
        {
            _userId = userId;
            return this;
        }
    }
}
