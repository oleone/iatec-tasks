using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository;
using IATecTasks.Repository.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class UpdateTaskUseCaseUnitTest
    {
        private UpdateTaskDto _updateTaskDto;
        private UpdateTaskUseCase _updateTaskUseCase;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<IRepository> _repository;

        public UpdateTaskUseCaseUnitTest()
        {
            var faker = new Faker();

            _updateTaskDto = new UpdateTaskDto
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
        public void MustUpdateTask()
        {
            _updateTaskUseCase.Execute(_updateTaskDto);

            _repository.Verify(r => r.Update(
                It.Is<UpdateTaskDto>(
                    t => t.Title == _updateTaskDto.Title &&
                    t.Description == _updateTaskDto.Description &&
                    t.UserId == _updateTaskDto.UserId &&
                    t.Id == _updateTaskDto.Id
                )
            ));
        }

        // TODO: CRIAR MAIS TESTES PARA ATUALIZAÇÃO DE TASK
    }
}
