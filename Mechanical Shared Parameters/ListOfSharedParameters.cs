using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechanical_Shared_Parameters
{
    public static class RTUSharedParameterList
    {
        public static List<string> sharedParam = new List<string> {"SE_M_NOM CAP TONS TEXT", "SE_M_TYPE TEXT", "SE_M_SERVICE TEXT", "SE_M_WEIGHT LBS TEXT", "SE_M_SUPPLY FAN_QTY TEXT",
            "SE_M_SUPPLY FAN_CFM TEXT", "SE_M_SUPPLY FAN_ESP IN WG TEXT", "SE_M_SUPPLY FAN_BHP TEXT", "SE_M_SUPPLY FAN_HP TEXT", "SE_M_FAN QTY TEXT", "SE_M_FAN_CFM TEXT",
            "SE_M_FAN ESP IN WG TEXT", "SE_M_FAN BHP TEXT", "SE_M_FAN_HP TEXT", "SE_M_OA CFM TEXT", "SE_M_TOTAL COOLING MBH TEXT","SE_M_COOLING SENS MBH TEXT",
            "SE_M_COOLING COIL_EAT °F_DB TEXT", "SE_M_COOLING COIL_EAT °F_WB TEXT", "SE_M_COOLING COIL_LAT °F_DB TEXT", "SE_M_COOLING COIL_LAT °F_WB TEXT", "SE_M_CONDENSE UNIT EFFIC SEER TEXT",
            "SE_M_COOLING_MIN_NO_STAGES TEXT", "SE_M_HEAT CAP MBH TEXT", "SE_M_HEAT CAP OUTPUT MBH TEXT", "SE_M_ELEC HEAT COIL KW TEXT", "SE_M_HEATING COIL_EAT DB °F TEXT",
            "SE_M_HEATING COIL LAT °F TEXT", "SE_M_HEATING_SOURCE", "SE_M_CONDENSING UNIT_HSPF TEXT", "SE_M_ELEC HEAT COIL STAGES TEXT", "SE_M_ELEC_VOLTS PH TEXT", "SE_M_ELEC_MCA TEXT",
            "SE_M_ELEC_MOCP TEXT", "SE_M_DISC_TYPE TEXT", "SE_M_COMMENTS"};
    }

    public static class louverSharedParameterList
    {
        public static List<string> sharedParam = new List<string> { "SE_M_TYPE TEXT", "SE_M_SIZE_IN TEXT", "SE_M_AIRFLOW", "SE_M_FREE AREA SQFT TEXT", "SE_M_VELOCITY FPM TEXT", "SE_M_PRESS DROP IN WG_FULL OPEN TEXT"
        , "SE_M_SERVES TEXT", "SE_M_MATERIAL_TEXT" };
    }

    public static class fanSharedParameterList
    {
        public static List<string> sharedParam = new List<string> { "SE_M_SYST TEXT", "SE_M_SERVES TEXT", "SE_M_TYPE TEXT", "SE_M_DRIVE TEXT",
        "SE_M_FAN_CFM TEXT", "SE_M_ESP IN WG TEXT", "SE_M_WATTS TEXT", "SE_M_HP TEXT", "SE_M_FAN RPM TEXT", "SE_M_MOTOR RPM TEXT", "SE_M_ELEC_VOLTS PH TEXT",
        "SE_M_DISCHARGE NC", "SE_M_WEIGHT LBS TEXT", "SE_M_CONTROL TYPE TEXT"};
    }

    public static class unitHeaterList
    {
        public static List<string> sharedParamGas = new List<string> { "SE_M_SERVES TEXT", "SE_M_TYPE TEXT", "SE_M_AIRFLOW",
        "SE_M_HEATING COIL_MBH TEXT", "SE_M_HEATING WATER COIL_EWT/LWT TEXT", "SE_M_GAS-FIRED HEAT_INPUT", "SE_M_GAS-FIRED HEAT_OUTPUT",
        "SE_M_GAS-FIRED HEAT_STAGES", "SE_M_ELEC HP TEXT", "SE_M_WEIGHT LBS TEXT"};

        public static List<string> sharedParamElectric = new List<string> { "SE_M_SERVES TEXT", "SE_M_TYPE TEXT", "SE_M_AIRFLOW", "SE_M_ELEC HEAT KW TEXT",
        "SE_M_ELEC HEAT STAGES TEXT", "SE_M_ELEC_VOLTS PH TEXT", "SE_M_WEIGHT LBS TEXT" };
    }

    public static class airDevices
    {
        public static List<string> sharedParam = new List<string> { "SE_M_SYST TEXT", "SE_M_DESC TEXT", "SE_M_NECK SIZE TEXT", "SE_M_FACE SIZE TEXT",
        "SE_M_MATERIAL TEXT"};
    }

    public static class EWH
    {
        public static List<string> sharedParamEWH = new List<string> { "SE_P_WATER HEATER LOCATION TEXT", "SE_P_WATER HEATER RECOVERY GPM TEXT", "SE_P_WATER HEATER RECOVERY RISE TEXT",
        "SE_P_WATER HEATER STOR CAP TEXT", "SE_P_WATER HEATER TEMP IN °F TEXT", "SE_P_WATER HEATER TEMP OUT °F TEXT", "SE_P_ELEC KW TEXT", "SE_P_ELEC VOLT/PHASE TEXT",
        "SE_P_ELEC VOLT/PHASE TEXT", "SE_P_WATER HEATER CONN INLET TEXT", "SE_P_WATER HEATER CONN OUTLET TEXT", "SE_P_NOTES TEXT"};

    }

    public static class GWH
    {
        public static List<string> sharedParamGWH = new List<string> { "SE_P_WATER HEATER LOCATION TEXT", "SE_P_WATER HEATER RECOVERY GPM TEXT", "SE_P_WATER HEATER RECOVERY RISE TEXT",
        "SE_P_WATER HEATER STOR CAP TEXT", "SE_P_WATER HEATER TEMP IN °F TEXT", "SE_P_WATER HEATER TEMP OUT °F TEXT", "SE_P_WATER HEATER GAS RQMT TEXT", "SE_P_WATER HEATER CONN INLET TEXT",
        "SE_P_WATER HEATER CONN OUTLET TEXT", "SE_P_NOTES TEXT"};
    }

    public static class IWH
    {
        public static List<string> sharedParamIWH = new List<string> { "SE_P_WATER HEATER LOCATION TEXT", "SE_P_WATER HEATER FLOW RATE AT ∆T TEXT", "SE_P_ELEC KW TEXT",
        "SE_P_WATER HEATER TEMP IN °F TEXT", "SE_P_WATER HEATER TEMP OUT °F TEXT", "SE_P_ELEC VOLT/PHASE TEXT", "SE_P_WATER HEATER CONN INLET TEXT",
        "SE_P_WATER HEATER CONN OUTLET TEXT", "SE_P_NOTES TEXT"};
    }

    public static class PUMP
    {
        public static List<string> sharedParamPUMP = new List<string> { "SE_P_SERVES TEXT", "SE_P_PUMP GPM TEXT", "SE_P_PUMP HEAD (FT) TEXT", "SE_P_PUMP SHUT-OFF HEAD (FT) TEXT",
        "SE_P_PUMP RPM TEXT", "SE_P_PUMP HP TEXT", "SE_P_ELEC VOLT/PHASE TEXT", "SE_P_NOTES TEXT"};
    }

    public static class PLMBFIXTURE
    {
        public static List<string> sharedParamPLMBFIXTURE = new List<string> { "SE_P_TYPE TEXT", "SE_P_CW CONNECTION TEXT", "SE_P_HW CONNECTION TEXT", "SE_P_SAN CONNECTION TEXT",
        "SE_P_VENT CONNECTION TEXT", "SE_P_NOTES TEXT"};
    }
}

