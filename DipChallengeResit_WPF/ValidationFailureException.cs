using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipChallengeResit_WPF
{
    public class ValidationFailureException : Exception
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ValidationFailureException(string message) : base(message)
        {
            logger.Debug($"ValidationFailureException: {message}");
        }
       
    }
}
