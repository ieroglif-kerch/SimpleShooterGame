using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameSSG
{
	class ModelSSG
	{
		static public BufferedGraphicsContext context;
		static public BufferedGraphics buffer;

		SolidBrush backGround = new SolidBrush(Color.Gray);
		Pen		   border     = new Pen(Color.Black);
		Size       playGroundSize;
 public HeroSSG	   hero;

		
		const int WIDTHMIN  = 150;
		const int HEIGHTMIN = 250;

		public ModelSSG(Graphics G, Size Size)
		{
			if (Size.Width < WIDTHMIN || Size.Height < HEIGHTMIN)
			{
			 throw new Exception( $"Wrong playground size: Widht > {WIDTHMIN}, Height > {HEIGHTMIN}" );
			}
			playGroundSize = Size;
			hero = new HeroSSG();
			context = BufferedGraphicsManager.Current;
			buffer = context.Allocate( G, new Rectangle(new Point( 0, 0), playGroundSize ) );

			CreateStage();

			Draw();
		}

		/// <summary>
		/// Draw playground
		/// </summary>
		private void CreateStage()
		{
			buffer.Graphics.FillRectangle( backGround, new Rectangle(new Point(0,0), playGroundSize ));

			buffer.Graphics.DrawLine( border, 
									  playGroundSize.Width / 5, 0,							//begin line
									  playGroundSize.Width / 5, playGroundSize.Height );	//end   line
			buffer.Graphics.DrawLine( border, 
									  playGroundSize.Width*4 / 5, 0,						//begin line
									  playGroundSize.Width * 4 / 5, playGroundSize.Height );//end   line

		}

		public void Draw()
		{
			if(hero.Condition!=0)
			{
			//erase current position
			buffer.Graphics.DrawEllipse( new Pen(Color.Gray), new Rectangle( hero.Positon, new Size( 5, 5 ) ) );
			//new position
			hero.Move();
			//paint hero
			buffer.Graphics.DrawEllipse( new Pen( Color.Black ), new Rectangle( hero.Positon, new Size( 5, 5 ) ) );
			}
			buffer.Render();
		}
		
	}
}
