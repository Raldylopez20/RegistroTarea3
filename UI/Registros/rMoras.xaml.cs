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
using RegistroTarea3.DAL;


namespace RegistroTarea3.UI.Registros
{
    public partial class rMoras : Window
    {
        private Moras moras = new Moras();
        public rMoras()
        {
            InitializeComponent();
            PrestamoIdDetalleComboBox.ItemsSource= PrestamosBLL.GetList(p =>true);
            PrestamoIdDetalleComboBox.SelectedValuePath= "PrestamosId";
            PrestamoIdDetalleComboBox.DisplayMemberPath="PrestamoId";            
            this.DataContext = moras;
        }
        //----------------------------------[ CARGAR - Registro Detallado ]----------------------------------
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = moras;
        }
        //=====================================================[ LIMPIAR ]=====================================================
        private void Limpiar()
        {
            this.moras = new Moras();
            this.DataContext = moras;
        }
        //=====================================================[ Validar ]=====================================================
        private bool Validar()
        {
            bool Validado = true;
            

            if(moras.MoraId < 0)
            {
                Validado = false;
                MessageBox.Show("\nNo puede Guardar con el campo MorasId vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(moras.Fecha.Date < DateTime.Now.Date)
            {
                Validado = false;
                MessageBox.Show("\nNo puede Guardar con el campo Fecha Mora vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

           /* if(moras.Total <= 0)
            {
                Validado = false;
                MessageBox.Show("\nNo puede Guardar con el campo Monto vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            } */

           
            return Validado;

        } 


        //=====================================================[ BUSCAR ]=====================================================
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            //----------------------------------[ BUSCAR - Registro Detallado ]----------------------------------
            Moras encontrado = MorasBLL.Buscar(moras.MoraId);

            if (encontrado != null)
            {
                moras = encontrado;
                Cargar();
                MessageBox.Show("Articulo Encontrado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Esta Id de Articulo no fue encontrada.\n\nAsegurese que existe o cree una nueva.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
            }
        }
        //----------------------------------[ AGREGAR FILA - Registro Detallado ]----------------------------------
      
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            MorasDetalle morita = new MorasDetalle();
            moras.Detalle.Add( new MorasDetalle(morita.Id, PrestamoIdDetalleComboBox.SelectedIndex+1,morita.FechaMoraDetalle, Convert.ToSingle(ValorTextBox.Text)));

            Cargar();

            ValorTextBox.Clear();
        }
      
      
      /*  private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
         moras.Detalle.Add( new  MorasDetalle( moras.MorasId, Convert.ToInt32(PrestamoIdDetalleTextBox.Text), FechaMoraDatePicker.DisplayDate, Convert.ToSingle(ValorTextBox.Text)));

            Cargar();

            ValorTextBox.Clear();
        }  */


        //----------------------------------[ REMOVER FILA - Registro Detallado ]----------------------------------
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                moras.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        //=====================================================[ NUEVO ]=====================================================
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        //=====================================================[ GUARDAR ]=====================================================
     
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = MorasBLL.Guardar(moras);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Faltan Campos, por favor agregarlos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
     
     
     
     
       /*  private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = MorasBLL.Guardar(moras);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Errada", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        } */
        
        //=====================================================[ ELIMINAR ]=====================================================
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (MorasBLL.Eliminar(Utilidades.ToInt(MoraIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}