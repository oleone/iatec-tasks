using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IATecTasks.API.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IInsertTaskUseCase _insertTaskUseCase;
        private readonly IUpdateTaskUseCase _updateTaskUseCase;
        private readonly IListTaskUseCase _listTaskUseCase;
        private readonly IDeleteTaskUseCase _deleteTaskUseCase;

        public TaskController(
            IInsertTaskUseCase insertTaskUseCase,
            IUpdateTaskUseCase updateTaskUseCase,
            IListTaskUseCase listTaskUseCase,
            IDeleteTaskUseCase deleteTaskUseCase)
        {
            _insertTaskUseCase = insertTaskUseCase;
            _updateTaskUseCase = updateTaskUseCase;
            _listTaskUseCase = listTaskUseCase;
            _deleteTaskUseCase = deleteTaskUseCase;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _listTaskUseCase.Execute("a89605f7-5e7e-4f7a-9ed6-92fee5b0aed9");

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/tasks
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskDto task)
        {
            try
            {
                var inserted = await _insertTaskUseCase.Execute(task);

                return Ok(inserted);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateTaskDto task)
        {
            try
            {
                if (string.IsNullOrEmpty(task.Id))
                {
                    task.Id = id;
                }

                var updated = await _updateTaskUseCase.Execute(task);

                return Created("", updated);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var deleted = await _deleteTaskUseCase.Execute(id);

                    return Ok(deleted);
                }
                else
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
