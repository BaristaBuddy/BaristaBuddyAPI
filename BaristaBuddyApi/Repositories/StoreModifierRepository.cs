using BaristaBuddyApi.Data;
using BaristaBuddyApi.Models;
using BaristaBuddyApi.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public class StoreModifierRepository : IstoreModifierRepository
    {

        private BaristaBuddyDbContext _context;

        public StoreModifierRepository(BaristaBuddyDbContext _context)
        {
            this._context = _context;
        }

        public async Task<StoreModifierDTO> DeleteModifier(int modifierId, int storeId)
        {
            var modifier = await _context.StoreModifier.FindAsync(modifierId);

            if (modifier ==null)
            {
                return null;
            }

            var modifierToReturn = await GetOneModifier(modifierId, storeId);

            _context.Remove(modifier);
            await _context.SaveChangesAsync();

            return modifierToReturn;

        }


        public async Task<IEnumerable<StoreModifierDTO>> GetAllModifiers(int storeId)
        {
            var allModifier = await _context.StoreModifier
                .Where(modifier => modifier.StoreId == storeId)
                .Select(modifer => new StoreModifierDTO
                {
                    ModifierId = modifer.ModifierId,
                    Name = modifer.Name,
                    Description = modifer.Description,
                    StoreId = modifer.StoreId

                }).ToListAsync();

            return allModifier;
        }

        public async Task<StoreModifierDTO> GetOneModifier(int storeId, int ModifierId)
        {
            var oneModifier = await _context.StoreModifier
                  .Where(modifier => modifier.StoreId == storeId)
                  .Select(modifer => new StoreModifierDTO
                  {
                      ModifierId = modifer.ModifierId,
                      Name = modifer.Name,
                      Description = modifer.Description,
                      StoreId = modifer.StoreId

                  }).FirstOrDefaultAsync();

            return oneModifier;
        }



        public async Task<StoreModifierDTO> SaveNewModifier(StoreModifier modifier, int storeId)
            {
                var newModifier = new StoreModifier
                {
                    ModifierId= modifier.ModifierId,
                    Name = modifier.Name,
                    Description = modifier.Description,
                    StoreId= modifier.StoreId
                };

               _context.StoreModifier.Add(newModifier);

              await _context.SaveChangesAsync();

               var modifierToRetun = await GetOneModifier(storeId, modifier.ModifierId);
               return modifierToRetun;
           }


        public async Task<bool> UpdateModifier(int modifierId, int itemId, StoreModifierDTO modifier)
        {
            _context.Entry(modifier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModifierExists(modifierId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }



        private bool ModifierExists(int id)
            {
                return _context.Item.Any(e => e.ItemId == id);
            }
        }
    }
