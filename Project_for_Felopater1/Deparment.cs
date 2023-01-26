﻿using System;
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
    public partial class Deparment : Form
    {
        Functions con;
        public Deparment()
        {
            InitializeComponent();
            con = new Functions();
            ShowDepartmentList();
        }
        private void ShowDepartmentList()
    }
    string Query = "Select * from Department";
    DeptList.DataSource = con.GetData(Query);
}
private void AddBtn_Click(object sender, EventArgs e)
{
    try
    {
        if (DeptName.Text == "")
        {
            MessageBox.Show("Missing Data !!!");
        }
        else
        {
            string Query = "insert into Department values('{0}')";
            Query = string.Format(Query, DeptName.Text);
            con.SetData(Query);
            ShowDepartmentList();
            MessageBox.Show("Department Added!!!");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}
int key = 0;
private void DeptList_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    DeptName.Text = DeptList.SelectedRows[0].Cells[1].Value.ToString();
    if (DeptName.Text == "") 
    {
        key = 0;
    }
}
private void EditBtn_Click(object sender, EventArgs e)
{
    try
    {
        if (DeptName.Text == "")
        {
            MessageBox.Show("Missing Data !!!");
        }
        else
        {