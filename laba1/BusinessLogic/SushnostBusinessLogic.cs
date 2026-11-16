using model.Entities;
using System;
using System.Collections.Generic;
using logic.Logic;
namespace laba1.BusinessLogic
{
    public class SushnostBusinessLogic
    {
        private double Stability = 1;
        public double GetStability() => Stability;

        public void ApplyEdit(Sushnost sushnost, string newName)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                sushnost.Name = newName;
            }
        }

        public void ApplyRift(List<Sushnost> list)
        {
            if (list.Count == 0) return;

            Stability = (Stability + 0.5) * 1.5;
            Random rnd = new Random();


            foreach (var sushnost in list)
            {
                sushnost.Transcendence += Convert.ToInt32(Math.Floor(rnd.Next(100) * Stability))
                                          - sushnost.Age * 15;
                sushnost.Age += 1;
            }
        }

        public void ApplyStabilize(List<Sushnost> list)
        {
            if (list.Count == 0) return;

            Stability = Math.Sqrt(Math.Sqrt(Stability));
            foreach (var sushnost in list)
            {
                sushnost.Transcendence = Convert.ToInt32(Math.Floor(Math.Sqrt(sushnost.Transcendence)));
            }
        }

        public bool ShouldDie(Sushnost sushnost)
        {
            return sushnost.Transcendence > 99 || sushnost.Transcendence <= 0;
        }
    }
}