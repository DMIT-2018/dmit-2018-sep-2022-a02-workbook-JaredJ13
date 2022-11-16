using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public class DbVersionInfo
    {
        // The view that is used by the "outside world"
        //  The access must match where the class is used (typically public)
        // Purpose: Used to simply carry data
        //          Creates data fields as auto-implemented properties
        //          Consists of the "raw" data on the query
        //          No validation done here

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
