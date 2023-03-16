using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class ItemgroupService:IitemgroupService
    {
        #region Declarations
        private IRepository<Item> _itemRepository;
        private IRepository<ItemGroup> _itemgroupRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public ItemgroupService(IRepository<Item> itemRepository, IMapper mapper, IRepository<ItemGroup> itemgroupRepository)
        {
            _itemRepository = itemRepository;
            _itemgroupRepository = itemgroupRepository;
             _mapper = mapper;
        }

        #endregion


        #region Get Methods
        public DishoutOLOResponseModel GetAllItems()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _itemRepository.GetAll().Where(x => x.IsCombo).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Data = null };

            }
        }
        public DataTableFilterModel GetItemGroupList(DataTableFilterModel filter)
        {
            try
            {
                IEnumerable<ListItemgroupModel> data = (from it in _itemRepository.GetAll()
                                                   join ig in _itemgroupRepository.GetAll() on
                                                   it.Id equals ig.ItemId
                                                   where ig.IsActive == true

                                                   select new ListItemgroupModel
                                                   {
                                                       
                                                       ItemName = it.ItemName,
                                                       ItemGroup = ig.itemGroup,
                                                       DisplayOrder = ig.DisplayOrder,
                                                       IsActive = ig.IsActive,
                                                       Id = it.Id,

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
                    data = data.Where(p => p.ItemGroup.ToLower().Contains(searchText));
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

        public AddItemgroupModel GetItemGroup(int Id)
        {
            try
            {
                ListItemgroupModel item = _itemgroupRepository.GetListByPredicate(x => x.IsActive && x.Id == Id
                                      )
                                      .Select(y => new ListItemgroupModel()
                                      { Id = y.Id, IsActive = y.IsActive,DisplayOrder=y.DisplayOrder,ItemGroup=y.itemGroup,ItemId=y.ItemId }
                                      ).FirstOrDefault();

                if (item != null)
                {
                    AddItemgroupModel obj = new  AddItemgroupModel();
                    obj.Id = item.Id;
                    obj.ItemName = item.ItemName;
                    obj.ItemGroup = item.ItemGroup;
                    obj.DisplayOrder = item.DisplayOrder;
                    obj.ItemId = item.ItemId;

                    return obj;
                }
                return new AddItemgroupModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        #endregion

        #region Crud Methods

        public DishoutOLOResponseModel AddOrUpdateItemGroup(AddItemgroupModel data)
        {
            try
            {
                ItemGroup Item = _itemgroupRepository.GetAllAsQuerable().FirstOrDefault(x => x.IsActive == false && (x.itemGroup.ToLower() == data.ItemGroup.ToLower()));
                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Item != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Item.itemGroup.ToLower() == data.ItemGroup.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "ItemGroup", ErrorDescription = "ItemGroup already exist" });
                    }

                }
                if (response.Errors == null)
                {
                    if (data.Id == 0)
                    {

                        ItemGroup tblItem = _mapper.Map<AddItemgroupModel, ItemGroup>(data);
                        tblItem.CreationDate = DateTime.Now;
                        tblItem.IsActive = true;
                        _itemgroupRepository.Insert(tblItem);
                    }
                    else
                    {
                        ItemGroup item = _itemgroupRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                        DateTime createdDt = item.CreationDate;
                        bool isActive = item.IsActive;
                        item = _mapper.Map<AddItemgroupModel, ItemGroup>(data);
                        item.ModifiedDate = DateTime.Now; item.CreationDate = createdDt; item.IsActive = isActive;
                        _itemgroupRepository.Update(item);
                    }
                }
                else
                {
                    return response;
                }

                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "ItemGroup") : string.Format(Constants.UpdatedSuccessfully, "ItemGroup") };
            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteItemGroup(int data)
        {
            try
            {
                ItemGroup item = _itemgroupRepository.GetByPredicate(x => x.Id == data);

                if (item != null)
                {
                    item.IsActive = false;
                    _itemgroupRepository.Update(item);
                    _itemgroupRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "ItemGroup") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }

        #endregion


    }
}
