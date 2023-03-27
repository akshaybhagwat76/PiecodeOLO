using DishoutOLO.Helpers.Provider;
using DishoutOLO.Service;
using DishoutOLO.Service.Interface;
using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;
using Microsoft.AspNetCore.Mvc;

namespace DishoutOLO.Controllers
{
    public class ProgramController : Controller
    {
        #region Declarations

        private readonly IProgramService _programService;
        private LoggerProvider _loggerProvider;

        #endregion

        #region Constructor
        public ProgramController(IProgramService programService, LoggerProvider loggerProvider)
        {
            _programService = programService;
            _loggerProvider = loggerProvider;
        }


        #endregion

        #region Crud Methods
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Create Program
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {

            return View("ManageProgram", new AddProgramModel());
        }
        /// <summary>
        /// To add or insert Program
        /// </summary>
        /// <param name="programVM"></param>
        /// <returns></returns>
        public JsonResult AddOrUpdateProgram(AddProgramModel programVM)
        {
            try
            {
                return Json(_programService.AddOrUpdateProgram(programVM));
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }

            return Json(programVM);
        }

        /// <summary>
        /// Delete Program
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteProgram(int id)
        {
            try
            {
                DishoutOLOResponseModel list = _programService.DeleteProgram(id);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(id);
        }

        #endregion

        #region Get Methods
        /// <summary>
        /// Get All Program List
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public JsonResult GetAllProgram(DataTableFilterModel filter)
        {
            try
            {
                DataTableFilterModel list = _programService.GetProgramList(filter);
                return Json(list);
            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return Json(filter);
        }
        /// <summary>
        ///  go to edit page with update data 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _loggerProvider.logmsg(ex.Message);
            }
            return View("ManageProgram", _programService.GetProgram(id));
        }

        #endregion
    }
}
