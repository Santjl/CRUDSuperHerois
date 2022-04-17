using CRUDSuperHeroisAPI.Domain.InputModels;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRUDSuperHeroisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisSuperpoderesController : ApiController
    {
        private readonly IHeroisSuperpoderesRepository _heroisSuperpoderesRepository;
        private readonly IHeroisRepository _heroisRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HeroisSuperpoderesController(IHeroisSuperpoderesRepository heroisSuperpoderesRepository,
            NotificationService notificationService,
            IHeroisRepository heroisRepository,
            IUnitOfWork unitOfWork) : base(notificationService)
        {
            _heroisSuperpoderesRepository = heroisSuperpoderesRepository;
            _unitOfWork = unitOfWork;
            _heroisRepository = heroisRepository;
        }

        [HttpGet]
        [Route(nameof(HeroisSuperpoderesController.BuscarHeroiSuperpoderes))]
        public async Task<dynamic> BuscarHeroiSuperpoderes(int heroiId)
        {
            try
            {
                var heroisSuperpoderes = _heroisSuperpoderesRepository
                    .BuscarHeroiSuperpoder(heroiId);
                if(heroisSuperpoderes != null) return ResponseGet(heroisSuperpoderes);
                throw new Exception();
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível obter os superpoderes deste herói:" 
                    + e.Message);
                return ResponseGet();
            }
        }

        [HttpPost]
        [Route(nameof(HeroisSuperpoderesController.AssociarHeroiSuperpoderes))]
        public async Task<dynamic> AssociarHeroiSuperpoderes([FromBody] AssociarHeroiSuperpoderes heroiSuperpoderes)
        {
            try
            {
                var heroi = _heroisRepository.BuscarHeroiPorId(heroiSuperpoderes.HeroiId);
                if(heroi != null && heroiSuperpoderes.SuperpoderesId.Count != 0)
                {
                    var heroiId = heroiSuperpoderes.HeroiId;
                    foreach(var superpoder in heroiSuperpoderes.SuperpoderesId)
                    {
                        _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(heroiId, superpoder);
                    }

                    return ResponsePost("");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível associar os superpoderes a este herói:"
                    + e.Message);
                return ResponseGet();
            }
        }

        [HttpDelete]
        [Route(nameof(HeroisSuperpoderesController.DesassociarHeroiSuperpoder))]
        public async Task<dynamic> DesassociarHeroiSuperpoder(int heroiId, int superpoderesId)
        {
            try
            {
                _heroisSuperpoderesRepository.DesassociarHeroiSuperpoder(heroiId, superpoderesId);
                return ResponseDelete();
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível desassociar o herói ao superpoder: " + e.Message);
                return ResponseDelete();
            }
        }
    }
}
