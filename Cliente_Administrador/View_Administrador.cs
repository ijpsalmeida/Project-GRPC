using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;
using GrpcServer.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Administrador
{
    public partial class View_Administrador : Form
    {
        public View_Administrador()
        {
            InitializeComponent();

            // Ligação ao servidor
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            string ipservidor = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(ipservidor, new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);

            //Verificar ligação 
            var reply = client.SayHello(new HelloRequest { Name = "Apostador" });
            if (reply.Message == "Ligação Feita! Boas Apostas!")
            {
                MessageBox.Show("Ligação Estabelecida!", "Administrador - Ligação", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Erro ao estabelecer ligação!", "Administrador - Ligação", MessageBoxButtons.OK);
            }
        }

        private void b_novosorteio_Click(object sender, EventArgs e)
        {
            //Ligação ao servidor
            string ipservidor = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(ipservidor);

            var client = new ServicoGeral.ServicoGeralClient(channel);
            var reply = client.NovoSorteio(new SorteioRequest { ArquivarCriar = "Novo"});
            MessageBox.Show(reply.RepostaArquivarCriar, "", MessageBoxButtons.OK);
        }

        private async void b_apostasatuais_Click(object sender, EventArgs e)
        {     
            List<VisualizarApostaReply> lista_apostas = new List<VisualizarApostaReply>();
            
            string ipservidor = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(ipservidor);
            var client = new ServicoGeral.ServicoGeralClient(channel);
            using var reply = client.ApostaAtual(new VisualizarApostaRequest { PedidoApostaAtual = "VerApostas" });

            await foreach (var aposta in reply.ResponseStream.ReadAllAsync())
            {           
                lista_apostas.Add(aposta);
            }

            View_VisualizarApostas viewapostas = new View_VisualizarApostas(lista_apostas);
            viewapostas.Show();
        }
    }
}
