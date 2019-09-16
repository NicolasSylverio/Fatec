using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Empresas;
using System.Collections.Generic;
using System.Linq;

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

        public void Cadastrar(EmpresaViewModel empresaViewModel)
        {
            var empresa = _mapper.Map<Empresa>(empresaViewModel);

            _empresaRepository.Add(empresa);
        }

        public IEnumerable<EmpresaViewModel> GetAllEmpresaViewModel()
        {           
            return _mapper.Map<List<EmpresaViewModel>>(_empresaRepository.GetAll());
        }
        public void Add(Empresa obj)
        {
            _empresaRepository.Add(obj);
        }

        public Empresa GetById(int id)
        {
            return _empresaRepository.GetById(id);
        }

        public void Remove(Empresa obj)
        {
            _empresaRepository.Remove(obj);
        }

        public void Update(Empresa obj)
        {
            _empresaRepository.Update(obj);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _empresaRepository.GetAll();
        }

        public EmpresaViewModel GetViewModel(int id)
        {
            var empresa = _empresaRepository.GetById(id);
            return _mapper.Map<EmpresaViewModel>(empresa);
        }

        public void Alterar(EmpresaViewModel obj)
        {
            var empresa = _mapper.Map<Empresa>(obj);
            _empresaRepository.Update(empresa);
        }
    }
}