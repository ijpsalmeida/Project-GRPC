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

namespace Cliente_Gestor
{
    public partial class View_Gestor : Form
    {
        public View_Gestor()
        {
            InitializeComponent();

            //Ligação ao servidor
            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            string ipservidor = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(ipservidor, new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);

            //Verificar ligação 
            var reply = client.SayHello(new HelloRequest { Name = "Apostador" });
            if(reply.Message == "Ligação Feita! Boas Apostas!")
            {
                MessageBox.Show("Ligação Estabelecida!", "Gestor - Ligação", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Erro ao estabelecer ligação!", "Gestor - Ligação", MessageBoxButtons.OK);
            }            
        }

        private async void b_chave_vencedora_Click(object sender, EventArgs e)
        {
            //Ligação ao servidor
            string ipservidor = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(ipservidor);

            //Outras variaveis
            string chave = "";
            int[] numeros = new int[5];
            int[] estrelas = new int[2];
            int aux;

            if (tb_numero_1.Text == "" || tb_numero_2.Text == "" || tb_numero_3.Text == "" || tb_numero_4.Text == "" || tb_numero_5.Text == "" || tb_estrela_1.Text == "" || tb_estrela_2.Text == "")
            {
                MessageBox.Show("Insira uma chave valida", "", MessageBoxButtons.OK);
            }
            else
            {

                numeros[0] = Convert.ToInt32(tb_numero_1.Text);
                numeros[1] = Convert.ToInt32(tb_numero_2.Text);
                numeros[2] = Convert.ToInt32(tb_numero_3.Text);
                numeros[3] = Convert.ToInt32(tb_numero_4.Text);
                numeros[4] = Convert.ToInt32(tb_numero_5.Text);
                estrelas[0] = Convert.ToInt32(tb_estrela_1.Text);
                estrelas[1] = Convert.ToInt32(tb_estrela_2.Text);

                //Ordenar 
                for (int k = 1; k <= 4; k++)
                {
                    for (int j = 0; j <= 4 - k; j++)
                    {
                        if (numeros[j] > numeros[j + 1])
                        {
                            aux = numeros[j];
                            numeros[j] = numeros[j + 1];
                            numeros[j + 1] = aux;
                        }
                    }
                }

                if (estrelas[1] < estrelas[0])
                {
                    aux = estrelas[1];
                    estrelas[1] = estrelas[0];
                    estrelas[0] = aux;
                }

                for (int i = 0; i <= 4; i++)
                {
                    if (i == 0)
                    {
                        chave = Convert.ToString(numeros[i]);
                    }
                    else
                    {
                        chave = chave + ";" + Convert.ToString(numeros[i]);
                    }
                }

                for (int j = 0; j <= 1; j++)
                {
                    chave = chave + ";" + Convert.ToString(estrelas[j]);
                }
             
                var client = new ServicoGeral.ServicoGeralClient(channel);
                using var reply = client.Vencedor(new ChaveRequest { ChaveVencedora = chave });

                await foreach (var vencedor in reply.ResponseStream.ReadAllAsync())
                {
                    MessageBox.Show("Nome: " + vencedor.NomeApostador + " | Telemovel: " + vencedor.Telemovel, "Vencedores", MessageBoxButtons.OK);
                }
                //var reply = await client.Vencedor(new ChaveRequest { ChaveVencedora = chave });
                //MessageBox.Show(reply.NomeApostador + reply.Telemovel, "Vencedores", MessageBoxButtons.OK);
            }
        }
    }
}
