using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesIrInterfaces
{
    public enum PersonCompareType
    {
        FirstName,
        LastName
    }
    public class PersonComparer : IComparer<Person>
    {
        private PersonCompareType _compareType;
        public PersonComparer(PersonCompareType compareType)
        {
            _compareType = compareType;
        }
        public int Compare(Person x, Person y)
        {
            int result = 0;
            switch (_compareType)
            {
                case PersonCompareType.FirstName:
                    result = x.FirstName.CompareTo(y.FirstName);
                    break;
                case PersonCompareType.LastName:
                    result = x.LastName.CompareTo(y.LastName);
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
