using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    [Serializable]
    public class PredictionTypeView
    {
        public int id { get; set; }
        public string type_name { get; set; }
        public int number_of_option { get; set; }

        public PredictionTypeView()
        {

        }

        public PredictionTypeView(PredictionType predictionType)
        {
            this.id = predictionType.id;
            this.type_name = predictionType.type_name;
            this.number_of_option = predictionType.number_of_option;
        }
    }
}
