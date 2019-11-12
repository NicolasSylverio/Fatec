using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.CrossCutting.Models;
using Fatec.CrossCutting.Models.PaginacaoHelper;
using Fatec.DataBase.Interfaces;
using System.Collections.Generic;

namespace Fatec.Application.Services
{
    public class TagsAppService : ITagsAppService
    {
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public TagsAppService
        (
            ITagsRepository tagsRepository,
            IMapper mapper
        )
        {
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        public void Add(TagsViewModel obj)
        {
            var tag = _mapper.Map<Tags>(obj);
            _tagsRepository.Add(tag);
        }

        public void Dispose()
        {
            _tagsRepository.Dispose();
        }

        public IEnumerable<TagsViewModel> GetAll()
        {
            return _mapper.Map<List<TagsViewModel>>(_tagsRepository.GetAll());
        }

        public PaginacaoViewModel<TagsViewModel> GetAll(Paginacao paginacao)
        {
            var result = _tagsRepository.GetAll(paginacao, x => x.Ativo, x => x.DataCadastro);

            var vagas = _mapper.Map<List<TagsViewModel>>(result.Resultados);

            return new PaginacaoViewModel<TagsViewModel>
            {
                Resultado = vagas,
                Direcao = result.Direcao,
                OrdenarPor = result.OrdenarPor,
                Pagina = result.Pagina,
                Total = result.Total,
                TotalPorPagina = result.TotalPorPagina
            };
        }

        public TagsViewModel GetById(int id)
        {
            return _mapper.Map<TagsViewModel>(_tagsRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _tagsRepository.Remove(id);
        }

        public void Update(TagsViewModel obj)
        {
            var tag = _mapper.Map<Tags>(obj);

            _tagsRepository.Update(tag);
        }
    }
}