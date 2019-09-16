using System.Collections.Generic;
using AutoMapper;
using Fatec.Application.Interface;
using Fatec.Application.ViewModels;
using Fatec.Domain.Interfaces.Repositories;
using Fatec.Domain.Models.Tags;

namespace Fatec.Application.Services
{
    public class TagsAppService : ITagsAppService
    {
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public TagsAppService(ITagsRepository tagsRepository, IMapper mapper)
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

        public TagsViewModel GetById(int id)
        {
            return _mapper.Map<TagsViewModel>(_tagsRepository.GetById(id));
        }

        public void Remove(TagsViewModel obj)
        {
            _tagsRepository.Remove(_mapper.Map<Tags>(obj));
        }

        public void Update(TagsViewModel obj)
        {
            var tag = _mapper.Map<Tags>(_tagsRepository.GetById(obj.Id));

            tag.Descricao = obj.Descricao;
            tag.Nome = obj.Nome;
            tag.Ativo = obj.Ativo;

            _tagsRepository.Update(tag);
        }
    }
}
