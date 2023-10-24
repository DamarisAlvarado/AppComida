namespace AppComida.ViewModels
{
    public class MenuViewModel
    {
        // AMEL a DAMARIS: Esta variable almacena el nombre de la imagen que mostrará en el menu.
        public string BackgroundImage { get; set; }

        // AMEL a DAMARIS: Este constructor se inicia cuando se inicia la ventana
        public MenuViewModel() 
        {
            // AMEL: Primero comprueba si el dispositivo es Android o iOS
            if (DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Si lo es... cargara "fondo.jpg"
                BackgroundImage = "fondo.jpg";
            }
            else 
            {
                // Si no lo es... cargará "windows.png"
                BackgroundImage = "windows.png";
            }
        }
    }
}
