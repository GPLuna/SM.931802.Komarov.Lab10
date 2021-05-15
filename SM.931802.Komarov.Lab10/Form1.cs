using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM._931802.Komarov.Lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dice Player = new Dice();
        Dice Comp = new Dice();
        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = Player.GenerateForPlayer();
            PRoll1.Text = array[0].ToString();
            PRoll2.Text = array[1].ToString();
            PRoll3.Text = array[2].ToString();
            PRoll4.Text = array[3].ToString();
            array = Comp.GenerateForComputer();
            CRoll1.Text = array[0].ToString();
            CRoll2.Text = array[1].ToString();
            CRoll3.Text = array[2].ToString();
            CRoll4.Text = array[3].ToString();
            PSum.Value = (PRoll1.Value + PRoll2.Value + PRoll3.Value + PRoll4.Value);
            CSum.Value = (CRoll1.Value + CRoll2.Value + CRoll3.Value + CRoll4.Value);
            if ((PSum.Value) > (CSum.Value))
            {
                Result.Text = "Player wins";
                PScore.Value += 1;
            }
            else if ((CSum.Value) > (PSum.Value))
            {
                Result.Text = "Computer wins";
                CScore.Value += 1;
            }
            else if ((CSum.Value) == (PSum.Value))
            {
                Result.Text = "Draw";
            }

        }

        public class Dice
        {
            int[] number = new int[6] { 1, 2, 3, 4, 5, 6 };
            Random r = new Random();
            public int[] GenerateForPlayer()
            {
                decimal[] prob = new decimal[6] { 0.16m, 0.17m, 0.17m, 0.17m, 0.17m, 0.17m };
                int[] array = new int[4];
                int k;
                decimal A;
                for (int i = 0; i < array.Length; i++)
                {
                    A = (decimal)r.NextDouble();
                    for (k = -1; A > 0; k++)
                    {
                        A -= prob[k + 1];
                    }
                    array[i] = number[k];
                }
                return array;
            }
            public int[] GenerateForComputer()
            {
                decimal[] prob = new decimal[6] { 0.1m, 0.1m, 0.1m, 0.2m, 0.2m, 0.3m };
                int[] array = new int[4];
                int k;
                decimal A;
                for (int i = 0; i < array.Length; i++)
                {
                    A = (decimal)r.NextDouble();
                    for (k = -1; A > 0; k++)
                    {
                        A -= prob[k + 1];
                    }
                    array[i] = number[k];
                }
                return array;
            }
        }
    }
}
