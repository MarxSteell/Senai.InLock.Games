using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= InLock_Games_Tarde; user id=sa; pwd=132;";

        public void Cadastrar(JogoDomain jogo)
        {
            string QueryInsert = @"INSERT INTO JOGOS(NomeJogo,Descricao,DataLancamento,Valor,EstudioId)
                                   VALUES (@NomeJogo,@Descricao,@DataLancamento,@Valor,@EstudioId)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogo", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@EstudioId", jogo.EstudioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            string QuerySelect = @"SELECT 
                                    JG.JogoId,
                                    JG.NomeJogo,
                                    JG.Descricao,
                                    JG.DataLancamento,
                                    JG.Valor,
                                    E.EstudioId,
                                    E.NomeEstudio
                                    FROM JOGOS JG
                                    LEFT JOIN ESTUDIOS E ON JG.EstudioId = E.EstudioId";

            List<JogoDomain> listarJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QuerySelect, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["NomeJogo"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                            Estudio = new EstudioDomain
                            {
                                EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                                NomeEstudio = sdr["NomeEstudio"].ToString(),
                            }
                        };
                listarJogos.Add(jogo);
                    }
            return listarJogos;
                }
            }
        }
    }
}
