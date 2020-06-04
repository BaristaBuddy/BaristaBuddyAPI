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
    [Route("api/Stores/{storeId}/Modifiers")]
    [ApiController]
    public class StoreModiferController : ControllerBase
    {

        IstoreModifierRepository storeModifierRepository;

        public StoreModiferController(IstoreModifierRepository storeModifierRepository)
        {
            this.storeModifierRepository = storeModifierRepository;
        }



        //// GET: api/Stores/{storeId}/Modifier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreModifierDTO>>> GetModifiers(int storeId)
        {
            return Ok(await storeModifierRepository.GetAllModifiers(storeId));
        }



        //// GET: api/Stores/{storeId}/Modifier/5
        [HttpGet("{modifierId}")]
        public async Task<ActionResult<StoreModifierDTO>> GetModifier(int modifierId, int storeId)
        {
            var modifier = await storeModifierRepository.GetOneModifier(modifierId, storeId);

            if (modifier == null)
            {
                return NotFound();
            }

            return modifier;
        }

        //// PUT: api/Stores/{storeId}/Modifier/5

        [HttpPut("{modifierId}")]
            public async Task<IActionResult> PutModifier(int modifierId, int storeId , StoreModifier modifier)
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

            //// POST: api/Stores/{storeId}/Modifier
          
            [HttpPost]
            public async Task<ActionResult<StoreModifierDTO>> PostItem(StoreModifier modifier, int storeId)
            {
                await storeModifierRepository.SaveNewModifier(modifier, storeId);

                return CreatedAtAction("GetModifier", new { storeId = storeId, modifierId = modifier.ModifierId}, modifier);
            }

            
           


        }
    }

