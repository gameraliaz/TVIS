using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TVIS.MVVM.Models;
using System.IO;
using System.Windows.Media.Imaging;

namespace TVIS.Services
{
    public class Database
    {
        private readonly SqlConnection con;
        public Database(string DataSource, string UserID, string Password)
        {
            string cs = $"Data Source={DataSource};Initial Catalog=master;User ID={UserID};Password={Password}";
            con = new(cs);
            string sqlCreate = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TVIS') BEGIN CREATE DATABASE TVIS; END;";
            SqlCommand command = new SqlCommand(sqlCreate, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            cs = $"Data Source={DataSource};Initial Catalog=TVIS;User ID={UserID};Password={Password}";
            con = new(cs);
            sqlCreate = "if not exists (select * from sysobjects where name='Persons' and xtype='U') " +
                "create table Persons (ID char(10),FirstName varchar(50),LastName varchar(50),Image image,primary key (ID)); " +
                "if not exists (select * from sysobjects where name='Vehicles' and xtype='U') " +
                "create table Vehicles (Pelak char(8),ConstractionYear smallint,Type tinyint,primary key (Pelak)); " +
                "if not exists (select * from sysobjects where name='Violations' and xtype='U') " +
                "create table Violations (ID char(10),Pelak char(8),Time Datetime,Type tinyint,Cost int,primary key (ID,Pelak,Time),FOREIGN KEY (ID) REFERENCES Persons(ID),FOREIGN KEY (Pelak) REFERENCES Vehicles(Pelak)); " +
                "if not exists (select * from sysobjects where name='PersonsVehicles' and xtype='U') " +
                "create table PersonsVehicles (ID char(10),Pelak char(8),primary key (ID,Pelak),FOREIGN KEY (ID) REFERENCES Persons(ID),FOREIGN KEY (Pelak) REFERENCES Vehicles(Pelak));";
            command = new SqlCommand(sqlCreate, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }

        public int InsertToPersons(Person person)
        {
            byte[]? bImage = ImageToByte(person.Image);
            string sqlInsertion = $"INSERT INTO Persons values('{person.ID}','{person.FirstName}','{person.LastName}',@ImageArray)";

            var byteParam = new SqlParameter("@ImageArray", SqlDbType.Image)
            {
                Direction = ParameterDirection.Input,
                Size = bImage.Length,
                Value = bImage
            }; 

            SqlCommand command = new SqlCommand(sqlInsertion, con);
            con.Open();
            command.Parameters.Add(byteParam);
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int InsertToVehicles(Vehicle vehicle)
        {
            string sqlInsertion = $"INSERT INTO Vehicles values('{vehicle.Pelak}',{vehicle.YearOfConstruction},{vehicle.TypeOfVehicle.Value})";
            SqlCommand command = new SqlCommand(sqlInsertion, con);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int InsertToViolations(Violation violation)
        {
            string sqlInsertion = $"INSERT INTO Violations values('{violation.Person.ID}','{violation.Vehicle.Pelak}','{violation.ViolationDateTime}')";
            SqlCommand command = new SqlCommand(sqlInsertion, con);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int InsertToPersonsVehicles(PersonsVehicle personsVehicle)
        {
            string sqlInsertion = $"INSERT INTO PersonsVehicles values('{personsVehicle.Person.ID}','{personsVehicle.Vehicle.Pelak}')";
            SqlCommand command = new SqlCommand(sqlInsertion, con);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int DeleteFromPersons(string ID)
        {
            string sqlDel = $"DELETE FROM Persons WHERE ID='{ID}'";
            SqlCommand command = new SqlCommand(sqlDel, con);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteFromVehicles(string Pelak)
        {
            string sqlDel = $"DELETE FROM Vehicles WHERE ID='{Pelak}'";
            SqlCommand command = new SqlCommand(sqlDel, con);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteFromViolations(string ID,string Pelak,DateTime time)
        {
            string sqlDel = $"DELETE FROM Violations WHERE ID='{ID}' and Pelak='{Pelak}' and Time='{time}'";
            SqlCommand command = new SqlCommand(sqlDel, con);
            con.Open();
            int res = command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteFromPersonsVehicles(string ID,string Pelak)
        {
            string sqlDel = $"DELETE FROM PersonsVehicles WHERE ID='{ID}' and Pelak='{Pelak}'";
            SqlCommand command = new SqlCommand(sqlDel, con);
            con.Open();
            int res = command.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int ModifyFromPersons(Person person)
        {
            byte[]? bImage = ImageToByte(person.Image);
            string sqlUp = $"UPDATE TABLE Persons SET FirstName='{person.FirstName}' , LastName='{person.LastName}' , Image=@ImageArray where ID='{person.ID}';";
            var byteParam = new SqlParameter("@ImageArray", SqlDbType.Image)
            {
                Direction = ParameterDirection.Input,
                Size = bImage.Length,
                Value = bImage
            };

            SqlCommand command = new SqlCommand(sqlUp, con);
            command.Parameters.Add(byteParam);
            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int ModifyFromVehicles(Vehicle vehicle)
        {
            string sqlUp = $"UPDATE TABLE Vehicles SET Type={vehicle.TypeOfVehicle.Value} , ConstractionYear='{vehicle.YearOfConstruction}' where Pelak='{vehicle.Pelak}';";
            
            SqlCommand command = new SqlCommand(sqlUp, con);

            con.Open();
            int res=command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int ModifyFromViolations(Violation violation)
        {
            string sqlUp = $"UPDATE TABLE Violations SET Type={violation.TypeOfViolation.Value} , Cost={violation.Cost} where ID='{violation.Person.ID}' and Pelak='{violation.Vehicle.Pelak}' and Time='{violation.ViolationDateTime}';";

            SqlCommand command = new SqlCommand(sqlUp, con);

            con.Open();
            int res =command.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int ModifyFromPersonsVehicle(PersonsVehicle personsVehicle)
        {
            throw new NotImplementedException();
        }

        public PersonsBook GetPersons()
        {
            PersonsBook Result = new();
            string sqlGet = $"SELECT * FROM Persons";
            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.AddPersons(new Person((string)reader[0])
                {
                    FirstName = (string?)reader[1],
                    LastName = (string?)reader[2],
                    Image = ByteToImage((Byte[]?)reader[3])
                });
            }
            con.Close();
            return Result;
        }
        public VehiclesBook GetVehicles()
        {
            VehiclesBook Result = new();
            string sqlGet = $"SELECT * FROM Vehicles";
            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.AddVehicles(new Vehicle((string)reader[0])
                {
                    YearOfConstruction = (int?)reader[1],
                    TypeOfVehicle = (VehiclesType?)reader[2]
                });
            }
            con.Close();
            return Result;
        }
        public ViolationsBook GetViolations()
        {
            ViolationsBook Result = new();
            string sqlGet = $"SELECT * FROM Violations";
            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.AddViolation(new Violation(new((string)reader[0]), new((string)reader[1]), (DateTime)reader[2])
                {
                    TypeOfViolation = (ViolationsType?)reader[3],
                    Cost = (int?)reader[4]
                });
            }
            con.Close();
            return Result;
        }
        public PersonsVehiclesBook GetPersonsVehicles()
        {
            PersonsVehiclesBook Result = new();
            string sqlGet = $"SELECT * FROM PersonsVehicles";
            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.AddPersonsVehicles(new PersonsVehicle(new((string)reader[0]), new((string)reader[1])));
            }
            con.Close();
            return Result;
        }

        public Tuple<BitmapImage?,List<PersonsViolation>> GetPersonsViolations(string ID)
        {
            List<PersonsViolation> Result = new();
            BitmapImage? img=null;

            string sqlGet = $"SELECT Image FROM Persons WHERE ID='{ID}'";
            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                img= ByteToImage((Byte[]?)reader[0]);
            }

            sqlGet = "select Violations.Pelak,sum(cost)" +
                " from Violations," +
                $"(select Pelak from Violations where ID='{ID}' group by Pelak)" +
                " as [Pelaks] where Violations.Pelak=Pelaks.Pelak group by Violations.Pelak";
            command = new SqlCommand(sqlGet, con);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.Add(new PersonsViolation((string)reader[0]) { CostSum = (int)reader[1]});
            }
            
            con.Close();
            return new Tuple<BitmapImage?, List<PersonsViolation>>(item1: img, item2: Result);
        }

        public List<Violation> GetPersonsViolationsTime(string ID,DateTime StartDate,DateTime EndDate)
        {
            List<Violation> Result = new();

            string sqlGet = "select * from Violations " +
                $"where ID = '{ID}' and time between '{StartDate}' and '{EndDate}'";

            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.Add(new(new((string)reader[0]), new((string)reader[1]), (DateTime)reader[2])
                {
                    TypeOfViolation = (ViolationsType?)reader[3],
                    Cost = (int?)reader[4]
                });
            }
            con.Close();
            return Result;
        }

        public List<VehiclesViolation> GetVehiclesViolationsTime(string Pelak)
        {
            List<VehiclesViolation> Result = new();

            string sqlGet = "select Firstname,Lastname,PersonsCost.Cost" +
                " from Persons,(select Persons.ID,sum(cost)as 'Cost' from Violations,Persons " +
                $"where Violations.ID=Persons.ID and Pelak='{Pelak}' group by Persons.ID) as [PersonsCost]" +
                " where Persons.ID=PersonsCost.ID";

            SqlCommand command = new SqlCommand(sqlGet, con);
            con.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Result.Add(new() { FirstName = (string?)reader[0],
                    LastName = (string?)reader[1],
                    CostSum= (int?)reader[2]
                });
            }
            con.Close();
            return Result;
        }


        public static Byte[]? ImageToByte(BitmapImage? imageSource)
        {
            if (imageSource == null) return null;
            Stream stream = imageSource.StreamSource;
            Byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }
            return buffer;
        }
        public static BitmapImage? ByteToImage(byte[]? array)
        {
            if (array == null) return null;
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
