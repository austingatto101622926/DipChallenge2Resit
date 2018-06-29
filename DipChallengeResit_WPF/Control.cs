using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DipChallengeResit_DataAccess;

namespace DipChallengeResit_WPF
{
    public class Control
    {
        public DataAccess DataAccess;

        public Control(Home home)
        {
            DataAccess = new DataAccess("http://dipchallenge2resit.azurewebsites.net/");

            Home = home;
            Procedures = new Procedures(this);
            Owners = new Owners(this);
        }

        public Home Home;
        public Procedures Procedures;
        public Treatments Treatments;
        public Owners Owners;
    }
}
