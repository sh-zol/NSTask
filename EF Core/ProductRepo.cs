using AppDBContext.DBContext;
using Domain.Core.Products.Contracts;
using Domain.Core.Products.DTOs;
using Domain.Core.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDBContexts _context;
        private readonly ILogger<ProductRepo> _logger;

        public ProductRepo(AppDBContexts context,
            ILogger<ProductRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Create(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                ProductName = productDTO.ProductName,
                ManufacturerEmail = productDTO.ManufacturerEmail,
                ManufacturerPhoneNumber = productDTO.ManufacturerPhoneNumber,
                ProduceDate = productDTO.ProduceDate,
                // Manufacturer = productDTO.Manufacturer,
                ManufacturerId = productDTO.ManufacturerId,
            };
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation($"product with the id of {product.Id} has been deleted");
            }
            else
            {
                _logger.LogError("no product was found");
            }
        }

        public async Task<List<ProductDTO>?> GetAll(CancellationToken cancellationToken)
        {
            var list = await _context.Products.AsNoTracking().Select(x => new ProductDTO
            {
                Id = x.Id,
                ManufacturerEmail = x.ManufacturerEmail,
                ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                ProduceDate = x.ProduceDate,
                ManufacturerId = x.ManufacturerId,
                Manufacturer = x.Manufacturer,
                ProductName = x.ProductName,
            }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no product was found");
                return new List<ProductDTO>();
            }
        }

        public async Task<ProductDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var product = await _context.Products.AsNoTracking().Where(x => x.Id == id)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    ManufacturerEmail = x.ManufacturerEmail,
                    ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                    ProduceDate = x.ProduceDate,
                    ManufacturerId = x.ManufacturerId,
                    Manufacturer = x.Manufacturer,
                    ProductName = x.ProductName,
                }).SingleOrDefaultAsync(cancellationToken);
            if(product != null)
            {
                return product;
            }
            else
            {
                _logger.LogError("no product was found");
                throw new NullReferenceException();
            }
        }

        public async Task<List<ProductDTO>?> GetManufacturerProducts(int id, CancellationToken cancellationToken)
        {
            var list = await _context.Products.AsNoTracking().Where(x => x.ManufacturerId == id)
                .Select(x => new ProductDTO
                {
                    Id = x.Id,
                    ManufacturerEmail = x.ManufacturerEmail,
                    ManufacturerPhoneNumber = x.ManufacturerPhoneNumber,
                    ProduceDate = x.ProduceDate,
                    ManufacturerId = x.ManufacturerId,
                    Manufacturer = x.Manufacturer,
                    ProductName = x.ProductName,
                }).ToListAsync(cancellationToken);
            if(list != null)
            {
                return list;
            }
            else
            {
                _logger.LogError("no product was found");
                throw new NullReferenceException();
            }
        }

        public async Task Update(ProductDTO productDTO, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productDTO.Id);
            if(product != null)
            {
                product.ProductName = productDTO.ProductName;
                product.ManufacturerPhoneNumber = productDTO.ManufacturerPhoneNumber;
                product.ManufacturerEmail = productDTO.ManufacturerEmail;
                product.ProduceDate = productDTO.ProduceDate;
                await _context.SaveChangesAsync();
                _logger.LogInformation($"product with the id of {product.Id} has been updated");
            }
            else
            {
                _logger.LogError("no product was found");
            }
        }
    }
}
