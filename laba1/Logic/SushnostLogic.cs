using DataAccessLayer;
using laba1.BusinessLogic; 
using System;
using System.Collections.Generic;
using System.Linq;
using model.Entities;

namespace logic.Logic
{
    public class SushnostLogic
    {
        private readonly IRepository<Sushnost> _repository;
        private readonly SushnostBusinessLogic _businessLogic;

        public SushnostLogic(IRepository<Sushnost> repository, SushnostBusinessLogic businessLogic)
        {
            _repository = repository;
            _businessLogic = businessLogic;
        }

        public void Add(string name)
        {
            var s = new Sushnost { Name = name, Age = 0 };
            _repository.Add(s);
        }

        public bool Evaporate(int id)
        {
            var thing = _repository.ReadById(id);
            if (thing == null) return false;

            _repository.Delete(id);
            return true;
        }

        public bool Edit(int id, string newName)
        {
            var thing = _repository.ReadById(id);
            if (thing == null) return false;

            _businessLogic.ApplyEdit(thing, newName);

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

            _businessLogic.ApplyRift(list);

    
            foreach (var sushnost in list)
            {
                if (_businessLogic.ShouldDie(sushnost))
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

            _businessLogic.ApplyStabilize(list);

            foreach (var sushnost in list)
            {
                _repository.Update(sushnost);
            }
            return true;
        }

        public double GetStability()
        {
            return _businessLogic.GetStability();
        }
    }
}