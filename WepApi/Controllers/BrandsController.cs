using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Responses;
using Business.Dtos.Request;
using Business.Abstracts;

namespace WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
       public IActionResult Add(CreatedBrandRequest CreatedBrandRequest)
        {
         CreatedBrandResponse createdBrandResponse=
                _brandService.Add(CreatedBrandRequest);
            return Ok(createdBrandResponse);
        }
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_brandService.GetAll());
        }
    }
}
