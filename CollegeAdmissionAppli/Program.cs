using System;
using System.Collections.Generic;
namespace CollegeAdmissionAppli;
class Program
{
    public static void Main(string[] args)
    {
        //Document file 
        List<StudentDetails> studentList = new List<StudentDetails>();
        string option = "";
        do
        {
            //StudentDetails student1 = new StudentDetails();
            Console.WriteLine("User Regestration form:");
            Console.WriteLine("Enter you name:");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter your Father name:");
            string fatherName = Console.ReadLine();
            Console.WriteLine("Enter you Gender:");
            string gender = Console.ReadLine();
            Console.WriteLine("Enter you DOB:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Enter your Phone Number:");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Physics Mark:");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Chemistry Mark:");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Maths Mark:");
            int maths = int.Parse(Console.ReadLine());

            // passing the values for constructor.
            StudentDetails student = new StudentDetails(studentName, fatherName, gender, dob, phone, physics, chemistry, maths);
            //auto increment id 
            Console.WriteLine("You have registried successfully!!!. Your ID : " + student.StudentId);


            // this is for adding more than one student in a list.
            studentList.Add(student);
            Console.WriteLine("----Do you want to continue?----");
            option = Console.ReadLine();

        } while (option == "yes");

        Console.WriteLine("---Enter your Student id to Login---");
        string loginID = Console.ReadLine().ToUpper();

        bool flag = true;  //if user not found
        foreach (StudentDetails student in studentList)
        {
            if (student.StudentId == loginID)
            {
                flag = false;
                Console.WriteLine("Name:" + student.StudentName + "\nFatherName: " + student.FatherName);
                Console.WriteLine("DOB:" + student.DOB + "\nGender: " + student.Gender);
                Console.WriteLine("Physics:" + student.Physics + "\nChemistry: " + student.Chemistry);
                Console.WriteLine("Maths:" + student.Maths);
                bool eligibility = student.IsEligibility(75);
                if (eligibility)
                {
                    Console.WriteLine("You are eligible");
                }
                else
                {
                    Console.WriteLine("You are not eligible");
                }
            }
        }
        if (flag)
        {
            Console.WriteLine("Invalid user Id");
        }
        // GC.Collect();
        // GC.WaitForPendingFinalizers();
        // Console.WriteLine("Code Ended");

    }
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Code Ended");
}