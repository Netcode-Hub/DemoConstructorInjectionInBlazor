using Microsoft.AspNetCore.Components;

namespace DemoConstructorInjectionInBlazor.Components.Pages
{
    public partial class Home
    {
        private readonly HttpClient httpClient;
        private List<Division> Divisions { get; set; } = [];
        public Home(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            httpClient.BaseAddress = new Uri("http://localhost:5000/api/");
            Divisions = httpClient.GetFromJsonAsync<List<Division>>("academic/get-divisions").Result!;
        }


        public List<Division> PublicDivisions = [];
        protected override void OnInitialized()
        {
            PublicDivisions = Divisions.Take(3).ToList();
        }
    }
     


    public class Division { public int Id { get; set; } public int Number { get; set; } }
}
