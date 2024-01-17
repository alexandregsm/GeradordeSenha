namespace GERADORDESENHA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var tamanhodesenha = Convert.ToInt32(numericUpDown1.Value.ToString());
            var AZ = checkBox1.Checked;
            var az = checkBox2.Checked;
            var numeros = checkBox3.Checked;
            var especiais = checkBox4.Checked;
            var ambiguos = checkBox5.Checked;

            OpcoesDesejadas opcoes = new OpcoesDesejadas()
            {
                tamanhodesenha = tamanhodesenha,
                AZ = AZ,
                ambiguos = ambiguos,
                az = az,
                especiais = especiais,
                numeros = numeros,
            };

            string senhaFinal = GerarSenha(opcoes);
            textBox1.Text = senhaFinal;
        }




        public static string GerarSenha(OpcoesDesejadas opcoes)
        {
            var letrasMinusculas = "abcdefghijklmnopqrstuvwxyz".Select(c => c.ToString()).ToList();
            var letrasMaiusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select(c => c.ToString()).ToList();
            var numerosZeroaNove = "0123456789".Select(c => c.ToString()).ToList();
            var caracteresEspeciais = "^!#!&$%@".Select(c => c.ToString()).ToList();

            string combinacao = "";
            string senhaFinal = "";
            var random = new Random();
            List<string> combinacaoFinal = new List<string>();

            if (opcoes.AZ == true)
                combinacao += string.Join("", letrasMaiusculas);

            if (opcoes.az == true)
                combinacao += string.Join("", letrasMinusculas);

            if (opcoes.numeros == true)
                combinacao += string.Join("", numerosZeroaNove);

            if (opcoes.especiais == true)
                combinacao += string.Join("", caracteresEspeciais);


            combinacaoFinal = combinacao.Select(c => c.ToString()).ToList();





            for (int i = 0; i < opcoes.tamanhodesenha; i++)
            {
                int numeroAleatorio = 0;
                numeroAleatorio = random.Next(combinacaoFinal.Count);

                if (opcoes.ambiguos == true)
                {
                    if (senhaFinal.Contains(combinacaoFinal[numeroAleatorio].ToString()))
                    {
                        i--;
                        continue;
                    }
                    else
                        senhaFinal += combinacaoFinal[numeroAleatorio].ToString();
                }
                else
                    senhaFinal += combinacaoFinal[numeroAleatorio].ToString();

            }

            return senhaFinal;
        }






        public class OpcoesDesejadas
        {
            public int tamanhodesenha { get; set; }
            public bool AZ { get; set; }
            public bool az { get; set; }
            public bool numeros { get; set; }
            public bool especiais { get; set; }
            public bool ambiguos { get; set; }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.FromArgb(40, 36, 36))
            {
                this.BackColor = Color.FromArgb(232, 232, 232); // this should be pink-ish
                button2.Text = "Escuro";

            }
            else
            {
                this.BackColor = Color.FromArgb(40, 36, 36);
                button2.Text = "Claro";
            }
        }
    }
}

