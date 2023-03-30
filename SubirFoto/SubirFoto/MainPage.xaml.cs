using Dapper;
using MySqlConnector;
using SubirFoto.Models;
using System.Data;

namespace SubirFoto;
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}
    IDbConnection connection = new MySqlConnection("Server = 89.117.7.154; Port = 3306; database = u553439813_serte; user id = u553439813_sopor; password = 9KX$2mnh");
    string RutaFoto = string.Empty;
    private async void OnSelectPhotoClicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Seleccionar foto"
            });

            if (photo != null)
            {
                SelectedPhotoImage.Source = ImageSource.FromFile(photo.FullPath);
                RutaFoto= photo.FullPath;
            }
        }
        catch (Exception ex)
        {
            // Manejar errores aquí
        }
    }
    private async void OnSelectSubirFoto(object sender, EventArgs e)
    {
        try
        {
            var foto = new Foto
            {
                _Imagen = File.ReadAllBytes(RutaFoto)

            };
            string consulta = "INSERT INTO Cumple (Imagen) VALUES (@_Imagen)";
            int filasInsertadas = await connection.ExecuteAsync(consulta, foto);
        }
        catch (Exception ex)
        {
            // Manejar errores aquí
        }
    }
}

