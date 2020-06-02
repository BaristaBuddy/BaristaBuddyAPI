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

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetAllItems(int storeId)
        {
            return Ok(await itemRepository.GetAllItems(storeId));
        }

        // GET: api/Items/5
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
        
        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            bool didUpdate = await itemRepository.UpdateItem(id, item);

            if (!didUpdate)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ItemDTO>> PostItem(Item item)
        {
            await itemRepository.SaveNewItem(item);

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }
        /*
        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

      */
    }
}
