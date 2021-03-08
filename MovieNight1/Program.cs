using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MovieNight1
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool FilmManaging = true;
            //while (Filming != false)
            //{
            //
            //}
            #region List of Films
            List<Film> film = FilmManageren.filmList();
            film.Add(new Film(0, " ", "textDescription"));
            foreach (Film item in film)
            {
                Console.WriteLine(item.Title);
            }
            #endregion

            #region List of Actors
            List<Actor> actorList = FilmManageren.actorList();
            foreach (Actor actor in actorList)
            {
                Console.WriteLine(actor.FirstName);

            }
            #endregion

            #region Film search
            Console.WriteLine("Any title you want to search for?\n");
            List<Film> searchResults = FilmManageren.searchList(Console.ReadLine());
            Console.WriteLine("\n");
            foreach (Film item in searchResults)
            {
                Console.WriteLine(item.Title);
            }
            Console.ReadKey();
            Console.WriteLine("\n");
            #endregion

            #region Film Inserter
            Console.WriteLine("Write the title of the movie you want to add");
            film.Add(FilmManageren.insertFilm(new Film(Console.ReadLine(), "")));
            Console.WriteLine("\n");
            foreach (Film item in film)
            {
                Console.WriteLine(item.Title);
            }
            Console.ReadKey();
            Console.WriteLine("\n");
            #endregion

            #region Replace/Update a Film
            foreach (Film item in film) 
            {
                Console.WriteLine(item.Id + " " + item.Title);
            }
            Console.WriteLine("Please input the Id nr of the title you wish to update");
            int idSelected = Convert.ToInt32( Console.ReadLine());
            Film film1 = new Film();
            foreach (Film item in film)
            {
                if (item.Id == idSelected)
                {
                    film1 = item;
                    break;
                }
            }
            Console.WriteLine("What is the new title?");
            film1.Title = Console.ReadLine();
            Console.WriteLine("\n");
            FilmManageren.filmUpdate(film1);
            film.Clear();
            film = FilmManageren.filmList();
            foreach ( Film item in film)
            {
                Console.WriteLine(item.Title);
                

            }
            Console.ReadKey();
            Console.WriteLine("\n");

            #endregion

            #region Remove Film
            foreach ( Film item in film)
            {
                Console.WriteLine(item.Id + " " + item.Title);
            }
            Console.WriteLine("Type the id of the movie you wish to remove?");
            int idRemoveSelected = Convert.ToInt32(Console.ReadLine());
            Film film2 = new Film();
            foreach (Film item in film)
            {
                if (item.Id == idRemoveSelected)
                {
                    film2 = item;
                    break;
                }
            }
            Console.WriteLine("Here is the new list");
            FilmManageren.filmRemove(film2);
            film.Clear();
            film = FilmManageren.filmList();
            Console.WriteLine("\n");
            foreach (Film item in film)
            {
                Console.WriteLine(item.Title);
                

            }
            Console.ReadKey();
            Console.WriteLine("\n");

            #endregion

            #region InsertActor
            Console.WriteLine("Please write the firstname of the Actor you want to add to the list");
            
            actorList.Add(FilmManageren.insertActor(new Actor(Console.ReadLine(), "")));
            foreach (Actor person in actorList)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
            Console.ReadKey();
            Console.WriteLine("\n");

            #endregion
        }
    }

}                  
                    
