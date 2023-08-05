using IATecTasks.Application.Dtos;
using IATecTasks.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class ListTaskUseCase : IUseCase<ListTaskDto>
    {
        private readonly ITaskRepository _repository;

        public ListTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public void Execute(ListTaskDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ListTaskDto>> Execute(string id)
        {
            var list = new List<ListTaskDto>();

            var tasks = await _repository.GetAllTasksByUserIdAsync(id);

            foreach (var task in tasks)
            {
                list.Add(new ListTaskDto
                {
                    Id = task.Id,
                    CreatedDate = task.CreatedDate,
                    Description = task.Description,
                    IsDeleted = task.IsDeleted,
                    IsDone = task.IsDone,
                    IsInProgress = task.IsInProgress,
                    Title = task.Title,
                    UpdatedDate = task.UpdatedDate,
                    UserId = task.UserId,
                });
            }

            return await Task.FromResult(list);
        }
    }
}
