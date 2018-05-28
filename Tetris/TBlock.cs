using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class TBlock
	{
		public  int Width = 25;
		public  int Height = 25;
		public int X = 0, Y = 0;
		private Color _color;

		public TBlock ():this (Color.Green)
		{
		}

		public TBlock (Color color)
		{
			_color = color;
		}
			
		public void Draw() {
			
			SwinGame.FillRectangle(_color, X, Y , Width, Height);

		}
			

		public Color TBlockColor 
		{
			get{ return _color; }
			set{ _color = value; }
		}

		public void DropDown() {
			Y = Y + 5;
		}

	}
}

