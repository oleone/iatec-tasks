﻿using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Domain;
using IATecTasks.Repository;
using IATecTasks.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class InsertTaskUseCase : IInsertTaskUseCase
    {
        private readonly IRepository _repository;

        public InsertTaskUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(CreateTaskDto dto)
        {
            try
            {
                var task = new ETask(dto.Title, dto.Description, dto.UserId);

                _repository.Add<ETask>(task);

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
