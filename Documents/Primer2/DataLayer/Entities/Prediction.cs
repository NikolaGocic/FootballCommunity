using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Prediction
    {
        public Prediction()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int prediction_id { get; set; }
        public int status { get; set; }
        public int chosen_option { get; set; }
        
        public int userId { get; set; }
       
        public int fixtureId { get; set; }
      
        public int predictionTypeId { get; set; }
        [ForeignKey("fixtureId")]
        public virtual Fixture fixture { get; set; }
        [ForeignKey("predictionTypeId")]
        public virtual PredictionType predictionType { get; set; }
        [ForeignKey("userId")]
        public virtual User user { get; set; }

    }
}
