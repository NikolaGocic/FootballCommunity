using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class League
    {
        public League()
        {
            this.fixtures = new List<Fixture>();
        }
        [Key]
        public int league_id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }

        public virtual ICollection<Fixture> fixtures { get; set; }
    }
}
