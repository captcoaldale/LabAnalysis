using System;
using ExcelMigrator.DataObjects;
using System.Drawing;
using System.Windows.Forms;

namespace LabAnalysis
{
    public partial class Form1 : Form
    {
        private int clientID;
        private int sampleID;
        private int testID;

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
            InitializeControls(this.gbxTest);

            this.clientID = GetSelectedValue((ComboBox)sender);
            string query = "SELECT c.company_name, "
                  + "p.project_number, p.date_initiated,p.is_reported, p.project_notes, p.bill_cust, p.bill_cust_notes, "
                  + "o.objective_desc, "
                  + "y.project_type_desc, y.project_type_notes, "
                  + "f.field_desc, z.zone_desc, i.site_desc, l.land_desc, "
                  + "s.sample_pk, s.is_in_office, s.sample_notes, s.date_collected, s.date_received "
                  + "FROM tbl_project p "
                  + "INNER JOIN tbl_company c ON p.client_fk = c.company_pk "
                  + "inner join tbl_project_objective o on p.project_objective_fk = o.objective_pk "
                  + "inner join tbl_project_type y on p.project_type_fk = y.project_type_pk "
                  + "inner join tbl_project_sample s on s.project_fk = p.project_pk "
                  + "inner join tbl_location l on s.location_fk = l.location_pk "
                  + "inner join tbl_field f on l.field_fk = f.field_pk "
                  + "inner join tbl_zone z on l.zone_fk = z.zone_pk "
                  + "inner join tbl_site i on l.site_fk = i.site_pk "
                  + "WHERE p.client_fk = " + this.clientID;
            PopulateDataGridView(query,this.dgvSample);
        }

        private int GetSelectedValue(ComboBox cmb)
        {
            object sv = cmb.SelectedValue.ToString();
            return Convert.ToInt32(sv);
        }


        private void cmbClient_TextChanged(object sender, EventArgs e)
        {
            // get the keyword to search
            string textToSearch = cmbClient.Text.ToLower();
 
            if (String.IsNullOrEmpty(textToSearch))
                return; // return with listbox hidden if the keyword is empty
                        //search
            /*
             * string[] result = (from i in lbxClient.Items()
                               where i.ToLower().Contains(textToSearch)
                               select i).ToArray();
            if (result.Length == 0)
                return; // return with listbox hidden if nothing found
            */
            //lbxClient.Items.Clear(); // remember to Clear before Add
            //lbxClient.Items.AddRange(result);
           // lbxClient.Visible = true; // show the listbox again
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
                        case "cmbMethod":
                            query = "SELECT test_method_pk, Concat(acronym, ' - ', method_desc) as display FROM tbl_test_method";
                            value = "test_method_pk";
                            display = "display";
                            prompt = "Select Method";
                            break;
                        default:
                            break;
                    }
                    if (!string.IsNullOrEmpty(query))
                    {
                        // prevent error (unset data) ...
                        cmb.DataSource = null;
                        MySQL_Connection conn = new MySQL_Connection();
                        //Create a binding source
                        conn.OpenConnection();
                        BindingSource bindingSource = new BindingSource(conn.DataTableGet(query), null);
                        conn.CloseConnection();
                        // set properties
                        cmb.Items.Insert(0, prompt);
                        cmb.ForeColor = Color.Gray;
                        cmb.DisplayMember = display;
                        cmb.ValueMember = value;
                        cmb.DataSource = bindingSource;
                        cmb.SelectedIndex = 0;
                        cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        cmb.AutoCompleteSource = AutoCompleteSource.ListItems;

                        if (ctl is DataGridView)
                        {
                            DataGridView dgv = (DataGridView)ctl;
                            dgv.DataSource = null;
                        }
                    }
                }
            }
        }

        private void PopulateDataGridView(string query, DataGridView dgv)
        {
            MySQL_Connection conn = new MySQL_Connection();
            //Create a binding source
            conn.OpenConnection();
            BindingSource bindingSource = new BindingSource(conn.DataTableGet(query), null);
            conn.CloseConnection();
            dgv.DataSource = bindingSource;
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("TestMethod changed.");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void dgvSample_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbxSample_Enter(object sender, EventArgs e)
        {

        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvSample_SelectionChanged(object sender, EventArgs eventArgs)
        {
           // MessageBox.Show("Sample Changed");
        }

        private void dgvSample_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            dgvSample.CurrentRow.Selected = true;
            object val = dgvSample.Rows[e.RowIndex].Cells["sample_pk"].FormattedValue.ToString();
            this.sampleID = Convert.ToInt32(val);
            string query = "select element_desc,value1, u1.unit_desc as unit_1_desc,value2, u2.unit_desc as unit_2_desc " +
                "from tbl_test_item " +
                "inner join tbl_project_test on test_fk = tbl_project_test.test_pk " +
                "inner join tbl_method_item on method_item_fk = tbl_method_item.method_item_pk " +
                "inner join tbl_element on element_fk = tbl_element.element_pk "+
                "inner join tbl_unit u1 on unit_1_fk = u1.unit_pk " +
                "inner join tbl_unit u2 on unit_2_fk = u2.unit_pk " +
                "inner join tbl_project_sample on sample_fk = sample_pk " +
                "where sample_fk = " + this.sampleID;
            PopulateDataGridView(query, dgvTestItems);
            // retrieve test_fk ...
            MySQL_Connection conn = new MySQL_Connection();
            conn.OpenConnection();
            query = "select test_pk from tbl_project_test where sample_fk = " + sampleID;
            this.testID = conn.DataGet( query);
            // fill dgvParameters
            query = "select test_fk, method_item, value1, u.unit_desc " +
                "from tbl_test_item " +
                "inner join tbl_project_test on test_fk = tbl_project_test.test_pk " +
                "inner join tbl_method_item on method_item_fk = tbl_method_item.method_item_pk " +
                "inner join tbl_unit u on unit_1_fk = u.unit_pk " +
                "where (method_item_fk <> 16 && method_item_fk <> 28) && test_fk = " + this.testID;
            PopulateDataGridView(query, dgvParameters);
            // fill dgvTotals
            query = "select method_item, element_desc, value1, u.unit_desc from tbl_test_item " +
                "inner join tbl_project_test on test_fk = tbl_project_test.test_pk " +
                "inner join tbl_method_item on method_item_fk = tbl_method_item.method_item_pk " +
                "inner join tbl_element on element_fk = tbl_element.element_pk " +
                "inner join tbl_unit u on unit_1_fk = u.unit_pk " +
                "where (method_item_fk = 28) && test_fk = " + this.testID;
            PopulateDataGridView(query, dgvTotals);
            // populate dtps and cmbMethod
            query = "select method_fk from tbl_project_test where test_pk = " + this.testID;
            cmbMethod.SelectedIndex = conn.DataGet(query);
            query = "select date_reported from tbl_project_test where test_pk = " + this.testID;
            DateTime dt = Convert.ToDateTime(conn.ValueGet(query));
            dtpEnd.Value  = dt;
            query = "select date_received from tbl_project_sample where sample_pk = " + this.sampleID;
            dtpBegin.Value = Convert.ToDateTime(conn.ValueGet(query));
            conn.CloseConnection();
        }

        private void dgvTestItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbxTest_Enter(object sender, EventArgs e)
        {

        }
    }
}