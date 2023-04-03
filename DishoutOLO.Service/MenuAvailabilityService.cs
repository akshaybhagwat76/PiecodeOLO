

using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{

    public class MenuAvailabilityService:IMenuAvailabilityService
    {
        private IRepository<MenuAvailabilities> _menuAvailabilitiesRepository;
        private IMapper _mapper;    

        public MenuAvailabilityService(IRepository<MenuAvailabilities> menuAvailabilitiesRepository,IMapper mapper)
        {
                      
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
        }

        public DishoutOLOResponseModel AddOrUpdateMenuAvailabilities(AddMenuAvaliblities data)
        {
            try
            {
                
                if (data.Id == 0)
                {
                    MenuAvailabilities menuAvailabilities = _mapper.Map<AddMenuAvaliblities, MenuAvailabilities>(data);
                    menuAvailabilities.CreationDate = DateTime.Now;
                    menuAvailabilities.IsActive = true;
                    _menuAvailabilitiesRepository.Insert(menuAvailabilities);

                }
                else
                {
                    MenuAvailabilities menuavailabilities = _menuAvailabilitiesRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                    DateTime CreationDate = menuavailabilities.CreationDate ?? new DateTime();
                    menuavailabilities = _mapper.Map<AddMenuAvaliblities, MenuAvailabilities>(data);
                    menuavailabilities.CreationDate = CreationDate;
                    menuavailabilities.ModifiedDate = DateTime.Now;
                    menuavailabilities.IsActive = true;
                    _menuAvailabilitiesRepository.Update(menuavailabilities);
                }
            
                                      
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "menuavailabilities") : string.Format(Constants.UpdatedSuccessfully, "menuavailabilities") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }


        public DishoutOLOResponseModel DeleteMenuAvailabilities(int data)
        {
            try
            {
                MenuAvailabilities menuavailabilities = _menuAvailabilitiesRepository.GetByPredicate(x => x.Id == data);

                if (menuavailabilities != null)
                {
                    menuavailabilities.IsActive = false;
                    _menuAvailabilitiesRepository.Update(menuavailabilities);
                    _menuAvailabilitiesRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Menu") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }


        

    }
}
