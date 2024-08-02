using Domain.Core.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Products.Contracts
{
    public interface IProductService
    {
        Task Create(ProductDTO productDTO, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Update(ProductDTO productDTO, CancellationToken cancellationToken);
        Task<ProductDTO> GetById(int id, CancellationToken cancellationToken);
        Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken);
        Task<List<ProductDTO>?> GetManufacturerProducts(int id, CancellationToken cancellationToken);
    }
}
