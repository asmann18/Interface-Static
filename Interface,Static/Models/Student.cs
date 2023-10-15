using Interface_Static.Interfaces;

namespace Interface_Static.Models;

public class Student:ICodeAcademy
{
    static int Count = 0;
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public string CodeEmail { get; init; }
    public Student(string name,string surname)
    {
        Count++;
        Id = Count;
        Name = name;
        Surname = surname;
        CodeEmail = GenerateEmail();
    }
    public static bool CheckNameAndSurname(string name, string surname)
    {
        if (name.Length > 3 && surname.Length>3 && name.Length<25 && surname.Length<25)
        {
            return true;
        }
        return false;
    }

    public string GenerateEmail()
    {
        return $"{Name.ToLower()}.{Surname.ToLower()}{Id}@code.edu.az";
    }
}
