
using System.Text.Json;

//defino la url del api
var url = "http://k8s-default-apisvc-0554af7ff0-49d70c805666de9b.elb.us-east-2.amazonaws.com:4000/drivers";

//ignorar mayus y minus del Json y pueda deserializar

JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };


using (var httpClient = new HttpClient())

//GET
{

    //uso el metodo GetAsync pasando el url 
    var response = await httpClient.GetAsync(url);

    //si la respuesta fue exitosa:
    if (response.IsSuccessStatusCode)
    //leer datos

    {
        //b clase para leer la respuesta del contenido de la peticion
        var conten = await response.Content.ReadAsStringAsync();
        //a clase para deserializar los datos
        var drivers = JsonSerializer.Deserialize<List<conductores>>(conten, options);

        //como uso consola imprimo
        foreach (var item in drivers)
        {
            //si respuesta correcta = deserializar e imprima
            Console.WriteLine($"{item.ID}{item.id_type}{item.first_name}{item.second_name}{item.surname}{item.second_surname}");
        }

    }
    else Console.WriteLine("Error");

    //FIN GET

    //INICIO POST
    //var response = await.httpClient.PostAsJsonAsync(url, new conductores { ID = "1128061906", id_type = "CC", first_name = "DANY" });
    //if (response.IsSuccessStatusCode)
    //    Console.WriteLine("Conductor agregado");
    //else Console.WriteLine("Error");
    //FIN POST

    Console.ReadKey();
}

//creando clase superior
public class conductores
{
    //3 strings dentro del Json
    public string ID { get; set; }
    public string id_type { get; set; }
    public string first_name { get; set; }
    public string second_name { get; set; }
    public string surname { get; set; }
    public string second_surname { get; set; }

 

}