using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalashnikovTest.Models
{
    public class GunRange : AppModel
    {

        public bool IsFree { get; set; } = true;
        public Shooter Shooter { get; set; }

        public int InstructorId { get; set; } = new Random().Next(1,3);

    }
}
