using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionAppli
{
  public class StudentDetails
  {
    //field
    private static int s_studentId=1000;
    //private string _studentName;
    //properties
    //public string StudentName
    //{
    //     get
    // { return _studentName; }
    // set
    // {_studentName=value;} //value=keyword
    // }
    //public string FatherName{get;set; }
    //AutoProperty
    public string StudentId { get;} //read-only property   
    public string StudentName { get; set; }
    public string FatherName { get; set; }
    public string Gender { get; set; }
    public DateTime DOB { get; set; }
    public long Phone { get; set; }
    public int Physics { get; set; }
    public int Chemistry { get; set; }
    public int Maths { get; set; }

    //events
    //Indexers
    //Constructor
    //default constructor
    public StudentDetails()
    {
      StudentName = "Enter your name";
      FatherName = "Enetr your father name";
      Gender = "Enter your gender";
    }
    //Parameterized constructor
    public StudentDetails(string studentName, string fatherName, string gender, DateTime dob, long phone,
                      int physics, int chemistry, int maths)
    {
      s_studentId++;
      StudentId="SF"+s_studentId;
      StudentName = studentName;
      FatherName = fatherName;
      Gender = gender;
      DOB = dob;
      Phone = phone;
      Physics = physics;
      Chemistry = chemistry;
      Maths=maths;
    }
    //Destructor  and // disposabales
    ~StudentDetails()
    {
      Console.WriteLine("Destructor called ");
    }
    //method
    public double Average()
    {
      return double(Physics+Chemistry+Maths)/3 ;
    }

    public bool IsEligibility(double cuttoff)
    {
       // average=(double)(Physics+Chemistry+Maths)/3;
       if(Average()>=cuttoff)
       {
        return true;
        return false;
       }
    }

  }
}