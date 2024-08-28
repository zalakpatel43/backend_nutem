using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using Skyward.Model;
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
            CreateMap<CauseMaster, CauseMasterList>();
            CreateMap<MastersEntity, MastersList>();
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
            CreateMap<AttributeCheck, AttributeCheckList>();
            CreateMap<AttributeCheck, AttributeCheckAddEdit>();
            CreateMap<AttributeCheckAddEdit, AttributeCheck>().ReverseMap();
            CreateMap<AttributeCheckDetails, AttributeCheckDetailsAddEdit>();
            CreateMap<AttributeCheckDetailsAddEdit, AttributeCheckDetails>().ReverseMap();
            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
               .ConvertUsing(typeof(PaginatedListConverter<,>));
        }

        public class PaginatedListConverter<TSource, TDestination> : ITypeConverter<PaginatedList<TSource>, PaginatedList<TDestination>>
        {
            private readonly IMapper _mapper;

            public PaginatedListConverter(IMapper mapper)
            {
                _mapper = mapper;
            }

            public PaginatedList<TDestination> Convert(PaginatedList<TSource> source, PaginatedList<TDestination> destination, ResolutionContext context)
            {
                var mappedItems = _mapper.Map<List<TDestination>>(source.Items);
                return new PaginatedList<TDestination>(mappedItems, source.TotalCount, source.PageNumber, source.PageSize);
            }
        }
    }
}
