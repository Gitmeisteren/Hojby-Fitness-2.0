using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Statistic
    {
        //Need to make a constructor that can add values.

        int _Age = 0;
        string _Type = "";
        string _Date = "";

        public Statistic()
        {

        }

        public Statistic(int age,string date, string goal)
        {
            this._Age = age;
            this._Date = date;
            this._Type = goal;
        }

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }
        public string Date
        {
            get
            {
                return _Date;
            }
            set
            {
                _Date = value;
            }
        }

    }
}
