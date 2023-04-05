

using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class CoupenRepository : Repository<Coupen>, ICoupenRepository
    {
        public CoupenRepository(DishoutOLOContext Context) : base(Context)
        {

        }
    }

}
