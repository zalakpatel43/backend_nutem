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
            CreateMap<WeightCheckAddEdit, WeightCheck>().ReverseMap();
            CreateMap<WeightCheckDetailsAddEdit, WeightCheckDetails>().ReverseMap();
            CreateMap<WeightCheckSubDetailsAddEdit, WeightCheckSubDetails>().ReverseMap();
            CreateMap<WeightCheck, WeightCheckList>()
            .ForMember(dest => dest.ShiftName, opt => opt.MapFrom(src => src.ShiftMaster.ShiftName));

            CreateMap<WeightCheck, WeightCheckAddEdit>()
            .ForMember(dest => dest.WeightCheckDetails, opt => opt.MapFrom(src => src.WeightCheckDetails))
            .ReverseMap();

            CreateMap<WeightCheckDetails, WeightCheckDetailsAddEdit>()
                .ForMember(dest => dest.WeightCheckSubDetails, opt => opt.MapFrom(src => src.WeightCheckSubDetails))
                .ReverseMap();

            CreateMap<WeightCheckSubDetails, WeightCheckSubDetailsAddEdit>()
                .ReverseMap();
        }
    }
}
