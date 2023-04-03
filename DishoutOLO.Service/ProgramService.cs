using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class ProgramService:IProgramService
    {
        #region Declarations
        private IRepository<Program> _programRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProgramService(IRepository<Program> programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }
        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateProgram(AddProgramModel data)
        {
            try
            {
                Program program = _programRepository.GetAllAsQuerable().FirstOrDefault(x => x.IsActive == false && (x.ProgramName.ToLower() == data.ProgramName.ToLower()));
                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (program != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (program.ProgramName.ToLower() == data.ProgramName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "ProgramName", ErrorDescription = "Program already exist" });
                    }

                }
                if (data.Id == 0)
                {
                    Program tblprogram = _mapper.Map<AddProgramModel, Program>(data);
                    tblprogram.CreationDate = DateTime.Now;
                    tblprogram.IsActive = true;
                    _programRepository.Insert(tblprogram);
                }
                else
                {
                    Program programModify = _programRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                    DateTime createdDt = programModify.CreationDate ?? new DateTime();
                    bool isActive = programModify.IsActive;
                    programModify = _mapper.Map<AddProgramModel, Program>(data);
                    programModify.ModifiedDate = DateTime.Now; 
                    programModify.CreationDate = createdDt; 
                    programModify.IsActive = isActive;
                    _programRepository.Update(programModify);
                }
                return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "category") : string.Format(Constants.UpdatedSuccessfully, "category") };
            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteProgram(int data)
        {
            try
            {
                Program program = _programRepository.GetByPredicate(x => x.Id == data);

                if (program != null)
                {
                    program.IsActive = false;
                    _programRepository.Update(program);
                    _programRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Category") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region Get methods
        public DataTableFilterModel GetProgramList(DataTableFilterModel filter)
        {
            try
            {
                IEnumerable<ListProgramModel> data = _programRepository.GetListByPredicate(x => x.IsActive == true
                                     )
                                     .Select(y => new ListProgramModel()
                                     { Id = y.Id, ProgramName = y.ProgramName, IsActive = y.IsActive}

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
                    data = data.Where(p => p.ProgramName.ToLower().Contains(searchText));
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

        public DishoutOLOResponseModel GetAllPrograms()
        {
            try
            {
                return new DishoutOLOResponseModel() { IsSuccess = true, Data = _programRepository.GetAll().Where(x => x.IsActive).ToList() };

            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false };

            }
        }

        public AddProgramModel GetProgram(int Id)
        {
            try
            {
                ListProgramModel program = _programRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id
                                      )
                                      .Select(y => new ListProgramModel()
                                      {
                                          Id = y.Id,
                                          ProgramName = y.ProgramName,
                                          IsActive = y.IsActive
                                          
                                      }
                                      ).FirstOrDefault();

                if (program != null)
                {
                    AddProgramModel obj = new AddProgramModel();
                    obj.Id = program.Id;
                    obj.ProgramName = program.ProgramName;
                  
                    return obj;
                }
                return new AddProgramModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion














    }
}
