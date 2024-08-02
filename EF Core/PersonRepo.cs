using AppDBContext.DBContext;
using Domain.Core.User.Contracts;
using Domain.Core.User.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core
{
    public class PersonRepo : IPersonRepo
    {
        private readonly AppDBContexts _context;
        private readonly ILogger<PersonRepo> _logger;
        public PersonRepo(AppDBContexts context,
            ILogger<PersonRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<AdminDTO>? GetAdmin(int id, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.AsNoTracking()
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id)
                .Select(x => new AdminDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                }).SingleOrDefaultAsync(cancellationToken);
            if(admin != null)
            {
                return admin;
            }
            else
            {
                _logger.LogError("no user was found");
                throw new NullReferenceException();
            }
        }

        public async Task<ManufacturerDTO>? GetManufacturer(int id, CancellationToken cancellationToken)
        {
            var man = await _context.Manufacturers.AsNoTracking()
                .Include(x => x.AppUser)
                .Where(x => x.AppUser.Id == id)
                .Select(x => new ManufacturerDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Products = x.Products,
                }).SingleOrDefaultAsync(cancellationToken);
            if(man  != null)
            {
                return man;
            }
            else
            {
                _logger.LogError("no user was found");
                throw new NullReferenceException();
            }
        }
    }
}
