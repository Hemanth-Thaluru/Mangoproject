﻿using Mango.MessageBus;
using Mango.Services.ShoppingCartAPI.Messages;
using Mango.Services.ShoppingCartAPI.Models.Dtos;
using Mango.Services.ShoppingCartAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : Controller
    {
       
       
            private readonly ICartRepository _cartRepository;
            //private readonly ICouponRepository _couponRepository;
             private readonly IMessageBus _messageBus;
            protected ResponseDto _response;
            //private readonly IRabbitMQCartMessageSender _rabbitMQCartMessageSender;

            public CartController(ICartRepository cartRepository)
            {
                _cartRepository = cartRepository;
                //_couponRepository = couponRepository;
                //_rabbitMQCartMessageSender = rabbitMQCartMessageSender;
                //_messageBus = messageBus;
                this._response = new ResponseDto();
            }

            [HttpGet("GetCart/{userId}")]
            public async Task<object> GetCart(string userId)
            {
                try
                {
                    CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                    _response.Result = cartDto;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Errormessages = new List<string>() { ex.ToString() };
                }
                return _response;
            }

            [HttpPost("AddCart")]
            public async Task<object> AddCart(CartDto cartDto)
            {
                try
                {
                    CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                    _response.Result = cartDt;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Errormessages = new List<string>() { ex.ToString() };
                }
                return _response;
            }

            [HttpPost("UpdateCart")]
            public async Task<object> UpdateCart(CartDto cartDto)
            {
                try
                {
                    CartDto cartDt = await _cartRepository.CreateUpdateCart(cartDto);
                    _response.Result = cartDt;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Errormessages = new List<string>() { ex.ToString() };
                }
                return _response;
            }

            [HttpPost("RemoveCart")]
            public async Task<object> RemoveCart([FromBody] int cartId)
            {
                try
                {
                    bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
                    _response.Result = isSuccess;
                }
                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.Errormessages = new List<string>() { ex.ToString() };
                }
                return _response;
            }


        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCOupon([FromBody] CartDto cartdto)
        {
            try
            {
                bool isSuccess = await _cartRepository.ApplyCoupon(cartdto.CartHeader.UserId,cartdto.CartHeader.CouponCode);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveCoupon(userId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                if(cartDto==null)
                {
                    return true;
                }
                checkoutHeader.CartDetails = cartDto.CartDetails;
                await _messageBus.PublishMessage(checkoutHeader, "checkoutmessagetopic");
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
