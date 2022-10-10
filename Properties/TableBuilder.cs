using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Windows.Forms;

namespace ExcelMigrator.DataObjects
{
    public class TableBuilder
    {
        private Worksheet wks;
        private string coordinates; // range coordinates
        private string extension; // 2nd range coordinates
        public System.Data.DataTable tbl;

        public TableBuilder(Worksheet wks, string coordinates = "", string extension = "") // add a second range if needed ...
        {
            this.wks = wks;
            this.coordinates = coordinates;
            this.extension = extension;
        }

        public System.Data.DataTable BuildField()
        {
            System.Data.DataTable tbl = new System.Data.DataTable();
            int count = 0;
            double d = 0;
            Range cell = wks.Range[coordinates];
            DataRow firstRow = tbl.NewRow();

            foreach (object result in cell.Value) // get the columns 
            {
                if (result == null)
                    continue;
                if (!double.TryParse(result.ToString(), out d)) // strip out the number values
                {
                    tbl.Columns.Add(result.ToString());
                }
            }
            cell = wks.Range[this.extension];
            foreach (object result in cell.Value) // get numbers and store in d 
            {
                if (result == null)
                    continue;
                if (double.TryParse(result.ToString(), out d)) // test for a number and store in d 
                {
                    firstRow[count++] = d;
                }
            }
            tbl.Rows.InsertAt(firstRow, 0); // add the numeric values ...
            return tbl;
        }

        public System.Data.DataTable BuildTwoColumn() // we're building a two-row table: description/value eg (temp, 19)
        {
            tbl = new System.Data.DataTable();
            double d = 0;
            int count = 1;
            Range cell = wks.Range[this.coordinates];
            DataRow row = tbl.NewRow();

            tbl.Columns.Add("Description", typeof(string));
            tbl.Columns.Add("Value", typeof(double));

            foreach (object result in cell.Value) // get numbers and store in d 
            {
                if (result == null)
                    continue;
                if (double.TryParse(result.ToString(), out d)) // test for a number and store in d 
                {
                    row[1] = d;
                }
                else if (result.ToString() == "-")
                {
                    row[1] = 0.0;
                }
                else
                {
                    row[0] = result.ToString();
                }
                // add the row when both row values are present (description + value) on every 2nd iteration ...
                // modulus yields the remainder eg 2/3 = .6; 2%3 = 1 (remember "=" assigns a value, "==" compares the values [is equal to ...])
                if (count++ % 2 == 0)
                {
                    tbl.Rows.Add(row); // add the row
                    row = tbl.NewRow();
                }
            }
            return tbl;
        }

