using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Team
    {
        public Team()
        {
            this.fixtures = new List<Fixture>();
            this.fixtures1 = new List<Fixture>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int team_id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }

        public virtual ICollection<Fixture> fixtures { get; set; }
        public virtual ICollection<Fixture> fixtures1 { get; set; }
    }
}
