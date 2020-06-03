using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using BaristaBuddyApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Controllers
{
    [Route("api/Stores/{storeId}/Modifier")]
    [ApiController]
    public class StoreModiferController : ControllerBase
    {
    
                IstoreModifierRepository storeModifierRepository;

            public StoreModiferController( StoreModifierRepository storeModifierRepository)
            {
                this.storeModifierRepository = storeModifierRepository;
            }



            //// GET: api/Stores/{storeId}/Items
            [HttpGet]
            public async Task<ActionResult<IEnumerable<StoreModifierDTO>>> GetModifiers(int storeId)
            {
                return Ok(await storeModifierRepository.GetAllModifiers(storeId));
            }



            //// GET: api/Stores/{storeId}/Items/5
            [HttpGet("{ModifierId}")]
              public async Task<ActionResult<StoreModifierDTO>> GetModifier(int modifierId , int storeId)
            {
                var modifier = await storeModifierRepository.GetOneModifier(modifierId, storeId);

              if (modifier == null)
              {
                  return NotFound();
             }

              return modifier;
            }

            //// PUT: api/Stores/{storeId}/Items/5
     
            [HttpPut("{id}")]
            public async Task<IActionResult> PutItem(int modifierId, int storeId , StoreModifierDTO modifier)
            {
                if (modifierId != modifier.ModifierId)
               {
                   return BadRequest();
              }

                bool didUpdate = await storeModifierRepository.UpdateModifier( modifierId, storeId, modifier);

                if (!didUpdate)
               {
                   return NotFound();
               }

              return NoContent();
            }

            //// POST: api/Stores/{storeId}/Items
          
            [HttpPost]
            public async Task<ActionResult<ItemDTO>> PostItem(StoreModifier modifier, int storeId)
            {
                await storeModifierRepository.SaveNewModifier(modifier, storeId);

                return CreatedAtAction("GetItem", new { storeId = storeId, modifierId = modifier.ModifierId}, modifier);
            }

            // DELETE: api/Stores/{storeId}/Items/5
            [HttpDelete("{itemId}")]
            public async Task<ActionResult<StoreModifierDTO>> DeleteItem(int modifierId , int storeId)
            {
                var item = await storeModifierRepository.DeleteModifier( modifierId , storeId);

                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }


        }
    }

