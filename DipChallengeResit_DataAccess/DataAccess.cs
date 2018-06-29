using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DipChallengeResit_DataAccess.Models;

namespace DipChallengeResit_DataAccess
{
    public class DataAccess
    {
        public ControllerHandler<Owner> Owner;
        public ControllerHandler<Pet> Pet;
        public ControllerHandler<Procedure> Procedure;
        public ControllerHandler<Treatment> Treatment;

        public DataAccess(string baseAddress)
        {
            Owner = new ControllerHandler<Owner>(baseAddress, "owners");
            Pet = new ControllerHandler<Pet>(baseAddress, "pets");
            Procedure = new ControllerHandler<Procedure>(baseAddress, "procedures");
            Treatment = new ControllerHandler<Treatment>(baseAddress, "treatments");
        }
    }
}
