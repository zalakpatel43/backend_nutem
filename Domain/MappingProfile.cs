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
            CreateMap<Permission, PermissionList>();
            CreateMap<Permission, PermissionAddEdit>();

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
            CreateMap<DowntimeTracking, DowntimeTrackingList>();
            CreateMap<DowntimeTracking, DowntimeTrackingAddEdit>();
            CreateMap<DowntimeTrackingAddEdit, DowntimeTracking>().ReverseMap();
            CreateMap<DowntimeTrackingDetails, DowntimeTrackingDetailsAddEdit>();
            CreateMap<DowntimeTrackingDetailsAddEdit, DowntimeTrackingDetails>().ReverseMap();

            // TrailerLoading mappings
            CreateMap<TrailerLoading, TrailerLoadingList>();
            CreateMap<TrailerLoading, TrailerLoadingAddEdit>();
            CreateMap<TrailerLoadingAddEdit, TrailerLoading>().ReverseMap();

            CreateMap<RolePermissionMap, RolePermissionList>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                    .ForMember(dest => dest.PermissionCode, opt => opt.MapFrom(src => src.Permission.Code));
                    //.ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name));

            CreateMap<RolePermissionMap, RolePermissionAddEdit>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.PermissionId, opt => opt.MapFrom(src => src.Permission.Code));
                
            CreateMap<RolePermissionAddEdit, RolePermissionMap>()
                .ForMember(dest => dest.Role, opt => opt.Ignore()) // Adjust if you need to map Role or Permission explicitly
                .ForMember(dest => dest.Permission, opt => opt.Ignore());

            // Ensure there is only one correct mapping for RoleAddEdit to Role and vice versa
            CreateMap<RoleAddEdit, Role>()
                .ForMember(dest => dest.RolePermissions, opt => opt.Ignore()); // Ignore if RolePermissions should not be mapped

            CreateMap<Role, RoleAddEdit>()
                .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions.Select(rp => new RolePermissionAddEdit
                {
                    Id = rp.Id,
                    RoleId = rp.RoleId,
                    PermissionId = rp.PermissionId,
                    HasMasterAccess = rp.HasMasterAccess,
                    
                })));

            CreateMap<Role, RoleList>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));



            // TrailerLoadingDetails mappings
            CreateMap<TrailerLoadingDetails, TrailerLoadingDetailsAddEdit>();
            CreateMap<TrailerLoadingDetailsAddEdit, TrailerLoadingDetails>().ReverseMap();


            // PalletPacking mappings
            CreateMap<PalletPacking, PalletPackingList>();
            CreateMap<PalletPacking, PalletPackingAddEdit>();
            CreateMap<PalletPackingAddEdit, PalletPacking>().ReverseMap();

            // PalletPackingDetails mappings
            CreateMap<PalletPackingDetails, PalletPackingDetailsAddEdit>();
            CreateMap<PalletPackingDetailsAddEdit, PalletPackingDetails>().ReverseMap();





            CreateMap<PreCheckListEntity, PreCheckList>();
            CreateMap<PreCheckListEntity, PreCheckListAddEdit>();
            CreateMap<PreCheckListAddEdit, PreCheckListEntity>().ReverseMap();

            CreateMap<PreCheckListDetailEntity, PreCheckListDetailAddEdit>();
            CreateMap<PreCheckListDetailAddEdit, PreCheckListDetailEntity>().ReverseMap();

            CreateMap<PrePostQuestionEntity, PrePostQuestionList>();

            CreateMap<PostCheckListEntity, PostCheckList>();
            CreateMap<PostCheckListEntity, PostCheckListAddEdit>();
            CreateMap<PostCheckListAddEdit, PostCheckListEntity>().ReverseMap();

            CreateMap<PostCheckListDetailEntity, PostCheckListDetailAddEdit>();
            CreateMap<PostCheckListDetailAddEdit, PostCheckListDetailEntity>().ReverseMap();



            CreateMap(typeof(PaginatedList<>), typeof(PaginatedList<>))
               .ConvertUsing(typeof(PaginatedListConverter<,>));

            CreateMap<CompanyMaster, CompanyMasterList>().ReverseMap();

            CreateMap<TrailerInspection, TrailerInspectionList>()
            .ForMember(dest => dest.VehicleTypeName, opt => opt.MapFrom(src => src.MasterEntity.Name))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyMaster.CompanyName))
            .ReverseMap();

            CreateMap<TrailerInspection, TrailerInspectionAddEdit>().ReverseMap();

            CreateMap<StartEndBatchChecklist, StartEndBatchCheckListList>().ReverseMap();
            CreateMap<TankMaster, TankMasterList>().ReverseMap();
            CreateMap<MaterialMaster, MaterialMasterList>().ReverseMap();
            CreateMap<ProductInstructionDetails, ProductInstructionDetailsList>()
               .ForMember(dest => dest.MaterialName, opt => opt.MapFrom(src => src.MaterialMaster.MaterialName))
               .ReverseMap();

            CreateMap<QCTSpecificationMaster, QCTSpecificationMasterList>().ReverseMap();

            CreateMap<LiquidPreparation, LiquidPreparationList>()
            .ForMember(dest => dest.ShiftName, opt => opt.MapFrom(src => src.ShiftMaster.ShiftName))
            .ReverseMap();

            CreateMap<LiquidPreparation, LiquidPreparationAddEdit>()
              .ForMember(dest => dest.liquidPreparationChecklistDetails, opt => opt.MapFrom(src => src.LiquidPreparationChecklistDetails))
              .ForMember(dest => dest.liquidPreparationInstructionDetails, opt => opt.MapFrom(src => src.LiquidPreparationInstructionDetails))
              .ForMember(dest => dest.liquidPreparationAdjustmentDetails, opt => opt.MapFrom(src => src.LiquidPreparationAdjustmentDetails))
              .ForMember(dest => dest.liquidPreparationSpecificationDetails, opt => opt.MapFrom(src => src.LiquidPreparationSpecificationDetails))
              .ReverseMap();

            CreateMap<LiquidPreparationChecklistDetails, LiquidPreparationChecklistDetailsAddEdit>().ReverseMap();
            CreateMap<LiquidPreparationAdjustmentDetails, LiquidPreparationAdjustmentDetailsAddEdit>().ReverseMap();
            CreateMap<LiquidPreparationInstructionDetails, LiquidPreparationInstructionDetailsAddEdit>().ReverseMap();
            CreateMap<LiquidPreparationSpecificationDetails, LiquidPreparationSpecificationDetailsAddEdit>().ReverseMap();


            CreateMap<LaborVariance, LaborVarianceList>();
            CreateMap<LaborVariance, LaborVarianceAddEdit>();
            CreateMap<LaborVarianceAddEdit, LaborVariance>().ReverseMap();
            CreateMap<LaborVarianceDetailsAddEdit, LaborVarianceDetails>().ReverseMap();
            CreateMap<LaborVariance, LaborVarianceList>()
            .ForMember(dest => dest.ShiftName, opt => opt.MapFrom(src => src.ShiftMaster.ShiftName))
            .ForMember(dest => dest.ProductLineName, opt => opt.MapFrom(src => src.Masters.Name));

            CreateMap<LaborVariance, LaborVarianceAddEdit>()
            .ForMember(dest => dest.LaborVarianceDetails, opt => opt.MapFrom(src => src.LaborVarianceDetails))
            .ReverseMap();

           

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
