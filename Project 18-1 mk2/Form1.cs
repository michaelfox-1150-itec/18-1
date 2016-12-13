using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_18_1_mk2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void techniciansBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.techniciansBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.techSupportDataSet);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("A concurrency error occurred. " + "Some rows were not updated.",
                                "Concurrency Exception.");
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);
            }
            catch (DataException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
                techniciansBindingSource.CancelEdit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error # " + ex.Number + ": " + 
                                ex.Message, ex.GetType().ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'techSupportDataSet.Technicians' table. You can move, or remove it, as needed.
            try
            {
                this.techniciansTableAdapter.Fill(this.techSupportDataSet.Technicians);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error # " + ex.Number + ": " + 
                                ex.Message, ex.GetType().ToString());
            }
        }

        private void techniciansDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            //Form2 tech = new Form2();
            //tech.Show();
        }

        private void techniciansDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int row = e.RowIndex + 1;
            string errorMessage = "A data error occurred.\n" + "Row: " + row + "\n" + 
                                  "Error: " + e.Exception.Message;
            MessageBox.Show(errorMessage, "Data Error");
        }

       
    }
}
