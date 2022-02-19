using Grpc.Core;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GrpcServer.Services
{
    public class pEuromilhoesService : ServicoGeral.ServicoGeralBase
    {
        private readonly ILogger<pEuromilhoesService> _logger;
        private SqlConnection basededados { get; set; }

        public pEuromilhoesService(ILogger<pEuromilhoesService> logger)
        {
            _logger = logger;
            basededados = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ijpsa\\Documents\\bd_euromilhoes.mdf;Integrated Security=True;Connect Timeout=30");
            basededados.Open();
        }

        //Utilizador
        public override Task<ApostaReply> RegistarAposta(ApostaRequest request, ServerCallContext context)
        {
            ApostaReply reply = new ApostaReply();
            SqlCommand comando = new SqlCommand();
            string aux_executar;
            string aux_numero_sorteio;
            int sorteio = 0;

            try
            {
                //Numero do sorteio atual 
                aux_numero_sorteio = string.Format("select nsorteio from sorteios order by id desc");
                comando = new SqlCommand(aux_numero_sorteio, basededados);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                sorteio = Convert.ToInt32(reader["nsorteio"]);
                
                if (sorteio == 0)
                {
                    sorteio = 1;
                }

                reader.Close();

                aux_executar = string.Format("insert into sorteios(nsorteio, nome, telemovel, chave) values ({0} , '{1}', '{2}', '{3}') ", 
                    sorteio, request.NomeApostador, request.Telemovel, request.Chave);

                comando = new SqlCommand(aux_executar, basededados);
                comando.ExecuteNonQuery();

                reply.RespostaAposta = "Aposta Feita!";                
            }
            catch
            {
                reply.RespostaAposta = "Erro ao realizar aposta!";
            }

            return Task.FromResult(reply);
        }

        public override async Task PedidoApostasFeitas(ApostasFeitasRequest request, IServerStreamWriter<ApostasFeitasReply> responseStream, ServerCallContext context)
        {
            string telemovel = request.Telemovel;
            var apostas = Obter_Apostas(telemovel);
            foreach (var aposta in apostas)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(aposta);
            }
        }

        private List<ApostasFeitasReply> Obter_Apostas(string telemovel)
        {
            List<ApostasFeitasReply> apostas = new List<ApostasFeitasReply>();
            SqlCommand comando = new SqlCommand();
            int sorteio = 0;

            // Numero do sorteio atual
            string aux_numero_sorteio = string.Format("select nsorteio from sorteios order by id desc");
            comando = new SqlCommand(aux_numero_sorteio, basededados);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            sorteio = Convert.ToInt32(reader["nsorteio"]);

            if (sorteio == 0)
            {
                sorteio = 1;
            }

            reader.Close();

            string aux_executar = string.Format("SELECT chave FROM sorteios WHERE telemovel='{0}' ", telemovel);
            comando = new SqlCommand(aux_executar, basededados);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                ApostasFeitasReply aposta = new ApostasFeitasReply();
                aposta.ApostasFeitas = Convert.ToString(reader["chave"]);
                apostas.Add(aposta);
            }

            return apostas;
        }

        //Administrador
        public override Task<SorteioReply> NovoSorteio(SorteioRequest request, ServerCallContext context)
        {
            SorteioReply reply = new SorteioReply();
            SqlCommand comando = new SqlCommand();
            string aux_executar;
            string aux_numero_sorteio;
            int sorteio;
            string admin_nome = "administrador", admin_telemovel = "administrado", admin_chave = "administrador";

            if (request.ArquivarCriar == "Novo")
            {
                try
                {
                    //Numero do sorteio atual 
                    aux_numero_sorteio = string.Format("select nsorteio from sorteios order by id desc");
                    comando = new SqlCommand(aux_numero_sorteio, basededados);
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    sorteio = Convert.ToInt32(reader["nsorteio"]);

                    sorteio++;

                    reader.Close();

                    aux_executar = string.Format("insert into sorteios(nsorteio, nome, telemovel, chave) values ({0} , '{1}', '{2}', '{3}') ",
                            sorteio, admin_nome, admin_telemovel, admin_chave);

                    comando = new SqlCommand(aux_executar, basededados);
                    comando.ExecuteNonQuery();

                    reply.RepostaArquivarCriar = "Sorteio arquivado! Novo sorteio criado";
                }
                catch
                {
                    reply.RepostaArquivarCriar = "Erro ao criar novo sorteio!";
                }
            }
            else
            {
                reply.RepostaArquivarCriar = "Erro ao criar novo sorteio!";
            }

            return Task.FromResult(reply);
        }

        public override async Task ApostaAtual(VisualizarApostaRequest request, IServerStreamWriter<VisualizarApostaReply> responseStream, ServerCallContext context)
        {
            var apostas = Obter_ApostaAtual();
            foreach (var aposta in apostas)
            {
                await Task.Delay(1000);
                await responseStream.WriteAsync(aposta);
            }
        }

        private List<VisualizarApostaReply> Obter_ApostaAtual()
        {
            List<VisualizarApostaReply> apostas = new List<VisualizarApostaReply>();
            SqlCommand comando = new SqlCommand();
            int sorteio = 0;

            // Numero do sorteio atual
            string aux_numero_sorteio = string.Format("select nsorteio from sorteios order by id desc");
            comando = new SqlCommand(aux_numero_sorteio, basededados);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            sorteio = Convert.ToInt32(reader["nsorteio"]);

            if (sorteio == 0)
            {
                sorteio = 1;
            }

            reader.Close();

            string aux_executar = string.Format("SELECT nome, telemovel, chave FROM sorteios WHERE nsorteio={0} and nome <> 'administrador'", sorteio);
            comando = new SqlCommand(aux_executar, basededados);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                VisualizarApostaReply aposta = new VisualizarApostaReply();
                aposta.NomeApostador = Convert.ToString(reader["nome"]);
                aposta.Telemovel = Convert.ToString(reader["telemovel"]);
                aposta.Chave = Convert.ToString(reader["chave"]);
                apostas.Add(aposta);
            }

            return apostas;
        }

        //Gestor
        public override async Task Vencedor(ChaveRequest request, IServerStreamWriter<VencedorReply> responseStream, ServerCallContext context)
        {
            string chave = request.ChaveVencedora; 
            var vencedores = Obter_Vencedores(chave);

                foreach (var vencedor in vencedores)
                {
                    await Task.Delay(1000);
                    await responseStream.WriteAsync(vencedor);
                } 
        }

        private List<VencedorReply> Obter_Vencedores(string chave)
        {
            List<VencedorReply> vencedores = new List<VencedorReply>();
            SqlCommand comando = new SqlCommand();
            int sorteio = 0;
            
            // Numero do sorteio atual
            string aux_numero_sorteio = string.Format("select nsorteio from sorteios order by id desc");
            comando = new SqlCommand(aux_numero_sorteio, basededados);
            SqlDataReader reader = comando.ExecuteReader();
            reader.Read();
            sorteio = Convert.ToInt32(reader["nsorteio"]);

            if (sorteio == 0)
            {
                sorteio = 1;
            }

            reader.Close();

            string aux_executar = string.Format("SELECT nome, telemovel FROM sorteios WHERE chave='{0}' and nsorteio={1}", chave, sorteio);
            comando = new SqlCommand(aux_executar, basededados);
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                VencedorReply vencedor = new VencedorReply();
                vencedor.NomeApostador= Convert.ToString(reader["nome"]);
                vencedor.Telemovel = Convert.ToString(reader["telemovel"]);
                vencedores.Add(vencedor);
            }
   
            return vencedores;
        }
    }
}
