using AutoMapper;
using IntusProject.Shared;
using IntusService.ServiceModel;

namespace IntusProject.Server.Mapping
{
    public class SharedModelProfile : Profile
    {
        public SharedModelProfile()
        {
            CreateMap<SubElementDTO, SubElement>();
            CreateMap<OrderDTO, Order>();
            CreateMap<WindowDTO, Window>();
        }
    }
}
