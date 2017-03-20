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
		bool reway;

		public HeroSSG(int X = 100, int Y = 20)
		{
			positon = new Point( X, Y );
		}
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
					case Keys.Left: Condition = Direction.Left; break;
					case Keys.Right: Condition = Direction.Right; break;
					case Keys.Up: Condition = Direction.Top; break;
					case Keys.Down: Condition = Direction.Down; break;
				}

			} else
			{
				if (Condition == Direction.Top)
					switch (KeyCode)
					{
						case Keys.Right: Condition = Direction.Top_Right; break;
						case Keys.Left: Condition = Direction.Top_Left; break;
					}
				if (Condition == Direction.Down)
					switch (KeyCode)
					{
						case Keys.Right: Condition = Direction.Down_Right; break;
						case Keys.Left: Condition = Direction.Down_Left; break;
					}
				if (Condition == Direction.Right)
					switch (KeyCode)
					{
						case Keys.Up: Condition = Direction.Top_Right; break;
						case Keys.Down: Condition = Direction.Down_Right; break;
						case Keys.Left: Condition = Direction.Left; reway = true; break;

					}
				if (Condition == Direction.Left)
					switch (KeyCode)
					{
						case Keys.Up: Condition = Direction.Top_Left; break;
						case Keys.Down: Condition = Direction.Down_Left; break;
						case Keys.Right: Condition = Direction.Right; reway = true; break;
					}
			}
		}

		/// <summary>
		/// Hero correct stoping 
		/// </summary>
		/// <param name="KeyCode"></param>
		public void Stop( Keys KeyCode)
		{
			if (( ( Condition == Direction.Top && KeyCode == Keys.Up )
					|| ( Condition == Direction.Down && KeyCode == Keys.Down )
					|| ( Condition == Direction.Right && KeyCode == Keys.Right )
					|| ( Condition == Direction.Left && KeyCode == Keys.Left ) ) && reway == false)
			{
				Condition = 0;
			} else if (( Condition == Direction.Right && KeyCode == Keys.Right ) && reway == true)
			{
				Condition = Direction.Left;
				reway = false;
			} else if (( Condition == Direction.Left && KeyCode == Keys.Left ) && reway == true)
			{
				Condition = Direction.Right;
				reway = false;
			} else
			{

				if (Condition == Direction.Top_Left)
					switch (KeyCode)
					{
						case Keys.Up: Condition = Direction.Left; break;
						case Keys.Left: Condition = Direction.Top; break;
					}
				if (Condition == Direction.Down_Left)
					switch (KeyCode)
					{
						case Keys.Down: Condition = Direction.Left; break;
						case Keys.Left: Condition = Direction.Down; break;
					}
				if (Condition == Direction.Top_Right)
					switch (KeyCode)
					{
						case Keys.Up: Condition = Direction.Right; break;
						case Keys.Right: Condition = Direction.Top; break;
					}
				if (Condition == Direction.Down_Right)
					switch (KeyCode)
					{
						case Keys.Right: Condition = Direction.Down; break;
						case Keys.Down: Condition = Direction.Right; break;
					}
			}
		}	
	}
}
