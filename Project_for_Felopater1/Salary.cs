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
