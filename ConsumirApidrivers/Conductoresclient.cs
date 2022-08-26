using Consumir;
using ConsumirApidrivers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumirApidrivers
{
    public class Conductoresclient : HttpClientJwtBase<TokenBody, TokenResult>
    {
        public Conductoresclient(TokenJwtBase<TokenBody> tokenData, TokenResult tokenResult) : base(tokenData, tokenResult)
        {
        }

        public void crearconductor()
        {
            this.getToken(callback: ResultToken);

        }

        private void ResultToken(TokenResult arg1, Exception arg2)
        {
            if (arg2 != null)
            {

                return;
            }

            this.token = arg1;
            //ASD
            //to do: logica/instancia que cree un objeto conductor
            Driver driver = new Driver()
            {
                id = "1128061906",
                ID_type = "CC",
                first_name = "Dany",
                second_name = "Daniel",
                surname = "Vargas",
                second_surname = "Urieles",
                ID_transport = "123"
               


            };

            //creando json string o body de peticion, convierto la instacia
            var jsonconductor = JsonConvert.SerializeObject(driver);
            
            this.JsonPost<dynamic>(uri: new Uri("https://d07d-181-139-121-211.ngrok.io/drivers"), @params: jsonconductor, token: this.token.Token, callback: excecuteCallback);
            //parms objeto conducdor
            //ASD
            

        }
        private void excecuteCallback(dynamic data, Exception ex)
        {

            if (ex != null)
            {

                return;

            }



        }




    }
}
