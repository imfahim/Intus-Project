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
            CreateMap<Window, WindowDTO>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
