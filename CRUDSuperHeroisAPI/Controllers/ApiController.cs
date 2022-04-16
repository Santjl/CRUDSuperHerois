using CRUDSuperHeroisAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUDSuperHeroisAPI.Controllers
{
    public class ApiController : ControllerBase
    {
        protected readonly NotificationService _notificationService;
        public ApiController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        protected IActionResult ResponseGet(object result = null)
        {
            if (!_notificationService.DomainNotifications.Any())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return NotFound(new
            {
                success = false,
                errors = _notificationService.DomainNotifications.Select(x => x.ErrorMessage)
            });
        }

        protected IActionResult ResponsePost(string uri, object result = null)
        {
            if (!_notificationService.DomainNotifications.Any())
            {
                return Created(uri, new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificationService.DomainNotifications.Select(x => x.ErrorMessage)
            });
        }

        protected IActionResult ResponseDelete(object result = null)
        {
            if (!_notificationService.DomainNotifications.Any())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return NotFound(new
            {
                success = false,
                errors = _notificationService.DomainNotifications.Select(x => x.ErrorMessage)
            });
        }

        protected IActionResult ResponsePut(object result = null)
        {
            if (!_notificationService.DomainNotifications.Any())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return NotFound(new
            {
                success = false,
                errors = _notificationService.DomainNotifications.Select(x => x.ErrorMessage)
            });
        }

    }
}
