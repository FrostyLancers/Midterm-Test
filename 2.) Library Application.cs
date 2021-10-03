using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.__Library_Application
{
    class Person
    {
        public string name;
        public string password;

        public Person(string name, string password)      // สร้างคลาส Person ขึ้นมา
        {
            this.name = name;
            this.password = password;
        }
    }

    class Student : Person          // คลาส Student ที่ Inherit กับ Person
    {
        public string studentID;

        public Student(string name, string password, string studentID) : base(name, password)
        {
            this.studentID = studentID;
        }
    }

    class Employee : Person            // คลาส Employee ที่ Inherit กับ Person
    {
        public string employeeID;

        public Employee(string name, string password, string employeeID) : base(name, password)
        {
            this.employeeID = employeeID;
        }
    }

    enum MainMenu
    {
        Login = 1,
        Register
    }

    enum Register
    {
        Student = 1,
        Employee
    }

    class Program
    {
        public static List<Student> student = new List<Student>();          // สร้าง List student ที่ไว้เก็บ name, password, studentID
        public static List<Employee> employee = new List<Employee>();       // สร้าง List employee ที่ไว้เก็บ name, password, employeeID

        static void Main(string[] args)
        {
            MainMenuScreen();              // ไปหน้า Main Menu
        }

        static void MainMenuScreen()
        {
            Console.Clear();
            MainMenuHeadLine();
            MainMenuChoices();
            InputMainMenuChoices();
        }

        static void MainMenuHeadLine()
        {
            Console.WriteLine("Welcome to Digital Library");
            Console.WriteLine("--------------------------");
        }

        static void MainMenuChoices()
        {
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
        }

        static void InputMainMenuChoices()              // ให้เลือกว่าจะ Login หรือจะ Register
        {
            Console.Write("Select Menu: ");
            MainMenu mainMenuChoice = (MainMenu)(int.Parse(Console.ReadLine()));

            MainMenuDestination(mainMenuChoice);
        }

        static void MainMenuDestination(MainMenu mainMenuChoice)
        {
            switch (mainMenuChoice)
            {
                case MainMenu.Login:
                    LoginToLibraryApp();        // หากกด 1 จะไปยังหน้า Login
                    break;
                case MainMenu.Register:
                    RegisterNewPerson();        // หากกด 2 จะไปยังหน้า Register
                    break;
                default:
                    IncorrectMenuMessage();     // หากกดอย่างอื่นจะไปหน้า IncorrectMessage
                    break;
            }
        }

        static void IncorrectMenuMessage()
        {
            Console.Clear();
            Console.WriteLine("Please input avaliable menu.");       // ต้องไปเลือกใหม่
            MainMenuChoices();
        }

        static void RegisterNewPerson()
        {
            Console.Clear();
            RegisterScreen();
        }

        static void RegisterScreen()
        {
            RegisterScreenHeadLine();
            RegisterScreenChoices();
        }

        static void RegisterScreenHeadLine()          //เฮดไลน์ของหน้า Register
        {
            Console.WriteLine("Register New Person");
            Console.WriteLine("-------------------");
        }

        static void RegisterScreenChoices()          // ใส่ชื่อกับรหัสโดยจะเก็บไว้ที่ตัวแปร name, password
        {
            Console.Write("Input Name: ");
            string name = Console.ReadLine();
            Console.Write("Input Password: ");
            string password = Console.ReadLine();

            StudentOrEmployee(name, password);       // คัดแยกว่าเป็น student หรือ employee
        }

        static void StudentOrEmployee(string name, string password)
        {
            string studentID;
            string employeeID;

            Console.Write("Input User Type 1 = Student, 2 = Employee: ");
            Register UserType = (Register)(int.Parse(Console.ReadLine()));        // ให้กำหนดตัวแปร UserType 

            if (UserType == Register.Student)          // หาก Usertype เป็น 1 ให้ใส่ studentID
            {
                Console.Write("Student ID: ");
                studentID = Console.ReadLine();

                Student studentList = new Student(name, password, studentID);

                Student student01 = new Student(name, password, studentID);       // สร้างตัวแปร student01 ที่เก็บ name, password, studentID
                student.Add(student01);       // เอา student01 เก็บไว้ใน List student

                MainMenuScreen();
            }
            else if (UserType == Register.Employee)      // หาก UserType เป็น 2 ให้ใส่ EmployeeID
            {
                Console.Write("Employee ID: ");
                employeeID = Console.ReadLine();

                Employee employeeList = new Employee(name, password, employeeID);

                Employee employee01 = new Employee(name, password, employeeID);       // สร้างตัวแปร employee01 ที่เก็บ name, password, employeeID
                employee.Add(employee01);         // เอา employee01 เก็บไว้ใน List employee

                MainMenuScreen();          // กลับหน้า Main Menu
            }
            else
            {
                Console.Clear();        // หาก UserType เป็นอย่างอื่นก็แจ้งเตือนแล้วใส่ใหม่
                Console.WriteLine("Please select the available options.");
                StudentOrEmployee(name, password);
            }
        }

        static void LoginToLibraryApp()
        {
            Console.Clear();
            LoginScreenHeadLine();      
            LoginScreenChoices();
        }

        static void LoginScreenHeadLine()       // เฮดไลน์ของหน้า Login
        {
            Console.WriteLine("Login Screen");
            Console.WriteLine("------------");
        }

        static void LoginScreenChoices()
        {
            RegisterOrNot();         // ตรวจสอบว่าเคย Register เข้าไปแล้วหรือยัง

            InputLoginScreenChoices();
        }

        static void RegisterOrNot()
        {
            if (student.Count == 0 && employee.Count == 0)      // หากไม่มีข้อมูลใน List student กับ employee ให้กลับไป Main Menu เพื่อ Register ก่อน 
            {
                Console.Clear();
                Console.WriteLine("Please Register before using. Press to Continue.");
                Console.ReadLine();

                MainMenuScreen();
            }
        }

        static void InputLoginScreenChoices()
        {
            Console.Write("Input Name: ");       // สร้างตัวแปรไว้ Username เก็บข้อมูลชื่อที่กรอกเข้ามา
            string Username = Console.ReadLine();
            Console.Write("Input Password: ");     // สร้างตัวแปรไว้ UserPassword เก็บข้อมูลรหัสที่กรอกเข้ามา
            string UserPassword = Console.ReadLine();

            Login(Username, UserPassword);
        }

        static void Login(string Username, string UserPassword)          // หลังจากนี้คือมั่วแหลกแล้วครับ...
        {
            string s = String.Join("", student);

            if (s.Contains(Username) && s.Contains(UserPassword))
            {
                StudentScreen();
            }
            else
            {
                EmployeeScreen();
            }
        }

        static void EmployeeScreen()
        {
            EmployeeScreenHeadLine();
            EmployeeScreenDescriptions();
        }

        static void EmployeeScreenHeadLine()
        {
            Console.WriteLine("Book List");
            Console.WriteLine("---------");
        }

        static void EmployeeScreenDescriptions()
        {
            Console.WriteLine(@"Book ID: 1
Book name: NOW I UNDERSTAND
Book ID: 2
Book name: REVOLUTIONARY WEALTH
Book ID: 3
Book name: Six Degrees
Book ID: 4
Book name: Les Vacances");
            return;
        }

        static void StudentScreen()
        {
            StudentScreenHeadLine();
            StudentScreenChoices();
        }

        static void StudentScreenHeadLine()
        {
            Console.WriteLine("Student Management");
            Console.WriteLine("------------------");

            Console.WriteLine("");

            Console.WriteLine("Name: 1");
            Console.WriteLine("Student ID: 123456");
        }

        static void StudentScreenChoices()
        {

        }
    }
}