using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_for_Felopater1
{
    public partial class Salary : Form
    {
        Functions con;
        public Salary()
        {
            InitializeComponent();

            con = new Functions();
            ShowSalaeries();
            GetEmployee();
        }
        private void ShowSalaeries()
        {
            string Query = "Select * from Salary";
            SalaryList.DataSource = con.GetData(Query);
        }
        private void GetEmployee()
        {
            string Query = "Select * from Employee";
            cbEmps.DisplayMember = con.GetData(Query).Columns["EmpName"].ToString();
            cbEmps.ValueMember = con.GetData(Query).Columns["EmpId"].ToString();
            cbEmps.DataSource = con.GetData(Query);

        }
        int Dsal = 0;
        string period = "";
        int d = 1;
        private void GetSalary()
        {
            string Query = "Select EmpSal from Employee where EmpId={0}";
            Query = string.Format(Query, cbEmps.SelectedValue.ToString());
            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                Dsal = Convert.ToInt32(dr["EmpSal"].ToString());
            }
            if (DAYS.Text == "")
            {
                SalAmount.Text = "Rs " + (d * Dsal);
            }
            else if (Convert.ToInt32(DAYS.Text) > 31)
            {
                MessageBox.Show("Days Can not Be Greater Than 31");
            }
            else
            {
                d = Convert.ToInt32(DAYS.Text);
                SalAmount.Text = "Rs " + (d * Dsal);

            }

        }
        int Key = 0;
        private void SalaryList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbEmps.SelectedValue = Convert.ToInt32(SalaryList.SelectedRows[0].Cells[1].Value.ToString());
            DAYS.Text = SalaryList.SelectedRows[0].Cells[2].Value.ToString();
            SalAmount.Text = SalaryList.SelectedRows[0].Cells[4].Value.ToString();


            if (cbEmps.SelectedIndex == -1)
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SalaryList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }