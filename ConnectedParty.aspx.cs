using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace ConnectedPartyForm
{
    
    public partial class ConnectedParty : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectedPartyConnectionString"].ConnectionString);

        public static class EmailBodyClass
        {
            public static string Emailbody { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_saveRelativeInfo_Click(object sender, EventArgs e)
        {
            conn.Open();
            string checkuser = "select count(*) from EmployeeInfo where Name='" + name.Text + "'";
            string updateSelfEmployed = "insert into RelativeInfo(r_name,r_relation,r_relativename,r_type,r_nature,r_jobTitle,r_stocks,r_countryofInc,r_additionalinfo,timestamp,emp_id) values(@r_entityname,@r_relation,@r_relativeName,@r_entitytype,@r_businesstype,@r_jobtitle,@r_shares,@r_countryofIncorportion,@r_additional,@timestamp,@temp)";
            string getuserid = "select id from EmployeeInfo where Name = '" + name.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (temp == 1)
            {
                //Response.Write("Employee record updated. Employee exists");
                cmd = new SqlCommand(getuserid, conn);
                temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                //update the relativeinfo table
                cmd = new SqlCommand(updateSelfEmployed, conn);
                cmd.Parameters.AddWithValue("@r_relativename", r_relativeName.Text);
                cmd.Parameters.AddWithValue("@r_relation", r_relation.Text);
                cmd.Parameters.AddWithValue("@r_entityname", r_entityName.Text);
                cmd.Parameters.AddWithValue("@r_entitytype", r_entityType.Text);
                cmd.Parameters.AddWithValue("@r_businesstype", r_businessType.Text);
                cmd.Parameters.AddWithValue("@r_jobtitle", r_jobTitle.Text);
                cmd.Parameters.AddWithValue("@r_shares", r_shares.Text);
                cmd.Parameters.AddWithValue("@r_countryofIncorportion", r_countryofIncorporation.Text);
                cmd.Parameters.AddWithValue("@r_additional", r_additional.Text);
                cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@temp", temp);
                cmd.ExecuteNonQuery();

                conn.Close();

               Response.Write("Relative Information submitted successfully!");

            }

            else

            try
            {
                //conn.Open();
                string insertQuery = "insert into EmployeeInfo(Name,JobTitle,Department,IsConnected,timestamp,email)values (@name,@title,@department,@isconnected,@timestamp,@email)";
                cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@title", title.Text);
                cmd.Parameters.AddWithValue("@department", department.Text);
                cmd.Parameters.AddWithValue("@isconnected", "Yes");
                cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@email", emailaddress.Text);
                cmd.ExecuteNonQuery();

                    //get the userid of the previous entry
                    cmd = new SqlCommand(getuserid, conn);
                    temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    //update the relativeinfo table
                    cmd = new SqlCommand(updateSelfEmployed, conn);
                    cmd.Parameters.AddWithValue("@r_relativename", r_relativeName.Text);
                    cmd.Parameters.AddWithValue("@r_relation", r_relation.Text);
                    cmd.Parameters.AddWithValue("@r_entityname", r_entityName.Text);
                    cmd.Parameters.AddWithValue("@r_entitytype", r_entityType.Text);
                    cmd.Parameters.AddWithValue("@r_businesstype", r_businessType.Text);
                    cmd.Parameters.AddWithValue("@r_jobtitle", r_jobTitle.Text);
                    cmd.Parameters.AddWithValue("@r_shares", r_shares.Text);
                    cmd.Parameters.AddWithValue("@r_countryofIncorportion", r_countryofIncorporation.Text);
                    cmd.Parameters.AddWithValue("@r_additional", r_additional.Text);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@temp", temp);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("Relative Information submitted successfully!");

                conn.Close();

            }
            catch (Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

            EmailBodyClass.Emailbody = String.Format(EmailBodyClass.Emailbody + "\r\n \r\n    Relative Name : {0} \r\n    Relation : {1} \r\n    Entity Name : {2} \r\n    Entity Type : {3} \r\n    Business Type : {4} \r\n    Job Title : {5} \r\n    Shares : {6} \r\n    Country of Incorporation : {7} \r\n    Additional Information : {8} \r\n", r_relativeName.Text, r_relation.Text, r_entityName.Text, r_entityType.Text, r_businessType.Text, r_jobTitle.Text, r_shares.Text, r_countryofIncorporation.Text, r_additional.Text);
           
            r_relativeName.Text = "";
            r_additional.Text = "";
            r_businessType.Text = "";
            r_countryofIncorporation.Text = "";
            r_entityName.Text = "";
            r_entityType.Text = "";
            r_jobTitle.Text = "";
            r_shares.Text = "";

        }

        protected void btn_saveSE_Click(object sender, EventArgs e)
        {
            conn.Open();
            string checkuser = "select count(*) from EmployeeInfo where Name='" + name.Text + "'";
            string updateSelfEmployed = "insert into SelfEmployed(se_name,se_type,se_nature,se_jobTitle,se_stocks,se_countryofInc,se_additionalinfo,timestamp,emp_id) values(@se_entityname,@se_entitytype,@se_businesstype,@se_jobtitle,@se_shares,@se_countryofIncorportion,@se_additional,@timestamp,@temp)";
            string getuserid = "select id from EmployeeInfo where Name = '" + name.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            if (temp == 1)
            {
                //Response.Write("Student Already Exist");
                cmd = new SqlCommand(getuserid, conn);
                temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                //update the self employed table
                cmd = new SqlCommand(updateSelfEmployed, conn);
                cmd.Parameters.AddWithValue("@se_entityname", se_entityName.Text);
                cmd.Parameters.AddWithValue("@se_entitytype", se_entityType.Text);
                cmd.Parameters.AddWithValue("@se_businesstype", se_businessType.Text);
                cmd.Parameters.AddWithValue("@se_jobtitle", se_jobTitle.Text);
                cmd.Parameters.AddWithValue("@se_shares", se_shares.Text);
                cmd.Parameters.AddWithValue("@se_countryofIncorportion", se_countryofIncorporation.Text);
                cmd.Parameters.AddWithValue("@se_additional", se_additional.Text);
                cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@temp", temp);
                cmd.ExecuteNonQuery();

                conn.Close();

                Response.Write("Company Information submitted successfully! ");
            }

            else

                try
                {
                    //conn.Open();
                    string insertQuery = "insert into EmployeeInfo(Name,JobTitle,Department,IsConnected,timestamp,email)values (@name,@title,@department,@isconnected,@timestamp,@email)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@title", title.Text);
                    cmd.Parameters.AddWithValue("@department", department.Text);
                    cmd.Parameters.AddWithValue("@isconnected", "Yes");
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@email", emailaddress.Text);
                    cmd.ExecuteNonQuery();

                    //get the userid of the previous entry
                    cmd = new SqlCommand(getuserid, conn);
                    temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    //update the self employed table
                    cmd = new SqlCommand(updateSelfEmployed, conn);
                    cmd.Parameters.AddWithValue("@se_entityname", se_entityName.Text);
                    cmd.Parameters.AddWithValue("@se_entitytype", se_entityType.Text);
                    cmd.Parameters.AddWithValue("@se_businesstype", se_businessType.Text);
                    cmd.Parameters.AddWithValue("@se_jobtitle", se_jobTitle.Text);
                    cmd.Parameters.AddWithValue("@se_shares", se_shares.Text);
                    cmd.Parameters.AddWithValue("@se_countryofIncorportion", se_countryofIncorporation.Text);
                    cmd.Parameters.AddWithValue("@se_additional", se_additional.Text);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@temp", temp);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    Response.Write("Company Information submitted successfully!");

                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }

            EmailBodyClass.Emailbody = String.Format(EmailBodyClass.Emailbody + "\r\n \r\n    Entity Name : {0} \r\n    Entity Type : {1} \r\n    Business Type : {2} \r\n    Job Title : {3} \r\n    Shares : {4} \r\n    Country of Incorporation : {5} \r\n    Additional Information : {6} \r\n", se_entityName.Text, se_entityType.Text, se_businessType.Text, se_jobTitle.Text, se_shares.Text, se_countryofIncorporation.Text, se_additional.Text);

            se_additional.Text = "";
            se_businessType.Text = "";
            se_countryofIncorporation.Text = "";
            se_entityName.Text = "";
            se_entityType.Text = "";
            se_jobTitle.Text = "";
            se_shares.Text = "";
        }

        protected void btn_saveAuditorInfo_Click(object sender, EventArgs e)
        {
            conn.Open();
            string checkuser = "select count(*) from EmployeeInfo where Name='" + name.Text + "'";
            System.Console.WriteLine(checkuser);
            string updateAuditorInfo = "insert into AuditorInfo(a_name,a_position,a_department,a_periodheld,a_additional,timestamp,emp_id) values(@a_name,@a_position,@a_department,@a_periodheld,@a_additional,@timestamp,@temp)";
            string getuserid = "select id from EmployeeInfo where Name = '" + name.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            System.Console.WriteLine(updateAuditorInfo);
            System.Console.WriteLine(temp);
           

            if (temp == 1)
            {
                //Response.Write("Student Already Exist");
                cmd = new SqlCommand(getuserid, conn);
                temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                //update the auditor table
                cmd = new SqlCommand(updateAuditorInfo, conn);
                cmd.Parameters.AddWithValue("@a_name", aud_Name.Text);
                cmd.Parameters.AddWithValue("@a_position", aud_Position.Text);
                cmd.Parameters.AddWithValue("@a_department", aud_Department.Text);
                cmd.Parameters.AddWithValue("@a_periodheld", aud_PositionHeld.Text);
                cmd.Parameters.AddWithValue("@a_additional", aud_additional.Text);
                cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                cmd.Parameters.AddWithValue("@temp", temp);
                cmd.ExecuteNonQuery();

                conn.Close();

                Response.Write("Auditor information submitted successfully! ");
            }

            else

                try
                {
                    //conn.Open();
                    string insertQuery = "insert into EmployeeInfo(Name,JobTitle,Department,IsConnected,timestamp,email)values (@name,@title,@department,@isconnected,@timestamp,@email)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@title", title.Text);
                    cmd.Parameters.AddWithValue("@department", department.Text);
                    cmd.Parameters.AddWithValue("@isconnected", "Yes");
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@email", emailaddress.Text);
                    cmd.ExecuteNonQuery();

                    //get the userid of the previous entry
                    cmd = new SqlCommand(getuserid, conn);
                    temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                    //update the auditor table
                    cmd = new SqlCommand(updateAuditorInfo, conn);
                    cmd.Parameters.AddWithValue("@a_name", aud_Name.Text);
                    cmd.Parameters.AddWithValue("@a_position", aud_Position.Text);
                    cmd.Parameters.AddWithValue("@a_department", aud_Department.Text);
                    cmd.Parameters.AddWithValue("@a_periodheld", aud_PositionHeld.Text);
                    cmd.Parameters.AddWithValue("@a_additional", aud_additional.Text);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@temp", temp);
                    cmd.ExecuteNonQuery();
                   

                    conn.Close();

                    Response.Write("Auditor Information submitted successfully!");

                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }

            EmailBodyClass.Emailbody = String.Format(EmailBodyClass.Emailbody + "\r\n \r\n    Auditor Name : {0} \r\n    Auditor Position : {1} \r\n    Auditor Department : {2} \r\n    Period Position Held : {3} \r\n    Additional Information : {4} \r\n", aud_Name.Text, aud_Position.Text, aud_Department.Text, aud_PositionHeld.Text, aud_additional.Text);

            aud_PositionHeld.Text = "";
            aud_Position.Text = "";
            aud_Name.Text = "";
            aud_Department.Text = "";
            aud_additional.Text = "";
        }

        protected void btn_clearSE_Click(object sender, EventArgs e)
        {
            se_additional.Text = "";
            se_businessType.Text = "";
            se_countryofIncorporation.Text = "";
            se_entityName.Text = "";
            se_entityType.Text = "";
            se_jobTitle.Text = "";
            se_shares.Text = "";

        }

        protected void btn_clearRelativeInfo_Click(object sender, EventArgs e)
        {

            r_relativeName.Text = "";
            r_additional.Text = "";
            r_businessType.Text = "";
            r_countryofIncorporation.Text = "";
            r_entityName.Text = "";
            r_entityType.Text = "";
            r_jobTitle.Text = "";
            r_shares.Text = "";
        }

        protected void btn_clearAuditorInfo_Click(object sender, EventArgs e)
        {
            aud_PositionHeld.Text = "";
            aud_Position.Text = "";
            aud_Name.Text = "";
            aud_Department.Text = "";
            aud_additional.Text = "";
            
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (se_entityName.Text != "")
            {
                // conn.Close();
                btn_saveSE_Click(sender, e);
            }

            if (r_relativeName.Text != "")
            {
                //conn.Close();
                btn_saveRelativeInfo_Click(sender, e);
            }

            if (aud_Name.Text != "")
            {
                // conn.Close();
                btn_saveAuditorInfo_Click(sender, e);
            }

            conn.Open();
            string checkuser = "select count(*) from EmployeeInfo where Name='" + name.Text + "'";
            System.Console.WriteLine(checkuser);
            string getuserid = "select id from EmployeeInfo where Name = '" + name.Text + "'";
            SqlCommand cmd = new SqlCommand(checkuser, conn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            System.Console.WriteLine(temp);

            conn.Close();

            if (temp == 1)
            {

                // conn.Close();

                Response.Write("Form Submitted Successfully!");
            }

            else

                try
                {
                    conn.Open();
                    string insertQuery = "insert into EmployeeInfo(Name,JobTitle,Department,IsConnected,timestamp,email)values (@name,@title,@department,@isconnected,@timestamp,@email)";
                    cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    cmd.Parameters.AddWithValue("@title", title.Text);
                    cmd.Parameters.AddWithValue("@department", department.Text);
                    cmd.Parameters.AddWithValue("@isconnected", "No");
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    cmd.Parameters.AddWithValue("@email", emailaddress.Text);
                    cmd.ExecuteNonQuery();


                    conn.Close();

                    Response.Write("Form Submitted Successfully!");

                    conn.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("error" + ex.ToString());
                }

            //send email to user
            // Send the message
            try {
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress("connectedparty@trinre.com", "Connected Party");
                    emailMessage.To.Add(new MailAddress(emailaddress.Text, "Receiver"));
                    emailMessage.Bcc.Add(new MailAddress("gabrielle.marhue@trinre.com","Admin"));
                    emailMessage.Bcc.Add(new MailAddress("karla.lewis@trinre.com", "Admin"));
                    emailMessage.Subject = "Connected Party Form";
                    emailMessage.Body = "Your Connected Party Form has been received. If you have entered information it will be shown below. \r\n    " + EmailBodyClass.Emailbody;
                    emailMessage.Priority = MailPriority.Normal;
                    using (SmtpClient MailClient = new SmtpClient("192.168.10.8", 25))
                    {
                        MailClient.Send(emailMessage);
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("error" + ex.ToString());
            }

            EmailBodyClass.Emailbody = "";

            }
    }
    }
