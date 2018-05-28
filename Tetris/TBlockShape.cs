using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public abstract class TBlockShape
	{
		public List<TBlock> Blocks;
		public TMoveBlocks MoveBlocks;


		public TBlockShape ()
		{
			Blocks = new List<TBlock>();
			MoveBlocks = new TMoveBlocks (Blocks);
		}

		public virtual void DrawShape() {
		}
			
		public abstract void MoveLeft ();

	
		public abstract void MoveRight ();


		public abstract void MoveDown ();


		public abstract void Rotate () ;


		public abstract List<TBlock> GetBlocks
		{
			get;
		}

		public abstract void DropDown () ;
	

	}
		
		
}


