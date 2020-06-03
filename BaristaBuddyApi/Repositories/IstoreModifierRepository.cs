using BaristaBuddyApi.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaristaBuddyApi.Repositories
{
    public interface IstoreModifierRepository
    {
        Task<IEnumerable<StoreModifierDTO>> GetAllModifier();
        Task<StoreModifierDTO> GetOneModifier(int modifierId);
        Task<bool> UpdateModifier( int modifierId);
        Task<StoreModifierDTO> SaveNewModifier(StoreModifierDTO modifier);
        Task<StoreModifierDTO> DeleteModifier(int modifierId); 
    }
}
