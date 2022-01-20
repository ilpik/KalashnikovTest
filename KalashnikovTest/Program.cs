using System;
using System.Collections.Generic;
using System.Threading;
using KalashnikovTest.Models;
using KalashnikovTest.Queue;
using KalashnikovTest.DoublyLinkedList;
using KalashnikovTest.Thread;

namespace KalashnikovTest
{
    class Program
    {
        private static int _instructorsCount = 2;
        private static int _shootersCount = 13;
        private static int _gunRangesCount = 6;


        static void Main(string[] args)
        {

            Instructor instructorOne = new Instructor()
            {
                InstructorId = 1,
            };
            Instructor instructorTwo = new Instructor()
            {
                InstructorId = 2,
            };

            //System.Threading.Thread myThreadOne = new System.Threading.Thread(new ThreadStart(First));
            //System.Threading.Thread myThreadTwo = new System.Threading.Thread(new ThreadStart(Second));


            ShootingRangeController.Init(_shootersCount,_gunRangesCount);

            while (ShootingRangeController.Shooters.Count!=0)
            {
                for (int i = 0; i < 2; i++)
                {
                    if(ShootingRangeController.Ranges.GetHead().Data.InstructorId == instructorOne.InstructorId && instructorOne.IsBusy==false)
                    {
                        instructorOne.SetGunRange();
                    }
                }
            }
            Console.WriteLine(ShootingRangeController.Ranges.Count);
            Console.WriteLine(ShootingRangeController.Shooters.Count);
        }

        //private static void First()
        //{

        //}

        //private static void Second()
        //{

        //}

    }
}
