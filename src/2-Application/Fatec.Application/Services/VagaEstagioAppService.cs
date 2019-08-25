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
        private readonly IVagaEstagioRepository _vagaEstagioRepository;
        private readonly IMapper _mapper;

        public VagaEstagioAppService
        (
            IVagaEstagioRepository vagaEstagioRepository,
            IMapper mapper
        )
        {
            _vagaEstagioRepository = vagaEstagioRepository;
            _mapper = mapper;
        }

        public void Cadastrar(VagaEstagioViewModel vagaEstagioViewModel)
        {
            var usuario = _mapper.Map<VagaEstagio>(vagaEstagioViewModel);

            _vagaEstagioRepository.Add(usuario);
        }

        public IEnumerable<VagaEstagioViewModel> GetAllVagaEstagioViewModel()
        {
            var vagaEstagios = _vagaEstagioRepository.GetAll().ToList();

            var usuariosViewModel = new List<VagaEstagioViewModel>();

            foreach (var vagaEstagio in vagaEstagios)
            {
                usuariosViewModel.Add(_mapper.Map<VagaEstagioViewModel>(vagaEstagio));
            }

            return usuariosViewModel;
        }
        public void Add(VagaEstagio obj)
        {
            _vagaEstagioRepository.Add(obj);
        }

        public VagaEstagio GetById(int id)
        {
            return _vagaEstagioRepository.GetById(id);
        }

        public void Remove(VagaEstagio obj)
        {
            _vagaEstagioRepository.Remove(obj);
        }

        public void Update(VagaEstagio obj)
        {
            _vagaEstagioRepository.Update(obj);
        }

        public void Dispose()
        {
            _vagaEstagioRepository.Dispose();
        }

        public IEnumerable<VagaEstagio> GetAll()
        {
            return _vagaEstagioRepository.GetAll();
        }
    }
}