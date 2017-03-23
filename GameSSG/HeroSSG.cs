using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;	//for use extern libraries

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
		  int STEP = 5;
		
		//Add extern library for GetKeyState
		[DllImport( "USER32.dll" )]
		//method declaration
		static extern short GetKeyState( Keys key);
		//Result Filter, methor return diferent button statuses, we need only if key pressed
		private const int KEY_PRESSED = 0x8000;
		//----------------------------------

		public bool IsPressed(Keys key)
		{
			int i = GetKeyState( key ) & KEY_PRESSED;
			return Convert.ToBoolean( i  );
		}

		public HeroSSG(int X = 100, int Y = 20)
		{
			positon = new Point( X, Y );
		}
		/// <summary>
		/// Calculate next position coordinats
		/// </summary>
		public void Move()
		{
			//if push only one button
				 if (IsPressed( Keys.A )) Condition = Direction.Left;
			else if (IsPressed( Keys.D )) Condition = Direction.Right;
			else if (IsPressed( Keys.W )) Condition = Direction.Top;
			else if (IsPressed( Keys.S )) Condition = Direction.Down;
			//if two
				 if (IsPressed( Keys.A ) && IsPressed( Keys.W )) Condition = Direction.Top_Left;
			else if (IsPressed( Keys.D ) && IsPressed( Keys.W )) Condition = Direction.Top_Right;
			else if (IsPressed( Keys.S ) && IsPressed( Keys.A )) Condition = Direction.Down_Left;
			else if (IsPressed( Keys.S ) && IsPressed( Keys.D )) Condition = Direction.Down_Right;


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
			Condition = 0;
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
		
		}

		/// <summary>
		/// Hero correct stoping 
		/// </summary>
		/// <param name="KeyCode"></param>
		public void Stop( Keys KeyCode)
		{
	
		}	
	}

}
