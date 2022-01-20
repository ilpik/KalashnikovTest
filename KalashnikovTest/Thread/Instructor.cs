using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalashnikovTest.DoublyLinkedList;
using KalashnikovTest.Models;

namespace KalashnikovTest.Thread
{
    public class Instructor
    {
        private GunRange  range { get; set;}

        public int InstructorId { get; set; }

        public bool IsBusy { get; set; } = false;

        public void Start()
        {
            CommandToPrepare();
            ShooterIsReady();
            CommandToShoot();

        }

        public void SetGunRange(DoublyNode<GunRange> gunRange)
        {
            range = gunRange.Data;
            IsBusy = true;
        }

        public void ClearGunRange()
        {
            range = null;
            IsBusy = false;
        }
        private void CommandToPrepare()
        {
            ShootingRangeController.AllTime += new Random().Next(2, 7);
            Console.WriteLine("Направление {0}, инструктор {1}, стрелок {2}: {3}", range.Id, range.InstructorId, range.Shooter.Id, "Подготовиться к стрельбе!");
        }

        private void ShooterIsReady()
        {
            ShootingRangeController.AllTime += new Random().Next(1, 5);
            Console.WriteLine("Направление {0}, инструктор {1}, стрелок {2}: {3}", range.Id, range.InstructorId, range.Shooter.Id, "К стрельбе готов!");
        }

        private void CommandToShoot()
        {
            ShootingRangeController.AllTime += new Random().Next(1,3);

            Console.WriteLine("Направление {0}, инструктор {1}, стрелок {2}: {3}", range.Id, range.InstructorId, range.Shooter.Id, "Произвести стрельбу!");
        }
    }
}
