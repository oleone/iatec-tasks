using AutoMapper;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces.ETask;
using IATecTasks.Domain;
using IATecTasks.Repository.Interfaces;
using IATecTasks.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class DeleteTaskUseCase : IDeleteTaskUseCase
    {
        private readonly IRepository _repository;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public DeleteTaskUseCase(IRepository repository, ITaskRepository taskRepository, IMapper mapper)
        {
            _repository = repository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<bool> Execute(string id)
        {
            try
            {
                var task = await _taskRepository.GetETaskById(id);

                if (task == null) return false;

                _repository.Delete(task);

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
