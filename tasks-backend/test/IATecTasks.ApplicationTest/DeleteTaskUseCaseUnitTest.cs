using AutoMapper;
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
        private ETaskUpdateDto _taskDto;
        private DeleteTaskUseCase _deleteTaskUseCase;
        private Mock<ITaskRepository> _taskRepository;
        private Mock<IRepository> _repository;
        private Mock<IMapper> _mapper;

        public DeleteTaskUseCaseUnitTest()
        {
            var faker = new Faker();

            _taskDto = new ETaskUpdateDto
            {
                Id = Guid.NewGuid().ToString(),
                Description = faker.Random.Words(50),
                IsDeleted = faker.Random.Bool(),
                IsDone = faker.Random.Bool(),
                IsInProgress = faker.Random.Bool(),
                Title = faker.Random.Words(20),
            };

            _taskRepository = new Mock<ITaskRepository>();
            _repository = new Mock<IRepository>();
            _mapper = new Mock<IMapper>();

            _deleteTaskUseCase = new DeleteTaskUseCase(_repository.Object, _taskRepository.Object, _mapper.Object);
        }

        [Fact]
        public async void MustDeleteTask()
        {
            await _deleteTaskUseCase.Execute(_taskDto.Id);

            _repository.Verify(r => r.Delete(
                It.Is<ETaskUpdateDto>(
                    t => t.Title == _taskDto.Title &&
                    t.Description == _taskDto.Description &&
                    t.Id == _taskDto.Id
                )
            ));
        }
    }
}
