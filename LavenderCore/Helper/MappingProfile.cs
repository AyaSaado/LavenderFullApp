using AutoMapper;
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;

namespace Lavender.Core.Helper
{
    public class MappingProfile
    {
        public static class Mapping
        {
            private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
                    cfg.AddProfile<AutoMapperProfile>();
                });
                var mapper = config.CreateMapper();
                return mapper;
            });
            public static IMapper Mapper => lazy.Value;
        }
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<User, UserDto>().ForMember(dest => dest.Role, opt => opt.Ignore()).ReverseMap();
     
                CreateMap<DesigningSection, DesignSectionDto>().ReverseMap();

                CreateMap<LineType, LineTypeDto>().ReverseMap();
                CreateMap<ProductionEmp, ProductionHeadDto>().ReverseMap();

                CreateMap<ItemSizeWithColor, ItemSizeWithColorDto>().ReverseMap();

                CreateMap<ItemSize, ItemSizeDto>()
                    .ForMember(dest => dest.ItemSizeWithColorDtos, opt => opt.MapFrom(src => src.ItemSizeWithColors))
                    .ReverseMap();
                
                CreateMap<DesignImage, DesignImageDto>()
                 .ForMember(dest => dest.Image, opt => opt.Ignore())
                    .ReverseMap();

                CreateMap<SType, ControlData>().ReverseMap();

                CreateMap<StoreItem, ControlData>().ReverseMap();

                CreateMap<DesigningSection , ControlData>().ReverseMap();

                CreateMap<Step, ControlData>().ReverseMap();
                
                CreateMap<Consuming, ConsumingDto>().ReverseMap();

                CreateMap<Plan, PlanDto>().ReverseMap();

            }
        }
    }
}
