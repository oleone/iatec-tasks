﻿using IATecTasks.Application.Dtos;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository.Context;
using IATecTasks.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IATecTasks.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly InsertTaskUseCase _insertTaskUseCase;
        private readonly UpdateTaskUseCase _updateTaskUseCase;
        private readonly ITaskRepository _taskRepository;

        public readonly IATecTasksContext _context;

        public TaskController(IATecTasksContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tasks
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
