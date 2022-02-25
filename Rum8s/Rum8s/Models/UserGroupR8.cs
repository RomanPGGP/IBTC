using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rum8s.Models
{
    public class UserGroupR8
    {
        public int Id { get; set; }

        public string OwnerID { get; set; }
        
        public int GroupR8Id { get; set; }
    }
}
