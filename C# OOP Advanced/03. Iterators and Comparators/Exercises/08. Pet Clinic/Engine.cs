using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Engine
{
    private ClinicsManager manager;
    private StringBuilder activityReport;

    public Engine()
    {
        this.manager = new ClinicsManager();
        this.activityReport = new StringBuilder();
    }

    public void Run()
    {
        var numberOfCommands = int.Parse(Console.ReadLine());

        while (numberOfCommands > 0)
        {
            var command = Console.ReadLine().Split();
            string clinicName;
            string operationResult;

            try
            {
                switch (command[0])
                {
                    case "Create":
                        this.ProcessCreation(command.Skip(1).ToArray());
                        break;
                    case "Add":
                        var petName = command[1];
                        clinicName = command[2];
                        operationResult = this.manager.AddPetToAClinic(petName, clinicName).ToString();
                        Console.WriteLine(operationResult);
                        break;
                    case "Release":
                        clinicName = command[1];
                        operationResult = this.manager.ReleaseAnumalFromClinic(clinicName).ToString();
                        Console.WriteLine(operationResult);
                        break;
                    case "HasEmptyRooms":
                        clinicName = command[1];
                        Console.WriteLine(this.manager.HasEmptyRooms(clinicName).ToString());
                        break;
                    case "Print":
                        this.ProcessPrinting(command.Skip(1).ToArray());
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            numberOfCommands--;
        }

        
    }

    private void ProcessPrinting(string[] command)
    {
        var clinicName = command[0];

        if (command.Length > 1)
        {
            var roomNumber = int.Parse(command[1]);
            Console.WriteLine(this.manager.PrintRoom(clinicName, roomNumber));
        }
        else
        {
            Console.WriteLine(this.manager.PrintClinic(clinicName));
        }
    }

    private void ProcessCreation(string[] cmdArgs)
    {
        var name = cmdArgs[1];

        if (cmdArgs[0] == "Pet")
        {
            var age = int.Parse(cmdArgs[2]);
            var kind = cmdArgs[3];
            this.manager.CreatePet(name, age, kind);
        }
        else if (cmdArgs[0] == "Clinic")
        {
            var rooms = int.Parse(cmdArgs[2]);

            try
            {
                this.manager.CreateClinic(name, rooms);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}