using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class ModifierService : IModifierService
    {
        #region Declarations
        private readonly IMapper _mapper;
        private IRepository<Modifier> _modifierRepository;

        #endregion

        #region Constructor
        public ModifierService(IRepository<Modifier> modifierRepository, IMapper mapper)
        {
            _modifierRepository = modifierRepository;
            _mapper = mapper;
        }

        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateModifier(AddModifierModel data)
        {
            try
            {
                Modifier Modifier = _modifierRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.ModifierName.ToLower() == data.ModifierName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Modifier != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Modifier.ModifierName.ToLower() == data.ModifierName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "ModifierName", ErrorDescription = "ModifierName already exist" });
                    }
                    return response;


                }
                if (response.Errors == null)
                {
                    if (data.Id == 0)
                    {
                        Modifier tblModifier = _mapper.Map<AddModifierModel, Modifier>(data);
                        tblModifier.CreationDate = DateTime.Now;
                        tblModifier.IsActive = true;
                        _modifierRepository.Insert(tblModifier);
                    }
                    else
                    {
                        Modifier modifier = _modifierRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                        DateTime CreationDate = modifier.CreationDate ?? new DateTime();
                        bool isactive = modifier.IsActive;
                        modifier = _mapper.Map<AddModifierModel, Modifier>(data);
                        modifier.CreationDate = CreationDate;
                        modifier.ModifiedDate = DateTime.Now;
                        modifier.IsActive = isactive;
                        _modifierRepository.Update(modifier);
                    }
                }
                
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "category") : string.Format(Constants.UpdatedSuccessfully, "category") };
            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteModifier(int data)
        {
            try
            {
                Modifier modifier = _modifierRepository.GetByPredicate(x => x.Id == data);

                if (modifier != null)
                {
                    modifier.IsActive = false;
                    _modifierRepository.Update(modifier);
                    _modifierRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Modifier") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region  Get methods
        public AddModifierModel GetModifier(int Id)
        {
            try
            {
                ListModifierModel modifier = _modifierRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id).Select(y => new ListModifierModel()
                {
                    Id = y.Id,
                    ModifierName = y.ModifierName,
                    Price = y.Price,
                    IsActive = y.IsActive,
                }).FirstOrDefault();

                if (modifier != null)
                {
                    AddModifierModel obj = new AddModifierModel();
                    obj.Id = modifier.Id;
                    obj.ModifierName = modifier.ModifierName;
                    obj.Price = modifier.Price;
                    obj.IsActive = modifier.IsActive;

                    return obj;
                }
                return new AddModifierModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTableFilterModel GetModifierList(DataTableFilterModel filter)
        {
            try
            {

                IEnumerable<ListModifierModel> data = _modifierRepository.GetListByPredicate(x => x.IsActive == true
                                     )
                                     .Select(y => new ListModifierModel()
                                     { Id = y.Id, ModifierName = y.ModifierName,Price=y.Price, IsActive = y.IsActive }
                                     ).Distinct().OrderByDescending(x => x.Id).AsEnumerable();


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
                    data = data.Where(p => p.ModifierName.ToLower().Contains(searchText));
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
        public DishoutOLOResponseModel GetAllModifier()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _modifierRepository.GetAll().Where(x => x.IsActive).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Data = null };

            }
        }


        #endregion
    }
}
