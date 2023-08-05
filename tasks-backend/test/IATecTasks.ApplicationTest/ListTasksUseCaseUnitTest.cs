using IATecTasks.Application.Dtos;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IATecTasks.ApplicationTest
{
    public class ListTasksUseCaseUnitTest
    {
        private readonly Mock<ITaskRepository> _mockTasksRepository;
        private readonly ListTaskUseCase _useCase;

        private readonly List<ListTaskDto> _listTasks;

        public ListTasksUseCaseUnitTest()
        {
            _mockTasksRepository = new Mock<ITaskRepository>();
            _useCase = new ListTaskUseCase(_mockTasksRepository.Object);
        }

        [Fact]
        public async void MustListTasks()
        {
            var tasks = await _useCase.Execute(Guid.NewGuid().ToString());
        }
    }
}
