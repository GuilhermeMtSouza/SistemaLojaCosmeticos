﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaLojaCosmeticos
{
    public partial class frmRelFuncionarios : MetroFramework.Forms.MetroForm
    {
        public frmRelFuncionarios()
        {
            InitializeComponent();
        }

        private void frmRelFuncionarios_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO TIPO DE RELATÓRIO
            cbTipoRel.Items.Add("Aniversariantes por Dia e Mês");
            cbTipoRel.Items.Add("Aniversariantes do Mês");
            cbTipoRel.Items.Add("Aniversariantes Data Completa");
            cbTipoRel.Items.Add("Aniversariantes Idade");
            cbTipoRel.Items.Add("Aniversariantes Maiores de");
            cbTipoRel.Items.Add("Cidade");
            cbTipoRel.Items.Add("Sexo");
            cbTipoRel.Items.Add("Status");
            cbTipoRel.Items.Add("Cargo");
            cbTipoRel.Items.Add("Data de Admissão");
            cbTipoRel.SelectedIndex = 7;

            //CARREGAR COMBO MÊS
            cbMes.Items.Add("Escolha um Mês");
            cbMes.Items.Add("Janeiro");
            cbMes.Items.Add("Fevereiro");
            cbMes.Items.Add("Março");
            cbMes.Items.Add("Abril");
            cbMes.Items.Add("Maio");
            cbMes.Items.Add("Junho");
            cbMes.Items.Add("Julho");
            cbMes.Items.Add("Agosto");
            cbMes.Items.Add("Setembro");
            cbMes.Items.Add("Outubro");
            cbMes.Items.Add("Novembro");
            cbMes.Items.Add("Dezembro");
            cbMes.SelectedIndex = 0;

            //CARREGAR COMBO DIA
            cbDia.Items.Add("Escolha um Dia");
            cbDia.Items.Add("01");
            cbDia.Items.Add("02");
            cbDia.Items.Add("03");
            cbDia.Items.Add("04");
            cbDia.Items.Add("05");
            cbDia.Items.Add("06");
            cbDia.Items.Add("07");
            cbDia.Items.Add("08");
            cbDia.Items.Add("09");
            cbDia.Items.Add("10");
            cbDia.Items.Add("11");
            cbDia.Items.Add("12");
            cbDia.Items.Add("13");
            cbDia.Items.Add("14");
            cbDia.Items.Add("15");
            cbDia.Items.Add("16");
            cbDia.Items.Add("17");
            cbDia.Items.Add("18");
            cbDia.Items.Add("19");
            cbDia.Items.Add("20");
            cbDia.Items.Add("21");
            cbDia.Items.Add("22");
            cbDia.Items.Add("23");
            cbDia.Items.Add("24");
            cbDia.Items.Add("25");
            cbDia.Items.Add("26");
            cbDia.Items.Add("27");
            cbDia.Items.Add("28");
            cbDia.Items.Add("29");
            cbDia.Items.Add("30");
            cbDia.Items.Add("31");
            cbDia.SelectedIndex = 0;

            //CARREGAR COMBO SEXO
            cbSexo.Items.Add("Escolha um Sexo");
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.SelectedIndex = 0;

            //CARREGAR COMBO DE CIDADE DO BANCO DE DADOS - TABELA CLIENTE
            classCliente cCliente = new classCliente();
            cbCidade.DataSource = cCliente.BuscarCidade(); // EXECUTAR MÉTODO DE CONSULTA CRIADO NA CLASSE CLIENTE
            cbCidade.DisplayMember = "Cidade"; // EXIBIR NA COMBO (CIDADE)
            cbCidade.ValueMember = "Cidade"; // GUARDAR NO BD (CIDADE)
            cbCidade.SelectedIndex = -1;

            classFuncionarios cCategoria = new classFuncionarios();
            cbCargo.DataSource = cCategoria.BuscarCargo();
            cbCargo.DisplayMember = "NomeCargo";
            cbCargo.ValueMember = "CodigoCargo";
            cbCargo.SelectedIndex = -1;


            this.rptv.RefreshReport();

        
            
        }

        private void btGerarRel_Click(object sender, EventArgs e)
        {
            string Consulta = cbTipoRel.SelectedItem.ToString();
            classFuncionarios obj = new classFuncionarios();
            switch (Consulta)
            {
                case "Status":
                    if (rbAtivo.Checked == true)
                    {
                        obj.Status = 1;

                        classFuncionariosBindingSource.DataSource = obj.RelFunStatus(obj.Status);
                        this.rptv.RefreshReport();
                    }
                    else
                    {
                        obj.Status = 0;

                        classFuncionariosBindingSource.DataSource = obj.RelFunStatus(obj.Status);
                        this.rptv.RefreshReport();
                    }
                    break;


                case "Aniversariantes do Mês":
                    if (cbMes.Text != "Escolha um Mês")
                    {
                        int mes = Convert.ToInt32(cbMes.SelectedIndex);
                        classFuncionariosBindingSource.DataSource = obj.RelFunMes(mes);
                        this.rptv.RefreshReport();
                    }

                    else
                    {
                        MessageBox.Show("Favor escolher um mês.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case "Aniversariantes por Dia e Mês":
                    if (cbDia.Text != "" && cbMes.Text != "")
                    {
                        int mes1 = Convert.ToInt32(cbMes.SelectedIndex);
                        int dia = Convert.ToInt32(cbDia.SelectedIndex);
                        classFuncionariosBindingSource.DataSource = obj.RelFunDiaMes(dia, mes1);

                        this.rptv.RefreshReport();
                    }

                    else
                    {
                        MessageBox.Show("Favor escolher um Dia e Mês.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case "Aniversariantes Data Completa":
                    DateTime dinicio, dfinal;
                    dinicio = Convert.ToDateTime(dtpDe.Text);
                    dfinal = Convert.ToDateTime(dtpAte.Text);
                    classFuncionariosBindingSource.DataSource = obj.RelFunDataCompleta(dinicio, dfinal);
                    this.rptv.RefreshReport();
                    break;


                //Data de Admissão

                case "Data de Admissão":
                    DateTime Dinicio, Dfinal;
                    Dinicio = Convert.ToDateTime(dtpDe.Text);
                    Dfinal = Convert.ToDateTime(dtpAte.Text);
                    classFuncionariosBindingSource.DataSource = obj.RelFunDataAdmissao(Dinicio, Dfinal);
                    this.rptv.RefreshReport();
                    break;

                case "Cidade":
                    if (cbCidade.Text != "")
                    {
                        string cidade = Convert.ToString(cbCidade.Text);
                        //obj.Cidade = Convert.ToInt32(cbCidade.SelectedItem);
                        classFuncionariosBindingSource.DataSource = obj.RelFunCidade(cidade);
                        this.rptv.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor escolher uma Cidade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Aniversariantes Idade":
                    if (txtIdadeDe.Text != "" && txtIdadeAte.Text != "")
                    {
                        int idadei = Convert.ToInt32(txtIdadeAte.Text);
                        int idadef = Convert.ToInt32(txtIdadeDe.Text);
                        classFuncionariosBindingSource.DataSource = obj.RelFunIdade(idadef, idadei);
                        this.rptv.RefreshReport();
                    }

                    else
                    {
                        MessageBox.Show("Favor escrever uma Idade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case "Aniversariantes Maiores de":
                    if (txtMaiorDe.Text != "")
                    {
                        int MD = Convert.ToInt32(txtMaiorDe.Text);
                        classFuncionariosBindingSource.DataSource = obj.RelFunIdadeMaior(MD);
                        this.rptv.RefreshReport();
                    }

                    else
                    {
                        MessageBox.Show("Favor escrever uma idade.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;


                case "Sexo":
                    if (cbSexo.SelectedIndex != 0)
                    {
                        string sexo = cbSexo.SelectedItem.ToString();
                        classFuncionariosBindingSource.DataSource = obj.RelFunSexo(sexo);
                        this.rptv.RefreshReport();
                    }

                    else
                    {
                        MessageBox.Show("Favor escolher um Sexo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    break;

                case "Cargo":
                    if (cbCargo.Text != "")
                    {
                        int cargo = Convert.ToInt32(cbCargo.SelectedValue);
                        classFuncionariosBindingSource.DataSource = obj.RelFunCargo(cargo);
                        this.rptv.RefreshReport();
                    }
                    else
                        MessageBox.Show("Favor escolher um cargo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    break;
            }
       }

        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipoRel.SelectedIndex == 0) //Aniversariantes por Dia e Mês
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = true;
                gbIdade.Enabled = false;
                dtpDe.Enabled = false;
                dtpAte.Enabled = false;
                cbDia.Enabled = true;
                cbMes.Enabled = true;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 1) //Aniversariantes do Mês
            {
                gbMaiores.Enabled = false;
                gbIdade.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = true;
                dtpDe.Enabled = false;
                dtpAte.Enabled = false;
                cbDia.Enabled = false;
                cbMes.Enabled = true;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 2) //Aniversariantes Data Completa
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = true;
                gbIdade.Enabled = false;
                dtpDe.Enabled = true;
                dtpAte.Enabled = true;
                cbDia.Enabled = false;
                cbMes.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 3) //Aniversariantes Idade
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = true;
                cbDia.Enabled = false;
                cbMes.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 4) //Aniversariantes Maiores de 
            {
                gbMaiores.Enabled = true;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                cbDia.Enabled = false;
                cbMes.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 5) //Cidade
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = true;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 6) //Sexo
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = true;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 7) //Status
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = true;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                cbCargo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 8) //Cargo
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = false;
                gbIdade.Enabled = false;
                dtpDe.Enabled = false;
                dtpAte.Enabled = false;
                cbDia.Enabled = false;
                cbMes.Enabled = false;
                cbCargo.Enabled = true;
            }

            if (cbTipoRel.SelectedIndex == 9) // Admissao
            {
                gbMaiores.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbAniversariantes.Enabled = true;
                gbIdade.Enabled = false;
                dtpDe.Enabled = true;
                dtpAte.Enabled = true;
                cbDia.Enabled = false;
                cbMes.Enabled = false;
                cbCargo.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
