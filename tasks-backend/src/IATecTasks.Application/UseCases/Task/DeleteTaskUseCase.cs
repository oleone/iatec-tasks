using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
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

        public DeleteTaskUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(UpdateTaskDto dto)
        {
            try
            {
                var entity = new ETask(dto.Id, dto.Title, dto.Description, dto.UserId, dto.IsInProgress, dto.IsDone, dto.IsDeleted);

                _repository.Delete(entity);

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
