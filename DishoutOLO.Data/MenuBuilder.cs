﻿

namespace DishoutOLO.Data
{
    public class MenuBuilder:BaseEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Descrition { get; set; }
        public string Week { get; set; }
        public DateTime FullTime { get; set; }

        //public int ItemId { get; set; }   

    }
}
