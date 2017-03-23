using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSSG
{
	public partial class GameForm : Form
	{
		ModelSSG game;
		
	
		public GameForm()
		{
			InitializeComponent();
		}

		private void Form_Paint( object sender, PaintEventArgs e )
		{
			game = new ModelSSG( this.CreateGraphics(), this.ClientSize );
		}

		private void timer1_Tick( object sender, EventArgs e )
		{
			game.Draw();
		}

		private void GameForm_KeyDown( object sender, KeyEventArgs e )
		{
			game.hero.MoveTo( e.KeyCode );
		}



		private void GameForm_KeyUp( object sender, KeyEventArgs e )
		{


			game.hero.Stop( e.KeyCode );

		}

		
	}
}
