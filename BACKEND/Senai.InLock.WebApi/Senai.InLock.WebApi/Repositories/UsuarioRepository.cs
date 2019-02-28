using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= InLock_Games_Tarde; user id=sa; pwd=132;";

        public UsuarioDomain BuscarPorEmailSenha(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QuerySelect = "SELECT UsuarioId, Email, TipoUsuario FROM USUARIOS WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain();
                        while (sdr.Read())
                        {
                            usuarioBuscado.UsuarioId = Convert.ToInt32(sdr["UsuarioId"]);
                            usuarioBuscado.Email = sdr["Email"].ToString();
                            usuarioBuscado.TipoUsuario = sdr["TipoUsuario"].ToString();
                        }

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
