using AutoMapper;
using Mango.Service.Coupin.Data;
using Mango.Service.Coupin.Model;
using Mango.Service.Coupin.Model.dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Service.Coupin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoupinApiController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private ResponseDto _responseDto;

        public CoupinApiController(AppDbContext appDbContext, IMapper mapper )
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto GetAll()
        {
            try
            {
                IEnumerable<Coupon> result = _appDbContext.coupons.ToList();
                _responseDto.Result = result;
            } catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("byId")]
        public ResponseDto GetAll(int id)
        {
            try
            {
                Coupon result = _appDbContext.coupons.First(i=>i.CouponId ==id);
                _responseDto.Result = result;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("getByCode")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon result = _appDbContext.coupons.First(i => i.CouponCode.ToLower() == code.ToLower());
                _responseDto.Result = _mapper.Map<Coupon>(result);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        [Route("addNewCoupin")]
        public ResponseDto AddCoupin([FromBody]CouponDto couponDto)
        {
            try
            {
                Coupon res = _mapper.Map<Coupon>(couponDto);
                _appDbContext.coupons.Add(res);
                _appDbContext.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(res);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return (_responseDto);
        }


        [HttpPut]
        [Route("UpdateCoupin")]
        public ResponseDto UpdateCoupin([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon result = _mapper.Map<Coupon>(couponDto);
                _appDbContext.coupons.Update(result);
                _appDbContext.SaveChanges();
                _responseDto.Result = _mapper.Map<CouponDto>(result);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return (_responseDto);
        }


        [HttpDelete]
        [Route("DeleteCoupin")]
        public ResponseDto DeleteCoupin(int id)
        {
            try
            {
                Coupon coupin = _appDbContext.coupons.FirstOrDefault(i => i.CouponId == id);
                _appDbContext.coupons.Remove(coupin);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return (_responseDto);
        }

    }
}
