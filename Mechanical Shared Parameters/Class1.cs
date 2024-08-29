using Autodesk.Private.InfoCenterLib;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System.Linq;
using System.Collections.Generic;
using Autodesk.Revit.DB.Structure;
using System;
using Autodesk.Revit.UI.Selection;

namespace Mechanical_Shared_Parameters
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Class1: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_MechanicalEquipment);
            List<Element> RTUs = collector.WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "RTU").ToList();
            List<Element> EFs = collector.WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "EF").ToList();
            List<Element> UHs = collector.WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && (e.LookupParameter("Description").AsString() == "GUH") || (e.LookupParameter("Description").AsString() == "EUH")).ToList();
            List<Element> LOUVERs = collector.WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "L").ToList();
            List<Element> AIRDEVICEs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_DuctTerminal).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "AD").ToList();
            List<Element> EWHs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PlumbingFixtures).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "EWH").ToList();
            List<Element> GWHs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PlumbingFixtures).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "GWH").ToList();
            List<Element> IWHs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PlumbingFixtures).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "IWH").ToList();
            List<Element> PUMPs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PlumbingFixtures).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "PUMP").ToList();
            List<Element> PLMBFIXTUREs = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PlumbingFixtures).WhereElementIsElementType().Where(e => e.LookupParameter("Description") != null && e.LookupParameter("Description").AsString() == "PLUMBING FIXTURES").ToList();

            IFamilyLoadOptions familyLoadOptions = new FamilyLoadOptions();

            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;

            app.SharedParametersFilename = @"M:\_Master AutoCAD & REVIT\Revit\Shared Parameters\SE_Shared_Parameters.txt";
            DefinitionFile defFile = app.OpenSharedParameterFile();
            DefinitionGroups groups = defFile.Groups;
            DefinitionGroup mechanical = groups.get_Item("Mechanical");
            Definitions mechanicalparameterDefinitions = mechanical.Definitions;
            Definitions plumbingParameterDefinitions = defFile.Groups.get_Item("Plumbing").Definitions;
            IEnumerable<Definition> parameterDefinition = mechanicalparameterDefinitions.Concat(plumbingParameterDefinitions);
            //parameterDefinition = parameterDefinition as Definitions;
            


            foreach (Element RTU in RTUs)
            {
                Equipment.AddSharedParameters(RTUSharedParameterList.sharedParam, parameterDefinition, RTU, doc);
            }

            foreach (Element louver in LOUVERs) {
                Equipment.AddSharedParameters(louverSharedParameterList.sharedParam, parameterDefinition, louver, doc);
            }

            foreach (Element EF in EFs)
            {
                Equipment.AddSharedParameters(fanSharedParameterList.sharedParam, parameterDefinition, EF, doc);
            }

            foreach (Element UH in UHs)
            {
                if (UH.LookupParameter("Description").AsString() == "GUH")
                {
                    Equipment.AddSharedParameters(unitHeaterList.sharedParamGas, parameterDefinition, UH, doc);
                }
                if (UH.LookupParameter("Description").AsString() == "EUH")
                {
                    Equipment.AddSharedParameters(unitHeaterList.sharedParamElectric, parameterDefinition, UH, doc);
                }
            }

            foreach (Element AD in AIRDEVICEs)
            {
                Equipment.AddSharedParameters(airDevices.sharedParam, parameterDefinition, AD, doc);
            }

            foreach (Element electricWaterHeater in EWHs)
            {
                Equipment.AddSharedParameters(EWH.sharedParamEWH, parameterDefinition, electricWaterHeater, doc);
            }

            foreach (Element gasWaterHeater in GWHs)
            {
                Equipment.AddSharedParameters(GWH.sharedParamGWH, parameterDefinition, gasWaterHeater, doc);
            }
            
            foreach (Element instantaneousWaterHeater in IWHs)
            {
                Equipment.AddSharedParameters(IWH.sharedParamIWH, parameterDefinition, instantaneousWaterHeater, doc);
            }

            foreach (Element pump in PUMPs)
            {
                Equipment.AddSharedParameters(PUMP.sharedParamPUMP, parameterDefinition, pump, doc);
            }

            foreach (Element plumbingFixture in PLMBFIXTUREs)
            {
                Equipment.AddSharedParameters(PLMBFIXTURE.sharedParamPLMBFIXTURE, parameterDefinition, plumbingFixture, doc);
            }

            return Result.Succeeded;
        }

        public bool doesSharedParamExist(IList<FamilyParameter> List)
        {
            foreach (FamilyParameter familyParameter in List)
            {
                if (familyParameter.IsShared)
                {
                    if (familyParameter.Definition.Name.Contains("SE_M_"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
    }

    public class FamilyLoadOptions : IFamilyLoadOptions
    {
        public bool OnFamilyFound(bool familyInUse, out bool overwriteParameterValues)
        {
            // Set the behavior for when a family is found
            overwriteParameterValues = true; // Specify whether to overwrite parameter values

            // Return true to continue loading the family, or false to cancel loading
            return true;
        }

        public bool OnSharedFamilyFound(Family sharedFamily, bool familyInUse, out FamilySource source, out bool overwriteParameterValues)
        {
            throw new NotImplementedException();
        }
    }


}
