using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    /// <summary>
    /// основной класс программы, осуществляет работу с классом Shushnost
    /// </summary>
    public class Logic
    {   
        private List<Sushnost> SList = new List<Sushnost>();
        private int Sushnost_Counter = 0;
        private double Stability = 1;
        /// <summary>
        /// добавляет в список сущность с именем Name
        /// </summary>
        /// <param name="Name"></param>
        public void Add(string Name)
        {
            Sushnost_Counter += 1;
            SList.Add(new Sushnost{Name = Name, Id = Sushnost_Counter, Age = 0});
        }
        /// <summary>
        /// Удаляет сущность по заданному Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1, если список сущностей не пуст, 0 в обратном случае </returns>
        public bool Evaporate(int id)
        {
            Sushnost Thing = SList.FirstOrDefault(x => x.Id == id);
            if (Thing == null) { return false; }
            SList.Remove(Thing);
            return true;
        }
        /// <summary>
        /// Изменяет имя сущности по заданному Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns>1, если список сущностей не пуст, 0 в обратном случае</returns>
        public bool Edit( int id, string name)
        {
            Sushnost Thing = SList.FirstOrDefault(x => x.Id == id);
            if (Thing == null) { return false; };
            Thing.Name = name;
            return true;
        }
        /// <summary>
        /// возвращает список сущностей
        /// </summary>
        /// <returns> списко сущностей SList</returns>
        public List<Sushnost> SData()
        {
            return SList;
        }
        /// <summary>
        /// убивает сущности с шансом Math.Floor(Rnd.Next(100)*Stability), если сущность выживет, повышается возраст на 1.
        /// сущность умирает, если трансцендентность достигает 100. увеличивает нестабильность на (Stability + 0.5) * 1.5; 
        /// </summary>
        /// <returns>1, если список сущностей не пуст, 0 в обратном случае</returns>
        public bool Rift()
        {
            if (SList.Count == 0) { return false; }

            Stability = (Stability + 0.5) * 1.5;
            Random Rnd = new Random();
            List<Sushnost> Temporal = SList.ToList();
            foreach (Sushnost sushnost in Temporal)
            {
                sushnost.Transcendence += Convert.ToInt32(Math.Floor(Rnd.Next(100)*Stability)) 
                    - sushnost.Age*15;
                sushnost.Age += 1;
                if (sushnost.Transcendence > 99) {SList.Remove(sushnost); }
            }
            
            return true;
        }
        /// <summary>
        /// уменьшает нестабильност на Math.Sqrt(Math.Sqrt(Stability)), уменьшает трансцендентность сущности на Math.Sqrt(sushnost.Transcendence))
        /// </summary>
        /// <returns>1, если список сущностей не пуст, 0 в обратном случае</returns>
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
        /// <summary>
        /// возвращает значение стабильности
        /// </summary>
        /// <returns>стабильность stability</returns>
        public Double GetStability()
        {
            return Stability;
        }
        /// <summary>
        /// этот загадочный инструмент пригодится нам чуточку позже. он работает за ~O(log n)
        /// </summary>
        /// <param name="n"></param>
        /// <returns>корень введённого числа n</returns>
        public int binSqrt(int n)
        {
            int left = 0; int right = n;
            while(right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if(mid * mid <= n)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }

    }
}
