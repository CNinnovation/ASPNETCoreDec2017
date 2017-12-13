using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesIrInterfaces
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }


        public int CompareTo(Person other) => this.LastName.CompareTo(other.LastName);


        public override string ToString() => LastName;

    }
}
