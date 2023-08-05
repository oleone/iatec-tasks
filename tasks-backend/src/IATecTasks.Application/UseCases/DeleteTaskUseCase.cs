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
    public class DeleteTaskUseCase : IDeleteTaskUseCase
    {
        private readonly IRepository _repository;

        public DeleteTaskUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(string id)
        {
            try
            {
                _repository.Delete(id);

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
