using EiGroupPlc.Application.PublicanChannel.Interfaces.Mappers;
using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using EiGroupPlc.Services.Contracts.Dtos.PromotionalContent;
using System.Collections.Generic;

namespace EiGroupPlc.Application.PublicanChannel.Mappers
{
    public class PromotionalContentMapper : IPromotionalContentMapper
    {
        public IList<PromotionalContentDto> Map(IList<PromotionalContent> input)
        {
            var result = new List<PromotionalContentDto>();
            foreach (var item in input)
            {
                result.Add(new PromotionalContentDto() { ImageUrl = item.ImageUrl });
            }
            return result;
        }
    }
}
