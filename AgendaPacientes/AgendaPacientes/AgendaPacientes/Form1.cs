using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaPacientes

{
    public partial class Form1 : Form
    {
        Form2 form2;
        DAOPaciente paciente;
        public Form1()
        {
           InitializeComponent();
            paciente = new DAOPaciente();
        }//fim do construtor

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //botao entrar/login
        private void button1_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.ShowDialog();
        }//fim do botao entrar
    }//fim da classe
}//fim do projeto
