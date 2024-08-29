using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Mechanical_Shared_Parameters
{
    internal class Application : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            String tabName = "Mechanical";
            String nameSpace = "Mechanical_Shared_Parameters";
            application.CreateRibbonTab(tabName);
            String assemblyPath = Assembly.GetExecutingAssembly().Location;

            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Adds Shared Parameters");

            PushButtonData buttonData = new PushButtonData("Add shared parameters", "Add shared parameters", assemblyPath, nameSpace + ".Class1");
            ribbonPanel.AddItem(buttonData);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

    }
}
