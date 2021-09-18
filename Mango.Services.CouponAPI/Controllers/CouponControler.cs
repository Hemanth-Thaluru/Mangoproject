using Mango.Services.CouponAPI.Models.Dtos;
using Mango.Services.CouponAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.CouponAPI.Controllers
{
    [ApiController]
    [Route("api/coupon")]
    public class CouponControler : Controller
    {
        private readonly ICouponRepository _couponRepository;
        //private readonly ICouponRepository _couponRepository;
        //private readonly IMessageBus _messageBus;
        protected ResponseDto _response;
        //private readonly IRabbitMQCartMessageSender _rabbitMQCartMessageSender;

        public CouponControler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
            this._response = new ResponseDto();
        }


        [HttpGet("{code}")]
        public async Task<object> GetDiscountForCode(string code)
        {
            try
            {
                CouponDto coupon = await _couponRepository.GetCouponByCode(code);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
