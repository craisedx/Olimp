using AutoMapper;
using Olimp.ViewModels.Mappings;

namespace Olimp.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<MappingProfile>();
            });

            mapperConfig.AssertConfigurationIsValid();
        }
    }
}
