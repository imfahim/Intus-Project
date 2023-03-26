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
            CreateMap<SubElement, SubElementDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<WindowDTO, Window>();
            CreateMap<Window, WindowDTO>();
        }
    }
}
