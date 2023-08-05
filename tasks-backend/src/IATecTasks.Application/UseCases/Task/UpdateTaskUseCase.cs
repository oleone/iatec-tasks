using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Domain;
using IATecTasks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class UpdateTaskUseCase : IUpdateTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRepository _repository;

        public UpdateTaskUseCase(IRepository repository, ITaskRepository taskRepository)
        {
            _repository = repository;
            _taskRepository = taskRepository;
        }

        public async Task<bool> Execute(UpdateTaskDto dto)
        {
            try
            {
                var task = new ETask(dto.Id, dto.Title, dto.Description, dto.UserId, dto.IsInProgress, dto.IsDone, dto.IsDeleted);

                _repository.Update(task);

                if (await _repository.SaveChangesAsync())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
