using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;

namespace DishoutOLO.Repo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DishoutOLOContext Context) : base(Context)
        {

        }
    }

}
