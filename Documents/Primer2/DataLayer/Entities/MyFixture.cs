using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class MyFixture
    {
        public MyFixture()
        {

        }
        [Key]
        public int id { get; set; }
        
        public int userId { get; set; }
        
        public int fixtureId { get; set; }

        [ForeignKey("fixtureId")]
        public virtual Fixture fixture { get; set; }
        [ForeignKey("userId")]
        public virtual User user { get; set; }
    }
}
