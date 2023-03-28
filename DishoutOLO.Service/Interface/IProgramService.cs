

using DishoutOLO.ViewModel;
using DishoutOLO.ViewModel.Helper;

namespace DishoutOLO.Service.Interface
{
    public interface IProgramService
    {
        public DishoutOLOResponseModel AddOrUpdateProgram(AddProgramModel data);
        public DishoutOLOResponseModel DeleteProgram(int data);
        public DataTableFilterModel GetProgramList(DataTableFilterModel filter);
        public DishoutOLOResponseModel GetAllPrograms();
        public AddProgramModel GetProgram(int Id);






    }
}
