using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;
namespace laba1
{
    public class Logic
    {
        private readonly IRepository<Sushnost> _repository;
        private double Stability = 1;

        
        public Logic()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UniversityDB;Integrated Security=True";

            
            _repository = new DapperRepository<Sushnost>(connString);
        }

        public void Add(string Name)
        {
            var s = new Sushnost { Name = Name, Age = 0 };
            _repository.Add(s);
        }

        public bool Evaporate(int id)
        {
            var thing = _repository.ReadById(id);
            if (thing == null) return false;
            _repository.Delete(id);
            return true;

        }

        public bool Edit(int id, string name)
        {
            var thing = _repository.ReadById(id);
            if (thing == null) return false;
            thing.Name = name;
            _repository.Update(thing);
            return true;

        }

        public List<Sushnost> SData()
        {
            
            return _repository.ReadAll().ToList();
        }

        public bool Rift()
        {
            var list = _repository.ReadAll().ToList();
            if (list.Count == 0) return false;

            Stability = (Stability + 0.5) * 1.5;
            Random Rnd = new Random();

            foreach (Sushnost sushnost in list)
            {
                sushnost.Transcendence += Convert.ToInt32(Math.Floor(Rnd.Next(100) * Stability))
                                         - sushnost.Age * 15;
                sushnost.Age += 1;

                if (sushnost.Transcendence > 99 || sushnost.Transcendence <= 0)
                {
                    _repository.Delete(sushnost.Id); 
                }
                else
                {
                    _repository.Update(sushnost); 
                }

            }
            return true;
        }

        public bool Stabilize()
        {
            var list = _repository.ReadAll().ToList();
            if (list.Count == 0) return false;

            Stability = Math.Sqrt(Math.Sqrt(Stability));
            foreach (Sushnost sushnost in list)
            {
                sushnost.Transcendence = Convert.ToInt32(Math.Floor(Math.Sqrt(sushnost.Transcendence)));
                _repository.Update(sushnost);
            }
            return true;
        }

        public Double GetStability() => Stability;

        public int binSqrt(int n)
        {
            int left = 0; int right = n;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (mid * mid <= n) left = mid;
                else right = mid;
            }
            return left;
        }
    }
}