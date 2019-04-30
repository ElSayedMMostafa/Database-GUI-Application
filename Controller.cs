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

        public int InsertFarm(string ID, string Size, string City, string FarmState, string Automated, string code, string PH = "NULL", string DO = "NULL", string DID = "NULL", string EID = "NULL")
        {
            string query = "INSERT INTO FishFarm " +
                            "Values ('" + ID + "'," + Size + ",'" + City + "','" + FarmState + "','" + Automated + "'," + PH + "," + DO + ",'" + code + "','" + DID + "','" + EID + "' );";

            return dbMan.UpdateData(query);
        }
        public int InsertDoctor(string ID, string FName,string LName, string Addr, string Phone)
        {
            string query = "INSERT INTO Doctor VALUES('" + ID + "','" + FName + "','" + LName + "','" + Addr + "','" + Phone + "');";

            return dbMan.UpdateData(query);
        }
        public int buyProduct(string manufacturer, string type, string code, string quantity, string total)
        {
            string query = "INSERT INTO Buy VALUES('" + manufacturer + "','" + type + "','" + code + "'," + quantity + "," + total + ");";

            return dbMan.UpdateData(query);
        }

        public int EditProduct(string quantity, string price,string manufacutrer, string type)
        {
            string query = "UPDATE Products SET quantity=" + quantity + " AND Price=" + price + " WHERE MANUFACTURER ='"+manufacutrer+"'AND PTYPE='" + type + "';";
            return dbMan.UpdateData(query);
        }
        public int InsertFishType(string FType, string ID)
        {
            string query = "INSERT INTO FishType VALUES('" + FType + "','" + ID + "');";
            return dbMan.UpdateData(query);
        }
        public int RequestMeeting(string code, string ID,string date,string Alert)
        {
            string query = "INSERT INTO Meet VALUES('" + code + "','" + ID + "','"+date+"','"+Alert+"');";
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
        public DataTable ViewFarm(string ID)
        {
            string query = "SELECT * FROM FishFarm WHERE DOCTORID='"+ID+"';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewOwnerAccount(string code)
        {
            string query = "SELECT FINANCIAL_ACCOUNT FROM FarmOwner WHERE code='" + code + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewImporterAccount(string name)
        {
            string query = "SELECT I_FINANCIAL_ACCOUNT FROM Importers WHERE I_NAME='" + name + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable SendAlert(string Ocode, string ID)
        {
            string query = "SELECT Alert FROM Meet WHERE Ocode='" + Ocode + "' AND DOCTORID='"+ID+"';";
            return dbMan.ExecuteTableQuery(query);
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }
}
