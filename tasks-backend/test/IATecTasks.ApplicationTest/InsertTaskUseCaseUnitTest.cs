using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.UseCases;
using IATecTasks.Domain;
using IATecTasks.Repository;
using IATecTasks.Repository.Repositories;
using Moq;
using System;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class InsertTaskUseCaseUnitTest
    {
        private CreateTaskDto _createTaskDto;
        private InsertTaskUseCase _insertTaskUseCase;

        private Mock<IRepository> _repositoryMock;
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

            _repositoryMock = new Mock<IRepository>();
            _taskRepositoryMock = new Mock<ITaskRepository>();

            _insertTaskUseCase = new InsertTaskUseCase(_repositoryMock.Object);
        }

        [Fact]
        public async void MustInsertTask()
        {
            await _insertTaskUseCase.Execute(_createTaskDto);

            _repositoryMock.Verify(r => r.Add(
                It.Is<ETask>(
                    t => t.Title == _createTaskDto.Title &&
                    t.Description == _createTaskDto.Description &&
                    t.UserId == _createTaskDto.UserId
                )
            ));
        }
    }
}
