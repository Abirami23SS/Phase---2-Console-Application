﻿using System;
namespace BloodBankApplication;
class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        FileHandling.ReadToCSV();
        //Operation.AddDefaultData();
        Operation.MainMenu();
        FileHandling.WriteToCSV();
    }
}