using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    public class Logic
    {   
        private List<Sushnost> SList = new List<Sushnost>();
        private int Sushnost_Counter = 0;
        private double Stability = 1;

        public void Add(string Name)
        {
            Sushnost_Counter += 1;
            SList.Add(new Sushnost{Name = Name, Id = Sushnost_Counter, Age = 0});
        }

        public bool Evaporate(int id)
        {
            Sushnost Thing = SList.FirstOrDefault(x => x.Id == id);
            if (Thing == null) { return false; }
            SList.Remove(Thing);
            return true;
        }

        public bool Edit( int id, string name)
        {
            Sushnost Thing = SList.FirstOrDefault(x => x.Id == id);
            if (Thing == null) { return false; };
            Thing.Name = name;
            Thing.Id = id;
            return true;
        }

        public List<Sushnost> SData()
        {
            return SList;
        }

        public bool Rift()
        {
            if (SList.Count == 0) { return false; }

            Stability = (Stability + 0.5) * 1.5;
            Random Rnd = new Random();
            List<Sushnost> Temporal = SList.ToList();
            foreach (Sushnost sushnost in Temporal)
            {
                sushnost.Transcendence += Convert.ToInt32(Math.Floor(Rnd.Next(100)*Stability)) - sushnost.Age*15;
                sushnost.Age += 1;
                if (sushnost.Transcendence > 99) {SList.Remove(sushnost); }
            }
            
            return true;
        }
        
        public bool Stabilize()
        {
            if (SList.Count == 0) { return false; }

            Stability = Math.Sqrt(Math.Sqrt(Stability));
            foreach (Sushnost sushnost in SList)
            {
                sushnost.Transcendence = Convert.ToInt32(Math.Floor(Math.Sqrt(sushnost.Transcendence)));
            }
            
            return true;
        }

        public Double GetStability()
        {
            return Stability;
        }

    }
}
