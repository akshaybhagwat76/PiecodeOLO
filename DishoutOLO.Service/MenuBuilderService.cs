  
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
        private IRepository<MenuBuilder> _menubuilderRepository;
        private IRepository<Item> _itemRepository;

        private readonly IMapper _mapper;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;

        #endregion  

        #region Constructor
        public MenuBuilderService(IRepository<MenuBuilder> menubuilderRepository, IMapper mapper, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository, IRepository<Item> itemRepository)
        {
            _menubuilderRepository = menubuilderRepository;
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _itemRepository = itemRepository;   
        }
        #endregion

        #region Get Methods
        public List<AddMenuBuilderModel> GetMenuBuilderList()
        {
            try
            {
     
                var data = _menubuilderRepository.GetAll()
                                      .Select(y => new AddMenuBuilderModel()
                                      {
                                          Id = y.Id,
                                          MenuName = y.MenuName,
                                          Descrition = y.Descrition,
                                          Week = y.Week,
                                         
                                          FullTime = y.FullTime.ToString(),
                                          ListAvaliblities = null,
                                          ItemModels=null

                                      }).OrderByDescending(x => x.Id).ToList();

                if (data != null && data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        var menuAvailabilities = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive && x.MenuId == item.Id).ToList();
                        var menuRelatedAvailabilities = _mapper.Map<List<Data.MenuAvailabilities>, List<AddMenuAvaliblities>>(menuAvailabilities);

                        var itemdata = _itemRepository.GetListByPredicate(x => x.IsActive && x.Id == item.Id).ToList();
                        var itemRelatedAvailabilities = _mapper.Map<List<Item>, List<AddItemModel>>(itemdata);


                        if (item != null)
                        {
                            item.ListAvaliblities = menuRelatedAvailabilities;
                            item.ItemModels = itemRelatedAvailabilities;
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
