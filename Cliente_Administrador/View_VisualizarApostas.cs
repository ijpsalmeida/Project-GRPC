using GrpcServer.Protos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cliente_Administrador
{
    public partial class View_VisualizarApostas : Form
    {
        List<VisualizarApostaReply> _lista_apostas = new List<VisualizarApostaReply>();

        public View_VisualizarApostas(List<VisualizarApostaReply> lista)
        {
            InitializeComponent();
            _lista_apostas = lista; 
        }

        private void View_VisualizarApostas_Load(object sender, EventArgs e)
        {
            foreach (var aposta in _lista_apostas)
            {
                lt_VisualizarApostas.Items.Add("Nome: " + aposta.NomeApostador + "   Telemóvel: "+ aposta.Telemovel + "   Chave: " + aposta.Chave);
            }

            lt_VisualizarApostas.Show();
        }
    }
}
