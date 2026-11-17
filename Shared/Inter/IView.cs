using System;
using System.Collections.Generic;
using Shared.DTO;

namespace Shared.Interfaces
{
    public interface IView
    {
        //view -- > pres
        event EventHandler LoadRequest;                  //кнопка Обновить
        event EventHandler AddRequest;                   //кнопка Добавить
        event EventHandler<int> DeleteRequest;           //кнопка Удалить (Id)
        event EventHandler<(int id, string name)> EditRequest; //кнопка Изменить (Id + Имя)
        event EventHandler RiftRequest;                  //кнопка Разлом
        event EventHandler StabilizeRequest;             //кнопка Стабилизация
        event EventHandler ExitRequest;                  //кнопка Выход

        //pres --> view
        void ShowData(List<SushnostDto> data, double stability); //Отрисовать
        void ShowMessage(string message, bool isError);          //MessageBox
        string ShowInputBox(string prompt, string title);        //вернуть введенное

        
        void CloseView();
    }
}