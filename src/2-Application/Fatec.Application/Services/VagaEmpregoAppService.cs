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
                Resultado = resultadoPaginacao.Resultados
            };
        }

        public VagasFiltroViewModel<VagaEmpregoViewModel> GetAllByTituloTags(string titulo, int tags, Paginacao paginacao)
        {
            var result = _vagaEmpregoRepository.GetAllByTituloTags(titulo, tags, paginacao);

            var vagas = _mapper.Map<List<VagaEmpregoViewModel>>(result.Resultados);

            return new VagasFiltroViewModel<VagaEmpregoViewModel>
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