
using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class UserStaffService:IUserStaffService
    {

        #region Declarations
        private IRepository<UserStaff> _userstaffRepository;
        private IRepository<Roles> _rolesRepository;

        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public UserStaffService(IRepository<UserStaff> userstaffRepository, IMapper mapper, IRepository<Roles> rolesRepository)
        {
            _userstaffRepository = userstaffRepository;
            _mapper = mapper;
            _rolesRepository = rolesRepository; 
        }
        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateUserStaff(AddUserStaffModel data)
        {
            try
            {
                UserStaff userStaff = _userstaffRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.UserName.ToLower() == data.UserName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (userStaff != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (userStaff.UserName.ToLower() == data.UserName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "UserName", ErrorDescription = "UserName already exist" });
                    }

                    return response;
                }
                if (response.Errors == null)
                {
                    if (data.Id == 0)
                    {
                        UserStaff tbluserstaff = _mapper.Map<AddUserStaffModel, UserStaff>(data);
                        tbluserstaff.CreationDate = DateTime.Now;
                        tbluserstaff.IsActive = true;
                        tbluserstaff.Password = Guid.NewGuid().ToString();
                        _userstaffRepository.Insert(tbluserstaff);

                    }
                    else
                    {
                        UserStaff UserStaff = _userstaffRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                        DateTime createdDt = UserStaff.CreationDate ?? new DateTime();
                        bool isActive = UserStaff.IsActive;
                        UserStaff = _mapper.Map<AddUserStaffModel, UserStaff>(data);
                        UserStaff.ModifiedDate = DateTime.Now;
                        UserStaff.CreationDate = createdDt;
                        UserStaff.IsActive = isActive;
                        _userstaffRepository.Update(UserStaff);
                    }

                }
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "Roles") : string.Format(Constants.UpdatedSuccessfully, "Roles") };


            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteUserStaff  (int data)
        {
            try
            {
                UserStaff userStaff = _userstaffRepository.GetByPredicate(x => x.Id == data);

                if (userStaff != null)
                {
                    userStaff.IsActive = false;
                    _userstaffRepository.Update(userStaff);
                    _userstaffRepository.SaveChanges();
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
        public DataTableFilterModel GetUserStaffList(DataTableFilterModel filter)
        {
            try
            {
                IEnumerable<ListUserStaffModel> data = (from rs in _rolesRepository.GetAll()
                                                            join us in _userstaffRepository.GetAll() on
                                                              rs.Id equals us.RoleId

                                                            where us.IsActive == true
                                                            select new ListUserStaffModel
                                                            {
                                                                RolesName = rs.RolesName,
                                                                UserName = us.UserName, 
                                                                Email = us.Email,
                                                                Password = us.Password,
                                                                Phonenumber = us.Phonenumber,
                                                                JoiningDate = us.JoiningDate,
                                                                DateOfBirth = us.DateOfBirth,
                                                                LicenseExpiration = us.LicenseExpiration,
                                                                State = us.State,
                                                                City = us.City,
                                                                Street = us.Street,
                                                                ZipCode = us.ZipCode,
                                                                LicensePlate = us.LicensePlate,
                                                                DriverLicenseNumber = us.DriverLicenseNumber,
                                                                LoginType = us.LoginType,
                                                                VehicleTypeId = us.VehicleTypeId,
                                                                Name = us.Name,
                                                                DeviceId = us.DeviceId,
                                                                Id = us.Id,
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
                            sortColumn = sortColumn.First().ToString().ToUpper() + sortColumn.Substring(1);
                            //if (sortColumnDirection == "asc")
                            //{

                            //    data = data.OrderByDescending(p => p.GetType()
                            //            .GetProperty(sortColumn)
                            //            .GetValue(p, null)).ToList();
                            //}
                            //else
                            //{
                            //    data = data.OrderBy(p => p.GetType()
                            //           .GetProperty(sortColumn)
                            //           .GetValue(p, null)).ToList();
                            //}
                        }
                    }
                }

                var totalCount = data.Count();
                if (!string.IsNullOrWhiteSpace(filter.search.value))
                {
                    var searchText = filter.search.value.ToLower();
                    data = data.Where(p => p.UserName.ToLower().Contains(searchText));
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

        public AddUserStaffModel GetUserStaff(int Id)
        {
            try
            {
                ListUserStaffModel userStaff = _userstaffRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id
                                     )
                                     .Select(y => new ListUserStaffModel()
                                     {
                                         Id = y.Id,
                                        UserName=y.UserName,    
                                        Email=y.Email,  
                                        Password=y.Password,
                                        DateOfBirth=y.DateOfBirth,
                                        RoleId=y.RoleId,
                                        Phonenumber=y.Phonenumber,
                                        JoiningDate=y.JoiningDate,
                                        LicenseExpiration=y.LicenseExpiration,
                                        State=y.State,  
                                        City=y.City,
                                        ZipCode=y.ZipCode,
                                        Street=y.Street,    
                                        LicensePlate=y.LicensePlate,
                                        DeviceId=y.DeviceId,    
                                        DriverLicenseNumber=y.DriverLicenseNumber,
                                        ContactInfo=y.ContactInfo,
                                         VehicleTypeId = y.VehicleTypeId,  
                                        Name=y.Name,    
                                        LoginType=y.LoginType,
                                        RolesName=y.RolesName,
                                     }).FirstOrDefault();

                if (userStaff != null)
                {
                    AddUserStaffModel obj = new AddUserStaffModel();
                    obj.Id = userStaff.Id;
                    obj.UserName = userStaff.UserName;
                    obj.Email = userStaff.Email;    
                    obj.Password = userStaff.Password;
                    obj.RolesName = userStaff.RolesName;
                    obj.DateOfBirth = userStaff.DateOfBirth;    
                    obj.RoleId  = userStaff.RoleId;
                    obj.Phonenumber = userStaff.Phonenumber;
                    obj.JoiningDate = userStaff.JoiningDate;
                    obj.LicenseExpiration   = userStaff.LicenseExpiration;
                    obj.City = userStaff.City;
                    obj.State = userStaff.State;
                    obj.ZipCode = userStaff.ZipCode;
                    obj.Street = userStaff.Street;
                    obj.LicensePlate = userStaff.LicensePlate;
                    obj.DeviceId = userStaff.DeviceId;
                    obj.DriverLicenseNumber = userStaff.DriverLicenseNumber;
                    obj.ContactInfo = userStaff.ContactInfo;
                    obj.Name = userStaff.Name;  
                    obj.VehicleTypeId = userStaff.VehicleTypeId;
                    obj.LoginType = userStaff.LoginType;
                    obj.IsActive= userStaff.IsActive;

                    
                    return obj;
                }
                return new AddUserStaffModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public DishoutOLOResponseModel GetAllRoles()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _rolesRepository.GetAll().Where(x => x.IsActive).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Data = null };

            }
        }

        #endregion
    }
}
