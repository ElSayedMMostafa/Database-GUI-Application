using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Company
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

        public int InsertFarm(string ID, string Size, string City, string FarmState, string Automated, string PH, string DO)
        {
            string query = "INSERT INTO FishFarm " +
                            "Values ('" + ID + "'," + Size + ",'" + City + "','" + FarmState + "','" + Automated + "'," + PH + "," + DO + ");";

            return dbMan.UpdateData(query);
        }

        public int UpdateFishType(string FType, string ID)
        {
            string query = "UPDATE FishType SET FTYPE='" + FType + "' WHERE ID='" + ID + "';";
            return dbMan.UpdateData(query);
        }

        public DataTable ViewAllFarms()
        {

            string query = "SELECT * FROM FishFarm;";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable DoctorView(string ID)
        {

            string query = "CREATE VIEW DoctorView AS SELECT PH, DO,FarmState,AUTOMATED FROM FishFarm where ID='"+ ID +"';";
            return dbMan.ExecuteTableQuery(query);
        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }
}
