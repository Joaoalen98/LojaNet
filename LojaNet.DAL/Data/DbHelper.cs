using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LojaNet.DAL.Data
{
    public static class DbHelper
    {
        public static readonly string Conexao = "server=LAPTOP-MLO9QO6J\\SQLEXPRESS;database=LojaNet;integrated security=true;trust server certificate=true;";
    
        private static SqlConnection GetDbConection()
        {
            return new SqlConnection(Conexao);
        }

        public static IEnumerable<T> GetColecao<T>(
            string query, object parametros, CommandType commandType = CommandType.StoredProcedure)
        {
            IEnumerable<T> colecao;
            using (var conn = GetDbConection())
            {
                colecao = conn.Query<T>(query, parametros, commandType: commandType);
            }
            return colecao;
        }

        public static T GetEntidade<T>(
            string query, object parametros, CommandType commandType = CommandType.StoredProcedure)
        {
            T entidade;
            using (var conn = GetDbConection())
            {
                entidade = conn.QueryFirstOrDefault<T>(query, parametros, commandType: commandType);
            }
            return entidade;
        }

        public static int ExecutarComando(
            string query, object parametros, CommandType commandType = CommandType.StoredProcedure)
        {
            int linhasAfetadas = 0;
            using (var conn = GetDbConection())
            {
                linhasAfetadas = conn.Execute(query, parametros, commandType: commandType);
            }
            return linhasAfetadas;
        }
    }
}
