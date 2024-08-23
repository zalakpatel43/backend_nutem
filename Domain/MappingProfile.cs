using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NozzelMaster, NozzleMasterList>();
            CreateMap<ProductionOrder, ProductionOrderList>();
            CreateMap<ProductMaster, ProdcutMasterList>();
            CreateMap<ShiftMaster, ShiftMasterList>();
            CreateMap<WeightCheck, WeightCheckList>();
            CreateMap<WeightCheck, WeightCheckAddEdit>();
            CreateMap<WeightCheckAddEdit, WeightCheck>();
            CreateMap<WeightCheckDetailsAddEdit, WeightCheckDetails>();
        }
    }
}
