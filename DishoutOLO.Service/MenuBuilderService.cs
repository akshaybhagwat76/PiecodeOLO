
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Repo.Migrations;
using DishoutOLO.ViewModel.Helper;
using DishoutOLO.ViewModel;
using DishoutOLO.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace DishoutOLO.Service
{
    public class MenuBuilderService : IMenuBuilderService
    {
        #region Declarations
        private IRepository<Item> _itemRepository;
        private IRepository<Menu> _menurepository;

        private readonly IMapper _mapper;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;

        #endregion  

        #region Constructor
        public MenuBuilderService(IMapper mapper, IRepository<Menu> menurepository, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository, IRepository<Item> itemRepository)
        {
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _menurepository = menurepository;
            _itemRepository = itemRepository;
        }
        #endregion




        #region Get Methods
        public List<AddMenuBuilderModel> GetMenuBuilderList()
        {
            try
            {

                var data = _menurepository.GetAll()
                                      .Select(y => new AddMenuBuilderModel()
                                      {
                                          Id = y.Id,
                                          MenuName = y.MenuName,
                                          Descrition = y.Description,
                                          ListAvaliblities = null,
                                          ItemModels = null

                                      }).OrderByDescending(x => x.Id).ToList();

                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var menuAvailabilities = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive == true && x.Id == item.Id).ToList();
                        var menuRelatedAvailabilities = _mapper.Map<List<Data.MenuAvailabilities>, List<AddMenuAvaliblities>>(menuAvailabilities);

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


        #endregion
    }
}
