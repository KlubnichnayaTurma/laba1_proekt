using laba1;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using winforms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace winforms
{
    public partial class formandq : Form
    {
        private Logic logic = new Logic();

        public formandq()
        {
            InitializeComponent();
            RefreshAll();

            SData.Enabled = false;
        }

        private void RefreshAll()
        {
            SData.DataSource = null;
            SData.DataSource = logic.SData();
            StabilityLabel.Text = $"Стабильность: {logic.GetStability()}";
            SetupColumns();
        }
        private void SetupColumns()
        {
            if (SData.Columns.Count == 0) return;


            SData.Columns["Id"].HeaderText = "Id";
            SData.Columns["Name"].HeaderText = "Имя";
            SData.Columns["Transcendence"].HeaderText = "Трансцендентность";
            SData.Columns["Age"].HeaderText = "Возраст";
            SData.ScrollBars = ScrollBars.Vertical;

            foreach (DataGridViewColumn col in SData.Columns)
            {
                col.Width = 150;
            }
        }


        private void Add_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Обзовите сущность:", "Добавление");
            if (name == "")
            {
                MessageBox.Show("Имя не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            logic.Add(name);
            RefreshAll();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {

            RefreshAll();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string answer = Interaction.InputBox("Кто вам не угодил? (Id)", "Испарение");
            if (!int.TryParse(answer, out int answer2) || answer == "")
            {
                MessageBox.Show("Id не может содержать буквы или быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            logic.Evaporate(Convert.ToInt32(answer));
            RefreshAll();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string answer = Interaction.InputBox("Кому поменять имя? (Id)", "Изменение");
            if (!int.TryParse(answer, out int answer2) || answer == "")
            {
                MessageBox.Show("Id не может содержать буквы или быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string New_Name = Interaction.InputBox("Какое имя?", "Изменение");
            if (New_Name == "")
            {
                MessageBox.Show("Имя не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            logic.Edit(Convert.ToInt32(answer), New_Name);
            RefreshAll();
        }

        private void Rift_Click(object sender, EventArgs e)
        {
            if (logic.SData().Count == 0)
            {
                MessageBox.Show("", "Пустота", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
            }
            else
            {
                logic.Rift();
                RefreshAll();
                MessageBox.Show("Разлом создан успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }

        private void Stabilization_Click(object sender, EventArgs e)
        {
            if (logic.SData().Count == 0)
            {
                MessageBox.Show("", "Пустота", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                logic.Stabilize();
                RefreshAll();
                MessageBox.Show("Стабилизация прошла успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
