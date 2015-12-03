using System;
using TranslatoWebsite.ServiceInsertText;

namespace TranslatoWebsite
{
    public partial class InsertText : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitText(object sender, EventArgs e)
        {
            ServiceInsertTextClient sitc = new ServiceInsertTextClient();

            string textData = TBX_Text_data.Text;

            Text text = new Text();
            text.textData = textData;

            int result = sitc.insertText(text);

            string output;
            if (result == 1)
            {
                output = "Text inserted succesfully.";
            }
            else
            {
                output = "Error. Please try again.";
            }
            LBL_Output_text.Text = output; 
        }
    }
}