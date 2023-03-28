using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(DishoutOLOContext context) : base(context)
        {

        }
    }
}

