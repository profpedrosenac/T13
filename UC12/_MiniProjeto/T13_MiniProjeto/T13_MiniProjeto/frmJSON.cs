using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace T13_MiniProjeto
{


    public class Pessoa
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Profissao { get; set; }
    }



    public partial class frmJSON : Form
    {
        public frmJSON()
        {
            InitializeComponent();
        }

        

        private void frmJSON_Load(object sender, EventArgs e)
        {
            ex02();
        }

        
        void ex02()
        {
            string text = File.ReadAllText(@"C:/Users/pedro.lhjunior/source/repos/T13/T13/UC12/_MiniProjeto/T13_MiniProjeto/nomes.json");
            var person = JsonSerializer.Deserialize<IList<Pessoa>>(text);
           
            foreach (var dept in person)
            {
                MessageBox.Show($"Primeiro Nome: {dept.PrimeiroNome}");
                MessageBox.Show($"Segundo Nome: {dept.SegundoNome}");
                MessageBox.Show($"Profissão: {dept.Profissao}");
            }
        }

        void ex01()
        {
            //string text = File.ReadAllText(@"./nomes.json");
            string text = File.ReadAllText(@"C:/Users/pedro.lhjunior/source/repos/T13/T13/UC12/_MiniProjeto/T13_MiniProjeto/teste01.json");
            var person = JsonSerializer.Deserialize<Pessoa>(text);

            MessageBox.Show($"Primeiro Nome: {person.PrimeiroNome}");
            MessageBox.Show($"Segundo Nome: {person.SegundoNome}");
            MessageBox.Show($"Profissão: {person.Profissao}");
        }
    }
}
