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
        ControllerHandler<Owner> Owner;
        ControllerHandler<Pet> Pet;
        ControllerHandler<Procedure> Procedure;
        ControllerHandler<Treatment> Treatment;

        public DataAccess(string baseAddress)
        {
            Owner = new ControllerHandler<Owner>(baseAddress, "owners");
            Pet = new ControllerHandler<Pet>(baseAddress, "pets");
            Procedure = new ControllerHandler<Procedure>(baseAddress, "procedures");
            Treatment = new ControllerHandler<Treatment>(baseAddress, "treatments");
        }
    }
}
