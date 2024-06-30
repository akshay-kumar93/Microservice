using AutoMapper;
using Mango.Service.Coupin.Model;
using Mango.Service.Coupin.Model.dto;

namespace Mango.Service.Coupin
{
    public class mappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
