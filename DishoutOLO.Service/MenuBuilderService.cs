

using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class MenuBuilderService:IMenuBuilderService
    {
        #region Declarations
        private IRepository<Menu> _menubuilderRepository;
        #endregion

        #region Constructor
        public MenuBuilderService(IRepository<Menu> menuRepository)
        {
            _menubuilderRepository = menuRepository;
        }
        #endregion

        #region Get methods


        #endregion













    }



}
