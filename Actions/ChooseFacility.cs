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
            var facilityWithCapacity = facilityList.Where(facility => facility.Total != facility.Capacity).ToList();

            Console.WriteLine($"Available Facilities:");
            Console.WriteLine("");
            //allows users to only select facilities that have the capacity to add a resource
            for (int i = 0; i < facilityWithCapacity.Count; i++)
            {
                var cFacility = facilityWithCapacity[i];
                Console.WriteLine($"{i + 1}. {cFacility.Type} ({cFacility.Total} animals)");
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
        public static bool CollectInput(Farm farm, IResource resource, List<PlantFacility> fieldList)
        {
            Console.Clear();

            //gets only the fields that are not full
            var fieldWithCapacity = fieldList.Where(field => !field.FieldFull).ToList();

            Console.WriteLine("Available Fields:");
            Console.WriteLine("");
            //allows users to only select fields that have the capacity to add plants
            for (int i = 0; i < fieldWithCapacity.Count; i++)
            {
                PlantFacility currentField = fieldWithCapacity[i];
                Console.WriteLine($"{i + 1}. {currentField.Type} ({currentField.TotalPlants} plants)");

                //figure out refactor later
                // currentField.GetPlantTypes().ForEach(at => Console.WriteLine($"        {at.Type}: {at.Total} plants"));
            }

            Console.WriteLine();

            Console.WriteLine($"Plant the {resource.Type} seeds where?");

            Console.Write("> ");
            try
            {
                int choice = Int32.Parse(Console.ReadLine());
                //index of list starts at 0, so the index will always be one less than the value the user selects
                int choiceIndex = choice - 1;
                //gets the field that was selected by the user
                PlantFacility selectedField = fieldWithCapacity[choiceIndex];
                //finds the field in the fieldList on the farm instance using the FacilityId
                PlantFacility fieldOnFarm = fieldList.Find(field => field.FacilityId == selectedField.FacilityId);
                // //adds plant to the Field on the farm
                fieldOnFarm.AddResource(resource);
                Console.WriteLine($"You added a plant to a {selectedField.Type}!");
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadLine();
                //return false so the user returns to the main menu
                return false;
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid Selection.");
                Console.WriteLine("Please press enter to select another field or enter 0 to return to main menu");
                Console.Write("> ");

                //if user enters 0, they will be brought to the main menu, if they enter anything else they will be brought back to the field menu
                if (Console.ReadLine() == "0")
                {
                    //return false so the user returns to the main menu
                    return false;
                }
                else
                {
                    //return true so the user returns to the list of fields
                    return true;
                }

            }
        }
    }
}