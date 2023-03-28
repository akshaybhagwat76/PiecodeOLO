

using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddProgramModel
    {
        public int Id { get; set; }

        [DisplayName("Program Name")]
        public string ProgramName { get; set; }

        public bool IsActive { get; set; }
    }
    public class UpdateProgramModel
    {
        public int Id { get; set; }

        [DisplayName("Program Name")]
        public string ProgramName { get; set; }

        public bool IsActive { get; set; }
    }
    public class ListProgramModel
    {
        public int Id { get; set; }

        [DisplayName("Program Name")]
        public string ProgramName    { get; set; }

        public bool IsActive { get; set; }
       
    }

    public class DeleteProgramModel
    {
        public int Id { get; set; }
    }

}
