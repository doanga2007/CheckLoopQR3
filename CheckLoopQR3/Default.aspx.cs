using System;
using System.Drawing;
using System.IO;
using ZXing;
using ZXing.QrCode;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace CheckLoopQR3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkTextAll.Text = " Check All";
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            long num = Convert.ToInt64(code);

            int i;

            for (i = 1; i < 6; i++)
            {
                num *= i;
                CheckBox1.Items.Add(new ListItem(" " + num));
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            if (CheckBox1.SelectedItem == null)
            {
                Response.Redirect("Default.aspx");
            }

            string[] texture = { "Selected Text 1 -> ", "Selected Text 2 -> ", "Selected Text 3 -> ",
                                 "Selected Text 4 -> ", "Selected Text 5 -> "};

            string[] texture2 = { " is Checkbox 1.", " is Checkbox 2.", " is Checkbox 3.",
                                 " is Checkbox 4.", " is Checkbox 5."};

            foreach (ListItem listItem in CheckBox1.Items)
            {
                if (listItem.Selected)
                {
                    int a = CheckBox1.Items.IndexOf(listItem);
                    a = a + 1;

                    string code = listItem.Text;

                    CheckBox1.Visible = false;
                    checkAll.Visible = false;
                    checkTextAll.Visible = false;

                    QrCodeEncodingOptions options = new QrCodeEncodingOptions();

                    options = new QrCodeEncodingOptions
                    {
                        DisableECI = true,
                        CharacterSet = "UTF-8",
                        Width = 150,
                        Height = 150,
                        Margin = 0,
                    };

                    var barcodeWriter = new BarcodeWriter();
                    barcodeWriter.Format = BarcodeFormat.QR_CODE;
                    barcodeWriter.Options = options;

                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;

                    Label lblvalues = new Label();
                    lblvalues.Text += texture[a - 1] + listItem.Text + texture2[a - 1];
                    lblvalues.Font.Size = FontUnit.Large;

                    using (Bitmap bitMap = barcodeWriter.Write(code))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        PlaceHolder1.Controls.Add(imgBarCode);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                    }
                }
                else
                {
                    //do something else 
                }
            }
        }
    }
}