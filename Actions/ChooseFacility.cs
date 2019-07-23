using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseFacility
    {
        public static bool CollectInput(Farm farm, IResource resource, List<Facility> facilityList)
        {
            Console.Clear();

            //gets only the facilities that are not full
            var facilityWithCapacity = facilityList.Where(facility => !facility.Full).ToList();

            Console.WriteLine($"Available Facilities:");
            Console.WriteLine("");
            //allows users to only select facilities that have the capacity to add a resource
            for (int i = 0; i < facilityWithCapacity.Count; i++)
            {
                var cFacility = facilityWithCapacity[i];
                Console.WriteLine($"{i + 1}. {cFacility.Type} ({cFacility.Total} {cFacility.Category})");
                cFacility.ResourceTypes.ForEach(r => Console.WriteLine($"    - {r.Type}: {r.Total} {cFacility.Category}"));
            }

            Console.WriteLine();

            Console.WriteLine($"Place the {resource.Type} where?");

            Console.Write("> ");

            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the facility that was selected by the user
                Facility selectedFacility = facilityWithCapacity[choiceIndex];
                //finds the facility in the facilityList on the farm instance using the FacilityId
                Facility facilityOnFarm = facilityList.Find(field => field.FacilityId == selectedFacility.FacilityId);
                //adds resource to the Facility on the farm
                facilityOnFarm.AddResource(resource);
                Console.WriteLine($"You added a {resource.Type} to a {selectedFacility.Type}!");
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                //return false so the user returns to the main menu
                return false;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection.");
                Console.WriteLine("Please press enter to select another facility or enter 0 to return to main menu");
                Console.Write("> ");

                //if user enters 0, they will be brought to the main menu, if they enter anything else they will be brought back to the facility menu
                if (Console.ReadLine() == "0")
                {
                    //return false so the user returns to the main menu
                    return false;
                }
                else
                {
                    //return true so the user returns to the list of facilities
                    return true;
                }

            }
        }
    }
}