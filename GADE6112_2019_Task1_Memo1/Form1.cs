using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADETask2
{
    public partial class Form1 : Form
    {
        GameEngine engine;	
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
			
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text = "Round: " + engine.Round.ToString();
            engine.Update();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, 10, txtInfo, grpMap);

        }

    private void TxtInfo_TextChanged(object sender, EventArgs e)
    {

    }

		private void SaveBttn_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			engine.TheProperSave();
			MessageBox.Show("Saved");
		}

		private void lblRound_Click(object sender, EventArgs e)
		{

		}

		private void ReadBttn_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			engine.ReadSave();
			MessageBox.Show("Loaded please push Start");
		}
	}
}
