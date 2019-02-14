<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ConnectedParty.aspx.cs" Inherits="ConnectedPartyForm.ConnectedParty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        #form1{
            width: 60%;
            position:absolute;
            left:20%;
        }

        h2 > span{
	display: block;
	margin-top: 2px;
	font: 13px Arial, Helvetica, sans-serif;
}
         input[type="text"],
 input[type="date"],
 input[type="datetime"],
 input[type="email"],
 input[type="number"],
 textarea,
 select {
	display: block;
	box-sizing: border-box;
	-webkit-box-sizing: border-box;
	-moz-box-sizing: border-box;
	width: 100%;
	padding: 8px;
	border-radius: 6px;
	-webkit-border-radius:6px;
	-moz-border-radius:6px;
	border: 2px solid #fff;
	box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
	-moz-box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
	-webkit-box-shadow: inset 0px 1px 1px rgba(0, 0, 0, 0.33);
}

         .button{
             	-moz-box-shadow:inset 0px 39px 0px -24px #e67a73;
	-webkit-box-shadow:inset 0px 39px 0px -24px #e67a73;
	box-shadow:inset 0px 39px 0px -24px #e67a73;
	background-color:#e4685d;
	-moz-border-radius:4px;
	-webkit-border-radius:4px;
	border-radius:4px;
	border:1px solid #ffffff;
	display:inline-block;
	cursor:pointer;
	color:#ffffff;
	font-family:Arial;
	font-size:15px;
	padding:6px 15px;
	text-decoration:none;
	text-shadow:0px 1px 0px #b23e35;
    align-content:center;
    padding-right:10px;
         }
        
        .auto-style1 {
            height: auto;
            text-align: center;
        }
        .auto-style2 {
            height: auto;
        }
        .auto-style6 {
            width: 250px;
            margin-left: 71px;
        }
        
        .auto-style25 {
            width: 128px;
        }
        .auto-style26 {
            width: 251px;
        }

        fieldset{
            border-color:red;
        }
        legend{
            padding: 3px 6px;
            font-weight:bold;
            color:red;
        }

        .auto-style27 {
            width: 210px;
        }

        .auto-style28 {
            height: 52px;
        }

    p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:8.0pt;
	margin-left:0in;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;
	}
        .auto-style29 {
            vertical-align: super;
        }

        .auto-style30 {
            font-size: small;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server" method ="post">

    <div id="Header" class="auto-style1">
       <h1> 
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/TRINRElogo.png" />
        </h1>
        <h2>CONNECTED PARTY FORM</h2><br />
        <br />
    </div>

    
       <fieldset><legend>Personal Information</legend>
       <div id="personalInfo">
            <table class="auto-style26">
          <tr>
            <td><b>Name</b> </td><td class="auto-style25"><asp:TextBox runat="server" id="name" AutoPostback ="true"/></td></tr>
                <asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="name" errormessage="Please enter your name!" />
            <tr><td><b>Job Title</b></td><td class="auto-style25"><asp:TextBox runat="server" name="title" id="title" AutoPostback ="true"/></td></tr>
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="title" errormessage="Please enter your job title!" />
            <tr><td><b>Department</b></td><td class="auto-style25"><asp:TextBox runat="server" name="department" id="department" AutoPostback ="true"/></td></tr><br />
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="department" errormessage="Please enter your department!" />
                <tr><td><b>Email</b></td><td class="auto-style25"><asp:TextBox runat="server" name="emailaddress" id="emailaddress" AutoPostback ="true"/></td></tr><br />
                <asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="department" errormessage="Please enter your email address!" />
      </table>

       </div>
            </fieldset>

       
        
        <br />
        <fieldset><legend>Company Information</legend>
        <div id="SEQuestion">
        Are you self-employed as a sole trader/consultant or the owner/director/shareholder/member/chief executive officer/controller/officer of a company/business arrangement?<br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem  onclick="show1()">Yes</asp:ListItem>
            <asp:ListItem Selected="True" onclick ="show2()">No</asp:ListItem>
        </asp:RadioButtonList>
            </div>
        <div id="selfEmployedInfo" class="auto-style3">
            Please complete the following table for each company/business arrangement. Use N/A for fields that are not applicable.<br />
         <table>
            <tr><td><b>Entity Name</b></td><td><asp:TextBox runat="server" id="se_entityName" class="auto-style6" /></td></tr>
            <tr><td class="auto-style28"><b>Entity Type</b></td><td class="auto-style6">
                <asp:DropDownList ID="se_entityType" runat="server" class="auto-style6">
                    <asp:ListItem>Limited Liability Company</asp:ListItem>
                    <asp:ListItem>Partnership</asp:ListItem>
                    <asp:ListItem>Unincorporated Business</asp:ListItem>
                    <asp:ListItem>Sole Trader</asp:ListItem>
                    <asp:ListItem>Publicy Traded Entity</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
                </td></tr>
            <tr><td><b>Nature/Type of Business</b></td><td><asp:TextBox runat="server" id="se_businessType" class="auto-style6" /></td></tr>
            <tr><td><b>Job Title/Nature of Relationship</b></td>
                <td><asp:DropDownList ID="se_jobTitle" runat="server" class="auto-style6">
                    <asp:ListItem>Owner</asp:ListItem>
                    <asp:ListItem>Shareholder</asp:ListItem>
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem>CEO</asp:ListItem>
                    <asp:ListItem>Controller</asp:ListItem>
                    <asp:ListItem>Officer</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td></tr>
            <tr><td><b>% Stocks/Shares in Entity</b></td><td> <asp:TextBox runat="server" id="se_shares" class="auto-style6" /></td></tr>
            <tr><td><b>Country of Incorporation of Entity</b></td><td><asp:TextBox runat="server" id="se_countryofIncorporation" class="auto-style6" /></td></tr>
            <tr><td><b> Additional Information</b></td><td><asp:TextBox runat="server" id="se_additional" class="auto-style6" /></td></tr>
        </table>
            <asp:Button ID="btn_saveSE" runat="server" Text="Save &amp; Add New " OnClick="btn_saveSE_Click" class="button"/>

            <asp:Button ID="btn_clearSE" runat="server" Text="Clear" Width="115px" class ="button" OnClick="btn_clearSE_Click"/>
        </div></fieldset>
        
       
            <br />
        <fieldset><legend>Relative Information</legend>
        <div id="relativeQuestion">
        Are any of your relatives<span class="auto-style29"><span style="font-size: 11.0pt; line-height: 107%; font-family: &quot;Calibri&quot;,sans-serif; mso-ascii-theme-font: minor-latin; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-hansi-theme-font: minor-latin; mso-bidi-font-family: &quot;Times New Roman&quot;; mso-bidi-theme-font: minor-bidi; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA"><span style="mso-special-character: footnote"><span style="font-size:11.0pt;line-height:107%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">1</span></span></span></span> self-employed as a sole trader/consultant or the owner/director/shareholder/member/chief executive officer/controller/officer of a company/business arrangement?<br />
        <asp:RadioButtonList ID="rbtn_relative" runat="server">
            <asp:ListItem  onclick="show3()">Yes</asp:ListItem>
            <asp:ListItem Selected="True" onclick ="show4()">No</asp:ListItem>
        </asp:RadioButtonList>
            </div>
       <div id="RelativeInfo" class="auto-style3">
            Please complete the following table for each company/business arrangement. Use N/A for fields that are not applicable.<br />
         <table>
             <tr><td><b>Relative Name</b></td><td><asp:TextBox runat="server" id="r_relativeName" class="auto-style6" /></td></tr>
             <tr><td class="auto-style28"><b>Relation to Employee/Owner</b></td><td class="auto-style6">
                <asp:DropDownList ID="r_relation" runat="server" class="auto-style6">
                    <asp:ListItem>Mother</asp:ListItem>
                    <asp:ListItem>Father</asp:ListItem>
                    <asp:ListItem>Sibling (Brother, Sister, Half-Sibling, Step-Sibling, Adoptive Sibling)</asp:ListItem>
                    <asp:ListItem Value="Sibling">Child</asp:ListItem>
<asp:ListItem Value="Spouse">Spouse or Common-Law Partner</asp:ListItem>
                    <asp:ListItem Value="Parent of Spouse">Parent of Spouse or Common-Law Partner</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            <tr><td><b>Entity Name</b></td><td><asp:TextBox runat="server" id="r_entityName" class="auto-style6" /></td></tr>
            <tr><td><b>Entity Type</b></td><td><asp:DropDownList ID="r_entityType" runat="server" class="auto-style6">
                    <asp:ListItem>Limited Liability Company</asp:ListItem>
                    <asp:ListItem>Partnership</asp:ListItem>
                    <asp:ListItem>Unincorporated Business</asp:ListItem>
                    <asp:ListItem>Sole Trader</asp:ListItem>
                    <asp:ListItem>Publicy Traded Entity</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList>
            </td></tr>
            <tr><td><b>Nature/Type of Business</b></td><td><asp:TextBox runat="server" id="r_businessType" class="auto-style6" /></td></tr>
            <tr><td><b>Job Title/Nature of Relationship</b></td><td><asp:DropDownList ID="r_jobTitle" runat="server" class="auto-style6">
                    <asp:ListItem>Owner</asp:ListItem>
                    <asp:ListItem>Shareholder</asp:ListItem>
                    <asp:ListItem>Director</asp:ListItem>
                    <asp:ListItem>CEO</asp:ListItem>
                    <asp:ListItem>Controller</asp:ListItem>
                    <asp:ListItem>Officer</asp:ListItem>
                    <asp:ListItem>Other</asp:ListItem>
                </asp:DropDownList></td></tr></td></tr>
            <tr><td><b>% Stocks/Shares in Entity</b></td><td> <asp:TextBox runat="server" id="r_shares" class="auto-style6"/></td></tr>
            <tr><td><b>Country of Incorporation of Entity</b></td><td><asp:TextBox runat="server" id="r_countryofIncorporation" class="auto-style6" /></td></tr>
            <tr><td><b>Additional Information</b></td><td><asp:TextBox runat="server" id="r_additional" class="auto-style6"/></td></tr>
        </table>
            <asp:Button ID="btn_saveRelativeInfo" runat="server" Text="Save &amp; Add New " OnClick="btn_saveRelativeInfo_Click" CssClass="button" />

            <asp:Button ID="btn_clearRelativeInfo" runat="server" Text="Clear" Width="115px" class="button" OnClick="btn_clearRelativeInfo_Click"/>
        
            <span style="font-size:11.0pt;line-height:107%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-fareast-font-family:Calibri;mso-fareast-theme-font:
minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;mso-fareast-language:
EN-US;mso-bidi-language:AR-SA"><br />
            </span>
        
       </div>
          </fieldset>  
        <br />

        <div id="auditorQuestion">
            <fieldset><legend>Auditor Information</legend>
        Have you or any of your relatives* been an employee of TRINRE's external auditor within the last three (3) years?<br />
        <asp:RadioButtonList ID="rbtn_auditor" runat="server">
            <asp:ListItem onclick="show5()">Yes</asp:ListItem>
            <asp:ListItem Selected="True" onclick ="show6()">No</asp:ListItem>
        </asp:RadioButtonList>
            
        <div id="AuditorInfo" class="auto-style3">
            Please complete the following table. Use N/A for fields that are not applicable.<br />
         <table>
            <tr><td class="auto-style27"><b>Name</b></td><td><asp:TextBox runat="server" id="aud_Name" class="auto-style6"/></td></tr>
            <tr><td class="auto-style27"><b>Position at External Audit Firm</b></td><td><asp:TextBox runat="server" id="aud_Position" class="auto-style6"/></td></tr>
            <tr><td class="auto-style27"><b>Department</b></td><td><asp:TextBox runat="server" id="aud_Department" class="auto-style6" type="text" /></td></tr>
            <tr><td class="auto-style27"><b>Period Position Held</b></td><td><asp:TextBox runat="server" id="aud_PositionHeld" class="auto-style6"/></td></tr>
            <tr><td class="auto-style27"><b>Additional Information</b></td><td><asp:TextBox runat="server" id="aud_additional" class="auto-style6"/></td></tr>
        </table>
            <asp:Button ID="btn_saveAuditorInfo" runat="server" Text="Save &amp; Add New " OnClick="btn_saveAuditorInfo_Click" CssClass="button" />

            <asp:Button ID="btn_clearAuditorInfo" runat="server" Text="Clear" Width="115px" CssClass="button" OnClick="btn_clearAuditorInfo_Click" />
            
        </div></fieldset></div>
        <p class="MsoNormal">
            <span class="auto-style29"><span style="font-size:11.0pt;line-height:107%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-fareast-font-family:Calibri;mso-fareast-theme-font:
minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;mso-fareast-language:
EN-US;mso-bidi-language:AR-SA"><span style="mso-special-character:footnote">
            <span style="line-height:107%;
font-family:&quot;Calibri&quot;,sans-serif;mso-ascii-theme-font:minor-latin;mso-fareast-font-family:
Calibri;mso-fareast-theme-font:minor-latin;mso-hansi-theme-font:minor-latin;
mso-bidi-font-family:&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA" class="auto-style30">1</span></span></span></span><span style="line-height:107%;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-fareast-font-family:Calibri;mso-fareast-theme-font:
minor-latin;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;mso-fareast-language:
EN-US;mso-bidi-language:AR-SA" class="auto-style30">Relative means spouse or cohabitant, parent, sibling, child (whether or not they are connected by blood)</span></p>
        <p class="MsoNormal" style="font-size: small; line-height: 107%">
            I hereby certify that the above information is complete and correct to the best of my knowledge and belief and I agree to notify TRINRE Insurance Company Limited of any material changes affecting the completeness or accuracy of the information provided on this form.<o:p></o:p></p>
        <center><asp:Button ID="btn_Submit" runat="server" Text="Submit" class ="button" OnClick="BtnSubmit_Click" OnClientClick="this.disabled = true; this.value = 'Submitting...';" 
         UseSubmitBehavior="false" /></center>
        <br />
        <br />
       <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectedPartyConnectionString %>" SelectCommand="SELECT * FROM [EmployeeInfo]" ProviderName="<%$ ConnectionStrings:ConnectedPartyConnectionString.ProviderName %>"></asp:SqlDataSource>
    </form>

    <script type ="text/javascript">

    function show1(){
        document.getElementById('selfEmployedInfo').style.display ='block';
    }
    function show2(){
        document.getElementById('selfEmployedInfo').style.display = 'none';
    }
    function show3(){
        document.getElementById('RelativeInfo').style.display ='block';
    }
    function show4(){
        document.getElementById('RelativeInfo').style.display = 'none';
        }
    function show5(){
        document.getElementById('AuditorInfo').style.display ='block';
    }
    function show6(){
        document.getElementById('AuditorInfo').style.display = 'none';
        }

        window.onload = function() {
            show2();
            show4();
            show6();
        }

</script>

</body>
</html>

