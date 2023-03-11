using LojaNet.DAL.Data;
using LojaNet.Models.Entidades;
using LojaNet.Models.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LojaNet.DAL
{
    public class PedidoDAL : IPedidoData
    {
        public int Alterar(Pedido entidade)
        {
            return DbHelper.ExecutarComando("PedidoAlterar", entidade);
        }

        public int Criar(Pedido entidade)
        {
            using var conn = new SqlConnection(DbHelper.Conexao);
            conn.Open();

            var txn = conn.BeginTransaction();

            try
            {
                var cmdPedido = new SqlCommand(@"PedidoCriar", conn);
                cmdPedido.CommandType = CommandType.StoredProcedure;
                cmdPedido.Parameters.AddWithValue("@Id", entidade.Id);
                cmdPedido.Parameters.AddWithValue("@UsuarioId", entidade.UsuarioId);

                cmdPedido.Transaction = txn;

                cmdPedido.ExecuteNonQuery();

                foreach (var item in entidade.PedidoItems)
                {
                    var cmdPedidoItem = new SqlCommand(@"PedidoItemCriar", conn);
                    cmdPedidoItem.CommandType = CommandType.StoredProcedure;
                    cmdPedidoItem.Parameters.AddWithValue("@Id", item.Id);
                    cmdPedidoItem.Parameters.AddWithValue("@Preco", item.Preco);
                    cmdPedidoItem.Parameters.AddWithValue("@ProdutoId", item.ProdutoId);
                    cmdPedidoItem.Parameters.AddWithValue("@PedidoId", entidade.Id);

                    cmdPedidoItem.Transaction = txn;

                    cmdPedidoItem.ExecuteNonQuery();
                }

                txn.Commit();

                return 1;
            }
            catch (Exception ex)
            {
                txn.Rollback();
                throw new ApplicationException(ex.Message);
            }
        }

        public int Deletar(string id)
        {
            return DbHelper.ExecutarComando("PedidoDeletar", new { Id = id });
        }

        public Pedido ObterPorId(string id)
        {
            return DbHelper.GetEntidade<Pedido>("PedidoObterPorId", new { Id = id });
        }

        public IEnumerable<Pedido> ObterTodos(string usuarioId)
        {
            return DbHelper.GetColecao<Pedido>("PedidoObterTodos", new { UsuarioId = usuarioId });
        }
    }
}
