using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class DeleteTaskUseCaseUnitTest
    {
        private UpdateTaskDto _taskDto;
        private DeleteTaskUseCase _deleteTaskUseCase;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<IRepository> _repository;

        public DeleteTaskUseCaseUnitTest()
        {
            var faker = new Faker();

            _taskDto = new UpdateTaskDto
            {
                Id = Guid.NewGuid().ToString(),
                Description = faker.Random.Words(50),
                IsDeleted = faker.Random.Bool(),
                IsDone = faker.Random.Bool(),
                IsInProgress = faker.Random.Bool(),
                Title = faker.Random.Words(20),
                UserId = Guid.NewGuid().ToString(),
            };

            _taskRepository = new Mock<ITaskRepository>();
            _repository = new Mock<IRepository>();

            _deleteTaskUseCase = new DeleteTaskUseCase(_repository.Object);
        }

        [Fact]
        public async void MustDeleteTask()
        {
            await _deleteTaskUseCase.Execute(_taskDto);

            _repository.Verify(r => r.Delete(
                It.Is<UpdateTaskDto>(
                    t => t.Title == _taskDto.Title &&
                    t.Description == _taskDto.Description &&
                    t.UserId == _taskDto.UserId &&
                    t.Id == _taskDto.Id
                )
            ));
        }
    }
}
