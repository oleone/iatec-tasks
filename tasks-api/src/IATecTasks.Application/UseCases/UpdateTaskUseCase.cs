using IATecTasks.Application.Dtos;
using IATecTasks.Domain.Tasks;
using IATecTasks.Repository;

namespace IATecTasks.Application.UseCases
{
    public class UpdateTaskUseCase : IUseCase<UpdateTaskDto>
    {
        private IRepository<UpdateTaskDto> _taskRepository;
        public UpdateTaskUseCase(IRepository<UpdateTaskDto> repository)
        {
            _taskRepository = repository;

        }

        public void Execute(string id, UpdateTaskDto dto)
        {
            _taskRepository.Update(id, dto);
        }
    }
}
