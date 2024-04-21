using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Tema2II
{
    public class CarContext
    {
        private string connectionString;

        public CarContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Car> GetAllCars() 
        {
        List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString.Replace("trust server certificate=true;", "")))


            {

                string query = "SELECT * FROM Reprezentanta ";

                using (SqlCommand command = new SqlCommand(query,connection)) 
                {
                connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) 
                    {
                        Car car = new Car();
                        car.Id = Convert.ToInt32(reader["Id"]);
                        car.Brand = Convert.ToString(reader["Brand"]);
                        car.Type = Convert.ToString(reader["Type_Car"]);
                        car.Model = Convert.ToString(reader["Model"]);
                        car.NumberOfOwners = Convert.ToInt32(reader["Nr_owners"]);
                        cars.Add(car);

                    }
                    reader.Close();
                }
            }
            return cars;
        }

        public void AddCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Replace("trust server certificate=true;", "")))
            {
                string query = "INSERT INTO Reprezentanta (Brand, Type_Car, Model, Nr_owners) " +
                               "VALUES (@Brand, @Type, @Model, @NumberOfOwners)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@Type", car.Type);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@NumberOfOwners", car.NumberOfOwners);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateCar(Car car)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Replace("trust server certificate=true;", "")))
            {
                string query = "UPDATE Reprezentanta SET Brand = @Brand, Type_Car = @Type, " +
                               "Model = @Model, Nr_owners = @NumberOfOwners WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@Type", car.Type);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@NumberOfOwners", car.NumberOfOwners);
                    command.Parameters.AddWithValue("@Id", car.Id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public void RemoveCar(int carId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString.Replace("trust server certificate=true;", "")))
            {
                string query = "DELETE FROM Reprezentanta WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", carId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}