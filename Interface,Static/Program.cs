using Interface_Static.Extensions;
using Interface_Static.Models;
using i = Task3.Models;

namespace Interface_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //#region Task1
            //restart:
            //    Console.WriteLine("Ad daxil edin:");
            //    string name=Console.ReadLine();
            //    Console.WriteLine("Soyad daxil edin:");
            //    string surname=Console.ReadLine();
            //    if(Student.CheckNameAndSurname(name, surname))
            //    {
            //        Student student = new(name,surname );
            //        Console.WriteLine(student.CodeEmail);

            //    }
            //    else
            //    {
            //        Console.WriteLine("Duzgun simvollar daxil edin:");
            //        goto restart;
            //    }

            //    #endregion


            //task3 note console app a cixariram bunlara ehtiyac yoxdur :D


            //i.Student student1 = new i.Student("Asiman","Qasimzade");
            //i.Student student2 = new i.Student("Zulfiyye","Qurbanzade");
            //i.Student student3 = new i.Student("Sebuhi","Camalzade");
            //i.Student student4 = new i.Student("Shamama","Quliyeva");

            //i.Group group = new("AB104");
            i.Group group2 = new("AF104");
            //i.Group.AddGroup(group);
            i.Group.AddGroup(group2);
        //group.AddStudent(student1);
        //group.AddStudent(student2);
        //group.AddStudent(student3);
        //group.AddStudent(student4);
        //group2.AddStudent(student1);
        //group2.AddStudent(student2);
        //group2.AddStudent(student3);
        //group2.AddStudent(student4);
        //var result=group.Search("asassaassaas");
        //group.RemoveStudent(1);
        //group.ShowStudents();
        restart:
            Console.WriteLine("Welcome to CodeAcademy :)");
            Console.WriteLine("1.Get All Groups");
            Console.WriteLine("2.Create Groups");
            Console.WriteLine("3.Add Student to Group");
            Console.WriteLine("4.Get Group Students");
            Console.WriteLine("5.Remove Student to Group");
            Console.WriteLine("6.Search");
            Console.WriteLine("0.Exit");

            char result = Console.ReadKey().KeyChar;
            switch (result)
            {
                case '1':
                    Console.Clear();
                    i.Group.ShowAllGroups();
                    Console.WriteLine();
                    break;
                case '2':
                    Console.Clear();
                    CreateGroup();
                    Console.WriteLine();
                    break;
                case '3':
                    Console.Clear();
                    CreateStudentAndAddGroup();
                    break;
                case '4':
                    Console.Clear();
                    var groupInfo = SelectGroup();
                    if (groupInfo != null)
                        groupInfo.ShowStudents();
                    break;
                case '5':
                    Console.Clear();
                    RemoveStudent();
                    break;
                case '6':
                    Console.Clear();
                    Searching();
                    break;
                case '0':
                    Console.WriteLine("Goodbye...");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Please enter valid number");
                    break;

            }
            goto restart;


        }


        public static void RemoveStudent()
        {

            var groupRemove = SelectGroup();
            groupRemove.ShowStudents();
        restart:
            Console.WriteLine("Enter the Student Id:");
            bool isParse = int.TryParse(Console.ReadLine(), out int id);
            if (isParse)
            {
                groupRemove.RemoveStudent(id);
            }
            else
            {
                Console.WriteLine("Please enter valid number");
                goto restart;
            }
        }
        public static i.Group SelectGroup()
        {
            Console.WriteLine("To which group you want, enter the id:");
            i.Group.ShowAllGroups();
            bool isParse = int.TryParse(Console.ReadLine(), out int groupId);
            if (!isParse)
            {
                Console.WriteLine("Invalid Symbol!400.");
                return null;
            }
            foreach (var group in i.Group.Groups)
            {
                if (group.GroupId == groupId)
                {
                    return group;
                }
            }
            Console.WriteLine("Group is Not Found!404.");
            return null;
        }




        public static void CreateGroup()
        {
            Console.WriteLine("Enter the Group Name");
        restart:
            string name = Console.ReadLine();
            if (name.Length < 2)
            {
                Console.WriteLine("Enter the valid Name");
                goto restart;
            }
            i.Group group = new(name);
            i.Group.AddGroup(group);

        }
        public static void CreateStudentAndAddGroup()
        {
            var group = SelectGroup();
            if (group is not null)
            {

            restart:
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the surname");
                string surname = Console.ReadLine();
                if (i.Student.CheckNameAndSurname(name, surname))
                {
                    i.Student student = new(name.Capitalize(), surname.Capitalize());
                    group.AddStudent(student);
                }
                else
                {
                    Console.WriteLine("Wrong input!400.");
                }

            }

        }
        public static void Searching()
        {
            var group = SelectGroup();
            if(group is not null)
            {

            Console.WriteLine("Who are you looking for?");
            string searh = Console.ReadLine();
            var arr = group.Search(searh);
            if (arr != null)
            {

                foreach (var item in arr)
                {
                    item.GetInfo();
                }
            }
            }
        }
    }
}