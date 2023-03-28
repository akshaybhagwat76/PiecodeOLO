using System.ComponentModel.DataAnnotations.Schema;

namespace DishoutOLO.Data
{
    [Table("Programs")]

    public class Program:BaseEntity
    {
        public string ProgramName { get; set; } 


    }
}
