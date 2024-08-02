using Domain.Core.Products.Contracts;
using Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _service;

        public ProductAppService(IProductService service)
        {
            _service = service;
        }

        public async Task Create(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            await _service.Create(productDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _service.Delete(id, cancellationToken);
        }

        public async Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task<ProductDTO> GetById(int id, CancellationToken cancellationToken)
        {
            return await _service.GetById(id, cancellationToken);
        }

        public async Task<List<ProductDTO>?> GetManufacturerProducts(int id, CancellationToken cancellationToken)
        {
            return await _service.GetManufacturerProducts(id, cancellationToken);
        }

        public async Task Update(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            await _service.Update(productDTO, cancellationToken);
        }
    }
}
