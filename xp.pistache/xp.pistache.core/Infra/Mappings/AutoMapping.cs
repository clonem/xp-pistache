using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xp.pistache.core.Domain.DTOs.Client;
using xp.pistache.core.Domain.DTOs.Products;
using xp.pistache.core.Domain.Model;

namespace xp.pistache.core.Infra.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ClientDTO, Client>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
