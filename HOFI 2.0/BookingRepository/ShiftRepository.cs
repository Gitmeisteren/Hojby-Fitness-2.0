using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class ShiftRepository
    {
        private List<Shift> _ShiftList = new List<Shift>();
        public void AddToRepo(Shift shift)
        {
            _ShiftList.Add(shift);
        }
    }
}
