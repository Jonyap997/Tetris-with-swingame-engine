using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class TMoveBlocks
	{
		List<TBlock> Blocks = new List<TBlock>();
		List<TBlock> BlockSrc;


		public TMoveBlocks (List<TBlock> TBlockShape)
		{
			//TBlockShape = (shapes-lshape, squre ...)
			BlockSrc = TBlockShape;
		}

		private void do_CopyBlocks() {
			Blocks.Clear(); //deltete all the items in Blocks 
			for (int i = 0; i < BlockSrc.Count; i++) {
				TBlock Block = new TBlock();
				Block.X = BlockSrc[i].X;
				Block.Y = BlockSrc[i].Y;
				Blocks.Add(Block);
			}
		}
	

	
		private void do_CopyToBlockSrc( ) {
			
			for (int i = 0; i < Blocks.Count; i++) {
				BlockSrc[i].X =  Blocks[i].X;
				BlockSrc[i].Y =  Blocks[i].Y;
			}
				
		}
			

			
		private int do_GetStartX() {
			int Result = 1000;

			for (int i = 0; i < Blocks.Count; i++) {
				int X =  Blocks[i].X;
				if (X < Result)
				{
					Result = X;
				}
			}
				
			return Result;
		}

		private int do_GetEndX() {
			int Result = -1000;

			for (int i = 0; i < Blocks.Count; i++) {
				int X = Blocks[i].X;
				if (X > Result)
				{
					Result = X;
				}
			}

	

			return Result;
		}

		private int do_GetStartY() {
			int Result = 1000;

			for (int i = 0; i < Blocks.Count; i++) {
				int Y = Blocks[i].Y;
				if (Y < Result)
				{
					Result = Y;
				}
			}
				

			return Result;
		}

		private int do_GetEndY() {
			int Result = -1000;

			for (int i = 0; i < Blocks.Count; i++) {
				int Y =  Blocks[i].Y;
				if (Y > Result) Result = Y;
			}

		

			return Result;
		}

		public void MoveLeft ()
		{
			do_CopyBlocks ();

			for (int i = 0; i < Blocks.Count; i++) {
				TBlock Block = Blocks[i];
				Block.X = Block.X - 25;
				//To prevent shape to be out of left side board.
				if (Block.X < 0 )
					return;
			}

			do_CopyToBlockSrc ();
		}

		public void MoveRight() {
			do_CopyBlocks();

			for (int i = 0; i < Blocks.Count; i++) {
				TBlock Block = Blocks[i];
				Block.X = Block.X + 25;
				//To prevent shape to be out of right side board.
				if (Block.X >= 400) 
					return;
			}

			do_CopyToBlockSrc();
		}

		public void MoveDown() {
			do_CopyBlocks();

			for (int i = 0; i < Blocks.Count; i++) {
				TBlock Block = Blocks[i];
				Block.Y = Block.Y + 25;
				//To prevent shape to be out of down side board.
				if (Block.Y >= 600) 
					return;
			}

			do_CopyToBlockSrc();
		}
			

		public void Rotate() {
			do_CopyBlocks();

			int StartX = do_GetStartX();
			int StartY = do_GetStartY();
			int EndX = do_GetEndX();
			int EndY = do_GetEndY();

			for (int Loop = 0; Loop < Blocks.Count; Loop++) {
				TBlock Block = Blocks[Loop];
				int X = Block.X;
				int Y = Block.Y;

				//To prevent shape to be of left side board.
				Block.X = StartX + (EndY - Y);
				if (Block.X >= 400)
					return;
				
				Block.Y = X + EndY - EndX;
				//To prevent shape to be of right side board.
				if (Block.Y >= 600)
					return;
				
				
			}

			do_CopyToBlockSrc();
		}


		public void DropDown() {
			
			do_CopyBlocks();
			foreach (TBlock block in Blocks)
			{
				block.DropDown ();
				if (block.Y >= 600)
					return;
			}

			do_CopyToBlockSrc();

		}


	}
}

