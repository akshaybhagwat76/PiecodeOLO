

using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class ModifierGroupService:IModifierGroupService
    {
        #region Declarations
        private readonly IMapper _mapper;
        private IRepository<Modifier> _modifierRepository;
        private IRepository<ModifierGroup> _modifiergroupRepository;

        #endregion

        #region Constructor
        public ModifierGroupService(IRepository<Modifier> modifierRepository, IRepository<ModifierGroup> modifiergroupRepository, IMapper mapper)
        {
            _modifiergroupRepository = modifiergroupRepository;
            _modifierRepository = modifierRepository;
            _mapper = mapper;
        }

        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateModifierGroup(AddModifierGroupModel data)
        {
            try
            {
                ModifierGroup Modifiergroup = _modifiergroupRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.ModifierGroupName.ToLower() == data.ModifierGroupName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Modifiergroup != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Modifiergroup.ModifierGroupName.ToLower() == data.ModifierGroupName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "ModifierGroupName", ErrorDescription = "ModifierGroupName already exist" });
                    }

                    return response;    
                }
                if (data.Id == 0)
                {
                    ModifierGroup tblModifier = _mapper.Map<AddModifierGroupModel, ModifierGroup>(data);
                    tblModifier.CreationDate = DateTime.Now;
                    tblModifier.IsActive = true;
                    _modifiergroupRepository.Insert(tblModifier);
                }
               else
                {
                    ModifierGroup modifier = _modifiergroupRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                    DateTime CreationDate = modifier.CreationDate ?? new DateTime();
                    bool isactive = modifier.IsActive;
                    modifier = _mapper.Map<AddModifierGroupModel, ModifierGroup>(data);
                    modifier.CreationDate = CreationDate;
                    modifier.ModifiedDate = DateTime.Now;
                    modifier.IsActive = isactive;
                    _modifiergroupRepository.Update(modifier);
                }
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "ModifierGroup") : string.Format(Constants.UpdatedSuccessfully, "ModifierGroup") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteModifierGroup(int data)
        {
            try
            {
                ModifierGroup modifierGroup = _modifiergroupRepository.GetByPredicate(x => x.Id == data);

                if (modifierGroup != null)
                {
                    modifierGroup.IsActive = false;
                    _modifiergroupRepository.Update(modifierGroup);
                    _modifiergroupRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true,Message = string.Format(Constants.DeletedSuccessfully, "ModifierGroupName") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region  Get methods
        public AddModifierGroupModel GetModifierGroup(int Id)
        {
            try
            {
                ListModifierGroupModel modifiergroup = _modifiergroupRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id).Select(y => new ListModifierGroupModel()
                {
                    Id = y.Id,
                   ModifierGroupName = y.ModifierGroupName,
                   ModifierId=y.ModifierId,
                    IsActive = y.IsActive,
                    price=y.price
                   
                    
                }).FirstOrDefault();

                if (modifiergroup != null)
                {
                    AddModifierGroupModel obj = new AddModifierGroupModel();
                    obj.Id = modifiergroup.Id;
                    obj.ModifierGroupName = modifiergroup.ModifierGroupName;
                    obj.price = modifiergroup.price;
                    obj.IsActive = modifiergroup.IsActive;
                    obj.ModifierId = modifiergroup.ModifierId;

                    return obj;
                }
                return new AddModifierGroupModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTableFilterModel GetModifierGroupList(DataTableFilterModel filter)
        {
            try
            {

                IEnumerable<ListModifierGroupModel> data = (from md in _modifierRepository.GetAll()
                                                   join mg in _modifiergroupRepository.GetAll() on
                                                     md.Id equals mg.ModifierId
                                                 
                                                   where mg.IsActive == true
                                                   select new ListModifierGroupModel
                                                   {
                                                       ModifierName = md.ModifierName,
                                                       ModifierGroupName =mg.ModifierGroupName,
                                                       price = mg.price,
                                                       Id = mg.Id,
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
                    data = data.Where(p => p.ModifierGroupName.ToLower().Contains(searchText));
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
