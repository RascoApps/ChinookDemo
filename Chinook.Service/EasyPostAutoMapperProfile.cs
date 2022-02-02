using AutoMapper;
using Chinook.DataStore.SqlServer;
using Chinook.Service.Models;
using Chinook.Service.Models.EasyPost;

namespace Chinook.Service;

public class EasyPostAutoMapperProfile : Profile
{
    public EasyPostAutoMapperProfile()
    {
        CreateMap<Rate, CustomerShippingRate>(MemberList.None).ForMember(d => d.EasyPostRateId, s => s.MapFrom(t => t.Id)).ForMember(d => d.CustomerShippingRateId, t => t.Ignore());
        CreateMap<Customer, ToCustomer>().ForMember(d => d.CustomerId, t => t.Ignore());
        CreateMap<Customer, FromCustomer>().ForMember(d => d.CustomerId, t => t.Ignore());
        CreateMap<IEnumerable<CustomerShippingRate>, CustomerShippingRateResponse>().ForMember(d => d.ShippingRates, s => s.MapFrom(t => t));
        CreateMap<Customer, Address>()
            .ForMember(d => d.Street1, s => s.MapFrom(c => c.Address))
            .ForMember(d => d.City, s => s.MapFrom(c => c.City))
            .ForMember(d => d.State, s => s.MapFrom(c => c.State))
            .ForMember(d => d.Zip, s => s.MapFrom(c => c.PostalCode))
            .ForMember(d => d.Country, s => s.MapFrom(c => c.Country));

    }
}