using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta.Ventanas;
using System.Text.RegularExpressions;
using Punto_de_venta.Base_de_datos;

namespace Punto_de_venta.Clases
{
    class ClassValidation
    {
        // ----- Códigos Regex ----- //
        //public Regex letterRGX = new Regex("^[a-zA-Z_áéíóúñ ]*[^ \f\n\r\t\v]$");
        public Regex letterRGX = new Regex("^[a-zA-Z_áéíóúñ ]*$");
        public Regex numberDecimalRGX = new Regex("^[0-9]+([.][0-9]{1,3})?$");
        public Regex numberRGX = new Regex("^[0-9]+?$");
        public Regex defaultRGX = new Regex("^[a-zA-Z0-9-_áéíóúÁÉÍÓÚñÑ.#, ]*$");
        public Regex fechaRGX = new Regex("^(?:[012]?[0-9]|3[01])[./-](?:0?[1-9]|1[0-2])[./-](?:[0-9]{2}){1,2}$");

        // ----- Escribir letras ----- //
        public void validationText(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;            
            else
                e.Handled = true;
        }
        public void validationTextandNumber(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;            
            else if (Char.IsNumber(e.KeyChar))
                e.Handled = false;            
            else
                e.Handled = true;
        }
        // ----- Escribir números con decimales ----- //
        public void validationNumber(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else if (e.KeyChar == 46)
                e.Handled = false;
            else
                e.Handled = true;
        }

        // ----- Escribir números enteros ----- //
        public void validationOnlyNumber(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }

        // ----- Escribir fecha con slash (/) ----- //
        public void validationFecha(KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == 47)
                e.Handled = false;
            else
                e.Handled = true;
        }

        // ----- Desactivar teclado con campo lleno ----- //
        public void DesactivarTeclado(TextBox txt, int n, KeyPressEventArgs e)
        {
            if (txt.Text.Length >= n)
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;  
        }

        // ----- Validar formato de los campos de texto ----- //
        public void validationTxtField(TextBox txt, Regex rgx)
        {
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.Focus();
                throw new Exception("Debe llenar el campo " + txt.Name.Replace("txt", "") + " para poder continuar");
            }
            else if (!rgx.IsMatch(txt.Text))
            {
                txt.Focus();
                throw new Exception("Revise que el formato del campo " + txt.Name.Replace("txt", "") + " sea correcto");
            } 
        }

        // ----- Validar formato de las listas desplegables ----- //
        public void validationCmb(ComboBox cmb) {
            if (cmb.Text.Equals("Seleccionar " + cmb.Name.Replace("cmb", "")) || (string.IsNullOrEmpty(cmb.Text)))
            {
                cmb.Focus();
                throw new Exception("Debe seleccionar un valor de la lista " + cmb.Name.Replace("cmb", ""));
            }
        }

        // ----- Activar ícono de error en los campos de texto ----- //
        public void errorActive(TextBox txt, Regex rgx, ErrorProvider error)
        {
            if (string.IsNullOrEmpty(txt.Text))
                error.SetError(txt, "Campo vacío");
            else if (!rgx.IsMatch(txt.Text))
                error.SetError(txt, "Formato del campo inválido");
            else
                error.SetError(txt, "");
        }
        public void errorActive(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) throw new Exception("El campo "+txt.Name.Replace("txtContrasena","Contraseña")+" está vacío");
        }
        // ----- Activar ícono de error en las listas desplegables ----- //
        public void errorActiveCmb(ComboBox cmb, ErrorProvider error)
        {
            if (cmb.Text.Equals("Seleccionar " + cmb.Name.Replace("cmb","")) || (string.IsNullOrEmpty(cmb.Text)))
                error.SetError(cmb, "Selecciona un valor");
            else
                error.SetError(cmb, "");
        }
        public void noExiste(string cb)
        {
            if (!BDArticulo.existe(cb)) throw new Exception("No se encontró el artículo");
        }
    }
}
