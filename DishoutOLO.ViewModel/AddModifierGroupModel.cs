
using System.ComponentModel;

namespace DishoutOLO.ViewModel
{
    public class AddModifierGroupModel
    {
        public int Id { get; set; }

        [DisplayName("Modifier")]
        public int ModifierId { get; set; }

        public int price { get; set; }

        public bool IsActive { get; set; }  

        public string ModifierName { get; set; }

        [DisplayName("ModifierGroup Name")]
        public string ModifierGroupName { get; set; }
    }
    public class UpdateModifierGroupModel
    {
        public int Id { get; set; }
        public int ModifierId { get; set; }

        public int price { get; set; }

        public bool IsActive { get; set; }

        public string ModifierName { get; set; }
        public string ModifierGroupName { get; set; }
    }

    public class ListModifierGroupModel
    {
        public int Id { get; set; }
        public int ModifierId { get; set; }

        public int price { get; set; }

        public bool IsActive { get; set; }

        public string ModifierName { get; set; }
        public string ModifierGroupName { get; set; }
    }

    public class DeleteModifierGroupModel
    {
        public int Id { get; set; }
        
    }
}
