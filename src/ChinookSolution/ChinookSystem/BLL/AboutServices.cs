#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamespaces
using ChinookSystem.DAL;
using ChinookSystem.Entities;
using ChinookSystem.ViewModels;
#endregion

namespace ChinookSystem.BLL
{
    public class AboutServices
    {
        // This class needs to be accessed by an "outside user" (WebApp)
        //  Therefore the class needs to be public

        #region Constructor and Context Dependency
        private readonly Chinook2018Context _context;
        internal AboutServices(Chinook2018Context context)
        {
            _context = context;
        }

        #endregion

        #region Services
        // Services are methods

        // Query to obtain the DbVersion data
        public DbVersionInfo GetDbVersion()
        {
            DbVersionInfo info = _context.DbVersions
                            .Select(x => new DbVersionInfo
                            {
                                Major = x.Major,
                                Minor = x.Minor,
                                Build = x.Build,
                                ReleaseDate = x.ReleaseDate
                            })
                            .SingleOrDefault();
            return info;
        }
        #endregion
    }
}
