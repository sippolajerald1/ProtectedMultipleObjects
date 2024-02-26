
using System.ComponentModel.Design;

namespace PrivateMultipleObjects
{

    // Base Class
    class Machines
    {
        protected int _CompanyNumber;
        protected string _Manufacturer;
        protected string _Description;
        protected string _GeneralSize;


        // default constructor
        public Machines()
        {
            _CompanyNumber = 0;
            _Manufacturer = string.Empty;
            _Description = string.Empty;
            _GeneralSize = string.Empty;
        }

        //parameterized constructor
        public Machines(int companynumber, string manufacturer, string description, string generalsize)
        {
            _CompanyNumber = companynumber;
            _Manufacturer = manufacturer;
            _Description = description;
            _GeneralSize = generalsize;
        }





        public virtual void addChange()
        {
            Console.Write("Company Number =");
            _CompanyNumber = (int.Parse(Console.ReadLine()));
            Console.Write("Manufacturer=");
            _Manufacturer = (Console.ReadLine());
            Console.Write("Description=");
            _Description = (Console.ReadLine());
            Console.Write("Size=");
            _GeneralSize = (Console.ReadLine());
        }


        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"   CompanyNumber: {_CompanyNumber}");
            Console.WriteLine($"   Manufacturer: {_Manufacturer}");
            Console.WriteLine($"   Description: {_Description}");
            Console.WriteLine($"   GeneralSize: {_GeneralSize}");
        }



        class InjectionMoldingMachines : Machines
        {
            protected double _Cost;
            protected string _MachineType;

            public InjectionMoldingMachines()
                : base()
            {
                _CompanyNumber = 0;
                _Manufacturer = string.Empty;
                _Description = string.Empty;
                _GeneralSize = string.Empty;
                _MachineType = string.Empty;
                _Cost = 0;
            }

            public InjectionMoldingMachines(int companynumber, string manufacturer, string description, string generalsize, double cost, string machinetype)

            {
                _CompanyNumber = companynumber;
                _Manufacturer = manufacturer;
                _Description = description;
                _GeneralSize = generalsize;
                _MachineType = machinetype;
                _Cost = cost;

            }


            public override void addChange()
            {
                Console.WriteLine("InjectionMoldingMachine Information");
                Console.Write($"Company Number");
                _CompanyNumber = int.Parse(Console.ReadLine());
                Console.Write("Manufacturer =");
                _Manufacturer = Console.ReadLine();
                Console.Write("Description = ");
                _Description = Console.ReadLine();
                Console.Write("General Size=");
                _GeneralSize = Console.ReadLine();
                Console.Write("Cost=");
                _Cost = double.Parse(Console.ReadLine());
                Console.Write("Machine Type= ");
                _MachineType = Console.ReadLine();

            }


            public override void print()
            {
                Console.WriteLine();
                Console.WriteLine("        Injection Molding Machines          ");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"       Machine Number: {_CompanyNumber} Manufacturer: {_Manufacturer} Description: {_Description}");
                Console.WriteLine($"       Cost: {_Cost}                    ");
                Console.WriteLine($"       Machine Type: {_MachineType}");
                Console.WriteLine();


            }





            internal class Program
            {

                static void Main(string[] args)
                {

                    Console.WriteLine("How many machines do you want to enter?");
                    int maxMachines;
                    while (!int.TryParse(Console.ReadLine(), out maxMachines))
                        Console.WriteLine("Please enter a whole number");
                    // array of machine objects
                    Machines[] mach = new Machines[maxMachines];
                    Console.WriteLine("How many Injection Molding Machines do you want to enter?");
                    int Maxinjctn;
                    while (!int.TryParse(Console.ReadLine(), out Maxinjctn)) ;
                    Console.WriteLine("Please enter a whole number");

                    // array of injection molding machines objects
                    InjectionMoldingMachines[] ijmm = new InjectionMoldingMachines[Maxinjctn];

                    int choice, rec, type;
                    int machineCounter = 0, InjectionCounter = 0;
                    choice = Menu();
                    while (choice != 4)
                    {
                        Console.WriteLine("Enter 1 for Machines or 2 for injection molding machines");
                        while (!int.TryParse(Console.ReadLine(), out type)) ;
                        Console.WriteLine("1 for injection molding machine or 2 for machines");

                        try
                        {
                            switch (choice)
                            {
                                case 1: // Add
                                    if (type == 1) // Injection molding machine
                                    {
                                        if (InjectionCounter <= Maxinjctn)
                                        {
                                            ijmm[InjectionCounter] = new InjectionMoldingMachines(); // places an object in the array instead of null
                                            ijmm[InjectionCounter].addChange();
                                            InjectionCounter++;

                                        }

                                        else
                                            Console.WriteLine("The maximum number of injection molding machines have been added");
                                    }

                                    else // Machine

                                    {
                                        if (machineCounter <= maxMachines)
                                        {
                                            mach[machineCounter] = new Machines(); // places an object in the array instead of null
                                            mach[machineCounter].addChange();
                                            machineCounter++;
                                        }

                                        else
                                            Console.WriteLine("The maximum number of managers has been added");

                                    }
                                    break;

                                case 2: // Change
                                    Console.Write("Enter the record number you want to change: ");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--; // subtract 1 because array index begins at 0
                                    if (type == 1) //injection molding machines
                                    {
                                        while (rec > InjectionCounter - 1 || rec < 0)
                                        {
                                            Console.Write("The number you enterred is out of range, try again");
                                            while (!int.TryParse(Console.ReadLine(), out rec))
                                                Console.Write("Enter the record number you want to change: ");
                                            rec--;
                                        }
                                        mach[rec].addChange();
                                    }
                                    break;
                                case 3: // Print All
                                    if (type == 1) // Injection Molding Machine
                                    {
                                        for (int i = 0; i < InjectionCounter; i++)
                                            ijmm[i].print();
                                    }

                                    else // Machines{
                                    {
                                        for (int i = 0; i < machineCounter; i++)
                                            mach[i].print();
                                    }
                                    break;
                                default:
                                    Console.WriteLine(("You made an invalid selection, please try again"));
                                    break;
                            }

                        }

                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        choice = Menu();


                    }


                }

                private static int Menu()
                {
                    Console.WriteLine("Please make a selection from the menu");
                    Console.WriteLine("1-Add 2-Change 3-Print 4-Quit) ");
                    int selection = 0;
                    while (selection < 1 || selection > 4)
                        while (!int.TryParse(Console.ReadLine(), out selection))
                            Console.WriteLine("1-Add 2-Change 3-Print 4-Quit");
                    return selection;
                }
            }
        }
    }
}
