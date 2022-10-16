using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Crmposfiyatgor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sqlayar : ContentPage
    {
        public sqlayar()
        {
            InitializeComponent();
            
        }

        public string sqlconn2;
        private SqlConnection sqlConnection;
        private async void concontrol_Clicked(object sender, EventArgs e)
        {
            try
            {

                sqladres.Text = Application.Current.Properties["sqladres"].ToString();
                sqldbad.Text = Application.Current.Properties["sqldb"].ToString();
                sqlkul.Text = Application.Current.Properties["sqlkul"].ToString();
                sqlpw.Text = Application.Current.Properties["sqlpw"].ToString();
                sqlconn2 = $"Data Source={sqladres.Text};Initial Catalog={sqldbad.Text};User ID={sqlkul.Text};Password={sqlpw.Text}";
                sqlConnection = new SqlConnection(sqlconn2);
                sqlConnection.Open();
                await App.Current.MainPage.DisplayAlert("İnfo", "Bağlantı Sağlandı", "Ok");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }

        }

        private async void consave_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["sqladres"] = sqladres.Text;
            Application.Current.Properties["sqldb"] = sqldbad.Text;
            Application.Current.Properties["sqlkul"] = sqlkul.Text;
            Application.Current.Properties["sqlpw"] = sqlpw.Text;

            await Application.Current.SavePropertiesAsync();
            await App.Current.MainPage.DisplayAlert("info", "Kayıt Başarılı", "Ok");

        }
    }
}