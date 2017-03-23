using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameSSG
{
	enum Direction
	{
		Top = 1,
		Down,
		Left,
		Right,
		Top_Right,
		Top_Left,
		Down_Right,
		Down_Left
	}
	
	class HeroSSG
	{
		Point  positon;
		public Point	 Direct    { get; set; }
		public Direction Condition { get; set; }
		const  int STEP = 5;
		bool reway=false;
	
		

		public HeroSSG(int X = 100, int Y = 20)
		{
			positon = new Point( X, Y );
		}
		/// <summary>
		/// Calculate next position coordinats
		/// </summary>
		public void Move()
		{
			if (Condition == Direction.Top)   positon.Y -= STEP; 
			if (Condition == Direction.Down)  positon.Y += STEP;
			if (Condition == Direction.Left)  positon.X -= STEP;
			if (Condition == Direction.Right) positon.X += STEP;
			if (Condition == Direction.Top_Left)
				{
				positon.X -= STEP;
				positon.Y -= STEP;
				}
			if (Condition == Direction.Top_Right)
				{
				positon.X += STEP;
				positon.Y -= STEP;
				}
			if(Condition == Direction.Down_Left)
				{
				positon.X -= STEP;
				positon.Y += STEP;
				}
			if(Condition == Direction.Down_Right)
			{
				positon.X += STEP;
				positon.Y += STEP;
			}
		}

		public Point Positon 
		{ 
		get {return positon;}
		}

		/// <summary>
		/// Change hero direction
		/// </summary>
		/// <param name="KeyCode"></param>
		public void MoveTo( Keys KeyCode )
		{
			
			if (Condition == 0)
			{
				switch (KeyCode)
				{
					case Keys.A: Condition = Direction.Left; break;
					case Keys.D: Condition = Direction.Right; break;
					case Keys.W: Condition = Direction.Top; break;
					case Keys.S: Condition = Direction.Down; break;
				}

			} else
			{
				if (Condition == Direction.Top)
					switch (KeyCode)
					{
						case Keys.D: Condition = Direction.Top_Right; break;
						case Keys.A: Condition = Direction.Top_Left; break;
					}
				if (Condition == Direction.Down)
					switch (KeyCode)
					{
						case Keys.D: Condition = Direction.Down_Right; break;
						case Keys.A: Condition = Direction.Down_Left; break;
					}
				if (Condition == Direction.Right)
					switch (KeyCode)
					{
						case Keys.W: Condition = Direction.Top_Right; break;
						case Keys.S: Condition = Direction.Down_Right; break;
						case Keys.A: Condition = Direction.Left; reway = true; break;

					}
				if (Condition == Direction.Left)
					switch (KeyCode)
					{
						case Keys.W: Condition = Direction.Top_Left; break;
						case Keys.S: Condition = Direction.Down_Left; break;
						case Keys.D: Condition = Direction.Right; reway = true; break;
					}
			}
		}

		/// <summary>
		/// Hero correct stoping 
		/// </summary>
		/// <param name="KeyCode"></param>
		public void Stop( Keys KeyCode)
		{
				if (( ( Condition == Direction.Top && KeyCode == Keys.W )
						|| ( Condition == Direction.Down && KeyCode == Keys.S )
						|| ( Condition == Direction.Right && KeyCode == Keys.D )
						|| ( Condition == Direction.Left && KeyCode == Keys.A ) ) && reway == false)
				{
					Condition = 0;
				} 
				
				else if (( Condition == Direction.Right && KeyCode == Keys.D ) && reway == true)
				{
					Condition = Direction.Left;
					reway = false;
				} else if (( Condition == Direction.Left && KeyCode == Keys.A ) && reway == true)
				{
					Condition = Direction.Right;
					reway = false;
				} else
				{

					if (Condition == Direction.Top_Left)
						switch (KeyCode)
						{
							case Keys.W: Condition = Direction.Left; break;
							case Keys.A: Condition = Direction.Top; break;
						}
					if (Condition == Direction.Down_Left)
						switch (KeyCode)
						{
							case Keys.S: Condition = Direction.Left; break;
							case Keys.A: Condition = Direction.Down; break;
						}
					if (Condition == Direction.Top_Right)
						switch (KeyCode)
						{
							case Keys.W: Condition = Direction.Right; break;
							case Keys.D: Condition = Direction.Top; break;
						}
					if (Condition == Direction.Down_Right)
						switch (KeyCode)
						{
							case Keys.D: Condition = Direction.Down; break;
							case Keys.S: Condition = Direction.Right; break;
						}
				}
		}	
	}

}
