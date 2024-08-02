using Domain.Core.Products.Contracts;
using Domain.Core.Products.DTOs;
using Domain.Core.User.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSTask.VMs;

namespace NSTask.Controllers
{
    [ApiController]
    [Authorize(Roles = "Manufacturer")]
    public class ProductController : Controller
    {
        private readonly IPersonAppService _person;
        private readonly IProductAppService _product;
        private readonly IAppUserAppService _appuser;

        public ProductController(IPersonAppService person, IProductAppService product,IAppUserAppService appUserAppService)
        {
            _person = person;
            _product = product;
            _appuser = appUserAppService;
        }

        [Route("CreateProduct")]
        [HttpGet]
        public IActionResult Create()
        {
            return Ok();
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> Create(ProductVM productvm,CancellationToken cancellationToken)
        {
            var id = await _appuser.GetUserId();
            var user = await _person.GetManufacturer(id, cancellationToken);
            var product = new ProductDTO
            {
                ProductName = productvm.Name,
                ManufacturerEmail = user.Email,
                ManufacturerId = user.Id,
                ManufacturerPhoneNumber = user.PhoneNumber,
                ProduceDate = productvm.ProduceDate,
            };
            await _product.Create(product, cancellationToken);
            return Ok();
        }

        [Route("Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            await _product.Delete(id,cancellationToken);
            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var list = await _product.GetAll(cancellationToken);
            if(list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("ManufacturersProduct")]
        [HttpGet]
        public async Task<IActionResult> ManufacturerProduct(CancellationToken cancellationToken)
        {
            var id = await _appuser.GetUserId();
            var user = await _person.GetManufacturer(id, cancellationToken);
            if(user != null)
            {
                var list = await _product.GetManufacturerProducts(user.Id, cancellationToken);
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
