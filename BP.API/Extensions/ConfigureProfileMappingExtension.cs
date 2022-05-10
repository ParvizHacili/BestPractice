
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BP.API.Extensions
{
    public static class ConfigureProfileMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mapConfig = new MapperConfiguration(i => i.AddProfile(new AutoMapperProfile()));

            IMapper mapper = mapConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BP.API.Data.Models.Contact, BP.API.Models.ContactDVO>()
                .ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName))
                .ReverseMap();
        }
    }
}
