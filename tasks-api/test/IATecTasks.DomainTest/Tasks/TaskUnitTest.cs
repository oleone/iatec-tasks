using Bogus;
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
    public class TaskUnitTest : IDisposable
    {
        private string _title;
        private string _description;
        private bool _isDone;
        private bool _isDeleted;
        private bool _isInProgress;
        private string _userId;

        private ITestOutputHelper _testOutputHelper;

        public TaskUnitTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _testOutputHelper.WriteLine("TaskUnitTest constructor is running...");

            var faker = new Faker();

            _description = faker.Random.Words(50);
            _title = faker.Random.Words(25);
            _isDone = faker.Random.Bool();
            _isDeleted = faker.Random.Bool();
            _isInProgress = faker.Random.Bool();
            _userId = Guid.NewGuid().ToString();
        }

        [Fact]
        public void MustBeCreateTask()
        {
            var expectedTask = new
            {
                Description = _description,
                IsDeleted = _isDeleted,
                IsDone = _isDone,
                IsInProgress = _isInProgress,
                Title = _title,
                UserId = _userId
            };

            var task = TaskBuilder.New().Build(_title, _description, _userId, _isInProgress, _isDone, _isDeleted);

            expectedTask.ToExpectedObject().ShouldMatch(task);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TaskMustHaveTitle(string title)
        {
            Assert.Throws<ArgumentException>(
                () => TaskBuilder.New().WithTitle(title).Build()
            ).WithMessage("Required field title");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TaskMustHaveUserId(string userId)
        {
            Assert.Throws<ArgumentException>(
                () => TaskBuilder.New().WithUserId(userId).Build()
            ).WithMessage("Required field userId");
        }

        public void Dispose()
        {
            _testOutputHelper.WriteLine("TaskUnitTest dispose is running...");
        }
    }
}
