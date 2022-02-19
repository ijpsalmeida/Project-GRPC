using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente_Utilizador
{
    public partial class View_ApostasFeitas : Form
    {
        List<ApostasFeitasReply> _lista_apostas = new List<ApostasFeitasReply>();
        public View_ApostasFeitas(List<ApostasFeitasReply> lista)
        {
            InitializeComponent();
            _lista_apostas = lista;
        }

        private void View_ApostasFeitas_Load(object sender, EventArgs e)
        {
            int i = 0;

            foreach(var aposta in _lista_apostas)
            {
                lt_apostasfeitas.Items.Add("Aposta número " + Convert.ToString(i+1) + "=>" + aposta.ApostasFeitas);
                i++;
            }
            
            lt_apostasfeitas.Show();
        }
    }
}
