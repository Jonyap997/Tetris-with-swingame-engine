using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class TBoard
	{
		public int _startX, _startY, _endX, _endY;
		private TBlock[,] Cells;
		public bool result;
		public bool _GameEnd;
		int _lineclearcount;
		int _score;

		public TBoard ()
		{
			Cells = new TBlock[400, 625];
			GameEnd = false;
			_lineclearcount = 0;
			_score = 0;


			_startX = 0;
			_endX = 400;
			_startY = 100;
			_endY = 600;

			for (int LoopX = 0; LoopX < 400; LoopX++)
			{
				for (int LoopY = 0; LoopY < 600; LoopY++)
				{
					Cells [LoopX, LoopY] = null;
				}
			}

			for (int LoopX = 0; LoopX < 400; LoopX++)
			{
				for (int LoopY = 0; LoopY < 625; LoopY++)
				{
					if (LoopY == 600)
					{
						TBlock Block = new TBlock ();
						Cells [LoopX, LoopY] = Block;
					}
				}
			}



		}

		public void DrawBoard ()
		{
			//draw the vertical and horizontal lines to look like a tetris board
			for (int i = 0; i <= 16; i++)
			{
				SwinGame.DrawVerticalLineOnScreen (Color.Aquamarine, _startX + (i*25), _startY + 0, _endY);
			}

			for (int i = 0; i <= 20; i++)
			{
				SwinGame.DrawHorizontalLineOnScreen (Color.Aquamarine, _startY + (i * 25), _startX, _endX); 
			}	

			//Draw the shape into the board if cells are not null
			for (int LoopX = 0; LoopX < 400; LoopX++)
			{
				for (int LoopY = 0; LoopY < 625; LoopY++)
				{
					if (Cells [LoopX, LoopY] != null)
					{
						Cells [LoopX, LoopY].Draw();
					}
				}
			}

			SwinGame.LoadBitmapNamed ("TetrisHeader", "fdFolder.png");
			SwinGame.DrawBitmap ("TetrisHeader", 0, 0);

			SwinGame.LoadBitmapNamed ("face", "FileDialog_Active.png");
			SwinGame.DrawBitmap ("face", 500, 0);

			SwinGame.DrawTextOnScreen ("************WELCOME TO SWIN TETRIS************", Color.Aquamarine,SwinGame.LoadFont ("Arial", 18), 450 ,100);
			SwinGame.DrawTextOnScreen ("Left&Right: Move", Color.Aquamarine, SwinGame.LoadFont ("Arial", 18), 450, 160);
			SwinGame.DrawTextOnScreen ("UP: Rotation", Color.Aquamarine, SwinGame.LoadFont ("Arial", 18), 450, 180);
			//SwinGame.DrawTextOnScreen ("DOWN: MoveDown", Color.Aquamarine, SwinGame.LoadFont ("Arial", 18), 450, 200);
			SwinGame.LoadBitmapNamed ("TetrisImg", "fdFile.png");
			SwinGame.DrawBitmap ("TetrisImg", 420, 300);


			SwinGame.DrawTextOnScreen ("LINECLEAR: " + _lineclearcount , Color.Aquamarine,SwinGame.LoadFont ("Arial", 18), 450, 260);
			SwinGame.DrawTextOnScreen ("SCORE: " + _score , Color.Aquamarine,SwinGame.LoadFont ("Arial", 18), 450, 280);
			SwinGame.DrawTextOnScreen ("****************************************************", Color.Aquamarine,SwinGame.LoadFont ("Arial", 18), 450, 600);
			SwinGame.ReleaseAllResources();
		}

		public void ClearCell()
		{
			for (int LoopX = 0; LoopX < 400; LoopX++)
				for (int LoopY = 0; LoopY < 600; LoopY++)
				{
					Cells [LoopX, LoopY] = null;
				}
		}	

		public bool CheckLanding (List<TBlock> Blocks)
		{
			result = false;

			for(int Loop = 0; Loop < Blocks.Count; Loop++) 
			{ 
				TBlock Block = Blocks[Loop];

				//To make able to stack shape on the drawn cells, 
				//checking wheter that below cells is not null is requried

				if  (Cells[Block.X, Block.Y+25] != null) 
				{
					result = true;	
				}

			}
			return result;
		}

		public void BlockLanding(List<TBlock> Blocks) {
			for(int Loop = 0; Loop < Blocks.Count; Loop++) { 
				TBlock Block = Blocks[Loop];
				if (Block.Y <= 100)
				{
					//SwinGame.ClearScreen(Color.White);
					_GameEnd = true;
				}
				Cells [Block.X, Block.Y] = Block;
			}
		}
			
	
		/*
		public bool MoveDownCheck (List<TBlock> Blocks)
		{
			
			bool result = false;
			bool[] boolarray = new bool[4];
			boolarray [0] = false;
			boolarray [1] = false;
			boolarray [2] = false;
			boolarray [3] = false;

			for(int Loop = 0; Loop < Blocks.Count; Loop++) 
			{ 
				TBlock Block= Blocks[Loop];

				if  (Cells[Block.X, Block.Y+25] == null  ) 
				{
					boolarray [Loop] = true;
				}

			}

			if (boolarray[0]==true && boolarray[1]==true && boolarray[2]==true && boolarray[3]==true)
			{

				result = true;

			}

			return result;
		}

		*/
		/*
		public bool MoveRightCheck (List<TBlock> Blocks)
		{
			try{
			result = false;
			
			bool[] boolarray = new bool[4];
			boolarray [0] = false;
			boolarray [1] = false;
			boolarray [2] = false;
			boolarray [3] = false;

			for(int Loop = 0; Loop < Blocks.Count; Loop++) 
			{ 
				TBlock Block = Blocks[Loop];

				if  (Cells[Block.X+25, Block.Y] == null  ) 
				{
					boolarray[Loop] = true;

				}
					
			}
			if (boolarray[0]==true && boolarray[1]==true && boolarray[2]==true && boolarray[3]==true)
			{
				
					result = true;


			}
			return result;

			}catch (ArgumentOutOfRangeException ex){
				throw new ArgumentOutOfRangeException ("Blocks", ex);
			}
		}
		*/
	
		public bool do_CheckFullLine(int row) {
			for (int LoopX = 0; LoopX < 16; LoopX++){
				 if (Cells[LoopX*25, row*25] == null) {
					return false;
				}
			}
			return true;
		}

		private void do_EraseFullLine(int Row) {
			//delete the fulline by assiging the null value!
			for (int Loop = 0; Loop < 16; Loop++) {
				Cells[Loop*25, Row*25] = null;
			}

			//All the upper lines have to one step(25) down to replace on the deleted empty line 
			for (int LoopX = 0; LoopX < 16; LoopX++)
				for (int LoopY = Row; LoopY > 1; --LoopY) {
					//step down(25) all upper lines
					Cells[LoopX*25, LoopY*25] = Cells[LoopX*25, (LoopY*25)-25];
					//if that replaced downed part also full
					if (Cells[LoopX*25, LoopY*25] != null) {
						Cells[LoopX*25, LoopY*25].X = LoopX*25;
						Cells[LoopX*25, LoopY*25].Y = LoopY*25;
					}
				}
		}
			
		public void EraseFullLine() {
			for (int row = 0; row < 24; row++)
				if (do_CheckFullLine (row) == true)
				{
					do_EraseFullLine (row);
					_lineclearcount++;
					_score = _score + 100;
				}
		}


		public TBlock[,] BoardCells
		{
			get { return Cells; }
			set { Cells = value; }
		}

		public bool GameEnd
		{
			get { return _GameEnd; }
			set { _GameEnd = value; }
		}

		public int LineClearCount
		{
			get { return _lineclearcount; }
			set { _lineclearcount = value; }
		}

		public int Score
		{
			get { return _score; }
			set { _score = value; }
		}



	}
}

