using CRUDSuperHeroisAPI.Domain.InputModels;
using CRUDSuperHeroisAPI.Domain.Interfaces;
using CRUDSuperHeroisAPI.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDSuperHeroisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroisSuperpoderesController : ApiController
    {
        private readonly IHeroisSuperpoderesRepository _heroisSuperpoderesRepository;
        private readonly IHeroisRepository _heroisRepository;
        private readonly ISuperpoderesRepository _superpoderesRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HeroisSuperpoderesController(IHeroisSuperpoderesRepository heroisSuperpoderesRepository,
            NotificationService notificationService,
            IHeroisRepository heroisRepository,
            ISuperpoderesRepository superpoderesRepository,
            IUnitOfWork unitOfWork) : base(notificationService)
        {
            _heroisSuperpoderesRepository = heroisSuperpoderesRepository;
            _unitOfWork = unitOfWork;
            _heroisRepository = heroisRepository;
            _superpoderesRepository = superpoderesRepository;
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

        [HttpPost]
        [Route(nameof(HeroisSuperpoderesController.AdicionarHeroiSuperpoderes))]
        public async Task<dynamic> AdicionarHeroiSuperpoderes([FromBody] AdicionarHeroiSuperpoderes heroi)
        {
            try
            {
                if (heroi == null) throw new Exception();
                var heroiNome = _heroisRepository.BuscarHeroiPorNome(heroi.Nome);
                var heroiNomeHeroi = _heroisRepository.BuscarHeroiPorNomeHeroi(heroi.NomeHeroi);
                if(heroiNome != null)
                {
                    _notificationService.AdicionarNotificacao("Já existe um herói com esse nome verdadeiro.");
                    return ResponsePost("");
                }
                if (heroiNomeHeroi != null)
                {
                    _notificationService.AdicionarNotificacao("Já existe um herói com esse nome de herói.");
                    return ResponsePost("");
                }
                _unitOfWork.CriarTransacao();
                var adicionarHeroi = _heroisRepository.AdicionarHeroi(heroi.Nome, heroi.NomeHeroi, heroi.DataNascimento, heroi.Altura, heroi.Peso);
                if (adicionarHeroi == null) throw new Exception();
                var superpoderes = heroi.Superpoderes;
                foreach(var superpoder in superpoderes)
                {
                    var superpoderExiste = _superpoderesRepository.BuscarSuperpoderPorNome(superpoder.Superpoder);
                    if(superpoderExiste == null)
                    {
                        var superpoderAdicionado = _superpoderesRepository.AdicionarSuperpoder(superpoder.Superpoder, superpoder.Descricao);
                        if(superpoderAdicionado == null) throw new Exception();
                        _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(adicionarHeroi.Id, superpoderAdicionado.Id);
                    }
                    else
                    {
                        _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(adicionarHeroi.Id, superpoderExiste.Id);
                    }
                }

                _unitOfWork.CommitComTransacao();

                return ResponsePost("");
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível adicionar o herói e seus superpoderes.");
                return ResponsePost("");
            }
        }
        
        [HttpPut]
        [Route(nameof(HeroisSuperpoderesController.AtualizarHeroiSuperpoderes))]
        public async Task<dynamic> AtualizarHeroiSuperpoderes([FromBody] AtualizarHeroiSuperpoderes heroi)
        {
            try
            {
                if (heroi == null) throw new Exception();
                var heroiExiste = _heroisRepository.BuscarHeroiPorId(heroi.Id);
                if (heroiExiste == null)
                {
                    _notificationService.AdicionarNotificacao("Não foi possível encontrar o herói para atualizar.");
                    return ResponsePut();
                }
                var heroiAtualizado = _heroisRepository.AtualizarHeroi(heroi.Id, heroi.Nome, heroi.DataNascimento, heroi.NomeHeroi, heroi.Altura, heroi.Peso);
                if (heroiAtualizado == null) throw new Exception();
                var superpoderesParaAssociar = heroi.Superpoderes;
                var heroiSuperpoderes = _heroisSuperpoderesRepository.BuscarHeroiSuperpoder(heroi.Id);
                if (heroiSuperpoderes != null)
                {
                    var superpoderesAssociados = heroiSuperpoderes.Superpoderes;
                    if (heroiSuperpoderes == null) throw new Exception();
                    _unitOfWork.CriarTransacao();
                    //verifica se há necessidade e associa superpoder ao herói
                    foreach (var superpoder in superpoderesParaAssociar)
                    {
                        bool verificaNecessidadeAssociar = !superpoderesAssociados.Any(x =>
                            x.Id == superpoder.Id
                        );
                        if (verificaNecessidadeAssociar)
                        {
                            var superpoderExiste = _superpoderesRepository.BuscarSuperpoderPorNome(superpoder.Superpoder);
                            if (superpoderExiste == null)
                            {
                                var superpoderAdicionado = _superpoderesRepository.AdicionarSuperpoder(superpoder.Superpoder, superpoder.Descricao);
                                if (superpoderAdicionado == null) throw new Exception();
                                _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(heroi.Id, superpoderAdicionado.Id);
                            }
                            else
                            {
                                _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(heroi.Id, superpoderExiste.Id);
                            }
                        }
                    }

                    //verifica se há necessidade e remove associação do superpoder do herói
                    foreach (var superpoder in superpoderesAssociados)
                    {
                        bool desassociarSuperpoder = !superpoderesParaAssociar.Any(x =>
                        x.Id == superpoder.Id
                        );

                        if (desassociarSuperpoder)
                        {
                            _heroisSuperpoderesRepository.DesassociarHeroiSuperpoder(heroi.Id, superpoder.Id);
                        }
                    }
                    _unitOfWork.CommitComTransacao();
                }
                else
                {
                    foreach (var superpoder in superpoderesParaAssociar)
                    {
                        var superpoderExiste = _superpoderesRepository.BuscarSuperpoderPorNome(superpoder.Superpoder);
                        if (superpoderExiste == null)
                        {
                            var superpoderAdicionado = _superpoderesRepository.AdicionarSuperpoder(superpoder.Superpoder, superpoder.Descricao);
                            if (superpoderAdicionado == null) throw new Exception();
                            _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(heroi.Id, superpoderAdicionado.Id);
                        }
                        else
                        {
                            _heroisSuperpoderesRepository.AssociarHeroiSuperpoder(heroi.Id, superpoderExiste.Id);
                        }
                    }
                }
            
                return ResponsePut();
            }
            catch (Exception e)
            {
                _notificationService.AdicionarNotificacao("Não foi possível atualizar o herói e seus superpoderes.");
                return ResponsePut();
            }
        }

        [HttpDelete]
        [Route(nameof(HeroisSuperpoderesController.ExcluirHeroiSuperpoderes))]
        public async Task<dynamic> ExcluirHeroiSuperpoderes(int heroiId)
        {
            try
            {
                var buscarHeroiExistente = _heroisRepository.BuscarHeroiPorId(heroiId);
                if(buscarHeroiExistente == null) throw new Exception();
                var heroiSuperpoderes = _heroisSuperpoderesRepository.BuscarHeroiSuperpoder(heroiId);
                if(heroiSuperpoderes != null)
                {
                    var superpoderes = heroiSuperpoderes.Superpoderes;
                    if (superpoderes != null)
                    {
                        _unitOfWork.CriarTransacao();
                        foreach(var superpoder in superpoderes)
                        {
                            _heroisSuperpoderesRepository.DesassociarHeroiSuperpoder(heroiId, superpoder.Id);
                        }
                        _heroisRepository.DeletarHeroi(heroiId);
                        _unitOfWork.CommitComTransacao();
                    }
                }
                else
                {
                    _unitOfWork.CriarTransacao();
                    _heroisRepository.DeletarHeroi(heroiId);
                    _unitOfWork.CommitComTransacao();
                }

                return ResponseDelete();
            }
            catch(Exception ex)
            {
                _notificationService.AdicionarNotificacao("Houve um erro na tentativa de deletar o registro do herói. Tente novamente.");
                return ResponseDelete();
            }


        }
    }
}
