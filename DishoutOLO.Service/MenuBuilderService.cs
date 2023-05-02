
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
using System.Collections;
using Microsoft.IdentityModel.Tokens;
using System;

namespace DishoutOLO.Service
{
    public class MenuBuilderService : IMenuBuilderService
    {
        #region Declarations
        private IRepository<Menu> _menurepository;
        private IRepository<Category> _categoryrepository;
        private IRepository<MenuDetails> _menudetailsrepository;
        private readonly IMapper _mapper;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;

        #endregion  

        #region Constructor
        public MenuBuilderService(IMapper mapper, IRepository<Category> categoryrepository, IRepository<Menu> menurepository, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository, IRepository<MenuDetails> menudetailsrepository)
        {
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _menurepository = menurepository;
            _categoryrepository = categoryrepository;
            _menudetailsrepository = menudetailsrepository;

        }
        #endregion

        #region Get Methods

        public List<AddMenuBuilderModel> GetMenuBuilderList()
        {
            try
            {
                List<AddMenuBuilderModel> data = (from m in _menurepository.GetAll()
                                                  join md in _menudetailsrepository.GetAll()
                                                  on m.Id equals md.MenuId into g
                                                  from md in g.DefaultIfEmpty()
                                                  where m.IsActive == true
                                                  select new AddMenuBuilderModel
                                                  {
                                                      Id = m.Id,
                                                      CategoryId = md.CategoryId,
                                                      ItemId = md.ItemId,
                                                      MenuId = md.MenuId,
                                                      MenuDetailId = md.Id,
                                                      MenuName = m.MenuName,
                                                      Descrition = m.Description,
                                                      CategoryName = m.CategoryName,
                                                  }).OrderByDescending(x => x.Id).ToList();





                if (data != null)
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
