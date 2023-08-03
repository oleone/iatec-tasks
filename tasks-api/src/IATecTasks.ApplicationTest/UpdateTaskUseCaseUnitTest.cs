﻿using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository;
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
        private IUseCase<UpdateTaskDto> _updateTaskUseCase;
        private Mock<IRepository<UpdateTaskDto>> _taskRepository;

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

            _taskRepository = new Mock<IRepository<UpdateTaskDto>>();
            _updateTaskUseCase = new UpdateTaskUseCase(_taskRepository.Object);
        }

        [Fact]
        public void MustUpdateTask()
        {
            _updateTaskUseCase.Execute(_updateTaskDto.Id, _updateTaskDto);

            _taskRepository.Verify(r => r.Update(_updateTaskDto.Id,
                It.Is<UpdateTaskDto>(
                    t => t.Title == _updateTaskDto.Title &&
                    t.Description == _updateTaskDto.Description &&
                    t.UserId == _updateTaskDto.UserId &&
                    t.Id == _updateTaskDto.Id
                )
            ));
        }
    }
}
