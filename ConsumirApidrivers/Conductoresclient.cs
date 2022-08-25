using Consumir;
using ConsumirApidrivers;
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

            //to do: logica/instancia que cree un objeto conductor


            //http://k8s-default-apisvc-0554af7ff0-49d70c805666de9b.elb.us-east-2.amazonaws.com:4000/drivers
            //this.JsonPost<dynamic>(uri: new Uri(this.request.EndPoint), @params: this.request.Body, token: this.token.Token, callback: excecuteCallback);
            //parms objeto conducdor

            //{"id":"1144475553","ID_type":"CC","first_name":"Julian","second_name":"Andres","surname":"Perez","second_surname":"Alcala","ID_transport":""}

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
