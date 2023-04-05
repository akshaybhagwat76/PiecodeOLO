using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.ViewModel;

namespace DishoutOLO.Service.Interface
{
    public interface IMenuAvailabilityService
    {
        public DishoutOLOResponseModel AddOrUpdateMenuAvailabilities(AddMenuAvaliblities data);
        public DishoutOLOResponseModel DeleteMenuAvailabilities(int data);
         


    }
}
