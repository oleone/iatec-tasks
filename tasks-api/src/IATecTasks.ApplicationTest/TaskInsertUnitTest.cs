using Bogus;
using IATecTasks.Domain.Tasks;
using IATecTasks.Repository;
using Moq;
using System;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class InsertTaskUseCaseUnitTest
    {
        private TaskDto _taskDto;
        private InsertTaskUseCase _insertTaskUseCase;
        private Mock<ITaskRepository> _taskRepositoryMock;

        public InsertTaskUseCaseUnitTest()
        {
            var faker = new Faker();
            _taskDto = new TaskDto
            {
                Title = faker.Random.Words(20),
                Description = faker.Random.Words(50),
                UserId = Guid.NewGuid().ToString(),
            };

            _taskRepositoryMock = new Mock<ITaskRepository>();
            _insertTaskUseCase = new InsertTaskUseCase(_taskRepositoryMock.Object);
        }

        [Fact]
        public void MustInsertTask()
        {
            _insertTaskUseCase.Execute(_taskDto);

            _taskRepositoryMock.Verify(r => r.Insert(
                It.Is<Task>(
                    t => t.Title == _taskDto.Title &&
                    t.Description == _taskDto.Description &&
                    t.UserId == _taskDto.UserId
                )
            ));
        }
    }

    public class InsertTaskUseCase
    {
        private ITaskRepository _taskRepository;

        public InsertTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(TaskDto dto)
        {
            var task = new Task(dto.Title, dto.Description, dto.UserId);
            _taskRepository.Insert(task);
        }
    }

    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
