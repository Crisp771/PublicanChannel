using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using EiGroupPlc.Services.Contracts.Dtos.PromotionalContent;
using System.Collections.Generic;

namespace EiGroupPlc.Application.PublicanChannel.Interfaces.Mappers
{
    public interface IPromotionalContentMapper : IMapper<IList<PromotionalContent>, IList<PromotionalContentDto>>
    {
    }
}
