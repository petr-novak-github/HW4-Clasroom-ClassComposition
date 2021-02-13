using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheClassRoom
{

    class Classroom
    {
        private Teacher teacher;
        private Student[] students;
        private int currentNumberOfStudents;
        private int maxStudentuVeTride;

        //gettery

        public Teacher GetTeacher() { return teacher; }
        public Student[] GetStudent() { return students; }
        public int GetCurrentNumberOfStudent() { return currentNumberOfStudents; }
        public int GetMaxStudentuVeTride() { return maxStudentuVeTride; }

        //settry

        public void SetTeacher(Teacher teacher) { this.teacher = teacher; }
        public void SetStudent(Student[] students) { this.students = students; }
        public void SetCurrentNumberOfStudents(int currentNumberOfStudents) { this.currentNumberOfStudents = currentNumberOfStudents; }
        public void SetMaxStudentuVeTride(int maxStudentuVeTride) { this.maxStudentuVeTride = maxStudentuVeTride; }
        
        
        // konstruktory
        public Classroom() { }
        public Classroom(int maxStudentuVeTride) {this.maxStudentuVeTride = maxStudentuVeTride; }

        // dalsi verejne metody

        public bool AddStudent(Student student) {

            int k = 0;
            bool added = false;
            bool volnaBunka = false;
            int[] volneBunky = new int[students.Length];
            int prvniVolnaBunka = 0;
            //zjisteni jestli ma pole students nejakou volnou bunku
            for (int j = 0; j < students.Length; j++)
            {
                if (students[j]==null)
                {
                    volnaBunka = true;
                    volneBunky[k] = j;
                    k++;
                }
            }
            //kdyz ma tak tam soupni studenta
            if (volnaBunka)
            {
                prvniVolnaBunka = volneBunky[0];
                students[prvniVolnaBunka] = student;
                added = true;
            }
                        
            return added;
        }
       
        public bool RemoveStudent(Student student) {
            //zjisteni jestli je student ve tride, jestli jo tak ho smazu

            bool smazan = false;
            for (int j = 0; j < students.Length; j++)
            {
                if (students[j] == student)
                {
                    smazan = true;
                    students[j] = null;
                }
            }
            return smazan;
           
        }

        public override string ToString()
        {
            string retStudenti = "";

            for (int j = 0; j < students.Length; j++)
            {
                if (students[j] != null)
                {
                    retStudenti = retStudenti + " /n" + students[j].ToString();
                }
            }

            return $"Jmeno ucitele je: {teacher.ToString()} /n " +
                $"Studenti teto tridy jsou: {retStudenti}";

            //pole students
            //smycka pres cele pole a vypis jejich jmen do stringu a ten string pridat do returnu
            //toho ucitele bych mohl volat nakou metodu z tridy ucitel, treba to string, nebo naky getter, nevim jeste
            //jo, je to i v zadani, musim volat ToStringy prislusnych trid
        }
    }

    class Teacher
    {
        private string teacherName;
        private string sex;
        private Classroom trida;

        public Teacher(){}

        public Teacher(string teacherName, string sex, Classroom trida)
        {
            this.teacherName = teacherName;
            this.sex = sex;
            this.trida = trida;
        }

        public void AddTeacherToClassroom(Classroom trida) {
            this.trida = trida;
        }

        public override string ToString()
        {
            return teacherName;
        }
    }

    class Student
    {
        private string firstName;
        private string lastName;
        private double age;
        private double average;

        public Student(string firstName, string lastName, double age, double average)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.average = average;
        }

        public override string ToString()
        {
            return  $"Jmeno studenta je:{firstName} {lastName} /n" +
                    $"Vek studenta je: {age} /n" +
                    $"Prumer znamek studenta je: {average}";
        }
    }


    class TestProgram
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Petr", "Novak", 38, 1);
            Student s2 = new Student("Josef", "Kaplan", 39, 4);
            Student s3 = new Student("Jiri", "Vojkovsky", 38, 3);
            Student s4 = new Student("Karel", "Vojkovsky", 39, 1);
            Student s5 = new Student("Lukas", "Vojkovsky", 41, 3);
            Student s6 = new Student("Zdenek", "Vojkovsky", 63, 2);
            Student s7 = new Student("Ladislav", "Novak", 63, 5);
          
            Student sx1 = new Student("Dana", "Novakova", 63, 2);

            Classroom cl1 = new Classroom(10);
            Classroom cl2 = new Classroom(15);

            Student[] poleStudentuTridy1 = new Student[cl1.GetMaxStudentuVeTride()];
            poleStudentuTridy1[0] = s1;
            poleStudentuTridy1[1] = s2;
            poleStudentuTridy1[2] = s3;
            Student[] poleStudentuTridy2 = new Student[cl2.GetMaxStudentuVeTride()];
            poleStudentuTridy2[0] = s4;
            poleStudentuTridy2[1] = s5;
            poleStudentuTridy2[2] = s6;
            poleStudentuTridy2[3] = s7;

            Teacher tch1 = new Teacher("Vaclav Navrat", "male", cl1);
            Teacher tch2 = new Teacher("Jarka Krupova", "female", cl2);

            cl1.SetStudent(poleStudentuTridy1);
            cl1.SetTeacher(tch1);

            cl2.SetStudent(poleStudentuTridy2);
            cl2.SetTeacher(tch2);
            Console.WriteLine(cl1.ToString());
            Console.WriteLine(cl1.GetTeacher());

            Console.ReadLine();

        }

    }
}
