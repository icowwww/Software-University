using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Stations.Data;
using Stations.Models;

namespace Stations.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportStations(StationsDbContext context, string jsonString)
		{
		    var stations = JsonConvert.DeserializeObject<Station[]>(jsonString);
		    var sb = new StringBuilder();
		    foreach (var station in stations)
		    {
		        if (station.Town == null)
		        {
		            station.Town = station.Name;
		        }
		        if (context.Stations.Any(e=> e.Name== station.Name))
		        {
		            sb.AppendLine(FailureMessage);
                    continue;
		        }                
		        if (!IsValid(station))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }
		        context.Stations.Add(station);
		        sb.AppendLine($"Record {station.Name} successfully imported.");
		        context.SaveChanges();
		    }
		    return sb.ToString().Trim();
		}

		public static string ImportClasses(StationsDbContext context, string jsonString)
		{
		    var classes = JsonConvert.DeserializeObject<SeatingClass[]>(jsonString);
		    var sb = new StringBuilder();
		    foreach (var seatingClass in classes)
		    {
		        if (context.SeatingClasses.Any(e=> e.Name == seatingClass.Name))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
                }
		        if (context.SeatingClasses.Any(e => e.Abbreviation == seatingClass.Abbreviation))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
		        }
		        if (!IsValid(seatingClass))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
                }
		        context.SeatingClasses.Add(seatingClass);
		        context.SaveChanges();
		        sb.AppendLine($"Record {seatingClass.Name} successfully imported.");
		    }
		    return sb.ToString().Trim();
		}

		public static string ImportTrains(StationsDbContext context, string jsonString)
		{
		    var trains = JsonConvert.DeserializeObject<Train[]>(jsonString);
		    var sb = new StringBuilder();
		    foreach (var train in trains)
		    {
		        if (!context.SeatingClasses.Any(e=> train.TrainSeats.Any(x=> x.SeatingClass.Name == e.Name) && train.TrainSeats.Any(x => x.SeatingClass.Abbreviation == e.Abbreviation)))
		        {
		            sb.AppendLine(FailureMessage);
		            continue;
                }
                train.TrainSeats.All(IsValid);
		    }
            throw new NotImplementedException();
		}

		public static string ImportTrips(StationsDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportCards(StationsDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		public static string ImportTickets(StationsDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

	    public static bool IsValid(object obj)
	    {
	        var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
	        var validationResults = new List<ValidationResult>();
	        var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
	        return isValid;
	    }
    }
}