using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.Application.Services
{
    public class VagaEstagioAppService : IVagaEstagioAppService
    {
        private readonly IVagaEstagioRepository _estagioRepository;
        private readonly IMapper _mapper;

        public VagaEstagioAppService
        (
            IVagaEstagioRepository vagaEstagioRepository,
            IMapper mapper
        ) 
        {
            _estagioRepository = vagaEstagioRepository;
            _mapper = mapper;
        }

        public void Add(VagaEstagioViewModel obj)
        {
            var usuario = _mapper.Map<VagaEstagio>(obj);

            _estagioRepository.Add(usuario);
        }

        public void Dispose()
        {
            _estagioRepository.Dispose();
        }

        public VagasFiltroViewModel<VagaEstagioViewModel> GetAll(Paginacao paginacao)
        {
            var result = _estagioRepository.GetAll(paginacao);

            var vagas = _mapper.Map<List<VagaEstagioViewModel>>(result.Resultados);

            var resultadoPaginacao = new ResultadoPaginacao<VagaEstagioViewModel>
            {
                Direcao = result.Direcao,
                OrdenarPor = result.OrdenarPor,
                Pagina = result.Pagina,
                Resultados = vagas,
                Total = result.Total,
                TotalPaginas = result.TotalPaginas,
                TotalPorPagina = result.TotalPorPagina
            };

            return new VagasFiltroViewModel<VagaEstagioViewModel>
            {
                Resultado = resultadoPaginacao.Resultados
            };
        }

        public VagasFiltroViewModel<VagaEstagioViewModel> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao)
        {
            var result = _estagioRepository.GetAllByTituloTags(titulo, tags, paginacao);

            var vagas = _mapper.Map<List<VagaEstagioViewModel>>(result.Resultados);

            return new VagasFiltroViewModel<VagaEstagioViewModel>
            {
                Resultado = vagas,
                Tags = tags,
                PesquisaTitulo = titulo,
                Direcao = result.Direcao,
                OrdenarPor = result.OrdenarPor,
                Pagina = result.Pagina,
                Total = result.Total,
                TotalPorPagina = result.TotalPorPagina
            };
        }

        public IEnumerable<VagaEstagioViewModel> GetAll()
        {
            var vagaEstagios = _estagioRepository.GetAll().ToList();

            var usuariosViewModel = new List<VagaEstagioViewModel>();

            foreach (var vagaEstagio in vagaEstagios)
            {
                usuariosViewModel.Add(_mapper.Map<VagaEstagioViewModel>(vagaEstagio));
            }

            return usuariosViewModel;
        }

        public VagaEstagioViewModel GetById(int id)
        {
            return _mapper.Map<VagaEstagioViewModel>(_estagioRepository.GetById(id));
        }

        public void Remove(int obj)
        {
            _estagioRepository.Remove(obj);
        }

        public void Update(VagaEstagioViewModel obj)
        {
            _estagioRepository.Update(_mapper.Map<VagaEstagio>(obj));
        }
    }
}