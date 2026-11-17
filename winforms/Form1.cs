using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Shared.DTO;
using Shared.Interfaces;

namespace winforms
{
    public partial class formandq : Form, IView
    {
        public event EventHandler LoadRequest;
        public event EventHandler AddRequest;
        public event EventHandler<int> DeleteRequest;
        public event EventHandler<(int id, string name)> EditRequest;
        public event EventHandler RiftRequest;
        public event EventHandler StabilizeRequest;
        public event EventHandler ExitRequest;

        public formandq()
        {
            InitializeComponent();
            SData.Enabled = false;
            this.Load += formandq_Load;
        }

       

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadRequest?.Invoke(this, EventArgs.Empty);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddRequest?.Invoke(this, EventArgs.Empty);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string answer = Interaction.InputBox("Кто вам не угодил? (Id)", "Испарение");
            if (int.TryParse(answer, out int id))
            {
                DeleteRequest?.Invoke(this, id);
            }
            else if (!string.IsNullOrWhiteSpace(answer))
            {
                ShowMessage("Id должен быть числом.", true);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string idStr = Interaction.InputBox("Кому поменять имя? (Id)", "Изменение");
            if (int.TryParse(idStr, out int id))
            {
                string newName = Interaction.InputBox("Какое имя?", "Изменение");
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    EditRequest?.Invoke(this, (id, newName));
                }
            }
        }

        private void Rift_Click(object sender, EventArgs e)
        {
            RiftRequest?.Invoke(this, EventArgs.Empty);
        }

        private void Stabilization_Click(object sender, EventArgs e)
        {
            StabilizeRequest?.Invoke(this, EventArgs.Empty);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            ExitRequest?.Invoke(this, EventArgs.Empty);
        }

        //pres --> iview

        public void ShowData(List<SushnostDto> data, double stability)
        {
            SData.DataSource = null;
            SData.DataSource = data;
            StabilityLabel.Text = $"Стабильность: {stability}";
            SetupColumns();
        }

        public void ShowMessage(string message, bool isError)
        {
            MessageBox.Show(message, isError ? "Ошибка" : "Успех",
                MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        public string ShowInputBox(string prompt, string title)
        {
            return Interaction.InputBox(prompt, title);
        }

        public void CloseView()
        {
            this.Close();
        }
        private void Guide_Click(object sender, MouseEventArgs e)
        {
            MessageBox.Show("1. Кнопка 'Добавить' позволяет задать имя сущности и добавить её в список. 2.Кнопка 'Удалить' позволяет удалить сущность по введённому Id. 3. кнопка 'Изменить' позволяет изменить имя сущности во введённому Id. 4. Кнопка 'Обновить' декарационная... 5. 'Разлом' - проверка сущностей на удачу, есть шанс умереть или пройти в следующее поколение и стать сильнее. 6. 'Стабилизация' уменьшает нестабильность, убивающую сущности. 7. кнопка 'Выход' закрывает программу ", "", MessageBoxButtons.OK);
        }

        private void formandq_Load(object sender, EventArgs e)
        {

            LoadRequest?.Invoke(this, EventArgs.Empty);
        }
        
        private void SetupColumns()
        {
            if (SData.Columns.Count == 0) return;
            if (SData.Columns["Id"] != null) SData.Columns["Id"].HeaderText = "Id";
            if (SData.Columns["Name"] != null) SData.Columns["Name"].HeaderText = "Имя";
            if (SData.Columns["Transcendence"] != null) SData.Columns["Transcendence"].HeaderText = "Трансцендентность";
            if (SData.Columns["Age"] != null) SData.Columns["Age"].HeaderText = "Возраст";
            SData.ScrollBars = ScrollBars.Vertical;
            foreach (DataGridViewColumn col in SData.Columns) col.Width = 150;
        }
    }
    

    }

