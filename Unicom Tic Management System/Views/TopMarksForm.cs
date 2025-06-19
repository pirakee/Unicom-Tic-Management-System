using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unicom_Tic_Management_System.Repositories;

namespace Unicom_Tic_Management_System.Views
{
    public partial class TopMarksForm : Form
    {
        private readonly MarkRepository markRepo = new MarkRepository();

        public TopMarksForm()
        {
            InitializeComponent();
            LoadTopMarks();
        }

        private void LoadTopMarks()
        {
            try
            {
                //DataTable dt = markRepo.GetAllTopMarks();
                //dgvTopMarks.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading top marks: " + ex.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadTopMarks();
        }
    

        private void TopMarksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
