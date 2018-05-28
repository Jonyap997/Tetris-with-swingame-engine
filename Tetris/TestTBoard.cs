using System;
using NUnit.Framework;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture()]
	public class TestTBoard
	{
		[Test()]
		public void TestBlockLanded ()
		{
			TBoard BoardCell = new TBoard ();
			TBlockShapeA BlockShapeA = new TBlockShapeA ();
			List<TBlock> Blocks = new List<TBlock> ();

			//move down the blockA untill it touchs the ground of the board and 
			//prove whether it can stack on it or not
			for (int row = 0; row < 22; row++)
			{
				BlockShapeA.MoveDown ();
				if (BoardCell.CheckLanding (BlockShapeA.GetBlocks))
				{
					BoardCell.BlockLanding (BlockShapeA.GetBlocks);
				}
			}
				
			Blocks = BlockShapeA.GetBlocks;

			Assert.AreEqual( 200, Blocks[0].X);
			Assert.AreEqual( 550, Blocks[0].Y);

			Assert.AreEqual( 225, Blocks[1].X);
		    Assert.AreEqual( 550, Blocks[1].Y);

			Assert.AreEqual( 200, Blocks[2].X);
			Assert.AreEqual( 575, Blocks[2].Y);

			Assert.AreEqual( 225, Blocks[3].X);
			Assert.AreEqual( 575, Blocks[3].Y);

		}


		[Test()]
		public void TestBlockErase ()
		{
			TBoard BoardCell = new TBoard ();
			List<TBlock> Blocks = new List<TBlock> ();
			TBlockShapeA BlockShapeA = new TBlockShapeA ();
			//fill the shape on the ground with leaving two block space as a hole so that
			//when blockA landed(filled) on that hole, it clears the line

			for(int i=0; i<8; i++)
			{
				TBlock Block = new TBlock ();
				BoardCell.BoardCells[i*25 , 550 ] = Block;
			}

			for(int i=0; i<6; i++)
			{
				int a = 250;
				TBlock Block = new TBlock ();
				BoardCell.BoardCells[a+(i*25) , 550 ] = Block;
			}

			for (int row = 0; row < 22; row++)
			{
				
				BlockShapeA.MoveDown ();
				if (BoardCell.CheckLanding (BlockShapeA.GetBlocks))
				{
					BoardCell.BlockLanding (BlockShapeA.GetBlocks);
					BoardCell.EraseFullLine ();
				}

			}

			for(int i=0; i<8; i++)
			{
				Assert.IsTrue (BoardCell.BoardCells [i * 25, 550] == null);
			}

			for(int i=0; i<6; i++)
			{
				int a =250;
				Assert.IsTrue (BoardCell.BoardCells [a+(i*25), 550] == null);
			}
				

		}




	}
}

