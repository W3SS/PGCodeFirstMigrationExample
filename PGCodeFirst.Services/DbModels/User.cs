using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGCodeFirst.Services.DbModels
{
    public class User
    {
        public User()
        {
            Interests = new HashSet<Interest>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        public string Nick { get; set; }
        public DateTime LastLogin { get; set; }

        public int CityId { get; set;}
        public virtual City City { get; set; }

        public ICollection<Interest> Interests { get; set; }
    }

  


}
