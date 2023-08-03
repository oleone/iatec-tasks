using IATecTasks.Application.Dtos;
using IATecTasks.Domain.Tasks;
using IATecTasks.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace IATecTasks.Application.UseCases
{
    public class InsertTaskUseCase: IUseCase<CreateTaskDto>
    {
        private IRepository<Task> _taskRepository;

        public InsertTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(CreateTaskDto dto)
        {
            var task = new Task(dto.Title, dto.Description, dto.UserId);
            _taskRepository.Insert(task);
        }
    }
}
