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
    public class UpdateTaskUseCaseUnitTest
    {
        private ETaskUpdateDto _updateTaskDto;
        private UpdateTaskUseCase _updateTaskUseCase;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<IRepository> _repository;

        public UpdateTaskUseCaseUnitTest()
        {
            var faker = new Faker();

            _updateTaskDto = new ETaskUpdateDto
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

            _updateTaskUseCase = new UpdateTaskUseCase(_repository.Object, _taskRepository.Object);
        }

        [Fact]
        public async void MustUpdateTask()
        {
            await _updateTaskUseCase.Execute(_updateTaskDto);

            _repository.Verify(r => r.Update(
                It.Is<ETaskUpdateDto>(
                    t => t.Title == _updateTaskDto.Title &&
                    t.Description == _updateTaskDto.Description &&
                    t.UserId == _updateTaskDto.UserId &&
                    t.Id == _updateTaskDto.Id
                )
            ));
        }
    }
}
