using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight1
{
    class FilmManageren
    {
        public static List<Film> filmList()
        {
            return DalManager.GetFilms();
        }
        public static List<Actor> actorList()
        {
            return DalManager.GetActors();
        }
        public static Actor insertActor(Actor a)
        {
            return DalManager.InsertActor(a);
        }

        public static List<Film> searchList(string search)
        {
            return DalManager.MovieSearch(search);
        }
        public static List<Actor> actorWanted(string search)
        {
            return DalManager.ActorWanted(search);
        }
        public static Film insertFilm(Film f)
        {
            return DalManager.InsertFilm(f);
        }
        public static void filmUpdate(Film f)
        {
            DalManager.FilmUpdate(f);
        }
        public static void filmRemove (Film f)
        {
            DalManager.FilmRemove(f);
        }
    }

}
