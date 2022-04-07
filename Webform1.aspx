<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="final.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">
                    <asp:TextBox ID="UserName" runat="server"  ViewStateMode="Enabled" Width="300px" ForeColor="Black" Font-Bold="True" Font-Size="Large"></asp:TextBox>
                    
                    <br />
                    <br />
                 
                   
                </td>
            </tr>
            <tr>
                  <td>
                       <asp:DropDownList ID="DropDownList1" runat="server"  AppendDataBoundItems="true"
DataTextField="Exam_MnthYear" DataValueField=""  Width="400px">  
                           <asp:ListItem Value="0">MonthYear</asp:ListItem>
        </asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="DropDownList1"
    InitialValue="0" runat="server" ForeColor="Red" />
            </td>
            </tr>
          


            <tr>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownList3" runat="server" ViewStateMode="Enabled" CssClass="auto-style5" Width="308px" Height="32px" Font-Size="Large">
                        <asp:ListItem Value="0">SEM</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ControlToValidate="DropDownList3"
    InitialValue="0" runat="server" ForeColor="Red" />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:DropDownList ID="DropDownList4" runat="server" ViewStateMode="Enabled" CssClass="auto-style5" Width="308px" Height="32px" Font-Size="Large">
                        <asp:ListItem value="0">Exam Type</asp:ListItem>
                        <asp:ListItem>Regular</asp:ListItem>
                        <asp:ListItem>KT</asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ControlToValidate="DropDownList4"
    InitialValue="0" runat="server" ForeColor="Red" />
                    <br />
                </td>
            </tr>
           
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Text="Approve" OnClick="Button1_Click" CssClass="auto-style11" Width="305px" BackColor="Lime" BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" ForeColor="Black" Font-Bold="True" Font-Size="XX-Large" Height="50px" ViewStateMode="Enabled" />
                    <br />
                    <br />
                     
                    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="#0000CC"></asp:Label>
                    <br />
                    <br />
                </td>
            </tr>
        </table>
   
    
        <div style="background-color: #FFFFFF; margin-left: 40px;">
            <asp:TextBox ID="TextBox1" runat="server"  BorderStyle="Solid" BorderWidth="2px" Font-Size="Large" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"  ></asp:TextBox>
           
            <asp:DropDownList ID="DropDownList7" runat="server"  AppendDataBoundItems="true"
