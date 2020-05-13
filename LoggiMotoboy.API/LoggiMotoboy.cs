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
        private readonly string urlHomologa = "https://staging.loggi.com/graphql/?=";
        private readonly string urlProducao = "https://www.loggi.com/graphql";

        private readonly GraphQLHttpClient _client;

        private string _apiToken;
        private string _email;

        public bool IsLogged = false;

        public LoggiMotoboy(string email, string password, string apiUrl = "https://www.loggi.com/graphql")
        {
            _client = new GraphQLHttpClient(apiUrl, new NewtonsoftJsonSerializer());

            _email = email;

            Login(email, password).Wait();
        }

        #region GetApiKey

        public async Task<GraphQLResponse<RetornoLogin>> Login(string email, string password)
        {
            var loginQL = new GraphQLRequest
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

            GraphQLResponse<RetornoLogin> graphQLResponse = null;
            graphQLResponse = await _client.SendMutationAsync<RetornoLogin>(loginQL);

            if (graphQLResponse.Errors == null)
            {
                _apiToken = graphQLResponse.Data.Login.User.ApiKey;

                IsLogged = true;

                _client.HttpClient.DefaultRequestHeaders.Add("Authorization", String.Format("ApiKey {0}:{1}", _email, _apiToken));
            }

            return graphQLResponse;
        }

        #endregion

        #region Estimar Preços

        public async Task<GraphQLResponse<EstimateCreateOrder>> EstimateCreateOrder(long shopID, string enderecoOrigem, string enderecoDestino)
        {
            if (!IsLogged)
                throw new Exception("Você precisa estar logado.");

            // TODO Colocar as variaveis fora da string da query.

            var estimateCreateOrderQL = new GraphQLRequest
            {
                Query = @"
                query {
                  estimateCreateOrder(
                    shopId: " + shopID + @"
                    pickups: [{
                      address: {
                        address: """ + enderecoOrigem + @"""
                      }
                    }]
                    packages: [{
                      pickupIndex: 0
                      recipient: {
                        name: ""Cliente A""
                        phone: ""11912345678""
                      }
                address: {
                        address: """ + enderecoDestino + @"""
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


            var graphQLResponse = await _client.SendMutationAsync<EstimateCreateOrder>(estimateCreateOrderQL);

            return graphQLResponse;
        }

        #endregion

        #region Lojas

        public async Task<GraphQLResponse<RetornoLogin>> CreateShop()
        {
            throw new Exception("Não Implementado");

            var CreateShop = new GraphQLRequest
            {
                Query = @"mutation {
                    createShop (input: {
                        name: ""Loja Integrando com a Loggi"",
                        addressCep: ""01418200"",
                        addressNumber: ""2400"",
                        addressComplement: ""apto. 61"",
                        phone: ""11999998888"",
                        companyId: 1003,
                        pickupInstructions: ""Entregar na recepção"",
                        numberOfRadialZones: 0,
                        externalId: ""integracao1019""
                    }) {
                        shop {
                            pk
                            name
                            address {
                                label
                    }
                    pickupInstructions
                }
                    }
                }",
                Variables = new
                {

                }
            };


            try
            {
                var graphQLResponse = await _client.SendMutationAsync<RetornoLogin>(CreateShop);
                return graphQLResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GraphQLResponse<AllShops>> AllShops()
        {
            if (!IsLogged)
                throw new Exception("Você precisa estar logado.");

            var AllShopsQL = new GraphQLRequest
            {
                Query = @"query {
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
                        }",
                Variables = new
                {

                }
            };


            try
            {
                var graphQLResponse = await _client.SendMutationAsync<AllShops>(AllShopsQL);
                return graphQLResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
