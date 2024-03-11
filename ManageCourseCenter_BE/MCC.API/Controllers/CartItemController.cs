﻿using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("get-cart_item_by_parent_id")]
        public async Task<IActionResult> GetCartItemByParentIDAsync(int parentId)
        {
            var result = await _cartItemService.getCartItemByParentIDAsync(parentId);
            return Ok(result);
        }

        [HttpDelete("delete-cart-item")]
        public async Task<IActionResult> DeleteCartItem(int cartItemId)
        {
            var result = await _cartItemService.DeleteCartItemAsync(cartItemId);
            return Ok(result);
        }
    }
}