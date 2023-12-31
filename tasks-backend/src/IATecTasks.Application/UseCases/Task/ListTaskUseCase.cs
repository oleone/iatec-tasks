﻿using AutoMapper;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces.ETask;
using IATecTasks.Repository;
using IATecTasks.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IATecTasks.Application.UseCases
{
    public class ListTaskUseCase : IListTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public ListTaskUseCase(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<ETaskListDto>> Execute(string id)
        {
            try
            {
                var tasks = await _taskRepository.GetAllTasksByUserIdAsync(id);
                var list = _mapper.Map<List<ETaskListDto>>(tasks);

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
