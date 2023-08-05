using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Domain;
using IATecTasks.Repository;
using IATecTasks.Repository.Repositories;
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
                _repository.Update(dto);

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
