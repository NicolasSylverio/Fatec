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

        public void Cadastrar(EmpresaViewModel EmpresaViewModel)
        {
            var usuario = _mapper.Map<Empresa>(EmpresaViewModel);

            _empresaRepository.Add(usuario);
        }

        public IEnumerable<EmpresaViewModel> GetAllEmpresaViewModel()
        {
            var empresas = _empresaRepository.GetAll().ToList();

            var usuariosViewModel = new List<EmpresaViewModel>();

            foreach (var empresa in empresas)
            {
                usuariosViewModel.Add(_mapper.Map<EmpresaViewModel>(empresa));
            }

            return usuariosViewModel;
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
    }
}