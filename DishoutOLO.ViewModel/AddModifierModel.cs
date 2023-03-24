

using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddModifierModel
    {
        public int Id { get; set; }

        [DisplayName("Modifier Name")]
        public string ModifierName { get; set; }

        public int Price { get; set; }
        public bool IsActive { get; set; }

    }

    public class UpdateModifierModel
    {
        public int Id { get; set; }
        public string ModifierName { get; set; }

        public int Price { get; set; }
        public bool IsActive { get; set; }

    }

    public class ListModifierModel
    {
        public int Id { get; set; }
        public string ModifierName { get; set; }

        public int Price { get; set; }
        public bool IsActive { get; set; }

    }

    public class DeleteModifierModel
    {
        public int Id { get; set; }
       

    }
}
