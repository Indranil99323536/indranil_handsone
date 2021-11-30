using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_defined_Data
{
    public class Class1
    {
        private string _FirstName;
        private string _LastName;
        private int _Roll;
        private double _Marks;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }

        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }

        }
        public int Roll
        {
            get
            {
                return _Roll;
            }
            set
            {
                _Roll = value;
            }

        }
    public double Marks
    {
        get
        {
            return _Marks;
        }
        set
        {
            _Marks = value;
        }
    }
}
}