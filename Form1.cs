using System.Media;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;


namespace POO_Urna_Eletronica
{
    public partial class frmUrna : Form
    {
        private Dictionary<string, Candidato> _dicCandidato;
        private System.Windows.Forms.Timer relogio; // Declarando o Timer


        public frmUrna()
        {
            InitializeComponent();

            _dicCandidato = new Dictionary<string, Candidato>();
            CarregarCandidatos();

            relogio = new System.Windows.Forms.Timer();// Inicializando o Timer
        }

        private void CarregarCandidatos()
        {
            string caminhoArquivo = "C:\\Users\\faelr\\OneDrive\\Documentos\\TrabPOO\\POO_Urna_Eletronica\\JsonFiles\\Presidentes.json";
            if (File.Exists(caminhoArquivo))
            {
                string jsonString = File.ReadAllText(caminhoArquivo);
                var candidatos = JsonSerializer.Deserialize<List<Candidato>>(jsonString);
                foreach (var candidato in candidatos)
                {
                    _dicCandidato.Add(candidato.Numero.ToString(), candidato);
                }
            }
            else
            {
                MessageBox.Show("Arquivo de candidatos não encontrado");
            }
        }



        private void button11_Click(object sender, EventArgs e)
        {

            Limpar();

            SoundPlayer s = new SoundPlayer(Properties.Resources.urna);
            s.Play();

            relogio.Tick -= AcaoFinal;

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 300;
            relogio.Enabled = true;
            relogio.Start();
        }

        private void AcaoFinal(Object? myObject, EventArgs myEventArgs)
        {
            relogio.Stop();
            relogio.Enabled = false;

            panelPrincipal.Visible = true;
        }

        private void RegistrarDigito(string digito)
        {
            if (string.IsNullOrEmpty(txtDecimal.Text))
                txtDecimal.Text = digito;
            else
            {
                txtUnidade.Text = digito;
                PreencherCandidato(txtDecimal.Text, txtUnidade.Text);
            }

            SoundPlayer s = new SoundPlayer(Properties.Resources.clique);
            s.Play();
        }

        private void PreencherCandidato(string d1, string d2)
        {
            string numeroCandidato = d1 + d2;
            if (_dicCandidato.ContainsKey(numeroCandidato))
            {
                var candidato = _dicCandidato[numeroCandidato];
                lblNomeCandidato.Text = candidato.Nome;
                lblPartidoCandidato.Text = candidato.Partido;
            }
            else
            {
                MessageBox.Show("Candidato não encontrado!");
            }
        }

        private void Limpar()
        {
            txtDecimal.Text = "";
            txtUnidade.Text = "";
            lblNomeCandidato.Text = String.Empty;
            lblPartidoCandidato.Text = String.Empty;
            picFotoCandidato.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarDigito("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarDigito("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrarDigito("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistrarDigito("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistrarDigito("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistrarDigito("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RegistrarDigito("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RegistrarDigito("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            RegistrarDigito("9");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RegistrarDigito("0");
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            Limpar();
            relogio.Stop();
            relogio.Enabled = false;
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecimal.Text) || string.IsNullOrEmpty(txtUnidade.Text))
            {
                MessageBox.Show("Favor informar o candidato.");
                return;
            }

            panelPrincipal.Visible = false;
            Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.urna);
            s.Play();

            // Remova o EventHandler existente para evitar múltiplas associações
            relogio.Tick -= AcaoFinal;

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();
            //InitializeComponent();
        }


    }
}
