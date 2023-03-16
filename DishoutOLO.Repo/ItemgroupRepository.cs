using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
     public class ItemgroupRepository : Repository<ItemGroup>, IitemgroupRepository

    {
        public ItemgroupRepository(DishoutOLOContext itemContext) : base(itemContext)
        {
        }

        
    }
}
