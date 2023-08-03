using IATecTasks.Application.Dtos;
using IATecTasks.Domain.Tasks;
using IATecTasks.Repository;

namespace IATecTasks.Application.UseCases
{
    public class InsertTaskUseCase: IUseCase<CreateTaskDto>
    {
        private IRepository<CreateTaskDto> _taskRepository;

        public InsertTaskUseCase(IRepository<CreateTaskDto> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(CreateTaskDto dto)
        {
            _taskRepository.Add(dto);
        }
    }
}
