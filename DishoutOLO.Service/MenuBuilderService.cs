

using DishoutOLO.Data;
using DishoutOLO.Repo;
using DishoutOLO.Repo.Interface;
using DishoutOLO.Repo.Migrations;
using DishoutOLO.ViewModel.Helper;
using DishoutOLO.ViewModel;
using DishoutOLO.Service.Interface;

namespace DishoutOLO.Service
{
    public class MenuBuilderService:IMenuBuilderService
    {
        #region Declarations
        private IRepository<MenuBuilder> _menubuilderRepository;

        #endregion

        #region Constructor
        public MenuBuilderService(IRepository<MenuBuilder> menubuilderRepository)
        {
            _menubuilderRepository = menubuilderRepository;

        }
        #endregion

        #region Get Methods
        public DataTableFilterModel GetMenuBuilderList(DataTableFilterModel filter)
        {
            try
            {

                var data = _menubuilderRepository.GetAll()
                                      .Select(y => new AddMenuBuilderModel()
                                      {
                                          Id = y.Id,
                                          MenuName=y.MenuName,
                                          Descrition=y.Descrition,
                                          Week=y.Week,
                                          FullTime=y.FullTime

            }
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
                    data = data.Where(p => p.MenuName.ToLower().Contains(searchText));
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


        #endregion
    }
}
