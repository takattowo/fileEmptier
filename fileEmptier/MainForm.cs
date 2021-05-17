using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fileEmptier
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string folder = fbd.SelectedPath;

            var rootFiles = Directory.GetFiles(folder);
            txtPath.Text = folder;

        }

        byte[] bytes = Encoding.ASCII.GetBytes("takaneko");
        bool isFaily = false;
        string[] filePaths = null;

        private void button2_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("Location is not selected.", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult rusure = MessageBox.Show("Are you sure you want to empty all the files in selected folder?", "Yes no question.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rusure == DialogResult.Yes)
            {
                try
                {
                    filePaths = Directory.GetFiles(txtPath.Text);
                }
                catch
                {
                    MessageBox.Show("The location is invalid!", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (string filePath in filePaths)
                {
                    try
                    {
                        File.WriteAllBytes(filePath, bytes);
                    } 
                    catch { isFaily = true; }
                }
            }
            else { return; }
            if (isFaily)
            {
                isFaily = false;
                MessageBox.Show("One or some of the files can not be emptied.", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
                MessageBox.Show("Successful~", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            isFaily = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPath.Text) || String.IsNullOrEmpty(txtTo.Text) || String.IsNullOrEmpty(txtFrom.Text))
            {
                MessageBox.Show("Field(s) missing.", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string to = txtTo.Text;
            string from = txtFrom.Text;

            DialogResult rusure = MessageBox.Show("Are you sure you want to replace the name of all the files in selected folder?", "Yes no question.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (rusure == DialogResult.Yes)
            {
                try
                {
                    filePaths = Directory.GetFiles(txtPath.Text);
                }
                catch
                {
                    MessageBox.Show("The location is invalid!", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach (string filePath in filePaths)
                {
                    try
                    {
                        System.IO.File.Move(filePath, filePath.Replace(from, to));
                    }
                    catch { isFaily = true; }
                }
            }
            else { return; }
            if (isFaily)
            {
                isFaily = false;
                MessageBox.Show("One or some of the files can not be renamed.", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                MessageBox.Show("Successful~", "Setence.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            isFaily = false;
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
