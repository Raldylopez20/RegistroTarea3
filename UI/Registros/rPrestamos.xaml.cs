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
    public partial class rPrestamos : Window
    {
        private Prestamos Prestamos = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            PersonaIdComboBox.ItemsSource= PersonasBLL.GetList(p =>true);
            PersonaIdComboBox.SelectedValuePath= "PersonaId";
            PersonaIdComboBox.DisplayMemberPath="Nombres";
            this.DataContext= Prestamos;

        }
        //Limpiar ********************************************************************************
        private void Limpiar()
        {
            this.Prestamos = new Prestamos();
            this.DataContext = Prestamos;
        }
        //Validar ********************************************************************************
        private bool Validar()
        {
            bool esValido = true;
            if (PrestamoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        //Buscar ****************************************************************************************************
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var prestamos = PrestamosBLL.Buscar(Utilidades.ToInt(PrestamoIdTextBox.Text));
            if (Prestamos != null)
                this.Prestamos = prestamos;
            else
                this.Prestamos = new Prestamos();

            this.DataContext = this.Prestamos;
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

                var paso = PrestamosBLL.Guardar(Prestamos);
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
                if (PrestamosBLL.Eliminar(Utilidades.ToInt(PrestamoIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
