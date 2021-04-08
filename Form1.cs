using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ahorcado3
{
    public partial class Form1 : Form
    {
        //aquí almacenamos la palabra aleatoria que vamos a tener que adivinar
        String palabraOculta = eligePalabra();
        //almacenamos el número de fallos que vamos teniendo
        int numeroFallos = 0;
        public Form1()
        {
            InitializeComponent();
            String _palabraConGuiones = "";
            for (int i=0; i < palabraOculta.Length; i++)
            {
                if (palabraOculta[i] != ' ')
                {
                    _palabraConGuiones += "_ ";
                }
                else
                {
                    _palabraConGuiones += " ";
                }
                label1.Text = _palabraConGuiones;
            }
        }

        private static String eligePalabra()
        {
            String[] listaPlabras = {"Cetys", "sol", "DAM", "donuts"};
            Random aleatorio = new Random();
            int posicion = aleatorio.Next(listaPlabras.Length);
            return listaPlabras[posicion].ToUpper();
        }

        private void botonPulsado(object sender, EventArgs e)
        {
            Button miBoton = (Button)sender;
            String letra = miBoton.Text;
            letra = letra.ToUpper();
            //comprobamos si la letra está en la palabraOculta
            if (palabraOculta.Contains(letra))
            {
                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == letra[0])
                    {
                        label1.Text = label1.Text.Remove(2*i, 1 ).Insert(2*i, letra);
                    }
                }
            }
            else
            {
                numeroFallos++;
            }
            

            switch (numeroFallos)
            {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }

            if (!label1.Text.Contains('_'))
            {
                pictureBox1.Image = Properties.Resources.acertasteTodo;
            }
        }
    }
}
