﻿using GraphQL;
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

        public async Task<GraphQLResponse<AllShops>> AllShops()
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

            var graphQLResponse = await _client.SendMutationAsync<AllShops>(allShops);

            IsLogged = true;

            return graphQLResponse;
        }

        #endregion

        #region Estimar Preços

        public async Task<GraphQLResponse<EstimateCreateOrder>> EstimateCreateOrder(int shopId, List<Pickup> pickups, List<Package> packages)
        {
            var estimateCreateOrder = new GraphQLRequest
            {
                Query = @"
                query estimateCreateOrder ($shopId: Int!, $pickups: [Pickup]!, $packages: [Packages]!){
                  estimateCreateOrder(
                    shopId: $shopId
                    pickups: $pickups
                    packages: $packages
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
                    shopId,
                    pickups,
                    packages
                }
            };


            var graphQLResponse = await _client.SendQueryAsync<EstimateCreateOrder>(estimateCreateOrder);

            return graphQLResponse;
        }

        #endregion

        #region Criar Pedido

        public async Task<GraphQLResponse<CreateOrder>> CreateOrder(CreateOrderInput createOrderInput)
        {
            var estimateCreateOrder = new GraphQLRequest
            {
                Query = @"mutation ($createOrderInput: createOrderMutationInput!) {
                          createOrder(input: $createOrderInput) {
                            success
                            shop
                        {
                            pk
                              name
                        }
                        orders {
                              pk
                              trackingKey
                              packages {
                                pk
                                status
                                pickupWaypoint {
                                  index
                                  indexDisplay
                                  eta
                                  legDistance
                                }
                                waypoint {
                                  index
                                  indexDisplay
                                  eta
                                  legDistance
                                }
                              }
                            }
                            errors {
                              field
                              message
                            }
                          }
                        }",
                Variables = new
                {
                    createOrderInput
                }
            };


            var graphQLResponse = await _client.SendQueryAsync<CreateOrder>(estimateCreateOrder);

            return graphQLResponse;
        }

        #endregion

        #region Consulta Pedido

        public async Task<GraphQLResponse<RetrieveOrderPK>> RetrieveOrderWithPk(long id)
        {
            var allShops = new GraphQLRequest
            {
                Query = @"
                query retrieveOrderWithPk ($id: Int!) {
                  retrieveOrderWithPk(orderPk: $id) {
                    status
                    statusDisplay
                    originalEta
                    totalTime
                    pricing {
                      totalCm
                    }
                    packages {
                      pk
                      shareds {
                        edges {
                          node {
                            trackingUrl
                          }
                        }
                      }
                    }
                    currentDriverPosition {
                      lat
                      lng
                      currentWaypointIndex
                      currentWaypointIndexDisplay
                    }
                  }
                }",
                Variables = new
                {
                    id
                }
            };

            var graphQLResponse = await _client.SendMutationAsync<RetrieveOrderPK>(allShops);

            IsLogged = true;

            return graphQLResponse;
        }

        public async Task<GraphQLResponse<RetrieveOrdersWithTrackingKey>> RetrieveOrdersWithTrackingKey(string traking)
        {
            var allShops = new GraphQLRequest
            {
                Query = @"
                query retrieveOrdersWithTrackingKey ($traking: String!) {
                  retrieveOrdersWithTrackingKey(trackingKey: $traking) {
                    status
                    statusDisplay
                    originalEta
                    totalTime
                    pricing {
                      totalCm
                    }
                    packages {
                      pk
                      shareds {
                        edges {
                          node {
                            trackingUrl
                          }
                        }
                      }
                    }
                    currentDriverPosition {
                      lat
                      lng
                      currentWaypointIndex
                      currentWaypointIndexDisplay
                    }
                  }
                }",
                Variables = new
                {
                    traking
                }
            };

            var graphQLResponse = await _client.SendMutationAsync<RetrieveOrdersWithTrackingKey>(allShops);

            IsLogged = true;

            return graphQLResponse;
        }

        #endregion

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
