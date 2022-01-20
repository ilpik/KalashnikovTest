using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalashnikovTest.Models;
using KalashnikovTest.Queue;
using KalashnikovTest.DoublyLinkedList;


namespace KalashnikovTest.Thread
{
    public class ShootingRangeController
    {
        public static int AllTime { get; set; }
        public static int ShootingTime { get; set; }
        public static AppQueue<Shooter> Shooters { get; set; }
        public  static DoublyLinkedList<GunRange> Ranges { get; set; }

        public static void Init(int shootersCount, int gunRangesCount)
        {
            Shooters = CreateShooterQueue(shootersCount);
            Ranges = CreateGunRangesList(gunRangesCount);

            SetShootersToRanges();
        }

   
        //первичное распределение стрелков по направлениям
        public static void SetShootersToRanges()
        {
            foreach (var gunRange in Ranges)
            {
               SetShooterToRange(gunRange);
            }
        }

        // Стрелок занимает пустое направление 
        public static void SetShooterToRange(GunRange gunRange)
        {
            gunRange.Shooter = Shooters.GetFirst;
            gunRange.IsFree = false;
            gunRange.Shooter.DecreaseAttempts();

            ShooterHasAttempts(gunRange.Shooter);
        
            AllTime +=  new Random().Next(3, 11);
            Console.WriteLine("Направление {0}, инструктор {1}, стрелок {2}: {3}", gunRange.Id, gunRange.InstructorId, gunRange.Shooter.Id, "Занял направление!");
        }

        //Стрелок закончил стрельбу
        public static void ShooterFinishedAttempt(DoublyNode<GunRange> range)
        {
            var time = new Random().Next(5, 16);

            AllTime += time;
            ShootingTime += time;

                Console.WriteLine("Направление {0}, инструктор {1}, стрелок {2}: {3}", range.Data.Id, range.Data.InstructorId, range.Data.Shooter.Id, "Стрельбу окончил!");

            if (Shooters.Count>0)
            {

                Ranges.SendNodeToEnd(range.Data);

                ShooterHasAttempts(range.Data.Shooter);

                range.Data.Shooter = null;
                range.Data.IsFree = true;

                SetShooterToRange(range.Data);
            }
            else
            {
                Ranges.DeleteFromList(range.Data);
            }
        }
     
        
        //создать очередь стрелков
        private static AppQueue<Shooter> CreateShooterQueue(int count)
        {
            AppQueue<Shooter> queue = new AppQueue<Shooter>();
            for (int i = 0; i < count; i++)
            {
                queue.AddToQueue(new Shooter()
                {
                    Id = i + 1,
                });
            }

            return queue;
        }

        // создать список направлений
        private static DoublyLinkedList<GunRange> CreateGunRangesList(int count)
        {
            DoublyLinkedList<GunRange> gunList = new DoublyLinkedList<GunRange>();
            for (int i = 0; i < count; i++)
            {
                gunList.Add(new GunRange()
                {
                    Id = i + 1,
                    IsFree = true
                });
            }

            return gunList;
        }

        public static void ShooterHasAttempts(Shooter shooter)
        {
            if (shooter.AttemptsLeft > 0)
            {
                Shooters.SendFirstToEnd();

            }
            else
            {
                Shooters.DeleteFromQueue();
            }
        }

    }
}
