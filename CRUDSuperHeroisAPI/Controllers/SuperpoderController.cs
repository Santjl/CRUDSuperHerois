using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSuperHeroisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperpoderController : ApiController
    {
        private readonly ISuperpoderesRepository _superpoderesRepository;
        private readonly IUnitOfWork _uow;

        public SuperpoderController(ISuperpoderesRepository superpoderesRepository,
            NotificationService notificationService,
            IUnitOfWork uow) : base(notificationService)
        {
            _superpoderesRepository = superpoderesRepository;
            _uow = uow;
        }
        
    }
}
