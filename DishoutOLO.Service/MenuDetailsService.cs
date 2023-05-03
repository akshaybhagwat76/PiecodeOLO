
using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class MenuDetailsService:IMenuDetailsService
    {
        #region Declarations
        private IRepository<MenuDetails> _menudetailsRepository;
        private IMapper _mapper;
        #endregion


        #region Constructor
        public MenuDetailsService(IRepository<MenuDetails> menudetailsRepository, IMapper mapper)
        {
             _mapper = mapper;
            _menudetailsRepository = menudetailsRepository;
        }
        #endregion


        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateMenuDetails(AddMenuDetailsModel data)
        {
            try
                {

                if (data.Id == 0)
                {
                    MenuDetails menudetails = _mapper.Map<AddMenuDetailsModel, MenuDetails>(data);
                    menudetails.CreationDate = DateTime.Now;
                    menudetails.IsActive = true;
                    _menudetailsRepository.Insert(menudetails);

                }
                else
                {
                    MenuDetails menudetails = _menudetailsRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                    DateTime CreationDate = menudetails.CreationDate ?? new DateTime();
                    menudetails = _mapper.Map<AddMenuDetailsModel, MenuDetails>(data);
                    menudetails.CreationDate = CreationDate;
                    menudetails.ModifiedDate = DateTime.Now;
                    menudetails.IsActive = true;
                    _menudetailsRepository.Update(menudetails);
                }


                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "MenuDetails") : string.Format(Constants.UpdatedSuccessfully, "MenuDetails") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }


        

        #endregion
    }
}
