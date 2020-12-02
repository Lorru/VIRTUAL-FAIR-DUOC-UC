using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualFairProject.Api.Integration;
using VirtualFairProject.Class;
using VirtualFairProject.Profiles.Administrator.ModuleUsers;

namespace VirtualFairProject.Profiles.Administrator
{
    public partial class Users : Form
    {

        public Users()
        {

            InitializeComponent();

            var nameUser = Session.NameUser;
            var nameProfile = Session.NameProfile;

            lblBienvenido.Text = String.Concat("Bienvenido ", nameUser, " | ", nameProfile.ToUpper());

            LoadGrid();

            
        }

        private void LimpiarGrid() 
        {

            dgvPrueba.Columns.Clear();
        }

        private void LoadGrid() 
        {

            LimpiarGrid();


            string token = Session.Token;

            var findAllUsers = VirtualFairIntegration.GetFindAllUser(token);

            List<AdminApi> lstUsers = new List<AdminApi>();

            if (findAllUsers.countRows != 0)
            {
                foreach (var item in findAllUsers.users)
                {
                    AdminApi users = new AdminApi();
                    users.country = item.country.ToString();
                    users.id = Convert.ToInt32(item.id.ToString());
                    users.status = Convert.ToInt32(item.status.ToString());
                    users.idProfile = Convert.ToInt32(item.idProfile.ToString());
                    users.email = item.email.ToString();
                    users.password = item.password.ToString();
                    users.fullName = item.fullName.ToString();
                    users.city = item.city.ToString();
                    users.nameProfile = item.profile.name.ToString();
                    users.address = item.address.ToString();

                    if (users.status == 1)
                    {
                        users.statusName = "ACTIVO";
                    }
                    else
                    {
                        users.statusName = "INACTIVO";
                    }

                    lstUsers.Add(users);
                }
            }
            

            dgvPrueba.AutoGenerateColumns = false;

            dgvPrueba.DataSource = lstUsers;

            List<string> lstString = new List<string>();

            string[] arrayString = new string[] { "id", "fullName", "email", "nameProfile", "statusName" };

            //List<PropertyInfo> lst = typeof(AdminApi).GetProperties().Where(x => x.Name == "id" || x.Name == "fullName" ||
            //                                                                x.Name == "email" || x.Name == "nameProfile" ).ToList();

            foreach (var item in arrayString)
            {
                DataGridViewTextBoxColumn dataGrid = new DataGridViewTextBoxColumn();

                dataGrid.DataPropertyName = item;
                if (item == "id")
                {
                    dataGrid.HeaderText = "Id";
                }
                else if (item == "fullName")
                {
                    dataGrid.HeaderText = "Nombre Completo";
                }
                else if (item == "email")
                {
                    dataGrid.HeaderText = "Email";
                }
                else if (item == "nameProfile")
                {
                    dataGrid.HeaderText = "Perfil";
                }
                else if (item == "statusName")
                {
                    dataGrid.HeaderText = "Estado Perfil";
                }

                dataGrid.Name = item;

                dgvPrueba.Columns.Add(dataGrid);

            }


            DataGridViewButtonColumn verDetalles = new DataGridViewButtonColumn();

            verDetalles.FlatStyle = FlatStyle.Popup;
            verDetalles.HeaderText = "Ver Detalles";
            verDetalles.Name = "Ver Detalles";
            verDetalles.UseColumnTextForButtonValue = true;
            verDetalles.Text = "Ver Detalles";

            verDetalles.Width = 80;
            if (dgvPrueba.Columns.Contains(verDetalles.Name = "Ver Detalles"))
            {

            }
            else
            {
                dgvPrueba.Columns.Add(verDetalles);
            }


            DataGridViewButtonColumn habilitarEstado = new DataGridViewButtonColumn();

            habilitarEstado.FlatStyle = FlatStyle.Popup;
            habilitarEstado.HeaderText = "Actualizar Estado";
            habilitarEstado.Name = "Actualizar Estado";
            habilitarEstado.UseColumnTextForButtonValue = true;
            habilitarEstado.Text = "Actualizar Estado";

            habilitarEstado.Width = 130;

            DataGridViewButtonColumn deshabilitarEstado = new DataGridViewButtonColumn();

            deshabilitarEstado.FlatStyle = FlatStyle.Popup;
            deshabilitarEstado.HeaderText = "Deshabilitar";
            deshabilitarEstado.Name = "Deshabilitar";
            deshabilitarEstado.UseColumnTextForButtonValue = true;
            deshabilitarEstado.Text = "Deshabilitar";

            deshabilitarEstado.Width = 80;


            if (dgvPrueba.Columns.Contains(habilitarEstado.Name = "Actualizar Estado"))
            {

            }
            else
            {
                dgvPrueba.Columns.Add(habilitarEstado);
            }

        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            var _loginData = new AdminApi();

            Session.Edit = false;

            var registrarUsuario = new AddUsers(_loginData);
            registrarUsuario.Show();
            this.Hide();
        }

        private void dgvPrueba_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                
                int rowIndex = dgvPrueba.CurrentCell.RowIndex;
                Session.Edit = true;

                var userAdminApi = dgvPrueba.CurrentRow.DataBoundItem;
                AdminApi adminApi = (AdminApi)userAdminApi;

                var _loginData = adminApi;

                this.Hide();

                var registrarUsuario = new AddUsers(_loginData);
                registrarUsuario.Show();

            }
            else if(e.ColumnIndex == 6)
            {
                //Actualizar
                string token = Session.Token;

                var userAdminApi = dgvPrueba.CurrentRow.DataBoundItem;
                AdminApi adminApi = (AdminApi)userAdminApi;

                dynamic user = new System.Dynamic.ExpandoObject();
                user.id = adminApi.id;

                var userUpdateStatusById = VirtualFairIntegration.UserUpdateStatusById(token,user);

                if (userUpdateStatusById.statusCode == 200)
                {
                    string text = userUpdateStatusById.message;
                    string title = "Información";
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadGrid();

                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            var homeAdmin = new HomeAdmin();
            homeAdmin.Show();
            this.Close();
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
