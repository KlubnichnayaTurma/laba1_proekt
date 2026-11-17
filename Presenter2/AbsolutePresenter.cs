using System;
using Shared.Interfaces;
using Shared.EventArguments;

namespace Presenter
{
    public class AbsolutePresenter
    {
        private readonly IView _view;
        private readonly IModel _model;

        public AbsolutePresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;

            //подписочк вью
            _view.LoadRequest += OnLoadRequest;
            _view.AddRequest += OnAddRequest;
            _view.DeleteRequest += OnDeleteRequest;
            _view.EditRequest += OnEditRequest;
            _view.RiftRequest += OnRiftRequest;
            _view.StabilizeRequest += OnStabilizeRequest;
            _view.ExitRequest += OnExitRequest;

            //подписочк модл
            _model.DataLoaded += OnDataLoaded;
            _model.MessageShown += OnMessageShown;
            _model.ExitConfirmed += OnExitConfirmed;
        }

        //смотреть обработка

        private void OnLoadRequest(object sender, EventArgs e)
        {
            _model.LoadData();
        }

        private void OnAddRequest(object sender, EventArgs e)
        {
            string name = _view.ShowInputBox("Обзовите сущность:", "Добавление");

            if (!string.IsNullOrWhiteSpace(name))
            {
                _model.Add(name);
            }
        }

        private void OnDeleteRequest(object sender, int id)
        {
            _model.Delete(id);
        }

        private void OnEditRequest(object sender, (int id, string name) data)
        {
            _model.Edit(data.id, data.name);
        }

        private void OnRiftRequest(object sender, EventArgs e)
        {
            _model.Rift();
        }

        private void OnStabilizeRequest(object sender, EventArgs e)
        {
            _model.Stabilize();
        }

        private void OnExitRequest(object sender, EventArgs e)
        {
            _model.RequestExit();
        }

        //модль обработка

        //данные мдль --> вью
        private void OnDataLoaded(object sender, DataTransferEventArgs e)
        {
            _view.ShowData(e.Data, e.Stability);
        }

        //сообщение мдль --> вью
        private void OnMessageShown(object sender, ShowMessageEventArgs e)
        {
            _view.ShowMessage(e.Message, e.IsError);
        }

        //выход
        private void OnExitConfirmed(object sender, EventArgs e)
        {
            _view.CloseView();
        }
    }
}