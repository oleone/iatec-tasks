using IATecTasks.API.Extensions;
using IATecTasks.Application.Dtos;
using IATecTasks.Application.Interfaces.ETask;
using IATecTasks.Application.UseCases;
using IATecTasks.Repository.Repositories;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/tasks")]
    [Produces("application/json")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IInsertTaskUseCase _insertTaskUseCase;
        private readonly IUpdateTaskUseCase _updateTaskUseCase;
        private readonly IListTaskUseCase _listTaskUseCase;
        private readonly IDeleteTaskUseCase _deleteTaskUseCase;
        private readonly IGetTaskByIdUseCase _getTaskByIdUseCase;

        public TaskController(
            IInsertTaskUseCase insertTaskUseCase,
            IUpdateTaskUseCase updateTaskUseCase,
            IListTaskUseCase listTaskUseCase,
            IDeleteTaskUseCase deleteTaskUseCase,
            IGetTaskByIdUseCase getTaskByIdUseCase)
        {
            _insertTaskUseCase = insertTaskUseCase;
            _updateTaskUseCase = updateTaskUseCase;
            _listTaskUseCase = listTaskUseCase;
            _deleteTaskUseCase = deleteTaskUseCase;
            _getTaskByIdUseCase = getTaskByIdUseCase;
        }

        /// <summary>
        /// Get all tasks by logged user
        /// </summary>
        /// <returns>A list of tasks by logged user</returns>
        /// <response code="200">Returns the tasks list</response>
        // GET: api/tasks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var userId = User.GetUserId();
                var tasks = await _listTaskUseCase.Execute(userId);

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Get task by id
        /// </summary>
        /// <param name="id" required="true">Task id</param>
        /// <returns></returns>
        // GET: api/tasks/1
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var userId = User.GetUserId();
                var task = await _getTaskByIdUseCase.Execute(id);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Create Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post /tasks
        ///     {
        ///         "title": "This is the title of task",
        ///         "description": "This is the description of task"
        ///     }
        ///     
        /// </remarks>
        // POST api/tasks
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ETaskCreateDto task)
        {
            try
            {
                var userId = User.GetUserId();
                var inserted = await _insertTaskUseCase.Execute(task, userId);

                return Ok(inserted);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="id"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        // PUT api/tasks/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(string id, [FromBody] ETaskUpdateDto task)
        {
            try
            {
                if (string.IsNullOrEmpty(task.Id))
                {
                    task.Id = id;
                }
                var userId = User.GetUserId();
                var updated = await _updateTaskUseCase.Execute(task, userId);

                return Created("", updated);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Delete task
        /// </summary>
        /// <param name="id">Task id</param>
        /// <returns></returns>
        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
