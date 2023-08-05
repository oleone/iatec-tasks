using IATecTasks.Application.Dtos;
using IATecTasks.Domain;
using IATecTasks.Repository.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class InsertTaskUseCase: IUseCase<CreateTaskDto>
    {
        private ITaskRepository _taskRepository;

        public InsertTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(CreateTaskDto dto)
        {
            var task = new ETask(dto.Title, dto.Description, dto.UserId);
            _taskRepository.Add(task);
        }

        public Task<List<ListTaskDto>> Execute(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
