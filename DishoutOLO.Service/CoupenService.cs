using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service
{
    public class CoupenService:ICoupenService
    {
        #region Declarations
        private IRepository<Coupen> _coupenRepository;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public CoupenService(IRepository<Coupen> coupenRepository, IMapper mapper)
        {
            _coupenRepository = coupenRepository;
            _mapper = mapper;
        }
        #endregion

        #region Crud Methods
        public DishoutOLOResponseModel AddOrUpdateCoupen(AddCoupenModel data)
        {
            try
            {
                Coupen Coupen = _coupenRepository.GetAllAsQuerable().WhereIf(data.Id > 0, x => x.Id != data.Id).FirstOrDefault(x => x.IsActive && (x.CouponName.ToLower() == data.CouponName.ToLower()));

                DishoutOLOResponseModel response = new DishoutOLOResponseModel();

                if (Coupen != null)
                {
                    response.IsSuccess = false;
                    response.Status = 400;
                    response.Errors = new List<ErrorDet>();
                    if (Coupen.CouponName.ToLower() == data.CouponName.ToLower())
                    {
                        response.Errors.Add(new ErrorDet() { ErrorField = "couponName", ErrorDescription = "Coupon already exist" });
                    }
                }
                if (response.Errors == null)
                {
                    if (data.Id == 0)
                    {
                        Coupen tblCoupen = _mapper.Map<AddCoupenModel, Coupen>(data);
                        tblCoupen.CreationDate = DateTime.Now;
                        tblCoupen.IsActive = true;
                        _coupenRepository.Insert(tblCoupen);
                    }
                    else
                    {
                        Coupen coupen = _coupenRepository.GetByPredicate(x => x.Id == data.Id && x.IsActive);
                        DateTime createdDt = coupen.CreationDate ?? new DateTime();
                        bool isActive = coupen.IsActive;
                        coupen = _mapper.Map<AddCoupenModel, Coupen>(data);
                        coupen.ModifiedDate = DateTime.Now;
                        coupen.CreationDate = createdDt;
                        coupen.IsActive = isActive;
                        _coupenRepository.Update(coupen);
                    }
                    return new DishoutOLOResponseModel() { IsSuccess = true, Message = data.Id == 0 ? string.Format(Constants.AddedSuccessfully, "Coupen") : string.Format(Constants.UpdatedSuccessfully, "Coupen") };
                }
                return response;
            }
            catch (Exception)
            {
                return new DishoutOLOResponseModel() { IsSuccess = false, Message = Constants.GetDetailError };
            }
        }

        public DishoutOLOResponseModel DeleteCoupen(int data)
        {
            try
            {
                Coupen coupen = _coupenRepository.GetByPredicate(x => x.Id == data);

                if (coupen != null)
                {
                    coupen.IsActive = false;
                    _coupenRepository.Update(coupen);
                    _coupenRepository.SaveChanges();
                }

                return new DishoutOLOResponseModel { IsSuccess = true, Message = string.Format(Constants.DeletedSuccessfully, "Coupen") };
            }
            catch (Exception ex)
            {
                return new DishoutOLOResponseModel { IsSuccess = false, Message = ex.Message };
            }
        }

        #endregion
        #region Get Methods
        public DataTableFilterModel GetCoupenList(DataTableFilterModel filter)
        {
            try
            {
                IEnumerable<ListCoupenModel> data = _coupenRepository.GetListByPredicate(x => x.IsActive == true)
                                     .Select(y => new ListCoupenModel()
                                     { Id = y.Id,
                                         CouponName = y.CouponName,
                                         CouponCode = y.CouponCode,
                                         IsActive = y.IsActive,
                                         MinOrderAmount=y.MinOrderAmount,
                                         StartDate=y.StartDate,
                                         EndDate=y.EndDate,
                                         Discount=y.Discount,
                                         RedemptionType=y.RedemptionType,
                                         Description=y.Description,
                                         DiscountTypePercentageval=y.DiscountTypePercentageval}

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
                            //if (sortcolumn.length > 0)
                            //{
                            //    sortcolumn = sortcolumn.first().tostring().toupper() + sortcolumn.substring(1);
                            //    if (sortcolumndirection == "asc")
                            //    {

                            //        data = data.orderbydescending(p => p.gettype()
                            //                .getproperty(sortcolumn)
                            //                .getvalue(p, null)).tolist();
                            //    }
                            //    else
                            //    {
                            //        data = data.orderby(p => p.gettype()
                            //               .getproperty(sortcolumn)
                            //               .getvalue(p, null)).tolist();
                            //    }
                            //}
                        }
                    }
                }

                var totalCount = data.Count();
                if (!string.IsNullOrWhiteSpace(filter.search.value))
                {
                    var searchText = filter.search.value.ToLower();
                    data = data.Where(p => p.CouponName.ToLower().Contains(searchText));
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

        public AddCoupenModel GetCoupen(int Id)
        {
            try
                {
                ListCoupenModel coupen = _coupenRepository.GetListByPredicate(x => x.IsActive == true && x.Id == Id
                                     )
                                     .Select(y => new ListCoupenModel()
                                     {
                                         Id = y.Id,
                                         CouponName = y.CouponName,
                                         CouponCode = y.CouponCode,
                                         IsActive = y.IsActive,
                                         MinOrderAmount = y.MinOrderAmount,
                                         StartDate = y.StartDate,
                                         EndDate = y.EndDate,
                                         Discount = y.Discount,
                                         RedemptionType = y.RedemptionType,
                                         Description = y.Description,
                                         DiscountTypePercentageval = y.DiscountTypePercentageval
                                     }).FirstOrDefault();

                if (coupen != null)
                {
                    AddCoupenModel obj = new AddCoupenModel();
                    obj.Id = coupen.Id;
                   obj.CouponName = coupen.CouponName;
                    obj.CouponCode = coupen.CouponCode;
                    obj.Discount = coupen.Discount; 
                    obj.RedemptionType = coupen.RedemptionType;
                    obj.Description = coupen.Description;
                    obj.DiscountTypePercentageval = coupen.DiscountTypePercentageval    ;
                    obj.StartDate = coupen.StartDate;
                    obj.EndDate = coupen.EndDate;
                    obj.MinOrderAmount = coupen.MinOrderAmount;
                    obj.IsActive = coupen.IsActive;
                    return obj;
                }
                return new AddCoupenModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
