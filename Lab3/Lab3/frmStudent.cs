using System;
using System.Windows.Forms;
using System.IO;
using Lab3.util;
using Lab3.dto;
using System.Collections.Generic;
using Lab3.dao;
using System.Text.RegularExpressions;

namespace StudentForm
{
    public partial class frmStudent : Form
    {
        StudentManager sm = null;
        List<Student> listTmp = null;
        bool showSearch = false;
        int amountList = 0;
        int selectedRow = -1;
        public frmStudent()
        {           
            InitializeComponent();
            sm = new StudentManager();
            txtID.Enabled = false;
        }
        bool ValidateInput()
        {
            bool bError = false;
            string id = txtID.Text.Trim();
            if (sm.FindStudent(id) && !flag || !Regex.IsMatch(id, "^\\d{3}$"))
            {
                errorProvider1.SetError(txtID, "Please enter ID, just 3-digits number only, please make sure it did not exist: ");
                bError = true;
            }
            string name = txtFullName.Text.Trim();
            
            if (!Regex.IsMatch(name,"^[\\s a-zA-Z ]{2,30}$"))
            {
                errorProvider1.SetError(txtFullName, "Please enter your name (just characters, from 2 to 30)!");
                bError = true;
            }
            DateTime currDate = DateTime.Now;
            int ageLimit = 18;
            int currYear = currDate.Year;
            DateTime DateofBirth = dTPDOB.Value;
            int birthYear = DateofBirth.Year;
            if (currYear - birthYear < ageLimit)
            {
                errorProvider1.SetError(dTPDOB,
                    "Age must be greater than or equal to " +  ageLimit);
                bError = true;
            }
            if (radMale.Checked == false && radFemale.Checked == false)
            {
                errorProvider1.SetError(groupBox1, "Please select gender!");
                bError = true;
            }
            if (mtxtPhone.MaskCompleted == false)
            {
                errorProvider1.SetError(mtxtPhone,
                    "please enter required digit!");
                bError = true;
            }
            if (cbNational.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbNational,
                    "please select National!");
                bError = true;
            }
            if (bError == true)
            {
                return false;
            }
            else
                errorProvider1.Clear();
            return true;
        }
        
        private void BtnNew_Click(object sender, EventArgs e)
        {
            //reset
            txtID.Clear();
            txtFullName.Clear();
            txtAddress.Clear();
            mtxtPhone.Clear();
            dTPDOB.Value = DateTime.Now;
            radFemale.Checked = false;
            radMale.Checked = false;
            cbNational.SelectedIndex = -1;
            cbMajor.SelectedIndex = -1;
            //Active/Deactive
            BtnAdd.Enabled = true;
            txtID.Enabled = true;          
            selectedRow = -1;
        }

       
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }                
            AddNewStudent();
            BtnAdd.Enabled = false;
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchbyName();
        }
        void SearchbyName()
        {
            FrmSearchResult frm = new FrmSearchResult();
            for (int i = 0; i < dgStudent.Rows.Count; i++)
            {
                DataGridViewRow r = dgStudent.Rows[i];
                if (r.Cells[1].Value.ToString().IndexOf(txtName.Text) > -1)
                {
                    frm.AddStudentInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(), r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString());
                }
            }
            frm.ShowDialog();
        }
        private void BtnFilter_Click(object sender, EventArgs e)
        {
            FrmSearchResult frm = new FrmSearchResult();
            for (int i = 0; i < dgStudent.Rows.Count; i++)
            {
                DataGridViewRow r = dgStudent.Rows[i];
                if (r.Cells[4].Value.ToString().Equals(cbNationalFilter.Text))
                {
                    frm.AddStudentInfo(r.Cells[0].Value.ToString(),
                    r.Cells[1].Value.ToString(), r.Cells[2].Value.ToString(),
                    r.Cells[3].Value.ToString(), r.Cells[4].Value.ToString(),
                    r.Cells[5].Value.ToString(), r.Cells[6].Value.ToString(),
                    r.Cells[7].Value.ToString());
                }
            }
            frm.ShowDialog();
        }
        private void BtnSavetoFile_Click(object sender, EventArgs e)
        {
            if(listTmp == null)
            {
                return;
            }
            if (sm.AddNewStudents(listTmp))
            {
                MessageBox.Show("Saved!!!");
                LoadTable();
                listTmp = null;
                txtID.Enabled = false;
            }                
            else
                MessageBox.Show("Can not save new students , try again");
          
        }
        void AddNewStudent()
        {
            if (listTmp == null)
            {
                listTmp = new List<Student>();
            }
            ////Fullname;DOB;gender;national;phone;address; Qualification; Salary
            string id = txtID.Text;
            string name = txtFullName.Text;
            string dob = dTPDOB.Text;
            string gender = radFemale.Checked ? "Female" : "Male";
            string national = cbNational.Text;
            string phone = mtxtPhone.Text;
            string address = txtAddress.Text;
            string major = cbMajor.Text;
            Student s = new Student(id, name, dob, gender, national, phone, address, major);
            amountList = listTmp.Count;
            listTmp.Add(s);

            if (listTmp.Count > amountList)
            {
                MessageBox.Show("Added!!!");
            }
            else
                MessageBox.Show("Can not add to list");
        }
        private void BtnLoadfromFile_Click(object sender, EventArgs e)
        {
            LoadTable();
        }
        void LoadTable()
        {
            List<Student> list = sm.LoadData();           
            if(list != null)
            {
                if (dgStudent.Rows.Count > 0)
                    dgStudent.Rows.Clear();
                foreach (Student s in list)
                {
                    //Fullname;DOB;gender;national;phone;address; Qualification; Salary
                    string[] infor = {s.GetId(), s.GetFullname(), s.GetDob(), s.GetGender(), s.GetNational(),
                s.GetPhone(),
                s.GetAddress(),
                s.GetMajor()};
                    dgStudent.Rows.Add(infor);
                }

            }            
        }
        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            pnSearchOptions.Visible = showSearch;
            showSearch = !showSearch;
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            
        }

        private void dgStudentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void cbNational_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRow > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete information of " + txtID.Text + " ?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    dgStudent.Rows.RemoveAt(selectedRow);
                    if (sm.DeleteStudent(txtID.Text))
                    {
                        MessageBox.Show("Done!!!");
                    }
                }
               
            }
        }
        bool flag = false;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            flag = true;
            if(selectedRow > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure to save new information of "+ txtID.Text +" ?", "Update Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (ValidateInput())
                    {
                        AddNewStudent();
                        sm.UpdateStudentInfor(txtID.Text, listTmp);
                        listTmp = null;
                        flag = false;
                    }                    
                    
                }
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dgStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (selectedRow > -1)
            {
                DataGridViewRow row = this.dgStudent.Rows[selectedRow];
                txtID.Text = row.Cells[0].Value.ToString();
                txtFullName.Text = row.Cells[1].Value.ToString();
                dTPDOB.Text = row.Cells[2].Value.ToString();
                string gender = row.Cells[3].Value.ToString();
                if (gender.Equals("Female"))
                {
                   
                    radFemale.Checked = true;
                    radMale.Checked = false;
                }
                else
                {
                    radFemale.Checked = false;
                    radMale.Checked = true;
                }
                cbNational.Text = row.Cells[4].Value.ToString();
                mtxtPhone.Text = row.Cells[5].Value.ToString();
                txtAddress.Text = row.Cells[6].Value.ToString();
                cbMajor.Text = row.Cells[7].Value.ToString();
            }
        }

        private void frmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to close this form? Please saving information carefully before leaving.", "Close form Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = (result == DialogResult.No) ;
            }
        }

        private void radMale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
