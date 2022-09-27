using MediatR;
using Microsoft.AspNetCore.Mvc;
using Util.Notification.Handlers;
using Util.Notification.Models;
using System;
using System.Collections.Immutable;
using System.Net;

namespace Base
{
    public class ApiController : ControllerBase
    {
        private readonly NotifiyHandler _notifyHandler;

        public ApiController(INotificationHandler<MyNotification> notifications)
        {
            _notifyHandler = (NotifiyHandler)notifications;
        }

        protected bool HasNotification => _notifyHandler.HasNotifications();

        [NonAction]
        protected IActionResult Execute(Func<IActionResult> success)
        {
            try
            {
                if (HasNotification)
                {
                    var notifications = _notifyHandler
                        .GetNotifications()
                        .ToImmutableList();

                    var response = new ApiResponse(HttpStatusCode.BadRequest, notifications);
                    return BadRequest(response);
                }

                if (!(success is null))
                    return success
                        .Invoke();

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.StackTrace, title: ex.Message);
            }
        }
    }
}
