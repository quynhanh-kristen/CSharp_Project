using System;
using System.Windows.Forms;

namespace StudentForm
{
    public partial class FrmSearchResult : Form
    {
        public FrmSearchResult()
        {
            InitializeComponent();
        }

        public void AddStudentInfo(params String[] values)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(gvStudents);
            for (int i = 0; i < r.Cells.Count; i++)
            {               
                r.Cells[i].Value = values[i];
            }
            gvStudents.Rows.Add(r);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
