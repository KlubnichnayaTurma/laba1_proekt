using System;
using System.Collections.Generic;
using DataAccessLayer;
using model.Entities;
using Shared.DTO;
using Shared.EventArguments;
using Shared.Interfaces;
using laba1.BusinessLogic;

namespace logic.Logic
{
    public class SushnostModel : IModel
    {
        private readonly IRepository<Sushnost> _repository;
        private readonly SushnostBusinessLogic _businessLogic;

        
        public event EventHandler<DataTransferEventArgs> DataLoaded;
        public event EventHandler<ShowMessageEventArgs> MessageShown;
        public event EventHandler ExitConfirmed;

        public SushnostModel(IRepository<Sushnost> repository, SushnostBusinessLogic businessLogic)
        {
            _repository = repository;
            _businessLogic = businessLogic;
        }

        public void LoadData()
        {
            List<Sushnost> list = _repository.ReadAll().ToList();
            List<SushnostDto> dtos = new List<SushnostDto>();

            foreach (Sushnost item in list)
            {
                SushnostDto dto = new SushnostDto();
                dto.Id = item.Id;
                dto.Name = item.Name;
                dto.Transcendence = item.Transcendence;
                dto.Age = item.Age;
                dtos.Add(dto);
            }

            DataLoaded?.Invoke(this, new DataTransferEventArgs(dtos, _businessLogic.GetStability()));
        }

        public void Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Имя не может быть пустым.", true));
                return;
            }

            Sushnost s = new Sushnost();
            s.Name = name;
            s.Age = 0;
            _repository.Add(s);

            MessageShown?.Invoke(this, new ShowMessageEventArgs("Сущность добавлена.", false));
            LoadData();
        }

        public void Delete(int id)
        {
            Sushnost thing = _repository.ReadById(id);
            if (thing == null)
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Не нашли.", true));
                return;
            }

            _repository.Delete(id);
            MessageShown?.Invoke(this, new ShowMessageEventArgs("Готово.", false));
            LoadData();
        }

        public void Edit(int id, string newName)
        {
            Sushnost thing = _repository.ReadById(id);
            if (thing == null)
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Не нашли.", true));
                return;
            }

            _businessLogic.ApplyEdit(thing, newName);
            _repository.Update(thing);

            MessageShown?.Invoke(this, new ShowMessageEventArgs("Готово.", false));
            LoadData();
        }

        public void Rift()
        {
            List<Sushnost> list = _repository.ReadAll().ToList();
            if (list.Count == 0)
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Пустота.", true));
                return;
            }

            _businessLogic.ApplyRift(list);

            foreach (Sushnost sushnost in list)
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

            MessageShown?.Invoke(this, new ShowMessageEventArgs("Успешно. Проверьте сущности.", false));
            LoadData();
        }

        public void Stabilize()
        {
            List<Sushnost> list = _repository.ReadAll().ToList();
            if (list.Count == 0)
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Пустота.", true));
                return;
            }

            _businessLogic.ApplyStabilize(list);

            foreach (Sushnost sushnost in list)
            {
                _repository.Update(sushnost);
            }

            MessageShown?.Invoke(this, new ShowMessageEventArgs("Успешно. Проверьте сущности.", false));
            LoadData();
        }

        public void RequestExit()
        {
            List<Sushnost> list = _repository.ReadAll().ToList();
            if (list.Count == 0)
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Безопасный выход из системы...", false));
            }
            else
            {
                MessageShown?.Invoke(this, new ShowMessageEventArgs("Они найдут вас.", true));
            }

            ExitConfirmed?.Invoke(this, EventArgs.Empty);
        }
    }
}