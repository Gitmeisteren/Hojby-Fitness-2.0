using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatisticHandler
    {
        SQLDatabaseConnectionPoint sqlDatabaseConnectionPoint = new SQLDatabaseConnectionPoint();
        StatisticRepository statisticRepo = StatisticRepository.GetInstance();
        FileExporter fileExporter = new FileExporter();
        private static StatisticHandler _Instance;
        public static StatisticHandler GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new StatisticHandler();
            }
            return _Instance;
        }
        private StatisticHandler()
        {

        }
        public void StatisticRepoUpdate()
        {
            List<Statistic> statisticFromDB = sqlDatabaseConnectionPoint.UpdateStatistic();
            statisticRepo.AddStatisticsToRepoFromDB(statisticFromDB);
        }

        public void AddToDBFromStatistic()
        {
            int Styrketræning = 4;
            int Opstramning = 0;
            int Vægttab = 0;
            int Konditionstræning = 0;
            int KomGodtIgang = 0;
            List<int> FileNumbersList = new List<int>();
            List<Statistic> StatisticListFromRepo =statisticRepo.GetStatisticFromRepo();

            List<Statistic> AgeGroup1 = new List<Statistic>(); //18-25
            List<Statistic> AgeGroup2 = new List<Statistic>(); //26-35
            List<Statistic> AgeGroup3 = new List<Statistic>(); //36-45
            List<Statistic> AgeGroup4 = new List<Statistic>(); //46-55
            List<Statistic> AgeGroup5 = new List<Statistic>(); //55+

            foreach (Statistic statistic in StatisticListFromRepo)
            {
                if (statistic.Age > 18 && statistic.Age < 25)
                {
                    AgeGroup1.Add(statistic);
                }else if(statistic.Age > 26 && statistic.Age < 35)
                {
                    AgeGroup2.Add(statistic);
                }else if (statistic.Age > 36 && statistic.Age < 45)
                {
                    AgeGroup3.Add(statistic);
                }else if (statistic.Age > 46 && statistic.Age < 55)
                {
                    AgeGroup4.Add(statistic);
                }else if(statistic.Age > 55)
                {
                    AgeGroup5.Add(statistic);
                }
            }
           // "Styrketræning", "Vægttab", "Opstramning", "Konditionstræning", "Kom-Godt-Igang"
            foreach (Statistic statistic in AgeGroup1)
            {
                if (statistic.Type == "Styrketræning")
                {
                    Styrketræning++;
                }
                else if( statistic.Type == "Opstramning")
                {
                    Opstramning++;
                }
                else if (statistic.Type == "Vægttab")
                {
                    Vægttab++;
                }
                else if (statistic.Type == "Konditionstræning")
                {
                    Konditionstræning++;
                }
                else if (statistic.Type == "Kom-Godt-Igang")
                {
                    KomGodtIgang++;
                }
            }
            
            FileNumbersList.Add(Styrketræning);
            FileNumbersList.Add(Opstramning);
            FileNumbersList.Add(Vægttab);
            FileNumbersList.Add(Konditionstræning);
            FileNumbersList.Add(KomGodtIgang);

            Styrketræning = 3;
            Opstramning = 2;
            Vægttab = 0;
            Konditionstræning = 0;
            KomGodtIgang = 0;
            foreach (Statistic statistic in AgeGroup2)
            {
                if (statistic.Type == "Styrketræning")
                {
                    Styrketræning++;
                }
                else if (statistic.Type == "Opstramning")
                {
                    Opstramning++;
                }
                else if (statistic.Type == "Vægttab")
                {
                    Vægttab++;
                }
                else if (statistic.Type == "Konditionstræning")
                {
                    Konditionstræning++;
                }
                else if (statistic.Type == "Kom-Godt-Igang")
                {
                    KomGodtIgang++;
                }
            }

            FileNumbersList.Add(Styrketræning);
            FileNumbersList.Add(Opstramning);
            FileNumbersList.Add(Vægttab);
            FileNumbersList.Add(Konditionstræning);
            FileNumbersList.Add(KomGodtIgang);

            Styrketræning = 0;
            Opstramning = 0;
            Vægttab = 4;
            Konditionstræning = 0;
            KomGodtIgang = 0;
            foreach (Statistic statistic in AgeGroup3)
            {
                if (statistic.Type == "Styrketræning")
                {
                    Styrketræning++;
                }
                else if (statistic.Type == "Opstramning")
                {
                    Opstramning++;
                }
                else if (statistic.Type == "Vægttab")
                {
                    Vægttab++;
                }
                else if (statistic.Type == "Konditionstræning")
                {
                    Konditionstræning++;
                }
                else if (statistic.Type == "Kom-Godt-Igang")
                {
                    KomGodtIgang++;
                }
            }

            FileNumbersList.Add(Styrketræning);
            FileNumbersList.Add(Opstramning);
            FileNumbersList.Add(Vægttab);
            FileNumbersList.Add(Konditionstræning);
            FileNumbersList.Add(KomGodtIgang);

            Styrketræning = 0;
            Opstramning = 0;
            Vægttab = 0;
            Konditionstræning = 5;
            KomGodtIgang = 0;
            foreach (Statistic statistic in AgeGroup4)
            {
                if (statistic.Type == "Styrketræning")
                {
                    Styrketræning++;
                }
                else if (statistic.Type == "Opstramning")
                {
                    Opstramning++;
                }
                else if (statistic.Type == "Vægttab")
                {
                    Vægttab++;
                }
                else if (statistic.Type == "Konditionstræning")
                {
                    Konditionstræning++;
                }
                else if (statistic.Type == "Kom-Godt-Igang")
                {
                    KomGodtIgang++;
                }
            }

            FileNumbersList.Add(Styrketræning);
            FileNumbersList.Add(Opstramning);
            FileNumbersList.Add(Vægttab);
            FileNumbersList.Add(Konditionstræning);
            FileNumbersList.Add(KomGodtIgang);

            Styrketræning = 0;
            Opstramning = 0;
            Vægttab = 0;
            Konditionstræning = 0;
            KomGodtIgang = 6;
            foreach (Statistic statistic in AgeGroup5)
            {
                if (statistic.Type == "Styrketræning")
                {
                    Styrketræning++;
                }
                else if (statistic.Type == "Opstramning")
                {
                    Opstramning++;
                }
                else if (statistic.Type == "Vægttab")
                {
                    Vægttab++;
                }
                else if (statistic.Type == "Konditionstræning")
                {
                    Konditionstræning++;
                }
                else if (statistic.Type == "Kom-Godt-Igang")
                {
                    KomGodtIgang++;
                }
            }

            FileNumbersList.Add(Styrketræning);
            FileNumbersList.Add(Opstramning);
            FileNumbersList.Add(Vægttab);
            FileNumbersList.Add(Konditionstræning);
            FileNumbersList.Add(KomGodtIgang);

            Styrketræning = 0;
            Opstramning = 0;
            Vægttab = 0;
            Konditionstræning = 0;
            KomGodtIgang = 7;

            fileExporter.UpdateStatisticTExcel(FileNumbersList);

        }

    }
}
