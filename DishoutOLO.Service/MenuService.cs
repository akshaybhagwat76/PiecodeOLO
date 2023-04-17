using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using AutoMapper;
using System.Security.Cryptography;
using DishoutOLO.Repo.Migrations;
using System;
using MenuAvailabilities = DishoutOLO.Data.MenuAvailabilities;
using DishoutOLO.Repo;

namespace DishoutOLO.Service
{
    public class MenuService : IMenuService
    {
        #region Declarations
        private readonly IMapper _mapper;
        private IRepository<Menu> _menuRepository;
        private IRepository<Data.MenuAvailabilities> _menuAvailabilitiesRepository;
        private IRepository<Category> _categoryRepository;
        private IMenuAvailabilityService _menuAvailabilitiesService;

        #endregion
        #region Constructor
        public MenuService(IRepository<Menu> menuRepository, IMenuAvailabilityService userService, IRepository<Category> categoryRepository, IMapper mapper, IRepository<Data.MenuAvailabilities> menuAvailabilitiesRepository)
        {
            _menuRepository = menuRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _menuAvailabilitiesRepository = menuAvailabilitiesRepository;
            _menuAvailabilitiesService = userService;
        }

        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateMenu(AddMenuModel data)
        {
            try
            {
                    Menu Menu = _menuRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive==false && (x.MenuName.ToLower() == data.MenuName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Menu != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Menu.MenuName.ToLower() == data.MenuName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "MenuName", ErrorDescription = "Menu already exist" });
                    }
                    return response;

                }
                if (response.Errors == null)
                {

                    if (data.Id == 0)
                    {
                        Menu tblMenu = _mapper.Map<AddMenuModel, Menu>(data);
                        tblMenu.CreationDate = DateTime.Now;
                        tblMenu.IsActive = true;
                        int menuId = _menuRepository.InsertAndGetId(tblMenu);
                        if (menuId > 0)
                        {

                            var menuavailableity = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive && x.week == data.ListAvaliblities[0].week).ToList();

                            if (data.ListAvaliblities != null && data.ListAvaliblities.Count > 0)
                            {
                                foreach (AddMenuAvaliblities item in data.ListAvaliblities)
                                {
                                    var menuAvailabilities = _mapper.Map<AddMenuAvaliblities, MenuAvailabilities>(item);

                                    item.MenuId = menuId;
                                    _menuAvailabilitiesService.AddOrUpdateMenuAvailabilities(item);

                                }
                            }
                            else
                            {
                                Menu menu = _menuRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                                DateTime CreationDate = menu.CreationDate ?? new DateTime();
                                bool isactive = menu.IsActive;
                                menu = _mapper.Map<AddMenuModel, Menu>(data);
                                menu.CreationDate = CreationDate;
                                menu.IsActive = isactive;
                                menu.ModifiedDate = DateTime.Now;
                                _menuRepository.Update(menu);

                                if (menu.Id > 0)
                                {
                                    if (data.ListAvaliblities != null && data.ListAvaliblities.Count > 0)
                                    {
                                        foreach (AddMenuAvaliblities item in data.ListAvaliblities)
                                        {
                                            item.MenuId = menu.Id;
                                            _menuAvailabilitiesService.AddOrUpdateMenuAvailabilities(item);
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "category") : string.Format(Constants.UpdatedSuccessfully, "category") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteMenu(int data)
        {
            try
            {
                Menu menu = _menuRepository.GetByPredicate(x => x.Id == data);

                if (menu != null)
                {
                    menu.IsActive = false;
                    _menuRepository.Update(menu);
                    _menuRepository.SaveChanges();
                }


                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Menu") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region  Get methods

        public List<Data.MenuAvailabilities> GetMenuAvailabilitiesById(int Id)
        {
            var menuAvailabilities = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive && x.MenuId == Id).ToList();
            return menuAvailabilities;
        }
        public AddMenuModel GetMenu(int Id)
        {
            try
            {

                var menu = _menuRepository.GetListByPredicate(x => x.IsActive && x.Id == Id).Select(y => new ListMenuModel()
                {
                    Id = y.Id,
                    MenuName = y.MenuName,
                    MenuPrice = y.MenuPrice,
                    CategoryId = y.CategoryId,
                    IsActive = y.IsActive,
                    ProgramId = y.ProgramId,
                    Description = y.Description,
                    CategoryName = y.CategoryName,
                    

                }).FirstOrDefault();

                var menuAvailabilities = _menuAvailabilitiesRepository.GetListByPredicate(x => x.IsActive && x.MenuId == Id).ToList();
                var menuRelatedAvailabilities = _mapper.Map<List<Data.MenuAvailabilities>, List<AddMenuAvaliblities>>(menuAvailabilities);

                if (menu != null)
                {
                    AddMenuModel obj = new AddMenuModel
                    {
                        Id = menu.Id,
                        MenuName = menu.MenuName,
                        MenuPrice = menu.MenuPrice,
                        IsActive = menu.IsActive,
                        CategoryId = menu.CategoryId,
                        ProgramId = menu.ProgramId,
                        ProgramName = menu.ProgramName,
                        Description = menu.Description,
                        CategoryName = menu.CategoryName,
                        ListAvaliblities = menuRelatedAvailabilities
                    };
                    return obj;
                }
                return new AddMenuModel();
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTableFilterModel GetMenuList(DataTableFilterModel filter)
        {
            try
            {

                IEnumerable<ListMenuModel> data = (from ct in _categoryRepository.GetAll()
                                                   join mn in _menuRepository.GetAll() on
                                                   ct.Id equals mn.CategoryId

                                                   where mn.IsActive == true
                                                   select new ListMenuModel
                                                   {
                                                       CategoryName = ct.CategoryName,
                                                       MenuName = mn.MenuName,
                                                       MenuPrice = mn.MenuPrice,
                                                       ProgramId = mn.ProgramId,

                                                       Description = mn.Description,
                                                       Id = mn.Id,
                                                   }).AsEnumerable();


                var sortColumn = string.Empty;
                var sortColumnDirection = string.Empty;
                if (filter.order != null && filter.order.Count() > 0)
                {
                    if (filter.order.Count() == 1)
                    {
                        sortColumnDirection = filter.order[0].dir;
                        if (filter.columns.Count() >= filter.order[0].column)
                        {
                            sortColumn = filter.columns[filter.order[0].column].data;
                        }
                    }
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)) && data.Count() > 0)
                        {
                            if (sortColumn.Length > 0)
                            {
                                sortColumn = sortColumn.First().ToString().ToUpper() + sortColumn.Substring(1);
                                if (sortColumnDirection == "asc")
                                {

                                    data = data.OrderByDescending(p => p.GetType()
                                            .GetProperty(sortColumn)
                                            .GetValue(p, null)).ToList();
                                }
                                else
                                {
                                    data = data.OrderBy(p => p.GetType()
                                           .GetProperty(sortColumn)
                                           .GetValue(p, null)).ToList();
                                }
                            }
                        }
                    }
                }

                var totalCount = data.Count();
                if (!string.IsNullOrWhiteSpace(filter.search.value))
                {
                    var searchText = filter.search.value.ToLower();
                    data = data.Where(p => p.MenuName.ToLower().Contains(searchText));
                }
                var filteredCount = data.Count();
                filter.recordsTotal = totalCount;
                filter.recordsFiltered = filteredCount;
                data = data.ToList();
                filter.data = data.Skip(filter.start).Take(filter.length).ToList();

                return filter;
            }
            catch (Exception ex)
            {
                return filter;
            }

        }

        public DishoutOLOResponseModel GetAllMenus()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _menuRepository.GetAll().Where(x => x.IsActive).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false };

            }
        }
        #endregion


    }
}
