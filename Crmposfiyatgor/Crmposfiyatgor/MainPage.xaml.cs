using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace Crmposfiyatgor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            barkod.Focus();
            
        }
        SqlConnection sqlConnection;
        public void baglanti()
        {
            var sqladresvalue = Application.Current.Properties["sqladres"];
            var sqldbadvalue = Application.Current.Properties["sqldb"];
            var sqlkulvalue = Application.Current.Properties["sqlkul"];
            var sqlpwvalue = Application.Current.Properties["sqlpw"];
            string sqlconn = $"Data Source={sqladresvalue};Initial Catalog={sqldbadvalue};User ID={sqlkulvalue};Password={sqlpwvalue}";

            sqlConnection = new SqlConnection(sqlconn);
        }

        private async void barkod_Completed(object sender, EventArgs e)
        {
            try
            {
                baglanti();
                sqlConnection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM dbo.wwwFIYAT_GOR WHERE BARKOD = '{barkod.Text.Trim()}' ", sqlConnection);
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    stokadi.Text = dr["AD"].ToString();
                    tlfiyat.Text = dr["FIYAT"].ToString() + " TL";
                    dolarfiyat.Text = dr["DOLARFIYAT"].ToString() + " $";
                    eurofiyat.Text = dr["EUROFIYAT"].ToString() + " €";
                   // lblmiktar.Text = dr["MIKTAR"].ToString();
                }

                dr.Close();
                sqlConnection.Close();
                barkod.Focus();
                barkod.Text = " ";
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
                throw;
            }

        }

        private async void btnsqlayar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new sqlayar());
        }
    }
}
