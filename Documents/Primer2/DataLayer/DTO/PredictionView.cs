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

        public PredictionView()
        { 
        }

        public PredictionView(Prediction prediction)
        {
            this.prediction_id = prediction.prediction_id;
            this.status = prediction.status;
            this.chosen_option = prediction.chosen_option;
            this.userId = prediction.userId;
            this.fixtureId = prediction.fixtureId;
        }
    }
}
