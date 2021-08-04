#region

using System;

using Microsoft.Rest;

using Sherweb.Apis.Authorization;
using Sherweb.Apis.Distributor;
using Sherweb.Apis.Distributor.Factory;
using Sherweb.Apis.ServiceProvider;
using Sherweb.Apis.ServiceProvider.Factory;

#endregion

namespace Sherweb.SampleCode
{
    public class Program
    {
        private static string _baseUrl;

        private static string _clientId;

        private static string _clientSecret;

        private static string _subscriptionKey;

        private static string _acceptLanguageHeader;

        private static AuthorizationService _authorizationClient;

        private static IDistributorService _distributorClient;

        private static IServiceProviderService _serviceProviderClient;

        private static SubscriptionService _subscriptionService;

        private static DistributorService _distributionService;

        private static int _selectedMenuOptions;

        private static readonly MainMenu _menu = new MainMenu();

        private static void Main(string[] args)
        {
            _baseUrl = "https://apim-test-sherweb.azure-api.net";

            _clientId = "e60ee65d-b1b0-4d4f-abc7-2bb0c3eb4997";
            _clientSecret = "F42w8W-yUNaUCv-BEtcamQunhFp0_svRT-cff6qU";
            _subscriptionKey = "074497deb67d4d95924b5428160f01e7";

            // Optional. This should follow [RFC 7231, section 5.3.5: Accept-Language]: https://tools.ietf.org/html/rfc7231#section-5.3.5
            // Example: en, en-CA;q=0.8, fr-CA;q=0.7
            _acceptLanguageHeader = null;
            // Get Bearer Token from Authorization API
            _authorizationClient = new AuthorizationService(new Uri($"{_baseUrl}/auth"));
            Console.Clear();
            while (true)
            {
                _menu.PrintMenu(new MainMenu.MenuOptions());
                ProcessMainMenu(Console.ReadLine());
            }
        }

        private static IDistributorService BuildDistributorClient()
        {
            var apiUrl = $"{_baseUrl}/distributor/v1";

            var token = _authorizationClient.TokenMethod(
                _clientId,
                _clientSecret,
                "distributor", // Scope : distributor for Distributor API
                "client_credentials");

            // Instantiate Distributor API client using Bearer token
            var credentials = new TokenCredentials(token.AccessToken, "Bearer");

            var distributorConfiguration = new DistributorServiceConfiguration
            {
                Uri = new Uri(apiUrl),
                Credentials = credentials,
                RetryCount = 0
            };

            var distributorServiceFactory = new DistributorServiceFactory(
                distributorConfiguration,
                new SubscriptionKeyHandler(_subscriptionKey));

            return distributorServiceFactory.Create();
        }

        private static IServiceProviderService BuildServiceProviderClient()
        {
            var apiUrl = $"{_baseUrl}/service-provider/v1";

            var token = _authorizationClient.TokenMethod(
                _clientId,
                _clientSecret,
                "service-provider",
                "client_credentials");

            var credentials = new TokenCredentials(token.AccessToken, "Bearer");

            var serviceProviderConfiguration = new ServiceProviderServiceConfiguration
            {
                Uri = new Uri(apiUrl),
                Credentials = credentials,
                RetryCount = 0
            };

            var serviceProviderServiceFactory = new ServiceProviderServiceFactory(
                serviceProviderConfiguration,
                new SubscriptionKeyHandler(_subscriptionKey));

            return serviceProviderServiceFactory.Create();
        }

        public static void ProcessMainMenu(string input)
        {
            if (int.TryParse(input, out _selectedMenuOptions))
            {
                switch (_selectedMenuOptions)
                {
                    case (int)MainMenu.MenuOptions.Distributor:
                    {
                        ProcessDistribution();
                        break;
                    }
                    case (int)MainMenu.MenuOptions.ServiceProvider:
                    {
                        ProcessServiceProvider();
                        break;
                    }
                    case 0:
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Try again!!");
                        break;
                    }
                }
            }
        }

        private static void ProcessDistribution()
        {
            _distributorClient = BuildDistributorClient();
            _distributionService = new DistributorService(_distributorClient);
            while (true)
            {
                _menu.PrintMenu(new MainMenu.DistributorOption());
                var input = Console.ReadLine();
                if (int.TryParse(input, out _selectedMenuOptions))
                {
                    switch (_selectedMenuOptions)
                    {
                        case (int)MainMenu.DistributorOption.GetPayableCharges:
                        {
                            _distributionService.GetPayableCharges();
                            break;
                        }
                        case 0:
                        {
                            return;
                        }
                        default:
                        {
                            Console.WriteLine("Try again!!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Try again!!");
                }
            }
        }

        private static void ProcessServiceProvider()
        {
            _serviceProviderClient = BuildServiceProviderClient();
            _subscriptionService = new SubscriptionService(_serviceProviderClient);

            while (true)
            {
                _menu.PrintMenu(new MainMenu.ServiceProviderOption());
                var input = Console.ReadLine();
                if (int.TryParse(input, out _selectedMenuOptions))
                {
                    switch (_selectedMenuOptions)
                    {
                        case (int)MainMenu.ServiceProviderOption.GetCustomers:
                        {
                            _subscriptionService.GetCustomers();
                            break;
                        }
                        case (int)MainMenu.ServiceProviderOption.GetSubscriptions:
                        {
                            Console.WriteLine("Enter CustomerId :");
                            var customerId = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(customerId))
                            {
                                _subscriptionService.GetSubscriptions(new Guid(customerId));
                            }

                            break;
                        }
                        case (int)MainMenu.ServiceProviderOption.GetSubscriptionsAmendmentStatus:
                        {
                            Console.WriteLine("Enter Subscription AmendmentId :");
                            var subscriptionsAmendmentId = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(subscriptionsAmendmentId))
                            {
                                _subscriptionService.GetAmendmentStatus(new Guid(subscriptionsAmendmentId));
                            }

                            break;
                        }
                        case 0:
                        {
                            return;
                        }
                        default:
                        {
                            Console.WriteLine("Try again!!");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Try again!!");
                }
            }
        }
    }
}