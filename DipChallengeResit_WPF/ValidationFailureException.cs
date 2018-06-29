using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_WPF
{
    public class ValidationFailureException : Exception
    {
        public ValidationFailureException(string message) : base(message) { }
    }
}
