using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameRates.Data_Controller;

namespace GameRates
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();

            try
            {
                var ratesResult = AnswerDataController.LoadAnwerFromFile();

                dataGridView1.DataSource = ratesResult;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }
    }
}
