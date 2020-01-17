using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{

    [Serializable]
    public class PredictionView
    {
        public int prediction_id { get; set; }
        public int status { get; set; }
        public int chosen_option { get; set; }

        public int userId { get; set; }

        public int fixtureId { get; set; }

        public int predictionTypeId { get; set; }

        public PredictionView()
        {
            
        }


        public PredictionView(Prediction p)
        {
            this.prediction_id = p.prediction_id;
            this.status = p.status;
            this.chosen_option = p.chosen_option;
            this.userId = p.userId;
            this.fixtureId = p.fixtureId;
            this.predictionTypeId = p.predictionTypeId;

        }
    }
}
