using Medii_Android.Models;

namespace Medii_Android;

public partial class ServiciuPage : ContentPage
{
    Programari sl;
    public ServiciuPage(Programari slist)
    {
        InitializeComponent();
        sl = slist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Servicii)BindingContext;
        await App.Database.SaveProductAsync(serviciu);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var serviciu = (Servicii)BindingContext;
        await App.Database.DeleteProductAsync(serviciu);
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProductsAsync();
    }
    
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Servicii p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Servicii;
            var lp = new ListService()
            {
                ProgramariID = sl.ID,
                ServiciuID = p.ID
            };
            await App.Database.SaveListProductAsync(lp);
            p.ListServices = new List<ListService> { lp };
            await Navigation.PopAsync();
        }
    }

    }