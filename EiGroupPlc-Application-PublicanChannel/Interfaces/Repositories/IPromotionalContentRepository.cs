using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using EiGroupPlc_Application_PublicanChannel.Interfaces.Repositories;
using System.Collections.Generic;

namespace EiGroupPlc.Application.PublicanChannel.Interfaces.Repositories
{
    public interface IPromotionalContentRepository : IRepository<PromotionalContent>
    {
        List<PromotionalContent> GetPromotionalContentByPageId(string pageId);
    }
}
