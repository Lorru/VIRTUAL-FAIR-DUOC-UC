using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Api.Integration;
using VirtualFairProject.Class;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace VirtualFairProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (ComprobarFormatoEmail(email))
            {
                if (email != "" && password != "")
                {
                    var getToken = VirtualFairIntegration.ApiLogin(email, password);
                    int statusCode = getToken.statusCode;

                    if (statusCode == 403)
                    {
                        string text = getToken.message;
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (statusCode == 200)
                    {
                        Session.Token = getToken.sessionToken.token;
                        Session.IdProfile = getToken.sessionToken.idUser;
                        Session.NameUser = getToken.userConnect.fullName;
                        Session.NameProfile = getToken.userConnect.profile.name;


                        int idProfile = getToken.userConnect.idProfile;
                        if (idProfile > 0)
                        {
                            if (idProfile == 1)
                            {
                                var homeAdmin = new HomeAdmin();
                                homeAdmin.Show();
                                this.Hide();
                            }
                            else if (idProfile == 2)
                            {
                                var homeConsultor = new HomeConsultant();
                                homeConsultor.Show();
                                this.Hide();
                            }
                            else if (idProfile == 3)
                            {
                                var homeProductor = new HomeProducer();
                                homeProductor.Show();
                                this.Hide();
                            }
                            else if (idProfile == 4)
                            {
                                var homeTransportista = new HomeCarrier();
                                homeTransportista.Show();
                                this.Hide();
                            }
                            else if (idProfile == 5)
                            {
                                //CLIENTE INTERNO 
                                //internal customer
                                var homeClient = new HomeInternalCustomer();
                                homeClient.Show();
                                this.Hide();
                            }
                            else if (idProfile == 6)
                            {
                                //CLIENTE EXTERNO
                                //internal customer
                                var homeClientExternal = new HomeExternalCustomer();
                                homeClientExternal.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            string text = "Usuario no existe";
                            string title = "Información";
                            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else if (email != "" && password == "")
                {
                    string text = "Debe ingresar password";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (email == "" && password != "")
                {
                    string text = "Debe ingresar email";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string text = "Email tiene formato incorrecto";
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
