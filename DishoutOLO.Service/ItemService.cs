﻿using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.IdentityModel.Tokens;

namespace DishoutOLO.Service
{

    public class ItemService : IitemService
    {

        #region Declarations
        private IRepository<Item> _itemRepository;
        private IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public ItemService(IRepository<Item> itemRepository, IMapper mapper, IRepository<Category> categoryRepository)
        {
            _itemRepository = itemRepository;
            _categoryRepository = categoryRepository;

            _mapper = mapper;
        }


        #endregion

        #region Crud Methods

        public DishoutOLOResponseModel AddOrUpdateItem(AddItemModel data)
        {
            try
            {
                Item Item = _itemRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.ItemName.ToLower() == data.ItemName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                {
                    if (Item != null)
                    {       
                        response.IsSuccess = false;
                        response.Status = 400;
                        response.Errors = new List<ErrorDet>();
                        if (Item.ItemName.ToLower() == data.ItemName.ToLower())
                        {
                            response.Errors.Add(new ErrorDet() { ErrorField = "ItemName", ErrorDescription = "Item already exist" });
                        }
                                              
                       return response;
                    }
                    if (response.Errors == null)
                    {
                        if (data.Id == 0)
                        {
                            Item tblItem = _mapper.Map<AddItemModel, Item>(data);
                            tblItem.CreatedBy = 21;
                            tblItem.CreationDate = DateTime.Now;
                            tblItem.IsActive = true;
                            _itemRepository.Insert(tblItem);
                        }
                        else
                        {
                            Item item = _itemRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                            string itemImg = item.ItemImage;
                            DateTime createdDt = item.CreationDate ?? new DateTime();
                            bool isActive = item.IsActive;
                            item = _mapper.Map<AddItemModel, Item>(data);
                            item.ModifiedDate = DateTime.Now;
                            item.CreationDate = createdDt;
                            item.IsActive = isActive;
                            item.ItemImage = itemImg;
                            _itemRepository.Update(item);
                        }
                    }
                    
                    return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "Item") : string.Format(Constants.UpdatedSuccessfully, "Item") };
                }
            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteItem(int data)
        {
            try
            {
                Item item = _itemRepository.GetByPredicate(x => x.Id == data);
                    
                if (item != null)
                {
                    item.IsActive = false;
                    _itemRepository.Update(item);
                    _itemRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Data = item.ItemImage, Message = string.Format(Constants.DeletedSuccessfully, "Item") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion


        #region Get Methods
        public DataTableFilterModel GetItemList(DataTableFilterModel filter)
        {
            try
            {

                IEnumerable<ListItemModel> data = _itemRepository.GetListByPredicate(x => x.IsActive == true
                                    )
                                    .Select(y => new ListItemModel()
                                    {
                                        CategoryId = y.CategoryId,
                                        ItemName = y.ItemName,
                                        ItemDescription=y.ItemDescription,
                                        ItemImage = y.ItemImage,
                                        IsActive = y.IsActive,
                                        UnitCost = y.UnitCost,
                                        MSRP = y.MSRP,
                                        TaxRate1 = y.TaxRate1,
                                        TaxRate2 = y.TaxRate2,
                                        TaxRate3 = y.TaxRate3,
                                        TaxRate4 = y.TaxRate4,
                                        Id = y.Id


                                    }).Distinct().OrderByDescending(x => x.Id).AsEnumerable();
                 

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
                    data = data.Where(p => p.ItemName.ToLower().Contains(searchText));
                }
                var filteredCount = data.Count();
                filter.recordsTotal = totalCount;
                filter.recordsFiltered = filteredCount;
                if (!string.IsNullOrEmpty(filter.CategoryName) && filter.CategoryName != "---SELECT---")
                {
                    data = data.Where(x => x.CategoryName == filter.CategoryName).ToList();
                }
                if (!string.IsNullOrEmpty(filter.ItemName))
                {
                    data = data.Where(x => x.ItemName == filter.ItemName).ToList();
                }
                if (string.IsNullOrEmpty(filter.ItemName) && string.IsNullOrEmpty(filter.CategoryName))
                    data = data.ToList();

                filter.data = data.Skip(filter.start).Take(filter.length).ToList();

                return filter;
            }
            catch (Exception ex)
            {
                return filter;
            }

        }

        public DishoutOLOResponseModel GetAllItems()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _itemRepository.GetAll().Where(x => x.IsActive).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Data = null };

            }
        }


        public AddItemModel GetItem(int Id) 
        {
            try
            {
               ListItemModel item = _itemRepository.GetListByPredicate(x => x.IsActive  && x.Id == Id
                                     )
                                     .Select(y => new ListItemModel()
                                     { Id = y.Id, ItemName = y.ItemName, IsActive = y.IsActive, 
                                         CategoryId = y.CategoryId,
                                         ItemDescription = y.ItemDescription,
                                         ItemImage=y.ItemImage ,
                                         CategoryName=y.CategoryName,
                                         UnitCost =y.UnitCost,
                                         MSRP=y.MSRP,
                                         TaxRate1=y.TaxRate1,
                                         TaxRate2=y.TaxRate2,
                                         TaxRate3 =y.TaxRate3,
                                         TaxRate4 =y.TaxRate4}
                                     ).FirstOrDefault();

                if (item != null)
                {
                    AddItemModel obj = new AddItemModel();
                    obj.Id = item.Id;
                    obj.ItemName = item.ItemName;
                    obj.ItemDescription = item.ItemDescription;
                    obj.CategoryId = item.CategoryId;
                    obj.CategoryName = item.CategoryName;   
                    obj.ItemImage= item.ItemImage;
                    obj.UnitCost = item.UnitCost;   
                    obj.MSRP = item.MSRP;
                    obj.TaxRate1=item.TaxRate1;
                    obj.TaxRate2=item.TaxRate2;
                    obj.TaxRate3 = item.TaxRate3;
                    obj.TaxRate4 = item.TaxRate4;
                        


                    return obj;
                }
                return new AddItemModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }

}
