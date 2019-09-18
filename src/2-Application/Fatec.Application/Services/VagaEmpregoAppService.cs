using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Vagas;
using System;
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
            var vagaEstagios = _vagaEmpregoRepository.GetAll().ToList();

            var usuariosViewModel = new List<VagaEmpregoViewModel>();

            foreach (var vagaEstagio in vagaEstagios)
            {
                usuariosViewModel.Add(_mapper.Map<VagaEmpregoViewModel>(vagaEstagio));
            }

            return usuariosViewModel;
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