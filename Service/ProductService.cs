using Domain.Core.Products.Contracts;
using Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repo;
        public ProductService(IProductRepo repo)
        {
            _repo = repo;
        }
        public async Task Create(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            await _repo.Create(productDTO, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _repo.Delete(id, cancellationToken);
        }

        public async Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken)
        {
            return await _repo.GetAll(cancellationToken);
        }

        public async Task<ProductDTO> GetById(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetById(id, cancellationToken);
        }

        public async Task<List<ProductDTO>?> GetManufacturerProducts(int id, CancellationToken cancellationToken)
        {
            return await _repo.GetManufacturerProducts(id, cancellationToken);
        }

        public async Task Update(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            await _repo.Update(productDTO, cancellationToken);
        }
    }
}
