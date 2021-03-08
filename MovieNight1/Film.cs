using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight1
{
    class Film
    {
        private int id;
        private string title;
        private string description;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }





        public Film(int Id, string Title, string Description)
            :this(Title,Description)
        {
            this.id = Id;
        }
        public Film(string Title, string Description)
        {
            this.title = Title;
            this.description = Description;
        }
        public Film()
        {

        }
    }
}
