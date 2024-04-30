using Microsoft.Extensions.DependencyInjection;
using ParkCinema.Application.Abstraction.Services.Payment.PayPal;
using ParkCinema.Application.Abstraction.Services.Payment.Stripe;
using ParkCinema.Application.Abstraction.Services.Payment;
using ParkCinema.Application.Abstraction.Services.Stroge;
using ParkCinema.Application.Abstraction.Services.Stroge.Local;
using ParkCinema.Infrastructure.Services;
using ParkCinema.Infrastructure.Services.Stroge;
using ParkCinema.Infrastructure.Services.Stroge.Local;
using Stripe;
using ParkCinema.Infrastructure.Services.Payment.Stripe;
using ParkCinema.Infrastructure.Services.Payment.PayPal;
using ParkCinema.Application.Abstraction.Services.QrCode;
using ParkCinema.Infrastructure.Services.QrCode;
using ParkCinema.Application.Abstraction.Services.Cryptography;
using ParkCinema.Infrastructure.Services.Cryptography;
using Microsoft.IdentityModel.Tokens;
using ParkCinema.Application.Abstraction.Services;
using ParkCinema.Infrastructure.Services.TokenResponseJwt;

namespace ParkCinema.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        //File
        //services.AddScoped<IStorgeService, StorgeService();
        services.AddScoped<IStorageFile, StorageFile>();
        services.AddScoped<ILocalStorage, LocalStorage>();

        //Payment
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IStripePayment, StripeService>();
        services.AddScoped<IPayPalPayment, PayPalService>();
        services.AddScoped<TokenService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<ChargeService>();
        //---------------------------------
        services.AddPayment<StripeService>();

        //user
        services.AddScoped<ITokenHandler, TokkenHandler>();

        //QRCode
        services.AddScoped<IQRCoderServıces, QRCoderServıces>();

        //Cryptography 
        services.AddScoped<IEncryptionService, EncryptionService>();
    }

    public static void AddStorageFile<T>(this IServiceCollection services) where T : Storage, IStorageFile
    {                                                                               //class
        services.AddScoped<IStorageFile, T>();
    }

    public static void AddPayment<T>(this IServiceCollection services) where T : class, IPayment
    {
        services.AddScoped<IPayment, T>();
    }
}
