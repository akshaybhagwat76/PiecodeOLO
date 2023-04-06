using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class RolesService:IRolesService
    {
        #region Declarations
        private IRepository<Roles> _rolesRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public RolesService(IRepository<Roles> rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }
        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateRoles(AddRolesModel data)
        {
            try
            {
                Roles Roles = _rolesRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.RolesName.ToLower() == data.RolesName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Roles != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Roles.RolesName.ToLower() == data.RolesName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "RolesName", ErrorDescription = "RolesName already exist" });
                    }

                    return response;
                }
                if (response.Errors == null)
                {
                    if (data.Id == 0)
                    {
                        Roles tblRoles = _mapper.Map<AddRolesModel, Roles>(data);
                        tblRoles.CreationDate = DateTime.Now;
                        tblRoles.IsActive = true;
                        _rolesRepository.Insert(tblRoles);

                    }
                    else
                    {
                        Roles roles = _rolesRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                        DateTime createdDt = roles.CreationDate ?? new DateTime();
                        bool isActive = roles.IsActive;
                        roles = _mapper.Map<AddRolesModel, Roles>(data);
                        roles.ModifiedDate = DateTime.Now;
                        roles.CreationDate = createdDt;
                        roles.IsActive = isActive;
                        _rolesRepository.Update(roles);
                    }

                }
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "Roles") : string.Format(Constants.UpdatedSuccessfully, "Roles") };


            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteRoles(int data)
        {
            try
            {
                Roles roles= _rolesRepository.GetByPredicate(x => x.Id == data);

                if (roles != null)
                {
                    roles.IsActive = false;
                    _rolesRepository.Update(roles);
                    _rolesRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Roles") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }

        #endregion

        #region Get Methods
        public DataTableFilterModel GetRolesList(DataTableFilterModel filter)
        {
            try
            {
                IEnumerable<ListRolesModel> data = _rolesRepository.GetListByPredicate(x => x.IsActive == true)
                                     .Select(y => new ListRolesModel()
                                     {
                                         Id = y.Id,
                                         RolesName = y.RolesName,
                                     }
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

                var totalCount = data.Count();
                if (!string.IsNullOrWhiteSpace(filter.search.value))
                {
                    var searchText = filter.search.value.ToLower();
                    data = data.Where(p => p.RolesName.ToLower().Contains(searchText));
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

        public AddRolesModel GetRoles(int Id)
        {   
            try
            {
                ListRolesModel roles = _rolesRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id
                                     )
                                     .Select(y => new ListRolesModel()
                                     {
                                         Id = y.Id,
                                       RolesName=y.RolesName,
                                       IsActive= y.IsActive,
                                     }).FirstOrDefault();

                if (roles != null)
                {
                    AddRolesModel obj = new AddRolesModel();
                    obj.Id =roles.Id;
                    obj.RolesName = roles.RolesName;    
                    obj.IsActive = roles.IsActive;

                    return obj;
                }
                return new AddRolesModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
