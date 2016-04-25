using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    List<DateTime> lstResult;
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GetResult();
    }

    private void GetResult()
    {
        DateTime SDate = clndStart.SelectedDate;
        DateTime EDate = clndEnd.SelectedDate;
        TimeSpan DateDiff = EDate.Subtract(SDate);
        int Month;
        if (EDate.Year == SDate.Year)
        {
            Month = EDate.Month - SDate.Month;
        }
        else
        {
            //((date1.Year - date2.Year) * 12) + date1.Month - date2.Month
            Month = ((EDate.Year - SDate.Year) * 12) + EDate.Month - SDate.Month;
        }

        lstResult = new List<DateTime>();

        DataTable dt = new DataTable();
        dt.Columns.Add("Id", System.Type.GetType("System.String"));
        dt.Columns.Add("Month", System.Type.GetType("System.String"));
        dt.Columns.Add("Year", System.Type.GetType("System.String"));

        for (int i = 0; i <= Month; i++)
        {
            DataRow dr = dt.NewRow();
            dr["Id"] = dt.Rows.Count + 1;
            dr["Month"] = SDate.AddMonths(i).ToString("MMM");
            dr["Year"] = SDate.ToString("yyyy");
            dt.Rows.Add(dr);
        }

        if (rbtnRepeated.Checked)
        {
            if (ddlRepeatedSecond.SelectedValue == "1" || ddlRepeatedSecond.SelectedValue == "7")
            {
                int Increment = Convert.ToInt32(ddlRepeatedFirst.SelectedValue);

                Increment = Increment * Convert.ToInt32(ddlRepeatedSecond.SelectedValue);
                for (int i = 0; i <= DateDiff.Days; i += Increment)
                {
                    lstResult.Add(SDate.AddDays(i));
                    //Result += SDate.AddDays(i).ToString() + "<br/>";
                }

                //for (int i = 0; i <= EDate.Month - SDate.Month; i++)
                //{
                //    DataRow dr = dt.NewRow();
                //    dr["Id"] = dt.Rows.Count + 1;
                //    dr["Month"] = SDate.AddMonths(i).ToString("MMM");
                //    dt.Rows.Add(dr);
                //}

                //rptResult.DataSource = dt;
                //rptResult.DataBind();
            }
            else
            {
                if (ddlRepeatedSecond.SelectedValue == "3")
                {
                    for (int i = 0; i <= Month; i = i + Convert.ToInt32(ddlRepeatedFirst.SelectedValue))
                    {
                        if (SDate.AddMonths(i) > EDate)
                            break;
                        lstResult.Add(SDate.AddMonths(i));
                        //Result += SDate.AddMonths(i).ToString() + "<br/>";
                    }

                    //for (int i = 0; i <= EDate.Month - SDate.Month; i++)
                    //{
                    //    DataRow dr = dt.NewRow();
                    //    dr["Id"] = dt.Rows.Count + 1;
                    //    dr["Month"] = SDate.AddMonths(i).ToString("MMM");
                    //    dt.Rows.Add(dr);
                    //}

                    //rptResult.DataSource = dt;
                    //rptResult.DataBind();
                }
                else
                {

                }
            }

            //if (ddlRepeatedSecond.SelectedValue == "1")
            //{
            //    for (int i = 0; i <= DateDiff.Days; i += Increment)
            //    {
            //        Result += SDate.AddDays(i).ToString() + "<br/>";
            //    }
            //    lblResult.Text = Result;
            //    for (int i = 0; i <= EDate.Month - SDate.Month; i++)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["Id"] = dt.Rows.Count + 1;
            //        dr["Month"] = SDate.AddMonths(i).ToString("MMM");
            //        dt.Rows.Add(dr);
            //    }

            //    rptResult.DataSource = dt;
            //    rptResult.DataBind();
            //}
            //else if (ddlRepeatedSecond.SelectedValue == "2")
            //{
            //    for (int i = 0; i <= DateDiff.Days; i = i + Increment)
            //    {
            //        Result += SDate.AddDays(i).ToString() + "<br/>";
            //    }
            //    lblResult.Text = Result;

            //    for (int i = 0; i <= EDate.Month - SDate.Month; i++)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["Id"] = dt.Rows.Count + 1;
            //        dr["Month"] = SDate.AddMonths(i).ToString("MMM");
            //        dt.Rows.Add(dr);
            //    }

            //    rptResult.DataSource = dt;
            //    rptResult.DataBind();
            //}

        }
        else if (rbtnRepeatedOn.Checked)
        {

            for (int i = 0; i <= Month; i++)
            {
                SDate = i > 0 ? SDate.AddMonths(Convert.ToInt32(ddlRepeatedOnThird.SelectedValue)) : SDate.AddMonths(0);
                if (SDate > EDate)
                    goto exit;
                for (int j = 0; j < DateTime.DaysInMonth(SDate.Year, SDate.Month); j++)
                {

                    if (SDate.Day > (7 * (Convert.ToInt32(ddlRepeatedOnFirst.SelectedValue) - 1)) && SDate.Day <= (7 * Convert.ToInt32(ddlRepeatedOnFirst.SelectedValue)) && Convert.ToInt32(SDate.DayOfWeek) == Convert.ToInt32(ddlRepeatedOnSecond.SelectedValue))
                    {
                        lstResult.Add(SDate);
                        //Result += SDate.ToString() + "<br/>";
                        SDate = SDate.AddDays(-j);
                        break;
                        //SDate = SDate.AddMonths(Convert.ToInt32(ddlRepeatedOnThird.SelectedValue));
                    }
                    else
                        SDate = SDate.AddDays(1);

                    if (SDate >= EDate)
                        goto exit;
                }


                //SDate.Day
            }
        exit: ;
            // lblResult.Text = Result;
            //DateTime.Now.DayOfWeek
            //SDate.Day

        }

        DLResult.DataSource = dt;
        DLResult.DataBind();
    }

    protected void clndStart_SelectionChanged(object sender, EventArgs e)
    {
        txtStartDate.Text = clndStart.SelectedDate.ToString();
    }
    protected void clndEnd_SelectionChanged(object sender, EventArgs e)
    {
        txtEndDate.Text = clndEnd.SelectedDate.ToString();
    }
}
