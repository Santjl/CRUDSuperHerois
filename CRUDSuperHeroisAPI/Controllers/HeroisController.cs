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
    public class HeroisController : ApiController
    {
        private readonly IHeroisRepository _heroisRepository;
        private readonly IUnitOfWork _uow;
        public HeroisController(IHeroisRepository heroisRepository, 
            NotificationService notificationService,
            IUnitOfWork unitOfWork) 
            : base (notificationService)
        {
            _heroisRepository = heroisRepository;
            _uow = unitOfWork;
        }

        [HttpGet]
        [Route(nameof(HeroisController.BuscarHerois))]
        public async Task<dynamic> BuscarHerois()
        {
            try
            {
                var herois = _heroisRepository.BuscarHerois();
                if (herois != null) return herois;
                throw new Exception();
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao("Nenhum herói cadastrado:" + e.Message);
                return ResponseGet();
            }
        }
        
        [HttpGet]
        [Route(nameof(HeroisController.BuscarHeroiPorId))]
        public async Task<dynamic> BuscarHeroiPorId(int heroiId)
        {
            try
            {
                var heroi = _heroisRepository.BuscarHeroiPorId(heroiId);
                if (heroi != null) return ResponseGet(heroi);
                throw new Exception();
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível encontrar o herói:" + e.Message);
                return ResponseGet();
            }
        }

        [HttpPost]
        [Route(nameof(HeroisController.CadastrarHeroi))]
        public async Task<dynamic> CadastrarHeroi([FromBody] AdicionarHerois inputHerois)
        {
            try
            {
                _uow.CriarTransacao();
                var adicionaHeroi = _heroisRepository.AdicionarHeroi(
                    inputHerois.Nome,
                    inputHerois.NomeHeroi,
                    inputHerois.DataNascimento,
                    inputHerois.Altura,
                    inputHerois.Peso
                    );
                if(adicionaHeroi == null) _uow.RollbackTransacao();
                else _uow.CommitComTransacao();

                 return ResponsePost("BuscarHeroiPorId", adicionaHeroi);
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível cadastrar o herói:" + e.Message);
                return ResponsePost("");
            }
        }

        [HttpDelete]
        [Route(nameof(HeroisController.DeletarHeroi))]
        public async Task<dynamic> DeletarHeroi(int heroiId)
        {
            try
            {
                _uow.CriarTransacao();
                _heroisRepository.DeletarHeroi(heroiId);
                _uow.CommitComTransacao();
                return ResponseDelete();
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível excluir o herói:" + e.Message);
                return ResponseDelete();
            }
        }

        [HttpPut]
        [Route(nameof(HeroisController.AtualizarHeroi))]
        public async Task<dynamic> AtualizarHeroi([FromBody] AtualizarHerois atualizarHeroi)
        {
            try
            {
                var heroi = _heroisRepository.AtualizarHeroi(atualizarHeroi.HeroiId,

                    atualizarHeroi.Nome,
                    atualizarHeroi.DataNascimento,
                    atualizarHeroi.NomeHeroi,
                    (double)atualizarHeroi.Altura,
                    (double)atualizarHeroi.Peso
                    ) ;
                if(heroi != null)
                {
                    return ResponsePut(heroi);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível atualizar o herói:" + e.Message);
                return ResponsePut();
            }
        }


    }
}
