<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="UploadPic.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
      <link href="css/manaStyle.css" type="text/css" rel="Stylesheet" />
    <script src="../js/jquery-1.3.2.js" type="text/javascript" language="javascript"></script>
    <style type="text/css">
        div
        {
            float:none;
        }
        .showSign
        {
        }
        .myblock h3
        {
            font: 13px "Lucida Grande" , Verdana, Arial, "Bitstream Vera Sans" , sans-serif;
            display: block;
            padding: 7px 3px 7px 5px;
            background: url(images/gray-grad.png) #dfdfdf repeat-x left top;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .myblock
        {
            border: solid 1px #DFDFDF;
            margin-bottom: 5px;
            
        }
        .mytable
        {
        }
        .mytable table
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div>
      <div class="title_td" style="float:left"></div>
      <em style="font-size:25px; float:left; padding:8px 0px 0px 5px; color:Gray;">编辑图片</em>
      </div>
      <div class="myblock" style="clear:both; margin:10px 0px 0px 15px; height: 70px;" >
             <h3>上传新图片</h3>
             <div style="padding:10px">
             <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox2" Width="274px" />
             <asp:Button ID="btn_upload" runat="server" Text="上传" CssClass="button7" OnClientClick="return confirm('确定上传此图片？上传后将不可更改！')" onclick="btn_upload_Click" />
                 <input id="Checkbox1" type="checkbox" />包含水印？
                 [ 注意：上传文件应为图片格式，小于4M]</div>
       </div>
             <div class="myblock" 
            
            style="clear:both; margin:10px 0px 0px 15px;  height: 70px;" >
             <h3>缩略图大小设置</h3>
             <div style="padding:10px;margin-bottom:10px;">
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                     RepeatDirection="Horizontal">
                     <asp:ListItem Selected="True" Value="0.5">1/2比例</asp:ListItem>
                     <asp:ListItem Value="0.25">1/4比例</asp:ListItem>
                     <asp:ListItem Value="0.125">1/8比例</asp:ListItem>
                 </asp:RadioButtonList>
             </div>
       </div>
       <div id="imgDetail" runat="server" style="clear:both;padding-bottom:10px; margin:10px 0px 0px 15px;" class="myblock">
       <h3>图片详情</h3>
      <table  style=" font-size:15px; margin:10px 0px 0px 15px;border:solid 1px #DFDFDF"  >
         <tr style="height:40px;">
                                  <td style="padding-left:15px; width:200px;" rowspan="3"><asp:Image id="img_teacherPhoto" runat="server" Width="100" Height="100"/>
                                      &nbsp;No.<asp:Label ID="PicID" runat="server" Text=""></asp:Label>
                                      </td>
                                  <td><asp:Label ID="lb_fileName" runat="server"></asp:Label><br /></td>
         </tr>
         <tr style="height:40px;"><td><asp:Label ID="lb_filePath" runat="server"></asp:Label><br /></td></tr>
         <tr style="height:40px;"><td><asp:Label ID="lb_fileSize" runat="server"></asp:Label></td></tr>  
         </table> 
         </div>
            </div>
    <p>
    
        &nbsp;</p>
    </form>
</body>
</html>
