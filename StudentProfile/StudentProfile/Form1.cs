using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentProfile
{
    public partial class Form1 : Form
    {
        // Student class at sample data para sa search feature
        public class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        private List<Student> studentList = new List<Student>()
        {
            new Student { Id = "001", Name = "Juan Dela Cruz" },
            new Student { Id = "002", Name = "Maria Santos" },
            new Student { Id = "003", Name = "Ruzzel Digno" }
        };

        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstResults;

        public Form1()
        {
            InitializeComponent();
            InitializeSearchUI(); // Tawagin ito para awtomatikong lumitaw ang mga search controls sa form
        }

        private void InitializeSearchUI()
        {
            txtSearch = new TextBox() { Location = new Point(20, 20), Width = 150 };
            btnSearch = new Button() { Location = new Point(180, 20), Text = "Search", Width = 75 };
            lstResults = new ListBox() { Location = new Point(20, 60), Width = 235, Height = 150 };

            btnSearch.Click += BtnSearch_Click;

            this.Controls.Add(txtSearch);
            this.Controls.Add(btnSearch);
            this.Controls.Add(lstResults);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var results = studentList.Where(s => s.Id.Contains(keyword) || s.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            lstResults.Items.Clear();
            if (results.Count > 0)
            {
                foreach (var r in results)
                {
                    lstResults.Items.Add($"{r.Id} - {r.Name}");
                }
            }
            else
            {
                MessageBox.Show("No student found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // updated contact number
        }
    }
}