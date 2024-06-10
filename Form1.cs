using System.Media;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

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
            _dicCandidato.Add("51", new Candidato() { Id = 51, Nome = "Darth Vader", Partido = "Império", Foto = Properties.Resources.DarthVader });
            _dicCandidato.Add("52", new Candidato() { Id = 52, Nome = "Chapolin", Partido = "Quase Nada", Foto = Properties.Resources.Chapolin });
            _dicCandidato.Add("91", new Candidato() { Id = 91, Nome = "Goku", Partido = "Saijin", Foto = Properties.Resources.Goku });
            _dicCandidato.Add("92", new Candidato() { Id = 92, Nome = "Homem de Ferro", Partido = "Vingadores", Foto = Properties.Resources.HomemDeFerro });
            _dicCandidato.Add("99", new Candidato() { Id = 99, Nome = "Batman", Partido = "Liga da Justiça", Foto = Properties.Resources.Batman });

            relogio = new System.Windows.Forms.Timer();// Inicializando o Timer
        }



        private void button11_Click(object sender, EventArgs e)
        {
            panelFim.Visible = true;
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
            panelFim.Visible = false;
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
            if (_dicCandidato.ContainsKey(d1 + d2))
            {
                lblNomeCandidato.Text = _dicCandidato[d1 + d2].Nome;
                lblPartidoCandidato.Text = _dicCandidato[d1 + d2].Partido;
                picFotoCandidato.Image = _dicCandidato[d1 + d2].Foto;
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
            if (string.IsNullOrEmpty(txtDecimal.Text))
            {
                MessageBox.Show("Favor informar o candidato.");
                return;
            }

            //panelFim.Visible = true;
            //Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.urna);
            s.Play();

            // Remova o EventHandler existente para evitar múltiplas associações
            relogio.Tick -= AcaoFinal;

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 300;
            relogio.Enabled = true;
            relogio.Start();
            //InitializeComponent();
        }

       
    }
    public class Candidato
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public string ?Partido { get; set; }
        public Image ?Foto { get; set; }
    }
}
