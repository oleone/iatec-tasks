using IATecTasks.Domain;
using System;
using Xunit;

namespace IATecTasks.DomainTest.Tasks
{
    public class TaskUnitTest: IDisposable
    {
        private string _title;
        private string _description;
        private DateTimeOffset _createdDate;
        private DateTimeOffset _updatedDate;
        private string _id;

        public TaskUnitTest()
        {
            _createdDate = DateTimeOffset.Now;
        }

        [Fact]
        public void MustBeCreateTask()
        {
            var expectedTask = new Task
            {
               CreatedDate = _createdDate,
               Description = _description,
               Id = Guid.NewGuid(),
               IsDeleted = false,
               IsDone = false,
               IsInProgress = false,
               Title = _title,
               UpdatedDate = _updatedDate,
               isInProgress = false,
            };
        }


        [Fact]
        public void TaskMustHaveTitle()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
