using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fatec.Application.Services
{
    public class VagaEmpregoAppService : IVagaEmpregoAppService
    {
        private readonly IVagaEmpregoRepository _empresaRepository;
        private readonly IMapper _mapper;

        public VagaEmpregoAppService(IVagaEmpregoRepository empresaRepository, IMapper mapper)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
        }

        public void Add(VagaEmpregoViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(VagaEmpregoViewModel vagaEstagioViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VagaEmpregoViewModel> GetAll()
        {
            var vagaEstagios = _empresaRepository.GetAll().ToList();

            var usuariosViewModel = new List<VagaEmpregoViewModel>();

            foreach (var vagaEstagio in vagaEstagios)
            {
                usuariosViewModel.Add(_mapper.Map<VagaEmpregoViewModel>(vagaEstagio));
            }

            return usuariosViewModel;
        }

        public void Remove(VagaEmpregoViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Update(VagaEmpregoViewModel obj)
        {
            throw new NotImplementedException();
        }

        VagaEmpregoViewModel IAppServiceBase<VagaEmpregoViewModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}