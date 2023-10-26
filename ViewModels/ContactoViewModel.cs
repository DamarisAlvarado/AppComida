﻿using AppComida.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppComida.ViewModels
{
    public class ContactoViewModel : INotifyPropertyChanged
    {
        #region AMEL: DEFINICION DE PROPIEDADES

        // AMEL: Comando para enviar email

        public Command SendEmail { get; }

        // AMEL: Interfaz para abrir servicio de Email
        readonly IEmail email;

        public Command OpenEmail { get; }

        // AMEL: Objeto que controla los cambios de las propiedades del viewmodel
        public event PropertyChangedEventHandler PropertyChanged;

        // AMEL: Propiedad que almacena los datos de nosotros
        private Damaris _damaris;
        public Damaris Damaris
        {
            get => _damaris;
            set
            {
                _damaris = value;
                OnPropertyChanged();
            }
        }

        private Samantha _samantha;
        public Samantha Samantha
        {
            get => _samantha;
            set
            {
                _samantha = value;
                OnPropertyChanged();
            }
        }

        private Amel _amel;
        public Amel Amel
        {
            get => _amel;
            set
            {
                _amel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region AMEL: DEFINICION DE METODOS

        // AMEL: Metodo para abrir la aplicacion de correos por defecto y enviar el email.
        public async void SendEmailAsync(object obj)
        {
            if (email.IsComposeSupported)
            {
                switch (obj.GetType().Name.ToString())
                {
                    case "Damaris":
                        await email.ComposeAsync("Subject", "Body", _damaris.correo.ToString());
                        break;

                    case "Samantha":
                        await email.ComposeAsync("Subject", "Body", _samantha.correo.ToString());
                        break;

                    case "Amel":
                        await email.ComposeAsync("Subject", "Body", _amel.correo.ToString());
                        break;
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Tu dispositivo no permite enviar emails", "OK");
            }
        }

        // AMEL: Metodo que abre el XAML para escribir el mesanje que queremos enviar
        public async void OpenEmailComposer(object obj)
        {
            var dynamicObj = obj as dynamic;
            if (Email.Default.IsComposeSupported) await App.Current.MainPage.Navigation.PushAsync(new Componer(dynamicObj.correo));
            else await App.Current.MainPage.DisplayAlert("Error", "Tu dispositivo no tiene una aplicación por default para envios de emails", "Entendido");
        }

        // AMEL: Funcion que se llama cuando se cambia una propiedad
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // AMEL: Si propertyName cambia se invocará PropertyChanged
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region AMEL: CONSTRUCTOR ContactoViewModel
        public ContactoViewModel()
        {

            // Creación de comandos
            OpenEmail = new Command(OpenEmailComposer);

            #region AMEL: Objetos que contiene nuestros datos
            Damaris = new Damaris() 
            { 
                nombre="Damaris Alvarado",
                matricula= "19480887",
                correo= "L19480887@nuevoleon.tecnm.mx",
                telefono="8764328787"
            };
            Samantha = new Samantha() 
            {
                nombre = "Samantha Flores",
                matricula = "19480820",
                correo = "L19480820@nuevoleon.tecnm.mx",
                telefono = "5430985656"
            };
            Amel = new Amel() 
            {
                nombre = "Amel Delgado",
                matricula = "19720124",
                correo = "L19720124@nuevoleon.tecnm.mx",
                telefono = "0985643222"
            };
            #endregion
        }
        #endregion
    }
}
