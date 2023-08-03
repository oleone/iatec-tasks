using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.UseCases;
using IATecTasks.Domain.Tasks;
using IATecTasks.Repository;
using Moq;
using System;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class InsertTaskUseCaseUnitTest
    {
        private CreateTaskDto _createTaskDto;
        private IUseCase<CreateTaskDto> _insertTaskUseCase;
        private Mock<ITaskRepository> _taskRepositoryMock;

        public InsertTaskUseCaseUnitTest()
        {
            var faker = new Faker();
            _createTaskDto = new CreateTaskDto
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
            _insertTaskUseCase.Execute(_createTaskDto);

            _taskRepositoryMock.Verify(r => r.Insert(
                It.Is<Task>(
                    t => t.Title == _createTaskDto.Title &&
                    t.Description == _createTaskDto.Description &&
                    t.UserId == _createTaskDto.UserId
                )
            ));
        }
    }
}
