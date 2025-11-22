using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTires.Models
{
    public class Inspection
    {
        public string InspectorName { get; set; }
        public string VehicleLicensePlate { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectionResult { get; set; }
        public string InspectionState { get; set; }

        public Inspection( string inspectorName, string vehicleLicensePlate, DateTime inspectionDate, string inspectionResult, string inspectionState)
        {
            InspectorName = inspectorName;
            VehicleLicensePlate = vehicleLicensePlate;
            InspectionDate = inspectionDate;
            InspectionResult = inspectionResult;
            InspectionState = inspectionState;
        }
    }

}