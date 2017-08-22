namespace WebApi.Controllers
{
    using AutoMapper;
    using Entity;
    using System;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            UnitProfiler();

            CompanyProfiler();

            ProductProfiler();
        }

        private void UnitProfiler()
        {
            CreateMap<Unit, UnitViewModel>();

            CreateMap<Unit, Unit>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.CreatedBy, opt => opt.Ignore())
                .ForMember(u => u.CreatedAt, opt => opt.Ignore());

            CreateMap<UnitViewModel, Unit>()
                .ForMember(u => u.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(u => u.CreatedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.ModifiedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.CreatedAt, opt => opt.UseValue(DateTime.Now))
                .ForMember(u => u.ModifiedAt, opt => opt.UseValue(DateTime.Now));
        }

        private void CompanyProfiler()
        {
            CreateMap<Company, CompanyViewModel>();

            CreateMap<Company, Company>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.CreatedBy, opt => opt.Ignore())
                .ForMember(u => u.CreatedAt, opt => opt.Ignore());

            CreateMap<CompanyViewModel, Company>()
                .ForMember(u => u.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(u => u.CreatedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.ModifiedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.CreatedAt, opt => opt.UseValue(DateTime.Now))
                .ForMember(u => u.ModifiedAt, opt => opt.UseValue(DateTime.Now));
        }

        private void ProductProfiler()
        {
            CreateMap<Product, ProductViewModel>();

            CreateMap<Product, Product>()
                .ForMember(u => u.Id, opt => opt.Ignore())
                .ForMember(u => u.CreatedBy, opt => opt.Ignore())
                .ForMember(u => u.CreatedAt, opt => opt.Ignore());

            CreateMap<ProductViewModel, Product>()
                .ForMember(u => u.Id, opt => opt.MapFrom(o => Guid.NewGuid()))
                .ForMember(u => u.CreatedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.ModifiedBy, opt => opt.UseValue("sudhakar"))
                .ForMember(u => u.CreatedAt, opt => opt.UseValue(DateTime.Now))
                .ForMember(u => u.ModifiedAt, opt => opt.UseValue(DateTime.Now));
        }
    }
}
