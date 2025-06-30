using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace student_registration_form
{
    public partial class Form1 : Form
    {
        public class Student
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Gender { get; set; }
            public string Department { get; set; }
        }
        // List to store student records
        private List<Student> students = new List<Student>();
        public Form1()
        {
            InitializeComponent();

        }

    // student id
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    // student name
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    // email
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    // phone number
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    // radio button male
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    // redio button female
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    // redio button other
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    // combo box 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // submit button
        private void button1_Click(object sender, EventArgs e)
        {
            //int studentID = Convert.ToInt32(textBox1.Text);
            //string name = textBox2.Text;
            //string email = textBox3.Text;
            //int phone = Convert.ToInt32(textBox4.Text);
            //string department = comboBox1.SelectedItem?.ToString() ?? "Not Selected";
            //string gender = "Not Selected";
            //if (radioButton1.Checked)
            //    gender = "Male";
            //else if (radioButton2.Checked)
            //    gender = "Female";
            //else if (radioButton3.Checked)
            //    gender = "Other";

            //string message = $"Student ID: {studentID}\n" +
            //                 $"Student Name: {name}\n" +
            //                 $"Email: {email}\n" +
            //                 $"Phone Number: {phone}\n" +
            //                 $"Gender: {gender}\n" +
            //                 $"Department: {department}\n\n" +
            //                 "Insert Data Successfully!";
            //// Display details in label
            //MessageBox.Show(message, "Confirmation", MessageBoxButtons.OK);
            if (ValidateInputs())
            {
                // Create a new student object
                Student student = new Student
                {
                    Name = textBox1.Text,
                    ID = textBox2.Text,
                    Email = textBox3.Text,
                    PhoneNumber = textBox4.Text,
                    Gender = gender(),
                    Department = comboBox1.SelectedItem?.ToString()
                };

                // Add to the list
                students.Add(student);

                // Show success message
                MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the form
                ClearForm();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No students registered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Create a new form to display student details
            Form detailsForm = new Form();
            detailsForm.Text = "Student Details";
            detailsForm.Size = new Size(800, 400);
            detailsForm.StartPosition = FormStartPosition.CenterParent;

            // Add a DataGridView to display student data
            DataGridView dataGridView = new DataGridView();
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoGenerateColumns = false;

            // Add columns
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                DataPropertyName = "Name",
                Width = 150
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "ID",
                Width = 100
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Phone",
                DataPropertyName = "PhoneNumber",
                Width = 120
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Gender",
                DataPropertyName = "Gender",
                Width = 80
            });
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Department",
                DataPropertyName = "Department",
                Width = 150
            });

            // Bind data
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = students;

            dataGridView.DataSource = bindingSource;

            detailsForm.Controls.Add(dataGridView);
            detailsForm.ShowDialog();
        }

        // all data clear button in table 
        private void button3_Click_1(object sender, EventArgs e)
        {
            // Confirm before clearing data
            var confirmResult = MessageBox.Show("Are you sure you want to clear all student records?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Clear the student list
                students.Clear();

                // Refresh the DataGridView
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Text == "Student Details")
                    {
                        foreach (Control control in form.Controls)
                        {
                            if (control is DataGridView dataGridView)
                            {
                                dataGridView.DataSource = null;
                                dataGridView.DataSource = students;
                            }
                        }
                    }
                }

                MessageBox.Show("All records have been cleared.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // select gender
        private string gender()
        {
            if (radioButton1.Checked)
                return "Male";
            else if (radioButton2.Checked)
                return "Female";
            else if (radioButton3.Checked)
                return "Other";
            return "";
        }

        private bool ValidateInputs()
        {
            // Check if name is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter Student Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            // Check if ID is empty
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter Student ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return false;
            }

            // Check if email is empty or invalid
            if (string.IsNullOrWhiteSpace(textBox3.Text) || !textBox3.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid Email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            // Check if phone is empty
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter Phone Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return false;
            }

            // Check if gender is selected
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Please select Gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if department is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return false;
            }

            return true;
        }


        // Clear all form fields
        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }
    }
}