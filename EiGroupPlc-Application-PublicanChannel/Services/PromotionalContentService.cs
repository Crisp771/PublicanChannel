using EiGroupPlc.Application.PublicanChannel.Interfaces.Mappers;
using EiGroupPlc.Application.PublicanChannel.Interfaces.Repositories;
using EiGroupPlc.Application.PublicanChannel.Mappers;
using EiGroupPlc.Application.PublicanChannel.Repositories;
using EiGroupPlc.Services.Contracts.Dtos.PromotionalContent;
using EiGroupPlc.Services.Contracts.PromotionalContent;
using System.Collections.Generic;

namespace EiGroupPlc.Application.PublicanChannel.Services
{
    public class PromotionalContentService : IPromotionalContentService
    {
        IPromotionalContentRepository _promotionalContentRepository;
        IPromotionalContentMapper _mapper;

        public PromotionalContentService()
        {
            _promotionalContentRepository = new PromotionalContentRepository();
            _mapper = new PromotionalContentMapper();
        }

        public PromotionalContentService(IPromotionalContentRepository promotionalContentRepository, IPromotionalContentMapper mapper)
        {
            _promotionalContentRepository = promotionalContentRepository;
            _mapper = mapper;
        }

        public IList<PromotionalContentDto> GetPromotionalContent(string pageId)
        {
            return _mapper.Map(_promotionalContentRepository.GetPromotionalContentByPageId(pageId));
        }
    }
}
