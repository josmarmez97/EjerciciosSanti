<%@ WebHandler Language="C#" Class="BasicHandler" %>

using System;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using BotDetect.Web;


public class BasicHandler : IHttpHandler
{

    public void ProcessRequest (HttpContext context)
    {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
            string dataJson = new StreamReader(context.Request.InputStream).ReadToEnd();

            Dictionary<string, string> formDataObj = new Dictionary<string, string>();
            formDataObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataJson);

            string userEnteredCaptchaCode = formDataObj["userEnteredCaptchaCode"];
            string captchaId = formDataObj["captchaId"];

            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = captcha.Validate(userEnteredCaptchaCode, captchaId);
           
            // create an object that stores the validation result
            Dictionary<string, bool> validationResult = new Dictionary<string, bool>();

            if (isHuman == false)
            {
                // captcha validation failed
                validationResult.Add("success", false);
                // TODO: consider logging the attempt                
            }
            else
            {
                // captcha validation succeeded
                validationResult.Add("success", true);
            }

            // return the json string with the validation result to the frontend
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(JsonConvert.SerializeObject(validationResult));
        }
        else
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Only HTTP POST requests are allowed.");
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}