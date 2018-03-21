using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EiGroupPlc.Application.PublicanChannel.Interfaces.Mappers
{
    public interface IMapper<in input, out output>
    {
        output Map(input input);
    }
}


