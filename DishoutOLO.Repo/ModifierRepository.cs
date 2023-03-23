using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;


namespace DishoutOLO.Repo
{
    public class ModifierRepository:Repository<Modifier>,IModifierRepository
    {
        public ModifierRepository(DishoutOLOContext context) : base(context)
        {
            
        }
    }
}
