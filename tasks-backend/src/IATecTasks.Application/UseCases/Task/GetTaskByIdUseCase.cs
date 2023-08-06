using AutoMapper;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces.ETask;
using IATecTasks.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases.Task
{
    public class GetTaskByIdUseCase : IGetTaskByIdUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskByIdUseCase(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<ETaskListDto> Execute(string id)
        {
            try
            {
                var task = await _taskRepository.GetETaskById(id);
                var result = _mapper.Map<ETaskListDto>(task);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar etask por id. Erro: {ex.Message}");
            }
        }
    }
}
