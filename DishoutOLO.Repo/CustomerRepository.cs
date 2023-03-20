using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
            
namespace DishoutOLO.Repo
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DishoutOLOContext Context) : base(Context)
        {

        }
    }
}
