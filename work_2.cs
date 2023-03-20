using System;

public class Student : IComparable<Student>
{
    public double mygrade;
    public string mysubject, myID;
    public Student() { }
    public Student(double grade, string subject, string id)
    {
        mygrade = grade;
        mysubject = subject;
        myID = id;
    }
    // 请在此处添加关键代码···
    public int CompareTo(Student t)
    {
        return mygrade.CompareTo(t.mygrade);
    }
}

internal class Program
{

    private static void Main(string[] args)
    {
        Student[] students = new Student[5];
        students[0] = new Student(50.0, "windows程序设计", "001");
        students[1] = new Student(90.0, "windows程序设计", "002");
        students[2] = new Student(100.0, "windows程序设计", "003");
        students[3] = new Student(70.0, "windows程序设计", "004");
        students[4] = new Student(80.0, "windows程序设计", "005");
        // 请在此处添加关键代码···
        Array.Sort(students);
        foreach (Student student in students)
        {
            Console.Write(student.mygrade + " " + student.mysubject + " " + student.myID + '\n');
        }
    }
}
