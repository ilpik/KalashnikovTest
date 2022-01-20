using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalashnikovTest.Models
{
    public class Shooter : AppModel
    {

        public int AttemptsLeft { get; set; } = 5;

        public void DecreaseAttempts()
        {
            if (AttemptsLeft > 0)
            {
                AttemptsLeft--;
            }
            else
            {
                AttemptsLeft = 0;
            }
        }
    }
}
