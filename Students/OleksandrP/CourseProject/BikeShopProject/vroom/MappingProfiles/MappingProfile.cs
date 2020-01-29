using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.Controllers.Resourses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace vroom.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelResources>();
        }
    }
}
