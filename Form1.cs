using System;
using ExcelMigrator.DataObjects;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAnalysis
{
    public partial class Form1 : Form
    {
        private int clientID;
        private int agentID;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeControls(this.gbxClient);
            this.FormClosing += new FormClosingEventHandler(Form1_Closing);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Determine if text has changed in the textbox by comparing to original text.
            /*
            if (textBox1.Text != strMyOriginalText)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
            */
            // cleanup, first release memory...
            System.Windows.Forms.Application.Exit();
        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbClient_TextChanged(object sender, EventArgs e)
        {
            // get the keyword to search
            string textToSearch = cmbClient.Text.ToLower();
            lbxClient.Visible = false; // hide the listbox, see below for why doing that
            if (String.IsNullOrEmpty(textToSearch))
                return; // return with listbox hidden if the keyword is empty
                        //search
            //string[] result = (from i in lbxClient.collection
            //                   where i.ToLower().Contains(textToSearch)
            //                   select i).ToArray();
            //if (result.Length == 0)
               // return; // return with listbox hidden if nothing found

            lbxClient.Items.Clear(); // remember to Clear before Add
            //lbxClient.Items.AddRange(result);
            lbxClient.Visible = true; // show the listbox again
        }
        private void InitializeControls(GroupBox gbx)
        {
            foreach (Control ctl in gbx.Controls)
            {
                if (ctl is ComboBox)
                {
                    string prompt = "";
                    string query = "";
                    string value = "";
                    string display = "";
                    ComboBox cmb = (ComboBox)ctl;
                    switch (cmb.Name)
                    {
                        case "cmbClient":
                            query = "SELECT company_pk, company_name FROM tbl_company WHERE is_client = true";
                            value = "company_pk";
                            display = "company_name";
                            prompt = "Select Client";
                            break;
                        case "cmbAgent":
                            query = "SELECT p.personnel_pk, concat(p.first_name,' ',p.last_name,' -- ',o.office_desc) " +
                                "AS display " +
                                "FROM tbl_personnel p " +
                                "INNER JOIN tbl_office o " +
                                "ON p.office_fk = o.office_pk " +
                                "WHERE p.function_fk = 5";
                            value = "personnel_pk";
                            display = "display";
                            prompt = "Select Agent";
                            break;
                        case "cmbProjectType":
                            query = "SELECT project_type_pk, project_type_desc " +
                                   "FROM tbl_project_type;";
                            value = "project_type_pk";
                            display = "project_type_desc";
                            prompt = "Select Project Type";
                            break;
                        case "cmbProject":
                            break;
                        case "cmbProjectObjective":
                            query = "SELECT objective_pk, objective_desc " +
                                  "FROM tbl_project_objective;";
                            value = "objective_pk";
                            display = "objective_desc";
                            prompt = "Select Project Objective";
                            break;
                        case "cmbPriorityRequested":
                            query = "SELECT priority_pk, priority_desc " +
                                  "FROM tbl_priority;";
                            value = "priority_pk";
                            display = "priority_desc";
                            prompt = "Select Project Priority";
                            break;
                        case "cmbPrice":
                            query = "SELECT price_pk, amount " +
                                  "FROM tbl_price;";
                            value = "price_pk";
                            display = "amount";
                            prompt = "Select Project Price";
                            break;
                        case "cmbTest":
                            query = "SELECT test_method_pk, " +
                                "concat(acronym,' -- ', method_desc) as display " +
                                 "FROM tbl_test_method;";
                            value = "test_method_pk";
                            display = "display";
                            prompt = "Select Project Test";
                            break;
                        case "cmbField":
                            query = "SELECT field_pk, field_desc " +
                                "FROM tbl_field;";
                            value = "field_pk";
                            display = "field_desc";
                            prompt = "Select Field";
                            break;
                        case "cmbZone":
                            query = "SELECT zone_pk, zone_desc " +
                                 "FROM tbl_zone";
                            value = "zone_pk";
                            display = "zone_desc";
                            prompt = "Select Zone";
                            break;
                        case "cmbDLS":
                            //query = "SELECT zone_pk, zone_desc " +
                            //  "FROM tbl_zone";
                            value = "zone_pk";
                            display = "zone_desc";
                            prompt = "Select Zone";
                            break;
                        case "cmbSite":
                            query = "SELECT site_pk, site_desc " +
                                "FROM tbl_site";
                            value = "site_pk";
                            display = "site_desc";
                            prompt = "Select Site";
                            break;
                        default:
                            break;

                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        MySQL_Connection conn = new MySQL_Connection();
                        //Create a binding source
                        conn.OpenConnection();
                        BindingSource bindingSource = new BindingSource(conn.DataTableGet(query), null);
                        conn.CloseConnection();
                        // set properties
                       cmb.Items.Insert( 0, prompt);
                        cmb.ForeColor = Color.Gray;
                        cmb.DisplayMember = display;
                        cmb.ValueMember = value;
                        cmb.DataSource = bindingSource;
                        cmb.SelectedIndex = 0;
                    }
                }

            }
        }
    }
}
