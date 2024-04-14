
using LeanerProject.Models.Entities;
using PagedList;

namespace LeanerProject.DAL.CategoryIconsDal
{
    public interface ICategoryIconsService
    {
        IPagedList<CategoryIcons> GetCategoryIconsList(int pageNumber);
    }
}
