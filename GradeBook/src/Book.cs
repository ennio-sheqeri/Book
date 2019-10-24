using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public delegate void GradeAddedDelegate(Object sender, EventArgs args);

        public Book(string name)
        {
            grades = new List<double>();//konstruktori qe mer grades
            this.name = name;//do kerkoje emrin sa her qe thirret klasa dhe kontruktori duke perdor this. duke perdor per ti referuar nje objekti

        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }

        }

        public void AddGrade(double grade)// metoda addgrade 
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade); // shtojme grades qe deklaruam me poshte notat (grade)
                if (GradeAdded !=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            { 
                // pra ben throw nje argumentExpception me peshkrimin perkates
                // {nameof(grade)} ka cdo variabel qe ne kemi deklaruar ne app ne rastin tone grade 
                throw new ArgumentException($"Invalid Grade {nameof(grade)}");  // kap argumet exepions dhe shfaqet vetem kur kemi venod ndonje vlere gabim

            }

        }

        public event GradeAddedDelegate GradeAdded;
        public Statistics GetStatistics()
        {
            var result = new Statistics(); //deklarojme variablene tipit var e cila e inicializojme me double 
            result.Low = double.MaxValue;
            result.Hight = double.MinValue;
           //foreach (var grade in grades) // sheben per te kapur te gjitha grades qe futen ne app 
            for (var index = 0; index < grades.Count; index++)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.Hight = Math.Max(grades[index], result.Hight);

                result.Result += grades[index]; // mbledh te gjithe nr 

            }
             result.Average = result.Result / grades.Count; // kalkulimi i avarages 

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }



            return result;
        }
        List<double> grades; // deklarojm listen te quajtur grades
        private string name; //deklarojme sting name per te venos emrin librit 
       

        public string Name
        {
            get;
            private set;

        }
    }
}