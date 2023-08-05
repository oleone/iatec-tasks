using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Repository;
using IATecTasks.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class ListTaskUseCase : IListTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public ListTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<ListTaskDto>> Execute(string id)
        {
            try
            {
                var tasks = await _taskRepository.GetAllTasksByUserIdAsync(id);
                var list = new List<ListTaskDto>();

                foreach (var task in tasks)
                {
                    list.Add(new ListTaskDto()
                    {
                        CreatedDate = task.CreatedDate,
                        Description = task.Description,
                        Id = task.Id,
                        IsDeleted = task.IsDeleted,
                        IsDone = task.IsDone,
                        IsInProgress = task.IsInProgress,
                        Title = task.Title,
                        UpdatedDate = task.UpdatedDate,
                        UserId = task.UserId,
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
