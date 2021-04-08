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
        String palabraOculta = "CETYS";
        int numeroFallos = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void botonPulsado(object sender, EventArgs e)
        {
            Button miBoton = (Button)sender;
            String letra = miBoton.Text;
            letra = letra.ToUpper();
            Boolean finPartida = false;
            if (!finPartida)
            {

            }
            if (palabraOculta.Contains(letra))
            {
                int posicion = palabraOculta.IndexOf(letra);
                label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);
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
