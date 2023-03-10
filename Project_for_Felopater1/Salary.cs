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
        private void Salary_Load(object sender, EventArgs e)
        {

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbEmps.SelectedIndex == -1 || DAYS.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    period = Pdate.Value.Date.ToString();
                    int Amount = Dsal * Convert.ToInt32(DAYS.Text);
                    int days = Convert.ToInt32(DAYS.Text);
                    string Query = "insert into Salary values({0},{1},'{2}',{3},'{4}')";
                    Query = string.Format(Query, Convert.ToInt32(cbEmps.SelectedValue.ToString()), days, period, Amount, DateTime.Today.Date);
                    con.SetData(Query);
                    ShowSalaeries();
                    MessageBox.Show("Salary is Paid !!");
                    cbEmps.SelectedIndex = -1; DAYS.Text = ""; SalAmount.Text = "";


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void cbEmps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetSalary();
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbEmps.SelectedIndex == -1 || DAYS.Text == "")
                {
                    MessageBox.Show("Missing Data !!!");
                }
                else
                {
                    period = Pdate.Value.Month.ToString() + "" + Pdate.Value.Year.ToString();
                    int Amount = Dsal * Convert.ToInt32(DAYS.Text);
                    int days = Convert.ToInt32(DAYS.Text);
                    string Query = "update Salary set Employee={0},Attendance={1},Period='{2}',Amount={3},PayDate='{4}' where SCode={5}";
                    Query = string.Format(Query, Convert.ToInt32(cbEmps.SelectedValue.ToString()), days, period, Amount, DateTime.Today.Date, Key);
                    con.SetData(Query);
                    ShowSalaeries();
                    MessageBox.Show("Salary is Updated !!");
                    cbEmps.SelectedIndex = -1; DAYS.Text = ""; SalAmount.Text = "";


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.Show();
            this.Hide();
        }
        private void label11_Click(object sender, EventArgs e)
        {
            Department dep = new Department();
            dep.Show();
            this.Hide();
        }
        private void cc_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();
        }
    }
}