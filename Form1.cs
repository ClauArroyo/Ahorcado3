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
        //Almacenamos la palabra aleatoria que vamos a tener que adivinar
        String palabraOculta = eligePalabra();
        //Amacenamos el número de fallos que vamos teniendo
        int numeroFallos = 0;
        //Nos indica si la partida ha terminado o no
        bool finPartida = false;
        public Form1()
        {
            InitializeComponent();
            //creamos un string que almacenará los guiones de la palabra aleatoria
            String _palabraConGuiones = "";
            //una vez tengamos la palabra aleatoria con este bucle for iremos poniendo tantos guiones como letras tenga la palabra aleatoria
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
            //creamos un array con las distintas palabras para posteriormente elegir una aleatoriamente
            String[] listaPlabras = {"Cetys", "sol", "DAM", "donuts"};
            Random aleatorio = new Random();
            int posicion = aleatorio.Next(listaPlabras.Length);
            //ponemos todas las letras en mayúscula para así evitar posibles errores
            return listaPlabras[posicion].ToUpper();
        }

        private void botonPulsado(object sender, EventArgs e)
        {
            //con este método hacemos que los botones funcionen siempre y cuando no haya terminado la partida
            if (!finPartida)
            {
                Button miBoton = (Button)sender;
                miBoton.Enabled = false;
                String letra = miBoton.Text;
                letra = letra.ToUpper();
                chequeaLetra(letra);
            }
        }
        private void chequeaLetra (String letra)
        {
            //comprobamos si la letra está en la palabra oculta y si está cambiamos el guión por la letra o letras adivinadas
            if (palabraOculta.Contains(letra))
            {
                for (int i = 0; i < palabraOculta.Length; i++)
                {
                    if (palabraOculta[i] == letra[0])
                    {
                        label1.Text = label1.Text.Remove(2 * i, 1).Insert(2 * i, letra);
                    }
                }
                //si en pantalla no quedarán guiones significa que ha terminado la partida
                if (!label1.Text.Contains('_'))
                {
                    finPartida = true;
                }
            }
            //en el caso de que la letra no se encuentre en la palabra oculta aumentará el contador del número de fallos
            else
            {
                numeroFallos++;
                //también en el caso de que haya 6 o más errores significará que ha terminado la partida
                if (numeroFallos >= 6)
                {
                    finPartida = true;
                    label1.Text = "";
                }
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
            //Si en pantalla no hay más guiones siginficará que hemos acertado la palabra y saldrá la imagen correspondiente. Es el fin de la partida
            if (!label1.Text.Contains('_'))
            {
                pictureBox1.Image = Properties.Resources.acertasteTodo;
            }
            //Si hemos tenido más de 6 fallos significará que no hemos acertado la palbra y saldrá la imagen correspondiente. Es el fin de la partida
            if (numeroFallos >= 6)
            {
                pictureBox1.Image = Properties.Resources.gameOver;
            }
        }
    }
}
