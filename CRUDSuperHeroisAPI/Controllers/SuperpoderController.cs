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
        

        [HttpGet]
        [Route(nameof(SuperpoderController.BuscarSuperpoderes))]
        public async Task<dynamic> BuscarSuperpoderes()
        {
            try
            {
                var superpoderes = _superpoderesRepository.BuscarSuperpoderes();
                if (superpoderes != null)
                {
                    return ResponseGet(superpoderes);
                }
                else throw new Exception();
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível buscar os superpoderes: " + e.Message);
                return ResponseGet();
            }
        }

        [HttpGet]
        [Route(nameof(SuperpoderController.BuscarSuperpoderPorId))]
        public async Task<dynamic> BuscarSuperpoderPorId(int superpoderId)
        {
            try
            {
                var superpoderes = _superpoderesRepository.BuscarSuperpoder(superpoderId);
                if (superpoderes != null)
                {
                    return ResponseGet(superpoderes);
                }
                else throw new Exception();

            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível buscar os superpoderes: " + e.Message);
                return ResponseGet();
            }
        }

        [HttpDelete]
        [RouteAttribute(nameof(SuperpoderController.DeletarSuperpoder))]
        public async Task<dynamic> DeletarSuperpoder(int superpoderId)
        {
            try
            {
                var superpoder = _superpoderesRepository.BuscarSuperpoder(superpoderId);
                
                if(superpoder != null)
                {
                    _uow.CriarTransacao();
                    _superpoderesRepository.DeletarSuperpoder(superpoderId);
                    _uow.CommitComTransacao();
                    return ResponseDelete();
                }
                else throw new Exception();
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível deletar os superpoder: " + e.Message);
                return ResponseDelete();
            }
        }

        [HttpPost]
        [RouteAttribute(nameof(SuperpoderController.AdicionarSuperpoder))]
        public async Task<dynamic> AdicionarSuperpoder(AdicionarSuperpoder superpoder)
        {
            try
            {
                if (superpoder.Superpoder != "" && superpoder.Descricao != "")
                {
                    _superpoderesRepository.AdicionarSuperpoder(superpoder.Superpoder, superpoder.Descricao);
                    return ResponsePost("");
                }
                else throw new Exception();

            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao(
                    "Não foi possível regristrar o novo superpoder: " + e.Message);
                return ResponsePost("");
            }
        }

    }
}
