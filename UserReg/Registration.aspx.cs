using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UserRegistration
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string curFile = @"c:\test\UserData.txt";
            if (!File.Exists(curFile))
            { // Create a file to write to   
                using (StreamWriter sw = File.CreateText(curFile))
                {
                }
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] {new DataColumn("Member ID"),
                                        new DataColumn("First Name"),
                                        new DataColumn("Last Name"),
                                        new DataColumn("Email")});
            using (System.IO.TextReader tr = File.OpenText(curFile))
            {
                string line;
                while ((line = tr.ReadLine()) != null)
                {
                    string[] items = line.Trim().Split(' ');
                    if (dt.Columns.Count < items.Length)
                    {
                        // Create the data columns for the data table based on the number of items
                        // on the first line of the file
                        for (int i = dt.Columns.Count; i < items.Length; i++)
                            dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                    }
                    dt.Rows.Add(items);

                }
                  //show it in gridview 
                    this.grdData.DataSource = dt;
                    this.grdData.DataBind();
               
            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (this.txtfirstname.Text != "" && this.txtlastname.Text != "" && this.txtemail.Text != "")
            {
                string curFile = @"c:\test\UserData.txt";
                string[] list = File.ReadAllLines(curFile);
                bool idPresent = false;
                for (int i = 0; i < list.Length; i++)
                {
                    if (string.Equals(list[i].Split(' ')[0], this.txtid.Text))
                    {
                        list[i] = this.txtid.Text + " " + this.txtfirstname.Text + " " + this.txtlastname.Text + " " + this.txtemail.Text + " ";
                        idPresent = true;
                    }
                }
                if (!idPresent)
                {
                    using (StreamWriter sw = File.AppendText(curFile))
                    {
                        sw.Write(this.txtid.Text + " ");
                        sw.Write(this.txtfirstname.Text + " ");
                        sw.Write(this.txtlastname.Text + " ");
                        sw.WriteLine(this.txtemail.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Member " + this.txtid.Text + " Already Exists", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Page_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Please enter all the Details", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtfirstname.Text != "" && this.txtlastname.Text != "" && this.txtemail.Text != "")
            {
                string curFile = @"c:\test\UserData.txt";
                string[] list = File.ReadAllLines(curFile);
                bool idPresent = false;
                for (int i = 0; i < list.Length; i++)
                {
                    if (string.Equals(list[i].Split(' ')[0], this.txtid.Text))
                    {
                        list[i] = this.txtid.Text + " " + this.txtfirstname.Text + " " + this.txtlastname.Text + " " + this.txtemail.Text + " ";
                        idPresent = true;
                    }
                }
                if (idPresent)
                {
                    UpdatingFile(curFile, list);
                }
                else
                {
                    MessageBox.Show("Member " + this.txtid.Text + " Does Not Exist", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Page_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Please enter all the Details", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdatingFile(String curFile, string[] list)
        {
            File.Delete(curFile);
            if (!File.Exists(curFile))
            { // Create a file to write to   
                using (StreamWriter sw = File.CreateText(curFile))
                {
                }
            }
            foreach (var i in list)
            {
                using (StreamWriter sw = File.AppendText(curFile))
                {
                    string[] newList = i.Split(' ');
                    sw.Write(newList[0] + " ");
                    sw.Write(newList[1] + " ");
                    sw.Write(newList[2] + " ");
                    sw.WriteLine(newList[3]);
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string curFile = @"c:\test\UserData.txt";
            string[] list = File.ReadAllLines(curFile);
            int removeIndex = 0;
            bool idPresent = false;
            for (int i = 0; i < list.Length; i++)
            {
                if (string.Equals(list[i].Split(' ')[0], this.txtid.Text))
                {
                    removeIndex = i;
                    idPresent = true;
                }
            }
            if (idPresent)
            {
                list = list.Where(x => x != list[removeIndex]).ToArray();
                UpdatingFile(curFile, list);
            }
            else
            {
                MessageBox.Show("Member " + this.txtid.Text + " Does Not Exist", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Page_Load(sender, e);
        }
    }
}