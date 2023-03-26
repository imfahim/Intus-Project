using AutoMapper;
using IntusRepository.Entity;
using IntusService.ServiceModel;

namespace IntusService.Mapping
{
    public class ServiceModelProfile : Profile
    {
        public ServiceModelProfile()
        {
            CreateMap<SubElement, SubElementDTO>();
            CreateMap<SubElementDTO, SubElement>();
            CreateMap<Window, WindowDTO>();
            CreateMap<WindowDTO, Window>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
