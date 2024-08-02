using Domain.Core.User.Contracts;
using Domain.Core.User.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IPersonService _service;

        public PersonAppService(IPersonService service)
        {
            _service = service;
        }

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            return await _service.GetAdmin(id, cancellationToken);
        }

        public async Task<ManufacturerDTO>? GetManufacturer(int id, CancellationToken cancellationToken)
        {
            return await _service.GetManufacturer(id, cancellationToken);
        }
    }
}
