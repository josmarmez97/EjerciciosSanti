using BotDetect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BotDetectFeaturesDemoCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // initial page setup
            if (!IsPostBack)
            {
                #region form initialization

                // set control text
                ValidateCaptchaButton.Text = "Validate";
                CaptchaCorrectLabel.Text = "Correct!";
                CaptchaIncorrectLabel.Text = "Incorrect!";
                ApplyButton.Text = "Apply";

                // these messages are shown only after validation
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = false;

                // code length dropdown initialization
                ListItem item = new ListItem("[Default (4-6)]", "Default");
                CodeLengthDropDown.Items.Insert(0, item);
                for (int i = 1; i <= 15; i++)
                {
                    item = new ListItem(i.ToString(), i.ToString());
                    CodeLengthDropDown.Items.Insert(i, item);
                }

                // code type dropdown initialization
                CodeStyleDropDown.DataSource = Enum.GetNames(typeof(CodeStyle));
                CodeStyleDropDown.DataBind();
                CodeStyleDropDown.SelectedValue = ExampleCaptcha.CodeStyle.ToString();

                // image format dropdown initialization
                ImageFormatDropDown.DataSource = Enum.GetNames(typeof(ImageFormat));
                ImageFormatDropDown.DataBind();
                ImageFormatDropDown.SelectedValue = ExampleCaptcha.ImageFormat.ToString();

                // image width textbox and validators initialization
                WidthTextBox.Text = ExampleCaptcha.ImageSize.Width.ToString();

                WidthRequiredValidator.ErrorMessage = "Width is a required value";
                WidthRequiredValidator.Display = ValidatorDisplay.None;

                WidthRangeValidator.ErrorMessage = "Width must be a number between 20 and 500";
                WidthRangeValidator.Type = ValidationDataType.Integer;
                WidthRangeValidator.MinimumValue = (20).ToString();
                WidthRangeValidator.MaximumValue = (500).ToString();
                WidthRangeValidator.Display = ValidatorDisplay.None;

                // image height textbox and validators initialization
                HeightTextBox.Text = ExampleCaptcha.ImageSize.Height.ToString();

                HeightRequiredValidator.ErrorMessage = "Height is a required value";
                HeightRequiredValidator.Display = ValidatorDisplay.None;

                HeightRangeValidator.ErrorMessage = "Height must be a number between 20 and 200";
                HeightRangeValidator.Type = ValidationDataType.Integer;
                HeightRangeValidator.MinimumValue = (20).ToString();
                HeightRangeValidator.MaximumValue = (200).ToString();
                HeightRangeValidator.Display = ValidatorDisplay.None;

                // audio format dropdown initialization
                SoundFormatDropDown.DataSource = Enum.GetNames(typeof(SoundFormat));
                SoundFormatDropDown.DataBind();
                SoundFormatDropDown.Items.Remove("Unknown");
                SoundFormatDropDown.SelectedValue = ExampleCaptcha.SoundFormat.ToString();

                // validation summary initialization
                PageValidationSummary.HeaderText = "Please correct the following errors:";
                PageValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                PageValidationSummary.ShowMessageBox = true;
                PageValidationSummary.ShowSummary = false;


                #endregion form initialization
            }
        }

        protected void ValidateCaptchaButton_Click(object sender, EventArgs e)
        {
            // validate the Captcha to check we're not dealing with a bot
            bool isHuman = ExampleCaptcha.Validate();
            if (isHuman)
            {
                CaptchaCorrectLabel.Visible = true;
                CaptchaIncorrectLabel.Visible = false;
            }
            else
            {
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = true;
            }
        }

        protected void ApplyButton_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // read input values and set BotDetect control properties 
            if (Page.IsValid)
            {
                // clear previous user input
                CaptchaCodeTextBox.Text = null;
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = false;

                // read and set code length
                if ("Default" == CodeLengthDropDown.SelectedValue)
                {
                    ExampleCaptcha.WebCaptcha.CaptchaBase.CodeLengthNullable = null;
                }
                else
                {
                    ExampleCaptcha.CodeLength = Int32.Parse(CodeLengthDropDown.SelectedValue);
                }

                // read and set locale
                ExampleCaptcha.Locale = LocaleDropDown.SelectedValue;

                // read and set code type
                object codeStyle = Enum.Parse(typeof(CodeStyle), CodeStyleDropDown.SelectedValue);
                ExampleCaptcha.CodeStyle = (CodeStyle)codeStyle;

                // custom light color
                if ("Default" == CustomLightColorDropDown.SelectedValue)
                {
                    ExampleCaptcha.CustomLightColor = Color.Empty;
                }
                else
                {
                    Color customLightColor = Color.FromName(CustomLightColorDropDown.SelectedValue);
                    ExampleCaptcha.CustomLightColor = customLightColor;
                }

                // custom dark color
                if ("Default" == CustomDarkColorDropDown.SelectedValue)
                {
                    ExampleCaptcha.CustomDarkColor = Color.Empty;
                }
                else
                {
                    Color customDarkColor = Color.FromName(CustomDarkColorDropDown.SelectedValue);
                    ExampleCaptcha.CustomDarkColor = customDarkColor;
                }

                // read and set image format
                object imageFormat = Enum.Parse(typeof(ImageFormat), ImageFormatDropDown.SelectedValue);
                ExampleCaptcha.ImageFormat = (ImageFormat)imageFormat;

                // read and set image size
                int width = Int32.Parse(WidthTextBox.Text);
                int height = Int32.Parse(HeightTextBox.Text);
                ExampleCaptcha.ImageSize = new Size(width, height);

                // read and set audio format
                object audioFormat = Enum.Parse(typeof(SoundFormat), SoundFormatDropDown.SelectedValue);
                ExampleCaptcha.SoundFormat = (SoundFormat)audioFormat;
            }
        }
    }
}