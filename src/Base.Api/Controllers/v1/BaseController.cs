using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Base.Application.Interface;
using Util.Notification.Models;
using System;
using System.Threading.Tasks;

namespace Base.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ApiController
    {
        private readonly IBaseAppService _baseAppService;

        public BaseController(INotificationHandler<MyNotification> notifications, IBaseAppService baseAppService)
            : base(notifications)
        {
            _baseAppService = baseAppService;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Policy = "read")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest("Id is required.");

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.StackTrace, title: ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Policy = "write")]
        public async Task<IActionResult> Post([FromBody] string cpf)
        {
            try
            {
                if (string.IsNullOrEmpty(cpf))
                    return BadRequest("CPF is required.");

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.StackTrace, title: ex.Message);
            }
        }
    }
}
