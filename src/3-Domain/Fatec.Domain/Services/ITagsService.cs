using Fatec.CrossCutting.Models;
using System.Collections.Generic;

namespace Fatec.Domain.Interfaces.Services
{
    public interface ITagsService
    {
        IEnumerable<Tags> GetTagsInArray(IEnumerable<int> idTags);
    }
}