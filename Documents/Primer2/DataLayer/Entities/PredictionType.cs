using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class PredictionType
    {
        public PredictionType()
        {
            this.predictions = new List<Prediction>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string type_name { get; set; }
        public int number_of_option { get; set; }

        public virtual ICollection<Prediction> predictions { get; set; }
    }
}
