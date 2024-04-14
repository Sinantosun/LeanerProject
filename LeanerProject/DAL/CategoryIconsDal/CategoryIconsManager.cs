using LeanerProject.Models;
using LeanerProject.Models.Entities;

using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.DAL.CategoryIconsDal
{
    public class CategoryIconsManager : ICategoryIconsService
    {
        public IPagedList<CategoryIcons> GetCategoryIconsList(int pageNumber)
        {
            Context _context = new Context();
            var list = _context.CategoryIcons.ToList().ToPagedList(pageNumber, 90);
            return list;

        }
    }
}