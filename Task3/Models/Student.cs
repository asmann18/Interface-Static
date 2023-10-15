namespace Task3.Models;

public class Student
{
    static int Count=0;
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Student(string name,string surname)
    {
        Count++;
        Id= Count;
        Name= name;
        Surname= surname;

    }
    public void GetInfo()
    {
        Console.WriteLine($"{Id} No---Name:{Name}  Surname:{Surname}");

    }
    public static bool CheckNameAndSurname(string name, string surname)
    {
        if (name.Length > 3 && surname.Length > 3 && name.Length < 25 && surname.Length < 25)
        {
            return true;
        }
        return false;
    }
}
