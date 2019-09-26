using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.CrossCutting.Models.Vagas;
using Fatec.DataBase.Interfaces;
using System.Collections.Generic;

namespace Fatec.Application.Services
{
    public class VagaEmpregoAppService : IVagaEmpregoAppService
    {
        private readonly IVagaEmpregoRepository _vagaEmpregoRepository;
        private readonly IMapper _mapper;

        public VagaEmpregoAppService(IVagaEmpregoRepository vagaEmpregoRepository, IMapper mapper)
        {
            _vagaEmpregoRepository = vagaEmpregoRepository;
            _mapper = mapper;
        }

        public void Add(VagaEmpregoViewModel obj)
        {
            _vagaEmpregoRepository.Add(_mapper.Map<VagaEmprego>(obj));
        }

        public void Dispose()
        {
            _vagaEmpregoRepository.Dispose();
        }

        public IEnumerable<VagaEmpregoViewModel> GetAll()
        {
            var vagaEmpregos = _vagaEmpregoRepository.GetAll();

            return _mapper.Map<List<VagaEmpregoViewModel>>(vagaEmpregos);
        }

        public VagasFiltroViewModel<VagaEmpregoViewModel> GetAll(Paginacao paginacao)
        {
            var result = _vagaEmpregoRepository.GetAll(paginacao);

            var vagas = _mapper.Map<List<VagaEmpregoViewModel>>(result.Resultados);

            var resultadoPaginacao = new ResultadoPaginacao<VagaEmpregoViewModel>
            {
                Direcao = result.Direcao,
                OrdenarPor = result.OrdenarPor,
                Pagina = result.Pagina,
                Resultados = vagas,
                Total = result.Total,
                TotalPaginas = result.TotalPaginas,
                TotalPorPagina = result.TotalPorPagina
            };

            return new VagasFiltroViewModel<VagaEmpregoViewModel>
            {
                Objeto = resultadoPaginacao,
                Tags = null,
                PesquisaTitulo = null
            };
        }

        public VagasFiltroViewModel<VagaEmpregoViewModel> GetAllByTituloTags(string titulo, IEnumerable<int> tags, Paginacao paginacao)
        {
            var result = _vagaEmpregoRepository.GetAllByTituloTags(titulo, tags, paginacao);

            var vagas = _mapper.Map<List<VagaEmpregoViewModel>>(result.Resultados);

            var resultadoPaginacao = new ResultadoPaginacao<VagaEmpregoViewModel>
            {
                Direcao = result.Direcao,
                OrdenarPor = result.OrdenarPor,
                Pagina = result.Pagina,
                Resultados = vagas,
                Total = result.Total,
                TotalPaginas = result.TotalPaginas,
                TotalPorPagina = result.TotalPorPagina
            };

            return new VagasFiltroViewModel<VagaEmpregoViewModel>
            {
                Objeto = resultadoPaginacao,
                Tags = null,
                PesquisaTitulo = null
            };
        }

        public void Remove(int obj)
        {
            _vagaEmpregoRepository.Remove(obj);
        }

        public void Update(VagaEmpregoViewModel obj)
        {
            _vagaEmpregoRepository.Update(_mapper.Map<VagaEmprego>(obj));
        }

        VagaEmpregoViewModel IAppServiceBase<VagaEmpregoViewModel>.GetById(int id)
        {
            return _mapper.Map<VagaEmpregoViewModel>(_vagaEmpregoRepository.GetById(id));
        }
    }
}