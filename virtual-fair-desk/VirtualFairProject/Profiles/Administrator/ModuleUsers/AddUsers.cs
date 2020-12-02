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
using System.Text.RegularExpressions;

namespace VirtualFairProject.Profiles.Administrator.ModuleUsers
{
    public partial class AddUsers : Form
    {

        private AdminApi _loginData;

        public AddUsers(AdminApi loginData)
        {
            _loginData = loginData;

            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

            string token = Session.Token;

            var allProfiles = VirtualFairIntegration.GetFindAllProfiles(token);

            cmbPerfil.DataSource = allProfiles.profiles;
            cmbPerfil.DisplayMember = "name";
            cmbPerfil.ValueMember = "id";
            cmbPerfil.DropDownStyle = ComboBoxStyle.DropDownList;

            btnRegistrar.Visible = true;
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            btnEditar.Visible = false;

            if (_loginData.id != 0)
            {
                if (Session.Edit)
                {
                    lblRegistrarUsuario.Text = "Editar Usuario";
                    btnRegistrar.Visible = false;
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                    btnEditar.Visible = true;

                    //Button btnEditar = new Button();
                    //btnEditar.Location = new Point(532, 391);
                    //btnEditar.Text = "Editar";
                    //btnEditar.AutoSize = true;
                    //Mybutton.BackColor = Color.LightBlue;
                    //Mybutton.Padding = new Padding(6);
                    //Mybutton.Font = new Font("French Script MT", 18);

                    //this.Controls.Add(btnEditar);


                    this.txtCiudad.Text = _loginData.city;
                    this.txtDireccion.Text = _loginData.address;
                    this.txtEmail.Text = _loginData.email;
                    this.txtNombreCompleto.Text = _loginData.fullName;
                    this.txtPais.Text = _loginData.country;
                    this.cmbPerfil.SelectedIndex = _loginData.idProfile - 1;

                }
            }

            

            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            var usuarios = new Users();
            usuarios.Show();
            
        }

        //private void btnEditar_Click(object sender, EventArgs e)
        //{
        //    //Editar

        //    string token = Session.Token;

        //    var address = txtDireccion.Text;
        //    var city = txtCiudad.Text;
        //    var country = txtPais.Text;
        //    var email = txtEmail.Text;
        //    var fullName = txtNombreCompleto.Text;
        //    var idProfile = Convert.ToInt32(cmbPerfil.SelectedValue);
        //    var password = txtPassword.Text;

        //    var emailCheck = email_bien_escrito(email);
        //    if (emailCheck)
        //    {
        //        if (address != null && city != null && country != null && email != null && fullName != null
        //         && idProfile != 0 && password != null)
        //        {
        //            //si el usuario existe
        //            //List<string> lst = new List<string>();
        //            //var findAllUsers = VirtualFairIntegration.GetFindAllUser(token);

        //            //foreach (var item in findAllUsers.users)
        //            //{
        //            //    if (item.email == email)
        //            //    {
        //            //        string text = "Usuario ya existe";
        //            //        string title = "Información";
        //            //        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            //        return;
        //            //    }
        //            //}

        //            dynamic user = new System.Dynamic.ExpandoObject();
        //            user.address = address;
        //            user.city = city;
        //            user.country = country;
        //            user.email = email;
        //            user.fullName = fullName;
        //            user.idProfile = idProfile;
        //            user.password = password;

        //            var updateUser = VirtualFairIntegration.UpdateById(token, user);

        //            if (updateUser.status == 201)
        //            {
        //                string text = updateUser.message;
        //                string title = "Información";
        //                MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }

        //        }
        //        else
        //        {
        //            string text = "Debe ingresar todos los campos requeridos";
        //            string title = "Información";
        //            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else
        //    {
        //        string text = "Email mal ingresado";
        //        string title = "Información";
        //        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //}

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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string token = Session.Token;

            var address = txtDireccion.Text;
            var city = txtCiudad.Text;
            var country = txtPais.Text;
            var email = txtEmail.Text;
            var fullName = txtNombreCompleto.Text;
            var idProfile = Convert.ToInt32(cmbPerfil.SelectedValue);
            var password = txtPassword.Text;
            

            var emailCheck = email_bien_escrito(email);
            if (emailCheck)
            {
                if (address != null && city != null && country != null && email != null && fullName != null
                 && idProfile != 0 && password != null)
                {
                    //si el usuario existe
                    List<string> lst = new List<string>();
                    var findAllUsers = VirtualFairIntegration.GetFindAllUser(token);

                    foreach (var item in findAllUsers.users)
                    {
                        if (item.email == email)
                        {
                            string text = "Usuario ya existe";
                            string title = "Información";
                            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    dynamic user = new System.Dynamic.ExpandoObject();
                    user.address = address;
                    user.city = city;
                    user.country = country;
                    user.email = email;
                    user.fullName = fullName;
                    user.idProfile = idProfile;
                    user.password = password;

                    var createUser = VirtualFairIntegration.CreateUser(token, user);

                    if (createUser.statusCode == 201)
                    {
                        string text = createUser.message;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Editar

            string token = Session.Token;

            var id = _loginData.id;
            var address = txtDireccion.Text;
            var city = txtCiudad.Text;
            var country = txtPais.Text;
            var email = txtEmail.Text;
            var fullName = txtNombreCompleto.Text;
            var idProfile = Convert.ToInt32(cmbPerfil.SelectedValue);
            var password = txtPassword.Text;

            var emailCheck = email_bien_escrito(email);
            if (emailCheck)
            {
                if (address != null && city != null && country != null && email != null && fullName != null
                 && idProfile != 0 && password != null)
                {

                    dynamic user = new System.Dynamic.ExpandoObject();
                    user.id = id;
                    user.address = address;
                    user.city = city;
                    user.country = country;
                    user.email = email;
                    user.fullName = fullName;
                    user.idProfile = idProfile;
                    //user.password = password;

                    var updateUser = VirtualFairIntegration.UpdateById(token, user);

                    if (updateUser.statusCode == 200)
                    {
                        string text = updateUser.message;
                        string title = "Información";
                        MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    this.Hide();

                    var users = new Users();
                    users.Show();

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

        private void lblCerrarSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string text = "Has cerrado tu sesión";
            string title = "Información";
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            var login = new Login();
            login.Show();

            this.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCiudad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPais_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreCompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombreCompleto_Click(object sender, EventArgs e)
        {

        }

        private void lblRegistrarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
