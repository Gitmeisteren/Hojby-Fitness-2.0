using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class StatisticRepository
    {
        List<Statistic> _StatisticsList = new List<Statistic>();
        private static StatisticRepository _Instance;
        public static StatisticRepository GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new StatisticRepository();
            }
            return _Instance;
        }
        private StatisticRepository()
        {

        }
        public void RefreshStatisticsFromDB(List<Statistic> statistics)
        {
            _StatisticsList.Clear();
            foreach (Statistic statistic in statistics)
            {
                _StatisticsList.Add(statistic);
            }
        }

        public List<Statistic> GetStatisticFromRepo()
        {
            return _StatisticsList;
        }
    }
}
