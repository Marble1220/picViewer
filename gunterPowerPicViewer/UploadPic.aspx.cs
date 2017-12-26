using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using BLL;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            imgDetail.Visible = false;
        }
    }
    protected void btn_upload_Click(object sender, EventArgs e)
    {
        //upImage();
        startUploadimg();
        imgDetail.Visible = true;
    }
    //private void upImage()
    //{
    //    if (FileUpload1.HasFile)
    //    {
    //        //判断上传的文件是否是图片类型
    //        if (input.IsImgString(FileUpload1.PostedFile.FileName))
    //        {
    //            HttpPostedFile myFile = FileUpload1.PostedFile;//获取上传的文件
    //            int filelen = myFile.ContentLength;
    //            byte[] myData = new byte[filelen];
    //            myFile.InputStream.Read(myData, 0, filelen);
    //            FileStream newFile = new FileStream(FileUpload1.PostedFile.FileName, FileMode.Create);
    //            newFile.Write(myData, 0, myData.Length);
    //            System.Drawing.Image img = System.Drawing.Image.FromStream(newFile);
    //            string imgNewName = input.ReDateTime("yyyyMMddHHmmssff") + ".jpg";
    //            string startPath = "~/AllUpLoadPic/" + imgNewName;
    //            string filePath = Server.MapPath(startPath);
    //            FileUpload1.SaveAs(filePath);//保存图片
    //            img_teacherPhoto.ImageUrl = startPath;
    //            //生成缩略图
    //            Bitmap ImgFile = new Bitmap(filePath);
    //            Bitmap tectSmalImg = CreateSmallImg.CreateThumbnail(ImgFile, 100, 100, true);
    //            tectSmalImg.Save(Server.MapPath("~/AllUpLoadPic" + imgNewName));
    //            Session["smallImgPath"] = "~/AllUpLoadPic/" + imgNewName;//缩略图的位置
    //            btn_upload.CommandArgument = startPath;//将图片路径存起来
    //            //显示新上传的图片的信息
    //            lb_fileName.Text = FileUpload1.FileName;
    //            lb_filePath.Text = "~/AllUpLoadPic/";
    //            lb_fileSize.Text = img.Width.ToString() + "*" + img.Height.ToString();
    //            //PicID.Text=
    //            newFile.Dispose();//释放FileStream
    //            FileUpload1.Enabled = false;
    //            btn_upload.Enabled = false;
    //        }
    //        else
    //        {
    //            ClientDeal.JsAlert("请选择图片类型的文件!");
    //        }
    //    }
    //}

    private void startUploadimg()
    {
        if (this.FileUpload1.HasFile)//检查是否有文件 
        {
            string fullFileName = this.FileUpload1.PostedFile.FileName;                           //文件路径名 
            string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);   //图片名称 
            string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1).ToLower();        //图片格式 
            //fileName = realImageName() + "." + type;
            fileName =realImageName()+ "." + type;
            if (type == "jpg" || type == "gif" || type == "bmp" || type == "jpeg") //判断是否为图片类型 
            {
                if (this.FileUpload1.PostedFile.ContentLength > 3072 * 1024)
                {
                    Response.Write("<script>alert('上传图片必须小于3M！');</script>");
                }
                else
                {

                    this.img_teacherPhoto.ImageUrl = "~/AllUpLoadPic/" + fileName;//显示图片
                    //Response.Write("<script>alert('" + img_teacherPhoto.ImageUrl + "');</script>");
                    string path = HttpContext.Current.Request.MapPath("~/AllUpLoadPic/");//获取上传文件的网站目录路径,"
                    this.FileUpload1.SaveAs(path + fileName);//存储文件到磁盘 
                    //Response.Write("<script>alert('图片上传成功！');</script>");//提示 
                    //upLoadDetail.Visible = true;
                    double flen = (double)this.FileUpload1.PostedFile.ContentLength / 1024 / 1024;
                    //decimal flen1 = Convert.ToDecimal(flen);
                    //upLoadDetail.Text = "上传图片的名称是：" + fullFileName + "<br/>" + "存库名称为：" + fileName + "<br/>" + "格式是：" + type.ToString() + "<br/>" + "大小：" + flen.ToString() + "MB";
                }
                HttpPostedFile myFile = FileUpload1.PostedFile;//获取上传的文件
                int filelen = myFile.ContentLength;
                byte[] myData = new byte[filelen];
                myFile.InputStream.Read(myData, 0, filelen);
                FileStream newFile = new FileStream(FileUpload1.PostedFile.FileName, FileMode.Create);
                newFile.Write(myData, 0, myData.Length);
                System.Drawing.Image img = System.Drawing.Image.FromStream(newFile);
               // string imgNewName = input.ReDateTime("yyyyMMddHHmmssff") + ".jpg";

                //System.Drawing.Image img = System.Drawing.Image.FromStream(newFile);
                string startPath = "~/AllUpLoadPic/" + fileName;
                string filePath = Server.MapPath(startPath);
                //生成缩略图
                Bitmap ImgFile = new Bitmap(filePath);
                Bitmap tectSmalImg = new Bitmap(ImgFile, 100, 100);
                //Bitmap tectSmalImg = CreateSmallImg.CreateThumbnail(ImgFile, 100, 100, true);
                //tectSmalImg.Save(Server.MapPath("~/AllUpLoadPic" + fileName));
                Session["smallImgPath"] = "~/AllUpLoadPic" + fileName;//缩略图的位置
                btn_upload.CommandArgument = startPath;//将图片路径存起来
                //显示新上传的图片的信息
                lb_fileName.Text = FileUpload1.FileName;
                lb_filePath.Text = "~/AllUpLoadPic/";
                lb_fileSize.Text = img.Width.ToString() + "*" + img.Height.ToString();
                //PicID.Text=
                newFile.Dispose();//释放FileStream
                FileUpload1.Enabled = true;
                btn_upload.Enabled = true;

                //保存到数据库
                int a = -1;
                //Response.Write("<script>alert('"+fileName+"');</script>");
                a = new PicManager().InsertPicInfo(fileName,  "好美，我要上！", img.Height,img.Width);
                if (a ==0)
                {
                    ;
                }
            }
            else
            {
                Response.Write("<script>alert('非图片类型，不允许上传！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('必须指定文件！');</script>");
        }
        //this.FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/")+FileUpload1.FileName);
        //this.Image1.ImageUrl = "~/Images/" + FileUpload1.FileName;
    }
    public string realImageName()
    {   //定义年月日，时分秒，毫秒作为文件的名称
        string strname = "";
        string y = DateTime.Now.Year.ToString();
        if (Convert.ToInt32(y) < 10) y = "0" + y;
        string m = DateTime.Now.Month.ToString();
        if (Convert.ToInt32(m) < 10) m = "0" + m;
        string d = DateTime.Now.Day.ToString();
        if (Convert.ToInt32(d) < 10) d = "0" + d;
        string hh = DateTime.Now.Hour.ToString();
        if (Convert.ToInt32(hh) < 10) hh = "0" + hh;
        string min = DateTime.Now.Minute.ToString();
        if (Convert.ToInt32(min) < 10) min = "0" + min;
        string sec = DateTime.Now.Second.ToString();
        if (Convert.ToInt32(sec) < 10) sec = "0" + sec;
        string msec = DateTime.Now.Millisecond.ToString();
        if (Convert.ToInt32(msec) < 10) msec = "0" + msec;
        strname = y + m + d + hh + min + sec + msec;
        return strname;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}
