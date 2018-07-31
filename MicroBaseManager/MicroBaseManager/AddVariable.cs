using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroBaseManager
{
    public partial class AddVariable : Template
    {
        DataBaseWork database;
        DataTable values;
        public AddVariable(DataBaseWork database)
        {
            this.database = database;
            InitializeComponent();
            values = new DataTable();
            values.Columns.Add("Value");
            dataGridView1.DataSource = values;
        }

        public AddVariable(DataBaseWork database, string var)
        {
            this.database = database;
            VarBox.Text = var;
            VarBox.ReadOnly = true;
            this.Text = "Изменить переменную";
            InitializeComponent();
            values = new DataTable();
            values.Columns.Add("Value");
            dataGridView1.DataSource = values;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int addIndex = 0;
            if (dataGridView1.SelectedRows.Count > 0)
                addIndex = dataGridView1.SelectedRows[0].Index;
            else if (dataGridView1.CurrentCell != null)
                addIndex = dataGridView1.CurrentCell.RowIndex;
            values.Rows.InsertAt(values.NewRow(), addIndex);
            DataGridViewCell cell = dataGridView1.Rows[addIndex].Cells[0];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int addIndex = dataGridView1.Rows.Count;
            if (dataGridView1.SelectedRows.Count > 0)
                addIndex = dataGridView1.SelectedRows[0].Index + 1;
            else if (dataGridView1.CurrentCell != null)
                addIndex = dataGridView1.CurrentCell.RowIndex + 1;
            values.Rows.InsertAt(values.NewRow(), addIndex);
            DataGridViewCell cell = dataGridView1.Rows[addIndex].Cells[0];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            int addIndex = dataGridView1.Rows.Count - 1;
            if (dataGridView1.SelectedRows.Count > 0)
                addIndex = dataGridView1.SelectedRows[0].Index;
            else if (dataGridView1.CurrentCell != null)
                addIndex = dataGridView1.CurrentCell.RowIndex;
            DataGridViewCell cell = dataGridView1.Rows[addIndex].Cells[0];
            dataGridView1.CurrentCell = cell;
            dataGridView1.BeginEdit(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            int addIndex = dataGridView1.Rows.Count - 1;
            if (dataGridView1.SelectedRows.Count > 0)
                addIndex = dataGridView1.SelectedRows[0].Index;
            else if (dataGridView1.CurrentCell != null)
                addIndex = dataGridView1.CurrentCell.RowIndex;
            values.Rows.RemoveAt(addIndex);
            try
            {
                DataGridViewCell cell = dataGridView1.Rows[addIndex].Cells[0];
                dataGridView1.Rows[addIndex].Selected = true;
                dataGridView1.CurrentCell = cell;
            }
            catch (Exception)
            {
                try
                {
                    DataGridViewCell cell = dataGridView1.Rows[addIndex - 1].Cells[0];
                    dataGridView1.Rows[addIndex - 1].Selected = true;
                    dataGridView1.CurrentCell = cell;
                }
                catch (Exception)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Database.SendGetAnswer("USE " + database.DataBaseName, "DEL " + VarBox.Text).Info != Inf.OK)
            {
                MessageBox.Show("Нет доступа!");
                return;
            }
            foreach (DataRow row in values.Rows)
            {
                if(Database.SendGetAnswer("USE " + database.DataBaseName, "APPEND " + VarBox.Text+ " \""+row.ItemArray[0].ToString() +"\"").Info != Inf.OK){
                    MessageBox.Show("Нет доступа!");
                    return;
                }
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
