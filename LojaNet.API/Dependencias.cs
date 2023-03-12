using LojaNet.BLL;
using LojaNet.Models.Interfaces;

namespace LojaNet.API
{
    public static class Dependencias
    {
        public static void Injetar(IServiceCollection services)
        {
            services.AddScoped<TokenHelper>();

            services.AddScoped<UsuarioBLL>();
            services.AddScoped<ProdutoBLL>();
            services.AddScoped<PedidoBLL>();
            services.AddScoped<PedidoItemBLL>();
        }
    }
}
