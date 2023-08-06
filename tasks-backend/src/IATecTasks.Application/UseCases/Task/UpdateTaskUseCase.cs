using AutoMapper;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces.ETask;
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
        private readonly IMapper _mapper;
        private readonly IGetTaskByIdUseCase _getTaskByIdUseCase;

        public UpdateTaskUseCase(IRepository repository, ITaskRepository taskRepository, IGetTaskByIdUseCase getTaskByIdUseCase, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _taskRepository = taskRepository;
            _getTaskByIdUseCase = getTaskByIdUseCase;
        }

        public async Task<bool> Execute(ETaskUpdateDto dto, string userId)
        {
            try
            {
                var task = new ETask(dto.Id, dto.Title, dto.Description, userId, dto.IsInProgress, dto.IsDone, dto.IsDeleted, dto.CreatedDate);

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
