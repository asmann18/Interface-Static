namespace Task3.Models;

public class Group
{
    public static Group[] Groups = new Group[0];
    static int GroupCount = 0;
    public int GroupId { get; init; }
    public string GroupName { get; set; }
    public Student[] Students = new Student[0];
    public Group(string groupName)
    {
        GroupCount++;
        GroupId = GroupCount;
        GroupName = groupName;
    }
    public void GetGroupInfo()
    {
        Console.WriteLine($"GroupId:{GroupId} ***** {GroupName} Group ------  Student Count:{Students.Length}");
    }
    public Student GetStudent(int studentId)
    {
        foreach (Student student in Students)
        {
            if (student.Id == studentId) return student;
        }
        return null;
    }
    public void AddStudent(Student student)
    {
        Array.Resize(ref Students, Students.Length + 1);
        Students[^1] = student;
        Console.WriteLine("Student successfully added");
    }
    public Student[] Search(string search)
    {
        Student[] result = new Student[0];
        foreach (Student student in Students)
        {
            if (student.Name.Contains(search) || student.Surname.Contains(search))
            {
                Array.Resize(ref result, result.Length + 1);
                result[^1] = student;
            }
        }
        if (result.Length == 0)
        {
            Console.WriteLine("Student is not fount!404.");
            return null;
        }


        return result;
    }
    public void RemoveStudent(int studentId)
    {
        for (int i = 0; i < Students.Length; i++)
        {
            if (Students[i].Id == studentId)
            {
                RemoveElementInArray(ref Students, i);
                Console.WriteLine("Student is removed");
                return;
            }
        }
        Console.WriteLine("Student is not found?");
    }
    public void ShowStudents()
    {
        GetGroupInfo();
        foreach (Student student in Students)
        {
            student.GetInfo();
        }
    }

    public static void ShowAllGroups()
    {
        for(int i = 0; i < Groups.Length; i++)
        {
            Groups[i].GetGroupInfo();
        }
    }
    public static void AddGroup(Group group)
    {
        Array.Resize(ref Groups, Groups.Length+1);
        Groups[^1]= group;
        Console.WriteLine("Group is successfully added");
    }
    public void RemoveElementInArray(ref Student[] students, int index)
    {
        for (int i = index; i < students.Length - 1; i++)
        {
            students[i] = students[i + 1];
        }
        Array.Resize(ref students, students.Length - 1);
    }
}
