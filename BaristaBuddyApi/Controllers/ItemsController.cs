using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Repositories;
using BaristaBuddyApi.Models.DTO;

namespace BaristaBuddyApi.Controllers
{
    [Route("api/Stores/{storeId}/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IitemsRepository itemRepository;

        public ItemsController(IitemsRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        // GET: api/Stores/{storeId}/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAllItems(int storeId)
        {
            return Ok(await itemRepository.GetAllItems(storeId));
        }

        // GET: api/Stores/{storeId}/Items/5
        [HttpGet("{itemId}")]
        public async Task<ActionResult<ItemDTO>> GetItem(int storeId, int itemId)
        {
            var item = await itemRepository.GetOneItem(storeId, itemId);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Stores/{storeId}/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{itemId}")]
        public async Task<IActionResult> PutItem(int storeId, int itemId, Item item)
        {
            if (itemId != item.ItemId)
            {
                return BadRequest();
            }

            bool didUpdate = await itemRepository.UpdateItem(storeId, itemId, item);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Stores/{storeId}/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> PostItem(CreateItem createItem, int storeId)
        {
            await itemRepository.SaveNewItem(createItem, storeId);

            return CreatedAtAction("GetItem", new { storeId = storeId, itemId = createItem.ItemId }, createItem);                
        }
        
        // DELETE: api/Stores/{storeId}/Items/5
        [HttpDelete("{itemId}")]
        public async Task<ActionResult<ItemDTO>> DeleteItem(int storeId, int itemId)
        {
            var item = await itemRepository.DeleteItem(storeId, itemId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        //Get all modifiers for a given store and item
        [HttpGet("{itemId}/Modifiers")]
        public async Task<ActionResult<IEnumerable<ItemModifierDTO>>> GetItemModifiers(int storeId, int itemId)
        {
            return Ok(await itemRepository.GetAllItemModifiers(storeId, itemId));
        }

        //Creating new Modifier
        [HttpPost("{itemId}/Modifiers")]
        public async Task<ActionResult<ItemModifierDTO>> AddNewItemModifier(int storeId, int itemId, ItemModifier itemModifier)
        {
            var result = await itemRepository.AddNewItemModifier( itemId, itemModifier);
            return result;
        }

        //Getting all sizes for an item
        [HttpGet("{itemId}/Sizes")]
        public async Task<ActionResult<IEnumerable<ItemSizeDTO>>> GetItemSizes(int storeId, int itemId)
        {
            return Ok(await itemRepository.GetAllItemSizes(storeId, itemId));
        }

        //Updating size information
        [HttpPut("{itemId}/Sizes/{sizeId}")]
        public async Task<IActionResult> PutItemSize( int itemId, string sizeId,  ItemSize itemSize)
        {
            if (sizeId != itemSize.Size)
            {
                return BadRequest();
            }

            bool didUpdate = await itemRepository.UpdateItemSize( itemId, sizeId, itemSize);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }

        //Creating New Size
        [HttpPost("{itemId}/Sizes")]
        public async Task<ActionResult<ItemSizeDTO>> AddNewItemSize( int itemId, ItemSize itemSize)
        {
            var result = await itemRepository.AddNewItemSize( itemId, itemSize);
            return result;
        }

        //Deleting Item Size
        [HttpDelete("{itemId}/Sizes/{sizeId}")]
        public async Task<ActionResult<ItemSizeDTO>> DeleteItemSize(int itemId, string sizeId)
        {
            var item = await itemRepository.DeleteItemSize( itemId, sizeId);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