        public System.Data.DataTable BuildThreeColumn()
        {
            int count = 0;
            double d = 0;
            string lower_than_detection = "<LOD";

            tbl = new System.Data.DataTable();
            DataRow row = tbl.NewRow();
            Range cell;
            tbl.Columns.Add("Ion", typeof(string));
            tbl.Columns.Add("mg/L", typeof(double));
            tbl.Columns.Add("meq/L", typeof(double));
            string coords = this.coordinates;

            for (int i = 0; i < 3; i++) //outer loops for soluables...
            {
                if (i == 0 && coords.Length > 0) // we have a range, so head to the inner loop.
                    break;
                else
                    switch (i)
                    {
                        case 0:
                            coords = "I20:L29";
                            break;
                        case 1:
                            coords = "N20:P29";
                            break;
                        case 2:
                            coords = "Q20:T27";
                            break;
                    }

                cell = wks.Range[coords];

                foreach (object result in cell.Value) // get the columns 
                {
                    if (result == null)
                        continue;
                    switch (count)
                    {
                        case 0:
                            if (result.ToString() != lower_than_detection)
                                row[0] = result.ToString(); // add the ion name
                            break;
                        case 1:
                            if (double.TryParse(result.ToString(), out d)) // add the first value
                                row[1] = d;
                            else if (result.ToString() == lower_than_detection)
                                row[1] = -.001; // ltd flag MUST HAVE a double value
                            break;
                        case 2:
                            if (double.TryParse(result.ToString(), out d)) // add the 2nd value
                                row[2] = d;
                            else if (result.ToString() == lower_than_detection)
                                row[2] = -.001; // ltd flag
                            break;
                    }

                    if (count == 2) // i.e. end of the  row ...
                    {
                        tbl.Rows.Add(row); // add the row (element, value1, value2)...
                        row = tbl.NewRow(); // add the new row for the next iteration...
                    }
                    if (++count > 2) // clamp count between 0 and 2 ...
                        count = 0;
                    else if (count < 0)
                        count = 2;
                }
            }
            return tbl;
        }
        public System.Data.DataTable BuildSaturationIndex()
        {
            tbl = new System.Data.DataTable();
            DataRow row = tbl.NewRow();

            tbl.Columns.Add("Press", typeof(double));
            tbl.Columns.Add("Temp", typeof(double));
            tbl.Columns.Add("Anhyd-SI", typeof(double));
            tbl.Columns.Add("Anhyd-mg/L", typeof(double));
            tbl.Columns.Add("Gyp-SI", typeof(double));
            tbl.Columns.Add("Gyp-mg/L", typeof(double));
            tbl.Columns.Add("Barite-SI", typeof(double));
            tbl.Columns.Add("Barite- mg/L", typeof(double));
            tbl.Columns.Add("Calcite-SI", typeof(double));
            tbl.Columns.Add("Calcite-mg/L", typeof(double));
            tbl.Columns.Add("Siderite-SI", typeof(double));
            tbl.Columns.Add("Siderite-mg/L", typeof(double));
            tbl.Columns.Add("Iron Sulfide-SI", typeof(double));
            tbl.Columns.Add("Iron Sulfide-mg/L", typeof(double));
            tbl.Columns.Add("Halite-SI", typeof(double));
            tbl.Columns.Add("Halite-mg/L", typeof(double));
            tbl.Columns.Add("Fe-Si-SI", typeof(double));
            tbl.Columns.Add("Fe-Si-mg/L", typeof(double));
            tbl.Columns.Add("Mg-Si-SI", typeof(double));
            tbl.Columns.Add("Mg-Si-mg/L", typeof(double));
            tbl.Columns.Add("Si-O2-SI", typeof(double));
            tbl.Columns.Add("Si-O2-mg/L", typeof(double));

            string coords = this.coordinates;
            double d = 0;
            int count = 0;
            for (int i = 0; i <= 8; i++) // get eight rows ...
            {
                coords = "C4" + i + ":W4" + i;  // "C40:W40"
                Range cell = wks.Range[coords]; // loop the rows ...
                count = cell.Columns.Count;
                for (int j = 0; j < count; j++)  // ++ = increment j after the loop begins ...
                {
                    foreach (object result in cell.Value) // loop the columns...
                    {
                        if (result != null)
                            row[++j] = double.TryParse(result.ToString(), out d) ? d : Double.NaN; // ++ = first increment j, then add the value ...
                    }
                }
                tbl.Rows.Add(row); // add the row ...
                row = tbl.NewRow(); // add blank row for the next iteration...
            }
            return tbl;
        }
        public System.Data.DataTable BuildTwoRow()
        {
            tbl = new System.Data.DataTable();
            string coords = this.coordinates;
            // string extension = this.extension; thought we could make the columns from the range data. Later ??
            double d = 0;
            int j = 0;
            DataRow row = tbl.NewRow();
            Range cell = wks.Range[this.coordinates];
            tbl.Columns.Add("Pressure-bar", typeof(double));
            tbl.Columns.Add("Temperature-oC", typeof(double));
            tbl.Columns.Add("CO2 in brine-mg/L", typeof(double));
            tbl.Columns.Add("CO2 in gas (cal.)-%", typeof(double));
            tbl.Columns.Add("H2S in brine-mg/L", typeof(double));
            tbl.Columns.Add("Corrosion-mmy", typeof(double));
            tbl.Columns.Add("Corrosion-mpy", typeof(double));
            tbl.Columns.Add("Contribution (%)-CO2", typeof(double));
            tbl.Columns.Add("Contribution (%)-H2S", typeof(double));
            tbl.Columns.Add("Contribution (%)-H2O", typeof(double));
            tbl.Columns.Add("Contribution (%)-pH", typeof(double));

            cell = wks.Range[this.coordinates]; // loop the rows // "C65:V67" ...
            foreach (object result in cell.Value) // numbers...
            {
                if (result != null)
                {
                    if (double.TryParse(result.ToString(), out d)) // add value
                        row[j++] = double.TryParse(result.ToString(), out d) ? d : 0; // ++ = first increment j, then add the value ... Also default to Not A Number ( Double.NaN )
                }
            } 
            tbl.Rows.Add(row); // add the row ...
            return tbl;
        }
    }
}