using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanical_Shared_Parameters
{
    public static class Equipment
    {
        public static void AddSharedParameters(List<string> sharedParameters, IEnumerable<Definition> paramDefinitions, Element e, Document doc)
        {

            IFamilyLoadOptions familyLoadOptions = new FamilyLoadOptions();
            FamilySymbol symbol = e as FamilySymbol;

            Document familyDoc = doc.EditFamily((e as FamilySymbol).Family);
            FamilyManager familyManager = familyDoc.FamilyManager;
            IList<FamilyParameter> List = familyManager.GetParameters();


            if (!doesSharedParamExist(List))
            {
                Transaction trans = new Transaction(familyDoc, "adding shared parameters");
                trans.Start();

                foreach (FamilyParameter famParam in List)
                {

                    //if (famParam.Definition.ParameterType != ParameterType.Length || famParam.AssociatedParameters.IsEmpty == true)

                    try
                    {
                        if (famParam.GetUnitTypeId().Equals(UnitTypeId.Feet) || famParam.GetUnitTypeId().Equals(UnitTypeId.Inches) || famParam.GetUnitTypeId().Equals(UnitTypeId.FeetFractionalInches) || famParam.GetUnitTypeId().Equals(UnitTypeId.FractionalInches))

                        {
                            continue;
                        }

                        else
                        {
                            try
                            {
                                familyManager.RemoveParameter(famParam);
                            }
                            catch { }
                        }
                    }

                    catch {
                        try { familyManager.RemoveParameter(famParam); }
                        catch { }
                    }
                }
                foreach (string parameter in sharedParameters)
                {

                    foreach (ExternalDefinition exDef in paramDefinitions)
                    {
                        if (parameter == exDef.Name)
                        {
                            try
                            {
                                if (symbol.LookupParameter("Description").AsString() != "RTU")
                                {
                                    familyManager.AddParameter(exDef, BuiltInParameterGroup.PG_MECHANICAL, true);
                                }
                            }
                            catch
                            {

                            }

                            break;
                        }
                    }


                }

                trans.Commit();
                familyDoc.LoadFamily(doc, familyLoadOptions);
            }
        }
        public static bool doesSharedParamExist(IList<FamilyParameter> List)
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
}