DataTextField="Exam_MnthYear" DataValueField=""  Width="400px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">  
                           <asp:ListItem Value="0">MonthYear</asp:ListItem>
        </asp:DropDownList>
            <asp:DropDownList ID="DropDownList6" runat="server" ViewStateMode="Enabled" CssClass="auto-style5" Width="308px" Height="32px" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                        <asp:ListItem Value="0">SEM</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                    </asp:DropDownList>
             <asp:DropDownList ID="DropDownList8" runat="server" ViewStateMode="Enabled" CssClass="auto-style5" Width="308px" Height="32px" Font-Size="Large" AutoPostBack="True" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged">
                        <asp:ListItem value="0">Exam Type</asp:ListItem>
                        <asp:ListItem>Regular</asp:ListItem>
                        <asp:ListItem>KT</asp:ListItem>

                    </asp:DropDownList>
            <asp:Button ID="Button2" runat="server"  CausesValidation="false" Text="Search" OnClick="Button2_Click" BackColor="Lime" Font-Size="Large" />
            <br />
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>

            <br />
            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="10"  BorderColor="Black" BorderStyle="Solid" BorderWidth="4px" HorizontalAlign="Left" ShowFooter="True" Width="1350px" Font-Size="Large" DataKeyNames="Seat_No,MnthYear,Semester,Exam_Type,Mod_Date" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
                
                <Columns>

                    <asp:TemplateField HeaderText="Seat-No."  AccessibleHeaderText="Seat-No.">
                        <ItemTemplate>
                            <asp:Label ID="LabelSeat" runat="server" Width="50px" Font-Size="Large" Text='<%# Eval("Seat_No") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtSeat" Text='<%# Eval("Seat_No") %>' Width="50px" Font-Size="Large" runat="server"></asp:TextBox>
                        </EditItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Exam MonthYear" AccessibleHeaderText="Exam-Session">
                        <ItemTemplate>
                            <asp:Label ID="LabelSession" runat="server" Font-Size="Large" Text='<%# Eval("MnthYear") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList9" Font-Size="Large" runat="server" DataSourceID="SqlDataSource1" DataTextField="Exam_MnthYear" DataValueField="Exam_MnthYear" SelectedValue='<%# Eval("MnthYear") %>' >
                                <asp:ListItem Value="0">MonthYear</asp:ListItem>
                               
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:rudraConnectionString %>" SelectCommand="SELECT DISTINCT [Exam_MnthYear] FROM [Examination]"></asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ControlToValidate="DropDownList9"
                                InitialValue="0" runat="server" ForeColor="Red" />
                           </EditItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Sem" AccessibleHeaderText="Sem">
                        <ItemTemplate>
                            <asp:Label ID="Label4" Font-Size="Large" runat="server" Text='<%# Eval("Semester") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList10" Font-Size="Large" runat="server" ViewStateMode="Enabled" DataSourceID="SqlDataSource2" DataTextField="Semester" DataValueField="Semester" SelectedValue='<%# Eval("Semester") %>'>
                                <asp:ListItem Value="0">SEM</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT DISTINCT [Semester] FROM [entries]"></asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="DropDownList10"
                                InitialValue="0" runat="server" ForeColor="Red" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exam Type" AccessibleHeaderText="Exam Type">

                         <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Font-Size="Large" Text='<%# Eval("Exam_Type") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownList11" Font-Size="Large" runat="server" DataSourceID="SqlDataSource3" DataTextField="Exam_Type" DataValueField="Exam_Type" SelectedValue='<%# Eval("Exam_Type") %>'>
                                <asp:ListItem Value="0">Exam Type</asp:ListItem>
                                <asp:ListItem>Regular</asp:ListItem>
                                <asp:ListItem>KT</asp:ListItem>
                            </asp:DropDownList>

                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT DISTINCT [Exam_Type] FROM [entries]"></asp:SqlDataSource>

                            
                        </EditItemTemplate>
                       

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date_of Application" AccessibleHeaderText="Date_of Application">
                        <ItemTemplate>
                            <asp:Label ID="Label6" runat="server" Font-Size="Large" Text='<%# Eval("Mod_Date") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtDate" Font-Size="Large" Text='<%# Eval("Mod_Date") %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>

                    </asp:TemplateField>

                    <asp:CommandField ButtonType="Image" CausesValidation="false" CancelImageUrl="images/cancel.png" HeaderText="Edit" ShowEditButton="True" ControlStyle-Width="25px" ControlStyle-Height="25px" CancelText="" DeleteImageUrl="images/delete.png" DeleteText="" EditImageUrl="images/edit.png" EditText="" UpdateImageUrl="images/save.png" UpdateText="">
                        <ControlStyle Height="25px" Width="25px"></ControlStyle>
                    </asp:CommandField>
                    <asp:CommandField AccessibleHeaderText="Delete" CausesValidation="false" ButtonType="Image" HeaderText="Delete" ShowDeleteButton="True" CancelText="" DeleteImageUrl="images/delete.png" DeleteText="" EditImageUrl="images.edit.png" EditText="">



                        <ControlStyle Height="25px" Width="25px" />
                    </asp:CommandField>



                </Columns>
                <EditRowStyle BackColor="#FFFF66" Font-Size="Large" Wrap="False" />
                <FooterStyle ForeColor="Red" HorizontalAlign="Left" VerticalAlign="Bottom" Width="500px" Wrap="False" />
                <RowStyle Font-Size="Large" />
                <SelectedRowStyle Font-Size="Large" />
            </asp:GridView>

        </div>
    
    </form>
   
</body>
</html>
