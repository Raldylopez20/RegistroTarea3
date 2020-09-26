using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroTarea3.BLL;
using RegistroTarea3.Entidades;

namespace RegistroTarea3.UI.Registros
{
    public partial class rPersonas : Window
    {
        private Personas Personas = new Personas();
        public rPersonas()
        {
            InitializeComponent();
            this.DataContext = Personas;
        }
        //Limpiar ****************************************************************************************************
        private void Limpiar()
        {
            this.Personas = new Personas();
            this.DataContext = Personas;
        }
        //Validar ****************************************************************************************************
        private bool Validar()
        {
            bool esValido = true;
            if (PersonaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        //Buscar ****************************************************************************************************
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var personas = PersonasBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text));
            if (Personas != null)
                this.Personas = personas;
            else
                this.Personas = new Personas();

            this.DataContext = this.Personas;
        }
        //Nuevo ****************************************************************************************************
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //Guardar ****************************************************************************************************
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = PersonasBLL.Guardar(Personas);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //Eliminar ****************************************************************************************************
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (PersonasBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //************************************************************************************************************************
    }
}
