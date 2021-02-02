using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Windows.Forms;
using Autodealer.Classes;

namespace Autodealer
{
    public class SQLiteDataAccess
    {
        public static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        public static List<Cars> loadCars()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Cars>("select * from Cars where carArchived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void saveCar(Cars car)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Cars (carMark, carReleaseDate, carModel, carColor, carPrice) values (@carMark, @carReleaseDate, @carModel, @carColor, @carPrice)", car);
            }
        }
        public static void addCarToArchive(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                Cars car = cnn.QueryFirst<Cars>("select * from Cars where id="+id);
                cnn.Execute("update Cars set carArchived=1 where id="+id);
                cnn.Execute("insert into ArchievedCars (archievedCarId) values (" + id + ")");
            }
        }
        public static void addClientToArchive(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                ClientsAuth cl = cnn.QueryFirst<ClientsAuth>("select * from Clients where id=" + id);
                cnn.Execute("update Clients set clientArchived=1 where id=" + id);
                cnn.Execute("insert into ArchivedClients (archivedClientId) values (" + id + ")");
            }
        }

        public static void addStaffToArchive(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                Staff cl = cnn.QueryFirst<Staff>("select * from Workers where id=" + id);
                cnn.Execute("update Workers set Archived=1 where id=" + id);
                cnn.Execute("insert into ArchivedWorkers (archivedWorkersId) values (" + id + ")");
            }
        }
        public static void addOrdersToArchive(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                Orders orders = cnn.QueryFirst<Orders>("select * from Orders where car_id = " + id);
                cnn.Execute("update Orders set Archived=1 where car_id=" + id);
                cnn.Execute("insert into ArchivedOrders (archivedOrdersId) values (" + orders.id + ")");
            }
        }
        public static void addAllOrdersToArchive(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                Orders orders = cnn.QueryFirst<Orders>("select * from Orders where id = " + id);
                cnn.Execute("update Orders set Archived=1 where id=" + id);
                cnn.Execute("insert into ArchivedOrders (archivedOrdersId) values (" + id + ")");
            }
        }

        public static List<UserAuth> loadUser(string login, string password){
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<UserAuth>("SELECT login, password, role FROM Workers where login = '"+login+"' and password = '"+password+"'");
                
                return output.ToList();
                
            }
        }
        public static List<UserAuth> loadUserList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserAuth>("select * from Workers where Archived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<ClientsAuth> loadClient(string login, string password)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ClientsAuth>("SELECT clientLogin, clientPassword FROM Clients where clientLogin = '" + login + "' and clientPassword = '" + password + "'");
                return output.ToList();
            }
        }
        public static ClientsAuth loadAuthClientList(string login, string password)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirst<ClientsAuth>("SELECT * FROM Clients where clientLogin = '" + login + "' and clientPassword = '" + password + "'");
                return output;
            }
        }

        public static UserAuth findStaff(string name, string surname)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.QueryFirst<UserAuth>("SELECT * FROM Workers where name = '" + name + "' and surname = '" + surname + "'");
                return output;
            }
        }
        public static List<ClientsAuth> loadClientList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ClientsAuth>("select * from Clients where clientArchived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void saveClient(ClientsAuth clients)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Clients (clientName, clientSurname, clientMiddlename, clientMobileNumber, clientEmail, clientLogin, clientPassword) " +
                    "values (@clientName, @clientSurname, @clientMiddlename, @clientMobileNumber, @clientEmail, @clientLogin, @clientPassword)", clients);
            }
        }
        public static void saveOrder(Orders order)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Orders (car_id, client_id) VALUES (@car_id, @client_id)", order);
            }
        }
        public static void addStaffToOrder(Orders staff)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("update Orders set worker_id = '" + staff.worker_id + "' where id = '" + staff.id + "'", staff);
            }
        }
        public static List<Staff> loadStaff()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Staff>("select * from Workers where Archived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<AOToWorkers> loadOrders(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AOToWorkers>("select o.id, c.carMark,c.carModel,c.carReleaseDate,c.carColor,c.carPrice, " +
                    "W.name, W.surname, W.middlename, " +
                    "C2.clientName, C2.clientSurname, C2.clientMiddlename, C2.clientMobileNumber, C2.clientEmail " +
                    "from Orders as o " +
                    "join Cars c on o.car_id = c.id " +
                    "join Workers W on o.worker_id = W.id " +
                    "join Clients C2 on o.client_id = C2.id where o.Archived <>1;", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<AOToClient> loadCarsFromOrders(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<AOToClient>("select c.*, C2.clientName, C2.clientSurname from Orders as o" +
                    " join Cars c on o.car_id = c.id" +
                    " join Clients C2 on o.client_id = C2.id where client_id ='" +id+"' and Archived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Orders> loadCarToOrders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Orders>("select c.* from Orders join Cars as c", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void saveStaff(Staff staff)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Workers (name, surname, middlename, mobileNumber, email, login, password, role) " +
                    "values (@name, @surname, @middlename, @mobileNumber, @email, @login, @password, @role)", staff);
            }
        }
        public static List<Staff> getStaff()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Staff>("select name, surname from Workers where Archived <> 1", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Staff> staffLoginCheck(string login)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Staff>("select login from Workers where login = '" + login + "'", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<ClientsAuth> clientLoginCheck(string login)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ClientsAuth>("select clientLogin from Clients where clientLogin = '" + login + "'", new DynamicParameters());
                return output.ToList();
            }
        }

    }
}
