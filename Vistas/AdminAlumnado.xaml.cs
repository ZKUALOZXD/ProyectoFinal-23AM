﻿using ProyectoFinal_23AM.Entities;
using ProyectoFinal_23AM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal_23AM.Vistas
{
    /// <summary>
    /// Lógica de interacción para AdminAlumnado.xaml
    /// </summary>
    public partial class AdminAlumnado : Window
    {
        public AdminAlumnado()
        {
            InitializeComponent();
            GetAlumnosTable();
            GetGradoTable();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Sistema main = new Sistema();
            main.Show();
            Close();
        }
        AlumnadoServices services = new AlumnadoServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtPkMatricula.Text == "")
            {
                Alumno alumno = new Alumno()
                {
                    Nombre = txtNombre.Text + " " + txtApellido.Text,
                    FkGrado = int.Parse(txtGrado.Text)
                };

                services.AddAlumno(alumno);
                MessageBox.Show("Alumno agregado");
                txtNombre.Clear();
                txtApellido.Clear();
                txtGrado.Clear();
                GetAlumnosTable();
                GetGradoTable();
            }
            else
            {
                int userId = Convert.ToInt32(txtPkMatricula.Text);
                Alumno alumno = new Alumno()
                {
                    PkMatricula = userId,
                    Nombre = txtNombre.Text + " " + txtApellido.Text,
                    FkGrado = int.Parse(txtGrado.Text)
                };
                services.UpdateAlumno(alumno);
                MessageBox.Show("Alumno modificado");
                txtNombre.Clear();
                txtApellido.Clear();
                txtGrado.Clear();
                LabelNombre.Visibility = Visibility.Hidden;
                txtNombreCompleto.Visibility = Visibility.Hidden;
                txtPkMatricula.Clear();
                GetAlumnosTable();
                GetGradoTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Alumno alumno = new Alumno();
            LabelNombre.Visibility = Visibility.Visible;
            txtNombreCompleto.Visibility = Visibility.Visible;

            alumno = (sender as FrameworkElement).DataContext as Alumno;
            txtPkMatricula.Text = alumno.PkMatricula.ToString();
            txtNombreCompleto.Text  = alumno.Nombre.ToString();
            txtGrado.Text = alumno.FkGrado.ToString();
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (txtPkMatricula.Text != "")
            {
                int userId = Convert.ToInt32(txtPkMatricula.Text);
                Alumno alumno = new Alumno();
                alumno.PkMatricula = userId;
                services.DeleteAlumno(userId);
                MessageBox.Show("Alumno Eliminado");

                txtNombre.Clear();
                txtApellido.Clear();
                LabelNombre.Visibility = Visibility.Hidden;
                txtNombreCompleto.Visibility = Visibility.Hidden;
                txtPkMatricula.Clear();
                txtGrado.Clear();
                GetAlumnosTable();
                GetGradoTable();
            }
            else
            {
                MessageBox.Show("Primero selecciona a un Alumnno");
            }
        }
        public void GetAlumnosTable()
        {
            UserTable.ItemsSource = services.GetAlumnos();

        }
        public void GetGradoTable()
        {
            UserTable.ItemsSource = services.GetGrado();
        }
        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            AdminAlumnado alumno = new AdminAlumnado();
            alumno.Show();
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            LabelNombre.Visibility = Visibility.Hidden;
            txtNombreCompleto.Visibility = Visibility.Hidden;
            txtPkMatricula.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtGrado.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminCalif calif = new AdminCalif();
            calif.Show();
            Close();
        }
    }
}
