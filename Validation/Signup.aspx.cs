using System;
using System.Collections.Generic;
using GenericValidation.DataValidators;
using GenericValidation;
using FluentValidation.Results;

namespace Validation
{
    public partial class Signup : System.Web.UI.Page
    {
        public string Username { get { return ViewState["username"] as string; } set { ViewState["username"] = value; } }
        public string Password { get { return ViewState["password"] as string; } set { ViewState["password"] = value; } }
        public string Email { get { return ViewState["email"] as string; } set { ViewState["email"] = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Username = iUsername.Value;
                Password = iPassword.Value;
                Email = iEmail.Value;
            }
            else
            {
                iUsername.Value = Username;
                iPassword.Value = Password;
                iEmail.Value = Email;
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            bool isValid;
            Dictionary<string,ValidationResult> result = ValidationManager.Validate(
                new SignupValidator()
                {
                    email = iEmail.Value,
                    password = iPassword.Value,
                    username = iUsername.Value
                },out isValid);

            if (!isValid)
            {
                lblErrorMessages.Text = ValidationManager.GetErrors(result);
            }
        }
    }
}