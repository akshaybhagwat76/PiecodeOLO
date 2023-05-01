
using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.Service.Interface;
using AutoMapper;
using System.Data;
using DishoutOLO.Repo;
using DishoutOLO.ViewModel.Helper;
using DishoutOLO.Repo.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using MenuDetail = DishoutOLO.Data.MenuDetails;

namespace DishoutOLO.Service
{
    public class MenuBuilderService : IMenuBuilderService
    {
        #region Declarations
        private IRepository<Menu> _menurepository;
        private IRepository<Category> _categoryrepository;
         private readonly IMapper _mapper;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;

        #endregion  

        #region Constructor
        public MenuBuilderService(IMapper mapper, IRepository<Category> categoryrepository, IRepository<Menu> menurepository, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository)
        {
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _menurepository = menurepository;
            _categoryrepository = categoryrepository;
        }
        #endregion
         
        #region Get Methods
        public List<AddMenuBuilderModel> GetMenuBuilderList()
        {
            try
            {

                List<AddMenuBuilderModel> data = _menurepository.GetAll()
                                      .Select(y => new AddMenuBuilderModel()
                                      {
                                          Id = y.Id,
                                          MenuName = y.MenuName,
                                          Descrition = y.Description,
                                          ListAvaliblities = null,
                                          CategoryId = y.CategoryId,
                                         
                                      }).OrderByDescending(x => x.Id).ToList();

                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var menuAvailabilities = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive == true && x.Id == item.Id).ToList();
                        var menuRelatedAvailabilities = _mapper.Map<List<Data.MenuAvailabilities>, List<AddMenuAvaliblities>>(menuAvailabilities);
                        item.CategoryName = _categoryrepository.GetByPredicate(x => x.Id == item.CategoryId).CategoryName;
                        if (item != null)
                        {
                            item.ListAvaliblities = menuRelatedAvailabilities;
                        }
                    }
                   
                }
                
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Menu> GetMenuById(int id)
        {
            var menubyid = _menurepository.GetListByPredicate(x => x.IsActive == true && x.CategoryId == id).ToList();
            return menubyid;
        }

       

        #endregion
    }
}
