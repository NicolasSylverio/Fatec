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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void Remove(int obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(VagaEstagioViewModel obj)
        {
            throw new System.NotImplementedException();
        }
    }
}