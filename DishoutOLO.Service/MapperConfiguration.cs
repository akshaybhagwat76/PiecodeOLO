﻿using AutoMapper;
using DishoutOLO.Data;
using DishoutOLO.ViewModel;

namespace DishoutOLO
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()

        {   
            CreateMaps();

        }
        private void CreateMaps()
        {
            CreateMap<Category,AddCategoryModel>().ReverseMap();
            CreateMap<Article,AddArticleModel>().ReverseMap();
            CreateMap<ItemGroups, AddItemgroupsModel>().ReverseMap();
            CreateMap<Modifier, AddModifierModel>().ReverseMap();
            CreateMap<ModifierGroup, AddModifierGroupModel>().ReverseMap();
            CreateMap<Program, AddProgramModel>().ReverseMap();
            CreateMap<Menu, AddMenuModel>().ReverseMap();
            CreateMap<MenuAvailabilities, AddMenuAvaliblities>().ReverseMap();
            CreateMap<Coupen, AddCoupenModel>().ReverseMap();
            CreateMap<Roles, AddRolesModel>().ReverseMap();
            CreateMap<UserStaff, AddUserStaffModel>().ReverseMap();


            CreateMap<Item,AddItemModel>()
                .ForMember(entity => entity.File, options => options.Ignore()).ReverseMap();
        }

    }

}   


