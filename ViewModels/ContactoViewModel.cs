using AppComida.Models;
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
        IEmail email;

        // AMEL: Objeto que controla los cambios de las propiedades del viewmodel
        public event PropertyChangedEventHandler PropertyChanged;

        // AMEL: Funcion que se llama cuando se cambia una propiedad
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // AMEL: Comando para enviar email
        public Command SendEmail { get; }

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

        public async void SendEmailAsync(object obj)
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

        public ContactoViewModel(IEmail email)
        {
            this.email = email;
            SendEmail = new Command(SendEmailAsync);
            Damaris = new Damaris() 
            { 
                nombre="Damaris Alvarado",
                matricula="19480123",
                correo="damaris@gmail.com",
                telefono="1234567890"
            };
            Samantha = new Samantha() 
            {
                nombre = "Samantha Flores",
                matricula = "19480321",
                correo = "samantha@gmail.com",
                telefono = "1234567890"
            };
            Amel = new Amel() 
            {
                nombre = "Amel Delgado",
                matricula = "19720124",
                correo = "amel@gmail.com",
                telefono = "1234567890"
            };
        }
    }
}
