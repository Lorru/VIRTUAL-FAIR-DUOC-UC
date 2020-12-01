using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Api.Integration;
using VirtualFairProject.Class;

namespace VirtualFairProject.Profiles.InternalCustomer
{
    public partial class MyProfile : Form
    {
        public MyProfile()
        {
            InitializeComponent();
            LoadProfile();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

        }

        private void LoadProfile() 
        {
            string token = Session.Token;
            string email = Session.email;
            string password = Session.password;

            var getToken = VirtualFairIntegration.ApiLogin(email, password);

            if (getToken.statusCode == 200)
            {
                txtNombreCompleto.Text = getToken.userConnect.fullName;
                txtEmail.Text = getToken.userConnect.email;
                txtPais.Text = getToken.userConnect.country;
                txtCiudad.Text = getToken.userConnect.city;
                txtDireccion.Text = getToken.userConnect.address;
            }
            else
            {

            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            var id = Session.id;
            var address = txtDireccion.Text;
            var city = txtCiudad.Text;
            var country = txtPais.Text;
            var email = txtEmail.Text;
            var fullName = txtNombreCompleto.Text;
            var password = txtPassword.Text;

            var emailCheck = email_bien_escrito(email);
            if (emailCheck)
            {
                if (address != null && city != null && country != null && email != null && fullName != null && password != null)
                {

                    dynamic user = new System.Dynamic.ExpandoObject();
                    user.id = id;
                    user.address = address;
                    user.city = city;
                    user.country = country;
                    user.email = email;
                    user.fullName = fullName;
                    user.idProfile = Session.IdProfile;
                    user.password = password;

                    var updateUser = VirtualFairIntegration.UpdateById(token, user);

                    if (updateUser.statusCode == 200)
                    {
                        Session.NameUser = user.fullName;

                        string text = updateUser.message;
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    string text = "Debe ingresar todos los campos requeridos";
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string text = "Email mal ingresado";
                string title = "Información";
                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeInternalCustomer = new HomeInternalCustomer();
            homeInternalCustomer.Show();
        }

        private void lblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = "Has cerrado tu sesión";
            string title = "Información";
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var login = new Login();
            login.Show();

            this.Close();
        }
    }
}
