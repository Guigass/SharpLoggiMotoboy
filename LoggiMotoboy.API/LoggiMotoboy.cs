using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using LoggiMotoboy.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoggiMotoboy.API
{
    public class LoggiMotoboy : IDisposable
    {
        private readonly GraphQLHttpClient _client;

        private string _apiToken;
        private string _email;

        public bool IsLogged = false;

        public LoggiMotoboy(string apiUrl = "https://staging.loggi.com/graphql")
        {
            _client = new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer());
        }

        public LoggiMotoboy(string email, string password, string apiUrl = "https://staging.loggi.com/graphql")
        {
            _client = new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer());

            Login(email, password).Wait();
        }

        #region GetApiKey

        private async Task<GraphQLResponse<RetornoLogin>> Login(string email, string password)
        {
            var login = new GraphQLRequest
            {
                Query = @"
                mutation ($input: LoginMutationInput!) {
                    login(input: $input) {
                        user {
                            apiKey
                        }
                    }
                }",
                Variables = new
                {
                    input = new
                    {
                        email,
                        password
                    }
                }
            };

            var graphQLResponse = await _client.SendMutationAsync<RetornoLogin>(login);

            if (graphQLResponse.Data.Login.User == null)
                throw new Exception("Não foi possivel efetuar o login na loggi");


            _apiToken = graphQLResponse.Data.Login.User.ApiKey;
            _email = email;

            IsLogged = true;

            _client.HttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("ApiKey {0}:{1}", _email, _apiToken));

            return graphQLResponse;
        }

        #endregion

        #region Get Shops

        public async Task<GraphQLResponse<RetornoShops>> AllShops()
        {
            var allShops = new GraphQLRequest
            {
                Query = @"
                query {
                  allShops {
                    edges {
                      node {
                        name
                        pickupInstructions
                        pk
                        address {
                          pos
                          addressSt
                          addressData
                        }
                        chargeOptions {
                          label
                        }
                        externalId
                      }
                    }
                  }
                }"
            };

            var graphQLResponse = await _client.SendMutationAsync<RetornoShops>(allShops);

            IsLogged = true;

            return graphQLResponse;
        }

        #endregion

        #region Estimar Preços

        public async Task<GraphQLResponse<RetornoLogin>> EstimateCreateOrder()
        {
            var estimateCreateOrder = new GraphQLRequest
            {
                Query = @"
                query {
                  estimateCreateOrder(
                    shopId: 1
                    pickups: [{
                      address: {
                        lat: -23.5703022
                        lng: -46.6473154
                        address: ""Av.Paulista, 100 - Bela Vista, São Paulo - SP, Brasil""
                        complement: ""8o andar""
                      }
                    }]
                    packages: [{
                      pickupIndex: 0
                      recipient: {
                        name: ""Cliente A\""
                        phone: ""11912345678\""
                      }
                address: {
                        lat: -23.635334
                        lng: -46.529835
                        address: ""Av. Estados Unidos, 505 - Parque das Nações, Santo André - SP, Brasil\""
                        complement: ""Apto 133""
                      }
                      dimensions: {
                        width: 44
                        height: 38
                        weight: 3000
                        length: 38
                      }
                      charge: {
                        value: ""10.00""
                        method: 2
                        change: ""5.00""
                      }
                    }, {
                      pickupIndex: 0
                      recipient: {
                        name: ""Client B""
                        phone: ""11987654312""
                      }
                      address: {
                        lat: -23.635334
                        lng: -46.529835
                        address: ""Av. Brasil, 2000 - Jardim Paulista, São Paulo - SP, 01429-011""
                        complement: ""Apto""
                      }
                      dimensions: {
                        width: 10
                        height: 10
                        weight: 1000
                        length: 1
                      }
                      charge: {
                        value: ""10.00""
                        method: 2
                        change: ""5.00""
                      }
                    }, {
                      pickupIndex: 0
                      recipient: {
                        name: ""Client C""
                        phone: ""11987656789""
                      }
                      address: {
                        lat: -23.635334
                        lng: -46.529835
                        address: ""Rua Groenlândia, 12 - Jardim Europa, São Paulo - SP""
                        complement: ""Apto 21""
                      }
                      dimensions: {
                        width: 10
                        height: 10
                        weight: 1000
                        length: 15
                      }
                    }]
                )  {
                    totalEstimate {
                      totalCost
                      totalEta
                      totalDistance
                    }
                    ordersEstimate {
                      packages {
                        isReturn
                        cost
                        eta
                        outOfCoverageArea
                        outOfCityCover
                        originalIndex
                        resolvedAddress
                        originalIndex
                      }
                      optimized {
                        cost
                        eta
                        distance
                      }
                    }
                    packagesWithErrors {
                      originalIndex
                      error
                      resolvedAddress
                    }
                  }
                }",
                Variables = new
                {

                }
            };


            var graphQLResponse = await _client.SendMutationAsync<RetornoLogin>(estimateCreateOrder);

            _apiToken = graphQLResponse.Data.Login.User.ApiKey;

            return graphQLResponse;
        }

        #endregion

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
