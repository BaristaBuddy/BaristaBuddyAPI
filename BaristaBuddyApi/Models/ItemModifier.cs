namespace BaristaBuddyApi.Models
{
    public class ItemModifier
    {
        // PK, FK to Item
        public int ItemId { get; set; }
        public Item Item { get; set; }

        // PK, FK to StoreModifier
        public int ModifierId { get; set; }
        public StoreModifier StoreModifier { get; set; }

        public double AdditionalCost { get; set; }
    }
}
