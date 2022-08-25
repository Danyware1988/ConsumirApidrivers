
using Consumir;
using ConsumirApidrivers;
using System.Text.Json;

//defino la url del api
var url = "http://k8s-default-apisvc-0554af7ff0-49d70c805666de9b.elb.us-east-2.amazonaws.com:4000/drivers";

//ignorar mayus y minus del Json y pueda deserializar

JsonSerializerOptions options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
TokenBody tokenBody = new TokenBody { User = "puertobahia", Password = "puertobahia2022" };


TokenResult tokenResult = new TokenResult();

var tokenJwtBase = new TokenJwtBase<TokenBody>(@"https://d07d-181-139-121-211.ngrok.io/jwtToken", tokenBody);



//llamado de httpclient
var httpclient = new Conductoresclient(tokenJwtBase, tokenResult);
httpclient.crearconductor();
Thread.Sleep(3000000);









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