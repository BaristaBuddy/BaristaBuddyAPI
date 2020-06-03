using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    public class StoreModiferController : ControllerBase
    {
        [Route("api/Stores/{storeId}/Modifier")]
        [ApiController]
    
                IstoreModifierRepository storeModifierRepository;

            public StoreModiferController( StoreModifierRepository storeModifierRepository)
            {
                this.storeModifierRepository = storeModifierRepository;
            }



            //// GET: api/Stores/{storeId}/Items
            //[HttpGet]
            //public async Task<ActionResult<IEnumerable<StoreModifierDTO>>> GetAllItems(int modifierId)
            //{
            //    return Ok(await storeModifierRepository.GetAllItems(modifierId));
            //}



            //// GET: api/Stores/{storeId}/Items/5
            //[HttpGet("{itemId}")]
            //public async Task<ActionResult<ItemDTO>> GetItem(int storeId, int itemId)
            //{
            //    var item = await itemRepository.GetOneItem(storeId, itemId);

            //    if (item == null)
            //    {
            //        return NotFound();
            //    }

            //    return item;
            //}

            //// PUT: api/Stores/{storeId}/Items/5
            //// To protect from overposting attacks, enable the specific properties you want to bind to, for
            //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            //[HttpPut("{id}")]
            //public async Task<IActionResult> PutItem(int storeId, int itemId, Item item)
            //{
            //    if (itemId != item.ItemId)
            //    {
            //        return BadRequest();
            //    }

            //    bool didUpdate = await itemRepository.UpdateItem(storeId, itemId, item);

            //    if (!didUpdate)
            //    {
            //        return NotFound();
            //    }

            //    return NoContent();
            //}

            //// POST: api/Stores/{storeId}/Items
            //// To protect from overposting attacks, enable the specific properties you want to bind to, for
            //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            //[HttpPost]
            //public async Task<ActionResult<ItemDTO>> PostItem(CreateItem createItem, int storeId)
            //{
            //    await itemRepository.SaveNewItem(createItem, storeId);

            //    return CreatedAtAction("GetItem", new { storeId = storeId, itemId = createItem.ItemId }, createItem);
            //}

            // DELETE: api/Stores/{storeId}/Items/5
            [HttpDelete("{itemId}")]
            public async Task<ActionResult<StoreModifierDTO>> DeleteItem(int modifierId)
            {
                var item = await storeModifierRepository.DeleteModifier( modifierId);

                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }


        }
    }

