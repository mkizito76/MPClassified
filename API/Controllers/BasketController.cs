using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdateBasket(CustomerBasketDto basket)
        {

            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            var newOrUpdatedBasket = await _basketRepository.CreateOrUpdateBasketAsync(customerBasket);
            return Ok(newOrUpdatedBasket);
        }

        [HttpDelete]
        public async Task DeleetBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}