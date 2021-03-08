using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace MovieNight1
{

    class DalManager
    {

        public static List<Film> GetFilms()
        {
            List<Film> films = new List<Film>();
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select id, title from movies", conn);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = (int)rdr["id"];
                string title = (string)rdr["title"];
                Film f = new Film(id, title, "");
                films.Add(f);
            }
            conn.Close();
            films.Add(new Film(20, "Nam Nori vs Acirema Niatpac: A Bollywood exclusive", ""));
            return films;

        }                    // Print list of films
        public static List<Actor> GetActors()
        {
            List<Actor> actors = new List<Actor>();
            actors.Add(new Actor ( " Robert", " Downey JR. " ));
            return new List<Actor>();
        }                 //Prints a list of actors
        public static Actor InsertActor (Actor a)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");

            SqlCommand cmd = new SqlCommand
                ("insert into actor(firstname, lastname) OUTPUT INSERTED.ID values(@fn,@ln)",
                conn);
            cmd.Parameters.Add(new SqlParameter("@fn", a.FirstName));
            cmd.Parameters.Add(new SqlParameter("@ln", a.LastName));
            
            conn.Open();
            cmd.ExecuteNonQuery();
            //int newId = (Int32)cmd.ExecuteScalar();
            //a.Id = newId;

            conn.Close();
            return a;
        }
        public static List<Film> MovieSearch(string search)
        {
            List<Film> movies = new List<Film>();
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand
            ("select id, title from movies where title like @search",
            conn);
            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@search";
            sp.Value = "%" + search + "%";
            cmd.Parameters.Add(sp);
            conn.Open();
            SqlDataReader tsl = cmd.ExecuteReader();
            while(tsl.Read())
            {
                int id = (int)tsl["id"];
                string title = (string)tsl["title"];
                Film f = new Film(id, title, "");
                movies.Add(f);
            }
            conn.Close();
            return movies;

        }   // Search for specific movie
        public static List<Actor> ActorWanted(string search)
        {
            List<Actor> actors = new List<Actor>();
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand(
                "select name from movies WHERE name like @search",
                conn);
            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@search";
            sp.Value = "%" + search + "%";
            cmd.Parameters.Add(sp);
            conn.Open();
            SqlDataReader aws = cmd.ExecuteReader();
            while (aws.Read())
            {
                string firstName = (string)aws["firstname"];
                string lastName = (string)aws["lastname"];
                Actor a = new Actor(firstName, lastName);
                actors.Add(a);
            }
            conn.Close();
            return actors;


        }  // Search movies with desired actor

        public static Film InsertFilm(Film f)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");

            SqlCommand cmd = new SqlCommand
                ("insert into movies(title) OUTPUT INSERTED.ID values(@tit)", 
                conn);
            cmd.Parameters.Add(new SqlParameter("@tit", f.Title));

            conn.Open();
            int newId = (Int32)cmd.ExecuteScalar();

            f.Id = newId;

            conn.Close();
            return f;
        }                 // Method to insert new film into the film list
        public static void FilmUpdate(Film f)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");

            SqlCommand cmd = new SqlCommand
                ( "update movies SET title = @tit WHERE id = @id",
                conn );
            cmd.Parameters.AddWithValue("@tit", f.Title);
            cmd.Parameters.AddWithValue("id", f.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }                 // Method to Update already existing films on the lsit
        public static void FilmRemove(Film f) 
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=MCU; Integrated Security=SSPI");

            SqlCommand cmd = new SqlCommand
                ("delete from movies WHERE id = @id ",
                conn);
            cmd.Parameters.AddWithValue("@id", f.Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
