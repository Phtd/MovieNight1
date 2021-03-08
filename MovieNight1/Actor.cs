using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight1
{

    class Actor
    {
        private int id;
        private string firstName;
        private string lastName;


        public int Id 
        { 
            get { return id; } 
            set { id = value; } 
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public Actor (int id, string firstName, string lastName)
            :this(firstName,lastName)
        {
            this.id = id;
        }
        public Actor(string firstName, string lastName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }
        public Actor()
        {

        }
    }
}
