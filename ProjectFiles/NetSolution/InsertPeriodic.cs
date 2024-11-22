#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.Alarm;
using FTOptix.Recipe;
using FTOptix.EventLogger;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.ODBCStore;
using FTOptix.S7TiaProfinet;
using FTOptix.Modbus;
using FTOptix.MelsecQ;
using FTOptix.Retentivity;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
#endregion

public class InsertPeriodic : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    /// <summary>
    /// Log dữ liệu theo chu kỳ quy trình vận hành
    /// </summary>
    [ExportMethod]
    public void SiemensDatabasePeriodic()
    {
        var project = Project.Current;

        var PlannedCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/PlannedCut").Value;
        var TotalCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/TotalCut").Value;
        var GoodCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/GoodCut").Value;
        var TargetSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/TargetSpeed").Value;
        var ActualSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/ActualSpeed").Value;
        var Uptime = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/Uptime").Value;
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/DowntimeCode").Value;
        var BadCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BadCut").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BadCutCode").Value;


        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = Int32.Parse(PlannedCut);
        rawValues[0, 2] = Int32.Parse(TotalCut);
        rawValues[0, 3] = Int32.Parse(GoodCut);
        rawValues[0, 4] = float.Parse(TargetSpeed);
        rawValues[0, 5] = float.Parse(ActualSpeed);
        rawValues[0, 6] = float.Parse(Uptime);
        rawValues[0, 7] = Int32.Parse(EmployeeID);
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo1");
        table1.Insert(columns, rawValues);
    }


    [ExportMethod]
    public void RockwellDatabasePeriodic()
    {
        var project = Project.Current;

        var PlannedCut = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/PlannedCut").Value;
        var TotalCut = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/TotalCut").Value;
        var GoodCut = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/GoodCut").Value;
        var TargetSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/TargetSpeed").Value;
        var ActualSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/ActualSpeed").Value;
        var Uptime = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/Uptime").Value;
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/DowntimeCode").Value;
        var BadCut = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BadCut").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BadCutCode").Value;


        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = Int32.Parse(PlannedCut);
        rawValues[0, 2] = Int32.Parse(TotalCut);
        rawValues[0, 3] = Int32.Parse(GoodCut);
        rawValues[0, 4] = float.Parse(TargetSpeed);
        rawValues[0, 5] = float.Parse(ActualSpeed);
        rawValues[0, 6] = float.Parse(Uptime);
        rawValues[0, 7] = Int32.Parse(EmployeeID);
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo1");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void DeltaDatabasePeriodic()
    {
        var project = Project.Current;

        var PlannedCut = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/PlannedCut").Value;
        var TotalCut = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/TotalCut").Value;
        var GoodCut = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/GoodCut").Value;
        var TargetSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/TargetSpeed").Value;
        var ActualSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/ActualSpeed").Value;
        var Uptime = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/Uptime").Value;
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/DowntimeCode").Value;
        var BadCut = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BadCut").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BadCutCode").Value;


        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = Int32.Parse(PlannedCut);
        rawValues[0, 2] = Int32.Parse(TotalCut);
        rawValues[0, 3] = Int32.Parse(GoodCut);
        rawValues[0, 4] = float.Parse(TargetSpeed);
        rawValues[0, 5] = float.Parse(ActualSpeed);
        rawValues[0, 6] = float.Parse(Uptime);
        rawValues[0, 7] = Int32.Parse(EmployeeID);
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo1");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void MitsuDatabasePeriodic()
    {
        var project = Project.Current;

        var PlannedCut = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/PlannedCut").Value;
        var TotalCut = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/TotalCut").Value;
        var GoodCut = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/GoodCut").Value;
        var TargetSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/TargetSpeed").Value;
        var ActualSpeed = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/ActualSpeed").Value;
        var Uptime = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/Uptime").Value;
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/DowntimeCode").Value;
        var BadCut = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BadCut").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BadCutCode").Value;


        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = Int32.Parse(PlannedCut);
        rawValues[0, 2] = Int32.Parse(TotalCut);
        rawValues[0, 3] = Int32.Parse(GoodCut);
        rawValues[0, 4] = float.Parse(TargetSpeed);
        rawValues[0, 5] = float.Parse(ActualSpeed);
        rawValues[0, 6] = float.Parse(Uptime);
        rawValues[0, 7] = Int32.Parse(EmployeeID);
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo1");
        table1.Insert(columns, rawValues);
    }


    /// <summary>
    /// Log dữ liệu theo sự kiện lỗi xảy ra
    /// </summary>

    [ExportMethod]
    public void SiemensDatabaseBadProduct()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BatchID").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BadCutCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 1;
        rawValues[0, 13] = Int32.Parse(BadCutCode);

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void SiemensDatabaseStopping()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/DowntimeCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = float.Parse(Downtime);
        rawValues[0, 11] = Int32.Parse(DowntimeCode);
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void RockwellDatabaseBadProduct()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BatchID").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BadCutCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 1;
        rawValues[0, 13] = Int32.Parse(BadCutCode);

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void RockwellDatabaseStopping()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/DowntimeCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = float.Parse(Downtime);
        rawValues[0, 11] = Int32.Parse(DowntimeCode);
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void DeltaDatabaseBadProduct()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BatchID").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BadCutCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 1;
        rawValues[0, 13] = Int32.Parse(BadCutCode);

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void DeltaDatabaseStopping()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/DowntimeCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = float.Parse(Downtime);
        rawValues[0, 11] = Int32.Parse(DowntimeCode);
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void MitsuDatabaseBadProduct()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BatchID").Value;
        var BadCutCode = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BadCutCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 0;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = 1;
        rawValues[0, 13] = Int32.Parse(BadCutCode);

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void MitsuDatabaseStopping()
    {
        var EmployeeID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/EmployeeID").Value;
        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BatchID").Value;
        var Downtime = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/Downtime").Value;
        var DowntimeCode = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/DowntimeCode").Value;

        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = 0;
        rawValues[0, 2] = 0;
        rawValues[0, 3] = 0;
        rawValues[0, 4] = 0;
        rawValues[0, 5] = 0;
        rawValues[0, 6] = 0;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = float.Parse(Downtime);
        rawValues[0, 11] = Int32.Parse(DowntimeCode);
        rawValues[0, 12] = 0;
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }


    [ExportMethod]
    public void ScanTrigger()
    {
        /// Notes
        /// 1 - Seimens; 2 - Rockwell; 3 - Delta; 4 - Mitsu

        //Operation
        var operation1 = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/CheckTime").Value;
        var operation2 = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/CheckTime").Value;
        var operation3 = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/CheckTime").Value;
        var operation4 = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/CheckTime").Value;

        if (operation1 == 1)
        {
            SiemensDatabasePeriodic();
        }
        if (operation2 == 1)
        {
            RockwellDatabasePeriodic();
        }
        if (operation3 == 1)
        {
            DeltaDatabasePeriodic();
        }
        if (operation4 == 1)
        {
            MitsuDatabasePeriodic();
        }

        //Fault Event
        var Down1 = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/DowntimeTrigger").Value;
        var Down2 = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/DowntimeTrigger").Value;
        var Down3 = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/DowntimeTrigger").Value;
        var Down4 = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/DowntimeTrigger").Value;

        if (Down1 == 1)
        {
            SiemensDatabaseStopping();
        }
        if (Down2 == 1)
        {
            RockwellDatabaseStopping();
        }
        if (Down3 == 1)
        {
            DeltaDatabaseStopping();
        }
        if (Down4 == 1)
        {
            MitsuDatabaseStopping();
        }

        //Bad Product Event
        var bad1 = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BadProductTrigger").Value;
        var bad2 = Project.Current.GetVariable("Model/Convert2InternalTag/Rockwell/BadProductTrigger").Value;
        var bad3 = Project.Current.GetVariable("Model/Convert2InternalTag/Delta/BadProductTrigger").Value;
        var bad4 = Project.Current.GetVariable("Model/Convert2InternalTag/Mitsu/BadProductTrigger").Value;

        if (bad1 == 1)
        {
            SiemensDatabaseBadProduct();
        }
        if (bad2 == 1)
        {
            RockwellDatabaseBadProduct();
        }
        if (bad3 == 1)
        {
            DeltaDatabaseBadProduct();
        }
        if (bad4 == 1)
        {
            MitsuDatabaseBadProduct();
        }
    }

    public void SiemensBatch()
    {

        var MachineID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/MachineID").Value;
        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BatchID").Value;
        var PlannedCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/PlannedCut").Value;
        var TotalCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/TotalCut").Value;
        var GoodCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/GoodCut").Value;
        var BadCut = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BadCut").Value;



        string[] columns = { "Timestamp", "PlannedCut", "TotalCut", "GoodCut", "TargetSpeed", "ActualSpeed", "Uptime",
             "EmployeeID", "MachineID", "BatchID", "Downtime", "DowntimeCode", "BadCut", "BadCutCode" };

        var rawValues = new object[1, 14];
        rawValues[0, 0] = DateTime.Now;
        rawValues[0, 1] = Int32.Parse(PlannedCut);
        rawValues[0, 2] = Int32.Parse(TotalCut);
        rawValues[0, 3] = Int32.Parse(GoodCut);
        rawValues[0, 4] = 1;
        rawValues[0, 5] = 1;
        rawValues[0, 6] = 1;
        rawValues[0, 7] = 0;
        rawValues[0, 8] = Int32.Parse(MachineID);
        rawValues[0, 9] = BatchID.ToString();
        rawValues[0, 10] = 1;
        rawValues[0, 11] = 0;
        rawValues[0, 12] = Int32.Parse(BadCut);
        rawValues[0, 13] = 0;

        var myStore = LogicObject.Owner as Store;
        var table1 = myStore.Tables.Get<Table>("OptixRawDataDemo2");
        table1.Insert(columns, rawValues);
    }

    [ExportMethod]
    public void Select2(out int value)
    {
        Store myStore = Project.Current.Get<Store>("DataStores/LocalDatabase");
        Table Table1 = myStore.Tables.Get<Table>("OptixRawDataDemo1");
        Table Table2 = myStore.Tables.Get<Table>("OptixRawDataDemo2");

        var BatchID = Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/BatchID").Value;

        Object[,] ResultSet;
        String[] Header;
        myStore.Query("SELECT SUM(Uptime) FROM OptixRawDataDemo1 WHERE BatchID = " + BatchID.ToString(), out Header, out ResultSet);
        value = Convert.ToInt32(ResultSet[0, 0]);
        Project.Current.GetVariable("Model/Convert2InternalTag/Siemens/CheckTime").Value = value;
    }
}
