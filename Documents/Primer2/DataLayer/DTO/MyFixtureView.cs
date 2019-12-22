using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    [Serializable]
    public class MyFixtureView
    {
        public int id { get; set; }

        public int userId { get; set; }

        public int fixtureId { get; set; }

        public MyFixtureView()
        {

        }

        public MyFixtureView(MyFixture myFixture)
        {
            this.id = myFixture.id;
            this.userId = myFixture.userId;
            this.fixtureId = myFixture.fixtureId;
        }


    }
}
