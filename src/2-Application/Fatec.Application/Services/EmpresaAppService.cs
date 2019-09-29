using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models.Empresas;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.DataBase.Interfaces;
using System.Collections.Generic;

namespace Fatec.Application.Services
{
    public class EmpresaAppService : IEmpresaAppService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;

        public EmpresaAppService
        (
            IEmpresaRepository empresaRepository,
            IMapper mapper
        )
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public void Add(EmpresaViewModel empresaViewModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaViewModel);

            _empresaRepository.Add(empresa);
        }

        public void Add(Empresa obj)
        {
            _empresaRepository.Add(obj);
        }

        public EmpresaViewModel GetById(int id)
        {
            return _mapper.Map<EmpresaViewModel>(_empresaRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _empresaRepository.Remove(id);
        }

        public void Update(Empresa obj)
        {
            _empresaRepository.Update(obj);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }

        public IEnumerable<EmpresaViewModel> GetAll()
        {
            return _mapper.Map<List<EmpresaViewModel>>(_empresaRepository.GetAll());
        }

        public EmpresaViewModel GetViewModel(int id)
        {
            var empresa = _empresaRepository.GetById(id);
            return _mapper.Map<EmpresaViewModel>(empresa);
        }

        public void Update(EmpresaViewModel obj)
        {
            var empresa = _mapper.Map<Empresa>(obj);
            _empresaRepository.Update(empresa);
        }

        public PaginacaoViewModel<EmpresaViewModel> GetAll(Paginacao paginacao)
        {
            try
            {
                var result = _empresaRepository.GetAll(paginacao);

                var vagas = _mapper.Map<List<EmpresaViewModel>>(result.Resultados);

                return new PaginacaoViewModel<EmpresaViewModel>
                {
                    Resultado = vagas,
                    Direcao = result.Direcao,
                    OrdenarPor = result.OrdenarPor,
                    Pagina = result.Pagina,
                    Total = result.Total,
                    TotalPorPagina = result.TotalPorPagina
                };
            }
            catch (System.Exception ex)
            {
                var teste = ex.InnerException;
                throw ex;
            }
        }
    }
}