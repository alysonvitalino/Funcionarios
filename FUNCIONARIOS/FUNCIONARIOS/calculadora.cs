﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FUNCIONARIOS
{
    public partial class calculadora : Form
    {
        MySqlConnection conexao;
        public calculadora()
        {
            InitializeComponent();
            PreencherComboBox();/*
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;*/


            // Definindo novas colunas
            dataGridView1.ColumnCount = 14;

            // Definindo os cabeçalhos das colunas
            dataGridView1.Columns[0].Name = "ValorBase";
            dataGridView1.Columns[1].Name = "LIQ CSRF";
            dataGridView1.Columns[2].Name = "LIQ ISS";
            dataGridView1.Columns[3].Name = "LIQ INSS";
            dataGridView1.Columns[4].Name = "LIQ IR";
            dataGridView1.Columns[5].Name = "LIQ IR+CSRF";
            dataGridView1.Columns[6].Name = "LIQ IR+CSRF+ INSS";
            dataGridView1.Columns[7].Name = "LIQ IR+CSRF+ INSS+ISS";
            dataGridView1.Columns[8].Name = "LIQ IR+CSRF+ISS";
            dataGridView1.Columns[9].Name = "LIQ CSRF+ISS";
            dataGridView1.Columns[10].Name = "LIQ INSS+ISS";
            dataGridView1.Columns[11].Name = "LIQ IR+ISS";
            dataGridView1.Columns[12].Name = "LIQ CSRF+ISS";

            // Ajusta o tamanho automático das colunas
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void SeuFormulario_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void paginaInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 produto = new Form1();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculadora produto = new calculadora();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void cadastrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastros produto = new cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void leisEAlíquotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void loginsESenhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logins produto = new logins();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 produto = new Form1();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Aliquotas produto = new Aliquotas();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cadastros produto = new cadastros();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            logins produto = new logins();
            produto.StartPosition = FormStartPosition.CenterScreen;
            produto.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se um valor foi inserido na TextBox1
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Por favor, insira um valor antes de calcular.");
                    return;
                }

                // Converte o valor da TextBox para double
                if (!double.TryParse(textBox1.Text, out double valorBase))
                {
                    MessageBox.Show("Digite um valor numérico válido.");
                    return;
                }

                // Verifica se há uma alíquota selecionada na ComboBox2
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Selecione uma alíquota na ComboBox.");
                    return;
                }

                // Obtém o DataRowView da seleção atual da ComboBox2
                DataRowView rowSelecionada = comboBox2.SelectedItem as DataRowView;
                if (rowSelecionada == null)
                {
                    MessageBox.Show("Erro ao obter os dados da alíquota.");
                    return;
                }

                // Obtém a alíquota de ISS a partir da seleção da ComboBox2
                if (!double.TryParse(rowSelecionada["aliquota_iss"].ToString(), out double aliquotaIss))
                {
                    MessageBox.Show("Erro ao converter a alíquota de ISS.");
                    return;
                }

                // Converte a alíquota de ISS para porcentagem (por exemplo, 4 -> 0.04)
                aliquotaIss = aliquotaIss / 100;

                // Pega o valor das deduções (TextBox2). Se estiver vazio, define como 0
                double deducoes = 0;
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (!double.TryParse(textBox2.Text, out deducoes))
                    {
                        MessageBox.Show("Digite um valor válido para as deduções.");
                        return;
                    }
                }

                // Obtém a alíquota de IR a partir da ComboBox3
                double aliquotaIr = 0;
                if (comboBox3.SelectedItem != null)
                {
                    if (comboBox3.SelectedItem.ToString() == "1")
                        aliquotaIr = 0.01;
                    else if (comboBox3.SelectedItem.ToString() == "1.5")
                        aliquotaIr = 0.015;
                }
                else
                {
                    MessageBox.Show("Selecione uma alíquota de IR na ComboBox3.");
                    return;
                }

                // Calculando os diferentes valores
                double liqCsr = valorBase * 0.0465; // 4.65%
                double liqIss = valorBase * aliquotaIss; // Alíquota de ISS dinâmica
                double liqInss = (valorBase - deducoes) * 0.11; // 11% após deduções
                double liqIr = valorBase * aliquotaIr;
                double liqIrCsr = liqIr + liqCsr;
                double liqIrCsrInss = liqIrCsr + liqInss;
                double liqIrCsrInssIss = liqIrCsrInss + liqIss;
                double liqIrCsrIss = liqIrCsr + liqIss;
                double liqIrIss = liqIr + liqIss;
                double liqCsrIss = liqCsr + liqIss;
                double liqInssIss = liqInss + liqIss;

                // Calculando o valor restante após as deduções para cada coluna
                double liqCsrRestante = valorBase - liqCsr;
                double liqIssRestante = valorBase - liqIss;
                double liqInssRestante = valorBase - liqInss;
                double liqIrRestante = valorBase - liqIr;
                double liqIrCsrRestante = valorBase - liqIrCsr;
                double liqIrCsrInssRestante = valorBase - liqIrCsrInss;
                double liqIrCsrInssIssRestante = valorBase - liqIrCsrInssIss;
                double liqIrIssRestante = valorBase - liqIrIss;
                double liqCsrIssRestante = valorBase - liqCsrIss;
                double liqInssIssRestante = valorBase - liqInssIss;
                double liqIrCsrIssRestante = valorBase - liqIrCsrIss;

                // Adicionando os valores restantes na DataGridView
                dataGridView1.Rows.Add(
                    valorBase.ToString("C2"),
                    liqCsrRestante.ToString("C2"),
                    liqIssRestante.ToString("C2"),
                    liqInssRestante.ToString("C2"),
                    liqIrRestante.ToString("C2"),
                    liqIrCsrRestante.ToString("C2"),
                    liqIrCsrInssRestante.ToString("C2"),
                    liqIrCsrInssIssRestante.ToString("C2"),
                    liqIrCsrIssRestante.ToString("C2"),
                    liqCsrIssRestante.ToString("C2"),
                    liqInssIssRestante.ToString("C2"),
                    liqIrIssRestante.ToString("C2"),
                    liqCsrIssRestante.ToString("C2")
                );

                // Ajustando o tamanho das colunas de acordo com o conteúdo
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular o valor: " + ex.Message);
            }
        }


        private void PreencherComboBox()
        {
            string data_source = "server=localhost; userid=root; password=''; database=agt";
            conexao = new MySqlConnection(data_source);

            try
            {
                conexao.Open();

                // Preencher ComboBox1 com a coluna "municipio"
                string sql = "SELECT DISTINCT municipio FROM aliquotas;"; // DISTINCT evita duplicatas
                MySqlCommand comando = new MySqlCommand(sql, conexao);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                comboBox1.DataSource = dataTable;
                comboBox1.DisplayMember = "municipio";
                comboBox1.ValueMember = "municipio";

                // Evento para atualizar ComboBox2 quando um município for selecionado
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

                // Carregar a ComboBox2 com base no primeiro município da lista
                if (comboBox1.Items.Count > 0)
                {
                    AtualizarComboBox2(comboBox1.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os municípios: " + ex.Message);
            }
            finally
            {
                conexao.Close(); // Fecha a conexão ao final do método
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                AtualizarComboBox2(comboBox1.SelectedValue.ToString());
            }
        }

        private void AtualizarComboBox2(string municipio)
        {
            try
            {
                // Abrimos e fechamos a conexão apenas dentro deste método
                using (MySqlConnection conexaoTemp = new MySqlConnection("server=localhost; userid=root; password=''; database=agt"))
                {
                    conexaoTemp.Open();

                    string sql2 = "SELECT cod_servico, desc_servico, aliquota_iss FROM aliquotas WHERE municipio = @municipio;";
                    MySqlCommand comando2 = new MySqlCommand(sql2, conexaoTemp);
                    comando2.Parameters.AddWithValue("@municipio", municipio);
                    MySqlDataAdapter dataAdapter2 = new MySqlDataAdapter(comando2);
                    DataTable dataTable2 = new DataTable();
                    dataAdapter2.Fill(dataTable2);

                    // Criar uma nova coluna para armazenar a concatenação
                    dataTable2.Columns.Add("DescricaoCompleta", typeof(string));

                    foreach (DataRow row in dataTable2.Rows)
                    {
                        row["DescricaoCompleta"] = row["cod_servico"].ToString() + " - "
                                                  + row["desc_servico"].ToString() + " - "
                                                  + row["aliquota_iss"].ToString() + "%";
                    }

                    comboBox2.DataSource = dataTable2;
                    comboBox2.DisplayMember = "DescricaoCompleta"; // Exibe a concatenação
                    comboBox2.ValueMember = "cod_servico"; // Define o valor interno como o código do serviço
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
            }
        }

        private void calculadora_Load(object sender, EventArgs e)
        {

        }
    }
}
