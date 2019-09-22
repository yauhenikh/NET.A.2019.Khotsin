using System;
using System.Collections.Generic;

namespace UsingWinDbgAndSos
{
    public interface IManagable
    {
        void Manage();
    }

    public class CompanyPolicy
    {
    }

    public class Employee
    {
        private int _id;
        private string _name;

        private static CompanyPolicy _policy;

        public virtual void Work()
        {
            Console.WriteLine("Zzzz...");
        }

        public void TakeVacation(int days)
        {
            Console.WriteLine("Zzzz...");
        }

        public static void SetCompanyPolicy(CompanyPolicy policy)
        {
            _policy = policy;
            Console.WriteLine("Setting new company policy...");
        }

        public override string ToString()
        {
            return "Employee";
        }
    }

    public class Manager : Employee, IManagable
    {
        private List<Employee> _reports;

        public void Manage()
        {
            Console.WriteLine("Managing...");
        }

        public override void Work()
        {
            Console.WriteLine("Employee working...");
        }

        public override string ToString()
        {
            return "Manager";
        }
    }

    public struct Point2D
    {
        public int X;
        public int Y;

        public int Sum()
        {
            return X + Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point2D))
            {
                return false;
            }

            Point2D other = (Point2D)obj;

            return X == other.X && Y == other.Y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee.SetCompanyPolicy(new CompanyPolicy());

            Employee employee1 = new Employee();
            employee1.TakeVacation(1);

            Employee employee2 = new Manager();
            employee2.Work();
            Console.WriteLine(employee2);

            IManagable employee3 = new Manager();
            employee3.Manage();

            Point2D point2D = new Point2D
            {
                X = 1,
                Y = 2
            };

            Point2D anotherPoint = new Point2D
            {
                X = 2,
                Y = 2
            };

            Console.WriteLine(point2D.Sum());
            Console.WriteLine(point2D.Equals(anotherPoint));

            Console.ReadLine();
        }
    }
}
