using System;
using NUnit.Framework;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture()]
	public class TestTBlockShape
	{
		[Test ()]
		public void TestTBlockShapeMovedLeft ()
		{
			TBlockShapeA BlockA = new TBlockShapeA ();
			List<TBlock> Blocks = new List<TBlock> ();
			BlockA.MoveLeft ();
			Blocks = BlockA.GetBlocks;
			//check whether BlockA's x and y corrdinates has been modified after one move left.
			Assert.AreEqual( 175, Blocks[0].X);
			Assert.AreEqual( 0, Blocks[0].Y);

			Assert.AreEqual( 200, Blocks[1].X);
			Assert.AreEqual( 0, Blocks[1].Y);

			Assert.AreEqual( 175, Blocks[2].X);
			Assert.AreEqual( 25, Blocks[2].Y);

			Assert.AreEqual( 200, Blocks[3].X);
			Assert.AreEqual( 25, Blocks[3].Y);

		}

		[Test ()]
		public void TestTBlockShapeMovedRight ()
		{
			TBlockShapeA BlockA = new TBlockShapeA ();
			List<TBlock> Blocks = new List<TBlock> ();
			BlockA.MoveRight ();
			Blocks = BlockA.GetBlocks;
			//check whether BlockA's x and y corrdinates has been modified after one move left. 
			Assert.AreEqual( 225, Blocks[0].X);
			Assert.AreEqual( 0, Blocks[0].Y);

			Assert.AreEqual( 250, Blocks[1].X);
			Assert.AreEqual( 0, Blocks[1].Y);

			Assert.AreEqual( 225, Blocks[2].X);
			Assert.AreEqual( 25, Blocks[2].Y);

			Assert.AreEqual( 250, Blocks[3].X);
			Assert.AreEqual( 25, Blocks[3].Y);
		}
		[Test ()]
		public void TestTBlockShapeMovedDown ()
		{
			TBlockShapeA BlockA = new TBlockShapeA ();
			List<TBlock> Blocks = new List<TBlock> ();
			BlockA.MoveDown ();
			Blocks = BlockA.GetBlocks;
			//check whether BlockA's x and y corrdinates has been modified after one move left. 
			Assert.AreEqual( 200, Blocks[0].X);
			Assert.AreEqual( 25, Blocks[0].Y);

			Assert.AreEqual( 225, Blocks[1].X);
			Assert.AreEqual( 25, Blocks[1].Y);

			Assert.AreEqual( 200, Blocks[2].X);
			Assert.AreEqual( 50, Blocks[2].Y);

			Assert.AreEqual( 225, Blocks[3].X);
			Assert.AreEqual( 50, Blocks[3].Y);

		}
		[Test ()]
		public void TestTBlockShapeRotate ()
		{
			TBlockShapeE BlockE = new TBlockShapeE ();
			List<TBlock> Blocks = new List<TBlock> ();
			BlockE.Rotate ();
			Blocks = BlockE.GetBlocks;
			//check whether BlockA's x and y corrdinates has been modified after one move left. 
			Assert.AreEqual( 275, Blocks[0].X);
			Assert.AreEqual( 75, Blocks[0].Y);

			Assert.AreEqual( 250, Blocks[1].X);
			Assert.AreEqual( 75, Blocks[1].Y);

			Assert.AreEqual( 225, Blocks[2].X);
			Assert.AreEqual( 75, Blocks[2].Y);

			Assert.AreEqual( 200, Blocks[3].X);
			Assert.AreEqual( 75, Blocks[3].Y);

		}


	}
}

