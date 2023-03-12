using LojaNet.BLL;
using LojaNet.Models.Interfaces;

namespace LojaNet.API
{
    public static class Dependencias
    {
        public static void Injetar(IServiceCollection services)
        {
            services.AddScoped<TokenHelper>();

            services.AddScoped<IUsuarioData, UsuarioBLL>();
            services.AddScoped<IProdutoData, ProdutoBLL>();
            services.AddScoped<IPedidoData, PedidoBLL>();
            services.AddScoped<IPedidoItemData, PedidoItemBLL>();
        }
    }
}
