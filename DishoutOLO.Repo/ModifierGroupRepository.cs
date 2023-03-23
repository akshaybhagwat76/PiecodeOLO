using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;


namespace DishoutOLO.Repo
{
    public class ModifierGroupRepository : Repository<ModifierGroup>, IModifierGroupRepository
    {
        public ModifierGroupRepository(DishoutOLOContext context) : base(context)
        {

        }
    }

}
