
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
using Microsoft.AspNetCore.Http;

namespace DishoutOLO.Service
{
    public class MenuBuilderService : IMenuBuilderService
    {
        #region Declarations
        private IRepository<Menu> _menurepository;
        private IRepository<Category> _categoryrepository;
        private IRepository<MenuDetails> _menudetailsrepository;
        private IRepository<Item> _itemrepository;
        private readonly IMapper _mapper;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;

        #endregion  

        #region Constructor
        public MenuBuilderService(IMapper mapper, IRepository<Category> categoryrepository, IRepository<Menu> menurepository, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository, IRepository<MenuDetails> menudetailsrepository, IRepository<Item> itemrepository)
        {
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _menurepository = menurepository;
            _categoryrepository = categoryrepository;
            _menudetailsrepository = menudetailsrepository;
            _itemrepository = itemrepository;
        }
        #endregion

        #region Get Methods

        public List<AddMenuBuilderModel> GetMenuBuilderList()
        {
            try
            {
                List<AddMenuBuilderModel> data = (from mn in _menurepository.GetAll()
                            join ca in _categoryrepository.GetAll() on mn.CategoryId equals ca.Id into catGroup
                            from cat in catGroup.DefaultIfEmpty()
                            join md in _menudetailsrepository.GetAll() on mn.Id equals md.MenuId into detailGroup
                            from detail in detailGroup.DefaultIfEmpty()
                            join it in _itemrepository.GetAll() on int.Parse(mn.ItemId) equals it.Id into itemGroup
                            from item in itemGroup.DefaultIfEmpty()
                            select new AddMenuBuilderModel
                            {
                                MenuId = mn.Id,
                                MenuName = mn.MenuName,
                                Descrition = mn.Description,
                                CategoryName = cat.CategoryName,
                                ItemId = mn.ItemId ,
                                CategoryId = mn.CategoryId,
                                ListAvaliblities = (_mapper.Map<List<Data.MenuAvailabilities>, List<AddMenuAvaliblities>>(_menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive == true && x.Id == mn.Id).ToList()))
                            }).ToList();



                

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
