using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FrmCalculadora : Form
    {
        double Numero1 = 0, Numero2 = 0;
        char Operador;
        public FrmCalculadora()
        {
            InitializeComponent();
        }

        private void AgregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);

            if (txtResultado.Text == "0")
                txtResultado.Text = "";

            txtResultado.Text += boton.Text;
        }
       
        private void btnIgual_Click(object sender, EventArgs e)
        {
            Numero2 = Convert.ToDouble(txtResultado.Text);

            if (Operador == '+')
            {
                txtResultado.Text = (Numero1 + Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '-')
            {
                txtResultado.Text = (Numero1 - Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == 'x')
            {
                txtResultado.Text = (Numero1 * Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '÷')
            {
                if (txtResultado.Text != "0")
                {
                    txtResultado.Text = (Numero1 / Numero2).ToString();
                    Numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else
                {
                    MessageBox.Show("No es posible dividir por cero!");
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text.Length > 1)
            {
                txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            

            Numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag);
            //Boton PALINDROMO está en Tag como A
            if (Operador == 'A')
            {               
                string Numero = Numero1.ToString();             
                               
                if (Numero == (new string(Numero.ToCharArray().Reverse().ToArray())))
                {
                    MessageBox.Show("Si es!");
                }
                else
                {
                    MessageBox.Show("No es!");
                }

               
                txtResultado.Text = Numero1.ToString();
            }
            //Boton Primo está en Tag como R
            else if (Operador == 'R')
            {
                double Contador = 0;
                 for (double PosicionNumero = 1; PosicionNumero <= Numero1; PosicionNumero++)
                {
                    if (Numero1 % PosicionNumero == 0) 
                    {
                        Contador++;
                    }
                }
                 if (Contador == 2)
                {
                    MessageBox.Show("Es un Número Primo!");
                }
                 else
                {
                    MessageBox.Show("No es un Número Primo!");
                }

            }
            else
            {
                txtResultado.Text = "0";
            }        
        }        
    }
}
