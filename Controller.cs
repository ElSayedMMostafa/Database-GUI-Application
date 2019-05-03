using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace GUIProject
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
        public int InsertDoctor(string ID, string FName, string LName, string Addr, string Phone)
        {
            string query = "INSERT INTO Doctor VALUES('" + ID + "','" + FName + "','" + LName + "','" + Addr + "','" + Phone + "');";

            return dbMan.UpdateData(query);
        }
        public int AddProduct(string manufacturer, string type, string quantity, string price)
        {
            string query = "INSERT INTO Products VALUES('" + manufacturer + "','" + type + "'," + quantity + "," + price + ");";
            return dbMan.UpdateData(query);
        }
        public int buyProduct(string manufacturer, string type, string code, string quantity, string total)
        {
            string query = "INSERT INTO Buy VALUES('" + manufacturer + "','" + type + "','" + code + "'," + quantity + "," + total + ");";

            return dbMan.UpdateData(query);
        }

        public int EditProduct(string quantity, string price, string manufacutrer, string type)
        {
            string query = "UPDATE Products SET QUNATITY=" + quantity + " , PRICE=" + price + " WHERE MANUFACTURER ='" + manufacutrer + "'AND PTYPE='" + type + "';";
            return dbMan.UpdateData(query);
        }
        public int InsertFishType(string FType, string ID)
        {
            string query = "INSERT INTO FishType VALUES('" + FType + "','" + ID + "');";
            return dbMan.UpdateData(query);
        }
        public int RequestMeeting(string code, string ID, string date, string Alert)
        {
            string query = "INSERT INTO Meet VALUES('" + code + "','" + ID + "','" + date + "','" + Alert + "');";
            return dbMan.UpdateData(query);
        }

        public DataTable ViewAllFarms()
        {

            string query = "SELECT * FROM FishFarm;";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewManufacturer(string type)
        {

            string query = "SELECT MANUFACTURER FROM Products WHERE PTYPE= '" + type + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewTypes(string MANUFACTURER)
        {

            string query = "SELECT PTYPE FROM Products WHERE MANUFACTURER= '" + MANUFACTURER + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewALLTypes()
        {

            string query = "SELECT PTYPE FROM Products ;";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewALLManufacturers()
        {

            string query = "SELECT MANUFACTURER FROM Products ;";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewALLProducts()
        {

            string query = "SELECT * FROM Products ;";
            return dbMan.ExecuteTableQuery(query);
        }
        public int InsertImporter(string IFAccount, string IName, string Manu, string PType)
        {
            string query = "INSERT INTO Importers " +
                            "Values ('" + IFAccount + "','" + IName + "','" + Manu + "','" + PType + "');";

            return dbMan.UpdateData(query);
        }
        public int DeleteProduct(string Manufacturer, string type)
        {

            string query = "Delete FROM Products WHERE MANUFACTURER='" + Manufacturer + "' AND PTYPE='" + type + "';";
            return dbMan.UpdateData(query);
        }
        public DataTable DoctorView(string ID)
        {

            string query = "CREATE VIEW DoctorView AS SELECT PH, DO,FarmState,AUTOMATED FROM FishFarm where ID='" + ID + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewFarm(string ID)
        {
            string query = "SELECT * FROM FishFarm WHERE DOCTORID='" + ID + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewFarmByItsID(string ID)
        {
            string query = "SELECT * FROM FishFarm WHERE ID='" + ID + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewFarmbyOwner(string Code)
        {
            string query = "SELECT * FROM FishFarm WHERE CODE='" + Code + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewOwnerAccount(string code)
        {
            string query = "SELECT FINANCIAL_ACCOUNT FROM FarmOwner WHERE code='" + code + "';";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewAllOwners()
        {
            string query = "SELECT CODE, PNAME,LNAME FROM FarmOwner;";
            return dbMan.ExecuteTableQuery(query);
        }
        public DataTable ViewImporters()
        {
            string query = "SELECT * FROM Importers";
            return dbMan.ExecuteTableQuery(query);
        }
        public int SendAlert(string ID, string DOCTORID, string Message)
        {
            string query = "INSERT INTO Alerts VALUES('" + ID + "','" + DOCTORID + "','" + Message + "');";
            return dbMan.UpdateData(query);
        }


        public int UpdateFarm(string ID, string FSize, string FAuto, string FPH, string FDO) //Modified by Sayed
        {
            string query = "UPDATE FishFarm SET SIZE='" + FSize + " ', AUTOMATED= ' " + FAuto + "', PH =" + FPH + "', DO= '" + FDO +
            "' WHERE ID ='" + ID + "';";
            return dbMan.UpdateData(query);
        }
        //Update:

        public int DeleteFarm(string FID)
        {
            string query = "DELETE FROM FishFarm WHERE ID ='" + FID + "';";
            return dbMan.UpdateData(query);
        }
        public int InsertOwner(string code, string FA, string PName, string LName, string PA)
        {
            string query = "INSERT INTO FarmOwner VALUES('" + code + "','" + FA + "','" + PName + "','" + LName + "','" + PA + "');";
            return dbMan.UpdateData(query);
        }
        /// <log in>
        /// this is the functions related to log in 
        public object getID(string username, string password)
        {
            string query = "SELECT ID FROM logIn WHERE username='" + username + "' AND password='" + password + "';";
            return dbMan.ExecuteScalarQuery(query);
        }
        public object getAccess(string username, string password)
        {
            string query = "SELECT Access FROM logIn WHERE username='" + username + "' AND password='" + password + "';";
            return dbMan.ExecuteScalarQuery(query);
        }
        public object getFname(string username, string password)
        {
            string query = "SELECT Fname FROM logIn WHERE username='" + username + "' AND password='" + password + "';";
            return dbMan.ExecuteScalarQuery(query);
        }
        /// </log in>
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
    }
}
