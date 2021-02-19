using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdateBasket(CustomerBasket basket)
        {
            var newOrUpdatedBasket = await _basketRepository.CreateOrUpdateBasketAsync(basket);
            return Ok(newOrUpdatedBasket);
        }

        [HttpDelete]
        public async Task DeleetBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}