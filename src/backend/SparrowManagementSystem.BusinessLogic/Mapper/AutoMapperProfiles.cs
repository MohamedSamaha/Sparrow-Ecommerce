using AutoMapper;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
