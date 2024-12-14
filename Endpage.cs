using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ExamApplication
{

    // Endpage.cs
    public partial class Endpage : Form
    {
        int score;

        public Endpage(int finalScore)  // Constructor that accepts the score
        {
            InitializeComponent();
            score = finalScore;  // Store the passed score
        }

        private void Endpage_Load(object sender, EventArgs e)
        {
            MessageBox.Show(score.ToString());  // Check if score is being passed
        }

        private void button1_Click(object sender, EventArgs e)
        {

           Application.Exit();
        }
    }
}
