using Business.Abstracts;
using Business.Dtos.Request;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
         _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreatedBrandRequest CreatedBrandRequest)
    {
        //business rules

        Brand brand =new Brand();
        brand.Name= CreatedBrandRequest.Name;   
        brand.CreatedDate=DateTime.Now;

        _brandDal.Add(brand);
        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = brand.Name;
        createdBrandResponse.Id = 4;
        createdBrandResponse.CreateDate= brand.CreatedDate;
        return createdBrandResponse;    
    }

    public List<GetAllBrandResponse> GetAll()
    {
       List<Brand> brands=_brandDal.GetAll();

       List<GetAllBrandResponse> getAllBrandResponse = new List<GetAllBrandResponse>();

      foreach (var brand in brands)
        {
            GetAllBrandResponse getAllBrandResponses = new GetAllBrandResponse();
            getAllBrandResponses.Name = brand.Name;
            getAllBrandResponses.Id = brand.Id;
            getAllBrandResponses.CreateDate = brand.CreatedDate;

            getAllBrandResponse.Add(getAllBrandResponses);
        }
      return getAllBrandResponse;
    }
    
}
