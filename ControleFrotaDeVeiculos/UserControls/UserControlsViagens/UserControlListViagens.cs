﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleFrotaDeVeiculos.models;

namespace ControleFrotaDeVeiculos.UserControlViagens
{
    public partial class UserControlListViagens : UserControl
    {
        public UserControlListViagens()
        {
            InitializeComponent();
        }

        private void UserControlListViagens_Load(object sender, EventArgs e)
        {
            materialListView1.Refresh();
            BLL bll = new BLL();
            List<Viagens> list = new List<Viagens>();
            list = bll.listaViagens("Todos","","","","","");
            foreach (var item in list)
            {
                materialListView1.Items.Add(new ListViewItem(new string[] { item.Veiculos.Placa, item.Motorista.Nome, item.dateViagem.ToShortDateString(), item.Situacao, item.ID.ToString() }));
            }
        }

        private void btnNewViagem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = (Form1)Application.OpenForms["Form1"];
            frm1.panelControl.Controls.Add(frm1.userControlCadastroViagens);
            frm1.userControlCadastroViagens.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            txtDia.Text = "Dia";
            txtMes.Text = "Mês";
            txtAno.Text = "Ano";
            metroComboBox1.Text = "Todos";
        }

        private void metroComboBox1_TextChanged(object sender, EventArgs e)
        {
            BLL bll = new BLL();
            if(metroComboBox1.Text == "Motorista")
            {
                txtSearch.AutoCompleteCustomSource = bll.AutoCompletarNome();
            }
            else if(metroComboBox1.Text == "Placa")
            {
                txtSearch.AutoCompleteCustomSource = bll.AutoCompletarPlaca();
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            String comando = "";
            String dia = "";
            String mes = "";
            String ano = "";
            String nomemotorista = "";
            String placa = "";
           if(metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "Todos";
            }
            else if (metroComboBox1.Text == "Todos" &&txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosDia";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosMes";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosAno";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosPend";
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosConc";
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosDiaMes";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosDiaAno";
                ano = txtAno.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosDiaPend";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosDiaConc";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosMesAno";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosMesPend";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosMesConc";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosAnoPend";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosAnoConc";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosMesAnoPend";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosDiaMesPend";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosDiaMesConc";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosDiaAnoPend";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "TodosDiaAnoConc";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "TodosDiaMesAno";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "TodosDiaMesAnoPend";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Todos" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                dia = txtDia.Text;
                comando = "TodosDiaMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "Mot";
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotDia";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotMes";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotAno";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotPend";
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotConc";
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotDiaMes";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotDiaAno";
                ano = txtAno.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotDiaPend";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotDiaConc";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotMesAno";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotMesPend";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotMesConc";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotAnoPend";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotAnoConc";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotMesAnoPend";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotDiaMesPend";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotDiaMesConc";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotDiaAnoPend";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "MotDiaAnoConc";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "MotDiaMesAno";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "MotDiaMesAnoPend";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Motorista" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                dia = txtDia.Text;
                comando = "MotDiaMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "Placa";
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaDia";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaMes";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaAno";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaPend";
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaConc";
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaMes";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaAno";
                ano = txtAno.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaPend";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaDiaConc";
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaMesAno";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaMesPend";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaMesConc";
                mes = txtMes.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaAnoPend";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaAnoConc";
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaMesAnoPend";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text == "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaMesPend";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text == "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaDiaMesConc";
                mes = txtMes.Text;
                dia = txtDia.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaAnoPend";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text == "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                comando = "PlacaDiaAnoConc";
                dia = txtDia.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaMesAno";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == true && checkConcluida.Checked == false)
            {
                comando = "PlacaDiaMesAnoPend";
                dia = txtDia.Text;
                mes = txtMes.Text;
                ano = txtAno.Text;
            }
            else if (metroComboBox1.Text == "Placa" && txtDia.Text != "Dia" && txtMes.Text != "Mês" && txtAno.Text != "Ano" && checkPendente.Checked == false && checkConcluida.Checked == true)
            {
                dia = txtDia.Text;
                comando = "PlacaDiaMesAnoConc";
                mes = txtMes.Text;
                ano = txtAno.Text;
            }


            DAL dal = new DAL();
            materialListView1.Items.Clear();
            List<Viagens> list = new List<Viagens>();
            list = dal.ListaViagens(comando, dia, mes, ano, nomemotorista, placa);
            foreach (var item in list)
            {
                materialListView1.Items.Add(new ListViewItem(new string[] { item.Veiculos.Placa, item.Motorista.Nome, item.dateViagem.ToShortDateString(), item.Situacao, item.ID.ToString() }));
            }
            materialListView1.Refresh();

        }

        private void btnUltViagens_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void checkPendente_CheckedChanged(object sender, EventArgs e)
        {
            checkConcluida.Checked = false;
        }

        private void checkConcluida_CheckedChanged(object sender, EventArgs e)
        {
            checkPendente.Checked = false;
        }

        private void materialListView1_MouseClick(object sender, MouseEventArgs e)
        {
            int id = Convert.ToInt32(materialListView1.SelectedItems[0].SubItems[4].Text);
            Form1 frm1 = (Form1)Application.OpenForms["Form1"];
            frm1.panelControl.Controls.Add(frm1.userControlViagem);
            frm1.userControlViagem.id = id;
            frm1.userControlViagem.BringToFront();
        }
    }
}
