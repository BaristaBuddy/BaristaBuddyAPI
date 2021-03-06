﻿using System;
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
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        IStoreRepository storeRepository;

        public StoresController(IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
        }

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDTO>>> GetStores()
        {
            return Ok(await storeRepository.GetAllStores());

        }

        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {

            return Ok(await storeRepository.GetOneStore(id));
           
        }

        // PUT: api/Stores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public  async Task<IActionResult> PutStore(int id, Store store)
        {
            if (id != store.Id)
            {
                return BadRequest();
            }

            bool didUpdate = await storeRepository.UpdateStore(id, store);

            if (!didUpdate)
            {
                return NotFound();
            }



            return NoContent();
        }

        // POST: api/Stores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Store>> PostStore(Store store)
        {
            await storeRepository.SaveNewStore(store);

            return CreatedAtAction("GetStore", new { id = store.Id }, store);
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StoreDTO>> DeleteStore(int id)
        {
            var store = await storeRepository.DeleteStore(id);

            if (store == null)
            {
                return NotFound();

            }
            return store;
        }

      
    }
}
