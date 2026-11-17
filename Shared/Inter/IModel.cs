using System;
using Shared.EventArguments;

namespace Shared.Interfaces
{
    public interface IModel
    {
        // model --> pres
        event EventHandler<DataTransferEventArgs> DataLoaded;
        event EventHandler<ShowMessageEventArgs> MessageShown;
        event EventHandler ExitConfirmed;

        //pres --> model
        void LoadData();
        void Add(string name);
        void Delete(int id);
        void Edit(int id, string newName);
        void Rift();
        void Stabilize();
        void RequestExit();
    }
}