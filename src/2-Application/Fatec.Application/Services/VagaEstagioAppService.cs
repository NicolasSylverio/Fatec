using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Vagas;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.Application.Services
{
    public class VagaEstagioAppService : IVagaEstagioAppService
    {
        private readonly IVagaEstagioRepository _empresaRepository;
        private readonly IMapper _mapper;

        public VagaEstagioAppService
        (
            IVagaEstagioRepository vagaEstagioRepository,
            IMapper mapper
        )
        {
            _empresaRepository = vagaEstagioRepository;
            _mapper = mapper;
        }

        public void Cadastrar(VagaEstagioViewModel vagaEstagioViewModel)
        {
            var usuario = _mapper.Map<VagaEstagio>(vagaEstagioViewModel);

            _empresaRepository.Add(usuario);
        }

        public IEnumerable<VagaEstagioViewModel> GetAllVagaEstagioViewModel()
        {
            var vagaEstagios = _empresaRepository.GetAll().ToList();

            var usuariosViewModel = new List<VagaEstagioViewModel>();

            foreach (var vagaEstagio in vagaEstagios)
            {
                usuariosViewModel.Add(_mapper.Map<VagaEstagioViewModel>(vagaEstagio));
            }

            return usuariosViewModel;
        }
        public void Add(VagaEstagio obj)
        {
            _empresaRepository.Add(obj);
        }

        public VagaEstagio GetById(int id)
        {
            return _empresaRepository.GetById(id);
        }

        public void Remove(VagaEstagio obj)
        {
            _empresaRepository.Remove(obj);
        }

        public void Update(VagaEstagio obj)
        {
            _empresaRepository.Update(obj);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
        }

        public IEnumerable<VagaEstagio> GetAll()
        {
            return _empresaRepository.GetAll();
        }
    }
}