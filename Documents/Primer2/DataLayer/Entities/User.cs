using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class User
    {
        public User()
        {
            this.predictions = new List<Prediction>();
            this.myFixtures = new List<MyFixture>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public virtual ICollection<Prediction> predictions { get; set; }

        public virtual ICollection<MyFixture> myFixtures { get; set; }
    }
}
