using System;
using System.Collections.Generic;
namespace GradeBook
{
    class Program
    {
        static void Main(string[] args) // Metoda Main qe ndodhet ne class Program dhe eshte Pika e hyrjes per App ku fillom ekzekutimi i metodes. brenda kllapave kemi parametrat ne rastin ton tipi string parametri args 
        {

            var book = new Book("IT");
            var stat = book.GetStatistics();
            book.AddGrade(8.8);
           // var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 }; //deklarojme grades e cila eshe nje liste qe ben pjese ne system.collection.generic 
           // grades.Add(56.1);
            book.AddGrade(7.5);
           while (true)//deklarojme kushtin will me true qe te jete gjithmone ne loop deri sa kushti if input==q ta breake kushtin 
           {
                Console.WriteLine("Put a Grade or q for exit");
                var input = Console.ReadLine();//sheben per te futur te dhenat ne app ku input do te jete ne string   


                if (input == "q")
                {
                    break;
                }

                try// provo te ekzekutosh
                {
                    var grade = double.Parse(input);// sherben per te bere convert input qe e marin ne string ne out put (grade) qe e duam ne double.
                    book.AddGrade(grade); // shtpkm vleren ne addGrade
                    
                }

                // catch kap throw qe eshte tek book.cs duke afishuar message dhe duke mos bere crash
                catch (AggregateException ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
               

           }




           // book.Name = "";
            Console.WriteLine($"For the book name {book.Name}");
            Console.WriteLine($"The grade is:{stat.Result:N1} ");
            Console.WriteLine($"The avarage is:{stat.Average:N1}");
            Console.WriteLine($"The low grade is:{stat.Low}");
            Console.WriteLine($"The Hight grade is:{stat.Hight}");
            Console.WriteLine($"The letter Grade is: {stat.Letter}");



        }
    }
}
