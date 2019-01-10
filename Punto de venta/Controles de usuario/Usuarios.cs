using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Base_de_datos;
using Punto_de_venta.Clases;
using Punto_de_venta.Ventanas;

namespace Punto_de_venta
{
    public partial class Usuarios : UserControl
    {
        public static List<Usuario> users;
        ClassValidation validar = new ClassValidation();
        int c;
        public Usuarios()
        {
            InitializeComponent();
        
        }
        public void cargar()
        {
            dgvUsuarios.Rows.Clear();
            users = BDUsuario.UsuariosTabla();
            users = users.OrderBy(x => x.id).ToList();
            foreach (Usuario i in users)
            {
                dgvUsuarios.Rows.Add(i.id,i.Nombre,i.Telefono,i.Contrasena,i.Rol);
            }            
        }
        public static int[] ids()
        {
            int[] ids = new int[users.Count];
            int c = 0;
            users=users.OrderBy(x => x.id).ToList();
            foreach (var id in users)
            {
                ids[c] = id.id;
                c++;
            }
            return ids;
        }
        public void eliminar()
        {
            try
            {
                if (Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value) != 1&&MessageBox.Show("¿Está seguro de eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes )
                {
                    BDUsuario.UsuarioEliminar(int.Parse(dgvUsuarios[0,c].Value + ""));
                    cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void agregar()
        {
            AgregarUsuario ac = new AgregarUsuario();
            ac.ShowDialog();
            if (ac.cierto)
                cargar();
        }
        public void editar()
        {
            AgregarUsuario ac = new AgregarUsuario();
            ac.setLbl("Editar Usuario", BDUsuario.ObtenerUsuario(int.Parse(dgvUsuarios[0,c].Value + "")));
            ac.ShowDialog();
            if (ac.cierto)
                cargar();
        }
        public void ajustar()
        {
            if (c >= dgvUsuarios.Rows.Count) { c = dgvUsuarios.Rows.Count - 1; }
            else if (c < 0) c = 0;
        }
        public void recorrertabla(int n)
        {
            try
            {
                c = dgvUsuarios.SelectedRows[0].Index;
                dgvUsuarios.Rows[c + n].Selected = true;
            }
            catch (Exception ex)
            {

            }
        }
        public void buscar(string txt)
        {
            dgvUsuarios.Rows.Clear();
            foreach (Usuario i in users)
            {
                if (i.Nombre.ToUpper().IndexOf(txt) != -1)
                {
                    dgvUsuarios.Rows.Add(i.id, i.Nombre, i.Telefono,i.Contrasena, i.Rol);
                }
            }
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            //cargar();
        }
        private void btnAgregar_MouseUp(object sender, EventArgs e)
        {
            agregar();
        }
        private void btnEditar_MouseUp(object sender, EventArgs e)
        {
            editar();
        }
        private void btnQuitar_MouseUp(object sender, EventArgs e)
        {
            eliminar();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {                
                case Keys.F12: { ajustar(); editar(); }
                    break;
                case Keys.Up:
                    {
                        try { recorrertabla(-1); c -= 1; }
                        catch (Exception ex) {  }
                    }
                    break;
                case Keys.Down:
                    {
                        try { recorrertabla(1); c += 1; }
                        catch (Exception ex) {  }
                    }
                    break;
                case Keys.Delete: { ajustar(); if (dgvUsuarios.RowCount > 0) eliminar(); }
                    break;
                case Keys.Add: { agregar(); }
                    break;
                default:                    
                    break;
            }
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {            
            validar.validationText(e);
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape) e.Handled = true;
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.RowCount > 0) c = dgvUsuarios.CurrentRow.Index;
        }
    }
}
