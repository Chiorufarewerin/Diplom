using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager.ClassesTabs
{
    public partial class DBDesigner : Template
    {
        private DataBaseWork CurrentDB;
        public DBDesigner(string DBName)
        {
            this.CurrentDB = new DataBaseWork(DBName);
            InitializeComponent();
            SortingTypeBox.SelectedIndex = 0;
       
        }

        public void LoadData()
        {
            int ColWidth = ValuesGridView.Columns[0].Width;
            string sort = "";
            if (SortingTypeBox.SelectedIndex == 1)
                sort = "/A";
            else if(SortingTypeBox.SelectedIndex == 2)
                sort = "/D";
            
            DataTable table = CurrentDB.GetValues(sort, OtborBox.Text);
            ValuesGridView.AutoGenerateColumns = false;
            ValuesGridView.Columns[0].DataPropertyName = "Переменная";
            ValuesGridView.Columns[1].DataPropertyName = "Значение";
            ValuesGridView.DataSource = table;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SortingTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void OtborBox_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void WatchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string var = ValuesGridView.SelectedRows[0].Cells[0].Value.ToString();
                TabWatch.Watches.Add(new WatchVariable(var, CurrentDB));
                if (MainForm.Tabss.TabPages.ContainsKey("Слежение"))
                {
                    ((UpdateDataInterface)(MainForm.Tabss.TabPages["Слежение"])).UpdateData();
                    MainForm.Tabss.SelectedTab = (MainForm.Tabss.TabPages["Слежение"]);
                }
                else
                {
                    MainForm.thisForm.Watch_Click(null, null);
                }
            }
            catch { }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddVariable(CurrentDB).ShowDialog();
            LoadData();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            try
            {
                new AddVariable(CurrentDB, ValuesGridView.SelectedRows[0].Cells[0].Value.ToString()).ShowDialog();
                LoadData();
            }
            catch
            {
                MessageBox.Show("Выберите одну строку для изменения");
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in ValuesGridView.SelectedRows)
                {
                    if (Database.SendGetAnswer("USE " + CurrentDB.DataBaseName, "DEL " + ValuesGridView.SelectedRows[0].Cells[0].Value.ToString()).Info != Inf.OK)
                    {
                        MessageBox.Show("Нет доступа");
                    }

                }
                LoadData();
            }
            catch { }
        }
    }
}
