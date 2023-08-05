using IATecTasks.Application.Dtos;
using IATecTasks.Domain;
using IATecTasks.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class UpdateTaskUseCase : IUseCase<UpdateTaskDto>
    {
        private ITaskRepository _taskRepository;
        public UpdateTaskUseCase(ITaskRepository repository)
        {
            _taskRepository = repository;

        }

        public void Execute(UpdateTaskDto dto)
        {
            _taskRepository.Update(dto);
        }

        public Task<List<ListTaskDto>> Execute(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
