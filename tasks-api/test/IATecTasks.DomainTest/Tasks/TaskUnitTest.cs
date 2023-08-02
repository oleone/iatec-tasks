using ExpectedObjects;
using IATecTasks.Domain;
using IATecTasks.DomainTest.Builders;
using IATecTasks.DomainTest.Utils;
using System;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace IATecTasks.DomainTest.Tasks
{
    public class TaskUnitTest: IDisposable
    {
        private string _id;
        private string _title;
        private string _description;
        private bool _isDone;
        private bool _isDeleted;
        private bool _isInProgress;
        private DateTimeOffset _createdDate;
        private DateTimeOffset _updatedDate;

        private ITestOutputHelper _testOutputHelper;

        public TaskUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("TaskUnitTest constructor is running...");

            _createdDate = DateTimeOffset.Now;
            _updatedDate = DateTimeOffset.Now;
            _id = Guid.NewGuid().ToString();
            _description = Guid.NewGuid().ToString();
            _title = Guid.NewGuid().ToString();
            _isDone = true;
            _isDeleted = false;
        }

        [Fact]
        public void MustBeCreateTask()
        {
            var expectedTask = new
            {
               CreatedDate = _createdDate,
               Description = _description,
               Id = Guid.NewGuid(),
               IsDeleted = _isDeleted,
               IsDone = _isDone,
               IsInProgress = _isInProgress,
               Title = _title,
               UpdatedDate = _updatedDate,
            };

            var task = new TaskBuilder().Build();

            expectedTask.ToExpectedObject().ShouldMatch(task);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TaskMustHaveTitle(string title)
        {
            Assert.Throws<ArgumentException>(() => TaskBuilder.New().WithTitle(title).Build()).WithMessage("Required field title");
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("TaskUnitTest dispose is running...");
        }
    }
}
