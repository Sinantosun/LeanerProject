using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeanerProject.DAL
{
    public static class CheckImageExtentions
    {
        public static bool CheckExtentions(string ext)
        {
            if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
            {
                return true;
            }
            return false;
        }
    }
}