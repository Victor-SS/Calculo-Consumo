using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cálculo_de_Consumo
{
    public partial class FrmConsumo : Form
    {
        public FrmConsumo()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtVeiculo.Clear();
            txtDistancia.Clear();
            txtLitros.Clear();
            txtNome.Focus();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string nome;
            string veiculo;
            string mensagem;
            decimal distancia;
            decimal litros;
            decimal consumo;

            mensagem = ValidarPreenchimento();
            if(mensagem != string.Empty)
            {
                MessageBox.Show(mensagem, "Cálculo de Consumo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nome = txtNome.Text;
            veiculo = txtVeiculo.Text;
            distancia = decimal.Parse(txtDistancia.Text);
            litros = decimal.Parse(txtLitros.Text);

            consumo = CalcularConsumo(distancia, litros);
            mensagem = RetornarMensagem(consumo, nome, veiculo);

            MessageBox.Show(mensagem, "Cálculo de Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private decimal CalcularConsumo(decimal dist, decimal lit)
        {
            decimal result = dist / lit;
            return result;
        }
        private string RetornarMensagem(decimal consumo, string nm, string vc)
        {
            string msg = nm + ", seu veículo " + vc +
                " faz " + consumo.ToString("#0.0") + " km/l\n"
                + "Ele é ";

            if (consumo < 12)
            {
                msg += "Gastão!";           // > 8     
            }
            else if (consumo >= 15)
            {
                msg += "Econômico!";        // < 7
            }
            else
            {
                msg += "Aceitavel!";        // >= 7
            }
            return msg;
        }
        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;
            if (txtNome.Text == string.Empty)
            {
                msgErro += "Campo Nome em branco.\n";
            }
            if (txtVeiculo.Text == string.Empty)
            {
                msgErro += "Campo Veículo em branco.\n";
            }
            if (txtDistancia.Text == string.Empty)
            {
                msgErro += "Campo Distâcia em branco.\n";
            }
            else if (!decimal.TryParse(txtDistancia.Text, out decimal result))
            {
                msgErro += "Campo Distância inválido.\n";
            }
            if (txtLitros.Text == string.Empty)
            {
                msgErro += "Campo Litros em branco.\n";
            }
            else if (!decimal.TryParse(txtLitros.Text, out decimal result))
            {
                msgErro += "Campo Litros inválido.\n";
            }
            return msgErro;
        }
    }
}
