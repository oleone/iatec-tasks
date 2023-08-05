using Bogus;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Application.UseCases;
using IATecTasks.Domain;
using IATecTasks.Repository;
using IATecTasks.Repository.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class ListTasksUseCaseUnitTest
    {
        private readonly Mock<ITaskRepository> _mockTasksRepository;
        private readonly ListTaskUseCase _listTaskUseCase;

        private readonly List<ListTaskDto> _listTasks;

        private readonly Guid _userId;

        public ListTasksUseCaseUnitTest()
        {
            _mockTasksRepository = new Mock<ITaskRepository>();
            _listTaskUseCase = new ListTaskUseCase(_mockTasksRepository.Object);

            _listTasks = new List<ListTaskDto>();

            var faker = new Faker();

            _userId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var task = new ListTaskDto()
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = faker.Random.Words(),
                    Id = Guid.NewGuid().ToString(),
                    IsDeleted = faker.Random.Bool(),
                    IsDone = faker.Random.Bool(),
                    IsInProgress = faker.Random.Bool(),
                    Title = faker.Random.Words(),
                    UpdatedDate = DateTime.UtcNow,
                    UserId = _userId.ToString(),
                };

                _listTasks.Add(task);
            }

            for (int i = 0; i < 10; i++)
            {
                var task = new ListTaskDto()
                {
                    CreatedDate = DateTime.UtcNow,
                    Description = faker.Random.Words(),
                    Id = Guid.NewGuid().ToString(),
                    IsDeleted = faker.Random.Bool(),
                    IsDone = faker.Random.Bool(),
                    IsInProgress = faker.Random.Bool(),
                    Title = faker.Random.Words(),
                    UpdatedDate = DateTime.UtcNow,
                    UserId = Guid.NewGuid().ToString(),
                };

                _listTasks.Add(task);
            }
        }

        [Theory]
        [InlineData("0b4d96c1-f99f-46e4-8a4a-0781adea050c")]
        [InlineData("953f6d92-99b2-4d64-b7b0-0672ec626a18")]
        [InlineData("ef9995b3-0a72-4c35-a595-904a55d44070")]
        public async void MustNotListTasksFromOtherUsers(string userId)
        {
            var taskList = await _listTaskUseCase.Execute(userId);

            var wherer = taskList.Where(t => t.UserId == userId);
            
            _mockTasksRepository.Verify(r => r.GetAllTasksByUserIdAsync(
                It.Is<string>(
                    t => t != _userId.ToString()
                )
            ));

        }
    }
}
