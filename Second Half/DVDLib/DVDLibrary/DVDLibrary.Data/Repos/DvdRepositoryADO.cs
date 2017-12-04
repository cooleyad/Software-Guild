using DVDLibrary.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Model;
using System.Data.SqlClient;
using System.Data;

namespace DVDLibrary.Data
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("AddDvd", cn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Title", dvd.Title);
                command.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                command.Parameters.AddWithValue("@DirectorName", dvd.Director);
                command.Parameters.AddWithValue("@RatingName", dvd.Rating);
                command.Parameters.AddWithValue("@Notes", dvd.Notes);
                cn.Open();
                command.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void DeleteDvd(int id)
        {
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DeleteDvd", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                cn.Open();
                command.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Dvd> DvdByDirector(string director)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DvdByDirector", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DirectorName", director);

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public List<Dvd> DvdByRating(string rating)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DvdByRating", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RatingType", rating);

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }
        }

        public List<Dvd> DvdByTitle(string dvdTitle)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DvdByTitle", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", dvdTitle);

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }

        }

        public List<Dvd> DvdReleaseYear(int year)
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DvdReleaseYear", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ReleaseYear", year);

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }

        }

        public void EditDvd(Dvd dvd)
        {
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("EditDvd", cn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID", dvd.DvdId);
                command.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                command.Parameters.AddWithValue("@DirectorName", dvd.Director);
                command.Parameters.AddWithValue("@RatingName", dvd.Rating);
                command.Parameters.AddWithValue("@Notes", dvd.Notes);
                cn.Open();
                command.ExecuteNonQuery();
                cn.Close();
            }
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> dvds = new List<Dvd>();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("DvdSelectAll", cn);
                command.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Dvd dvd = new Dvd();
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();

                        dvds.Add(dvd);
                    }
                }
                return dvds;
            }

        }

        public Dvd GetDvdById(int id)
        {
            Dvd dvd = new Dvd();
            using (var cn = new SqlConnection(StringBridge.ConnectionString()))
            {
                SqlCommand command = new SqlCommand("GetDvdById", cn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                cn.Open();

                using (SqlDataReader rd = command.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        dvd.DvdId = (int)rd["Id"];
                        dvd.Title = rd["Title"].ToString();
                        dvd.ReleaseYear = (int)rd["ReleaseYear"];
                        dvd.Director = rd["DirectorName"].ToString();
                        dvd.Rating = rd["RatingType"].ToString();
                        dvd.Notes = rd["Notes"].ToString();
                    }
                }
                return dvd;
            }

        }
    }
}
