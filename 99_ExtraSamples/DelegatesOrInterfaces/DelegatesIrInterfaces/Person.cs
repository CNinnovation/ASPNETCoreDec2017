using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesIrInterfaces
{
    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Person other) => this.LastName.CompareTo(other.LastName);


        public override string ToString() => LastName;

    }
}
