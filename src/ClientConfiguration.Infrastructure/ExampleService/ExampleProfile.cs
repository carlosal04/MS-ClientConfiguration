using AutoMapper;
using ClientConfiguration.Domain.Models;

namespace ClientConfiguration.Infrastructure.ExampleService
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<ExampleEntity, Example>()
                .ReverseMap();
        }
    }
}