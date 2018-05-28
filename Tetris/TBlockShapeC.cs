using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class TBlockShapeC : TBlockShape {
		

		//LeftThunder-shape
		public TBlockShapeC():base()
		{
			Blocks = new List<TBlock>();
			MoveBlocks = new TMoveBlocks (Blocks);

			TBlock Block = new TBlock();
			Block.X = 200;
			Block.Y = 0;
			Blocks.Add(Block);

			Block = new TBlock();
			Block.X = 200;
			Block.Y = 25;
			Blocks.Add(Block);

			Block = new TBlock();
			Block.X = 225;
			Block.Y = 25;
			Blocks.Add(Block);

			Block = new TBlock();
			Block.X = 225;
			Block.Y = 50;
			Blocks.Add(Block);

		}

		public override void DrawShape ()
		{
			foreach (TBlock Block in Blocks)
			{
				Block.TBlockColor = Color.Crimson;
				Block.Draw ();
			}
		}

		public override void MoveLeft (){
			MoveBlocks.MoveLeft ();
		}

		public override void MoveRight (){
			MoveBlocks.MoveRight ();
		}

		public override void MoveDown (){
			MoveBlocks.MoveDown ();
		}

		public override void Rotate (){
			MoveBlocks.Rotate ();
		}

		public override List<TBlock> GetBlocks
		{
			get {return Blocks;}
		}

		public override void DropDown (){
			
			MoveBlocks.DropDown ();
		}


	}	

}

