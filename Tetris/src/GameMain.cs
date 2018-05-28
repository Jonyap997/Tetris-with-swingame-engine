using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class GameMain
	{
		

		public static void Main()
		{
			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 900, 700);
			//SwinGame.ShowSwinGameSplashScreen();

			TBoard BoardCell = new TBoard ();
			TBlockShape BlockShape = null;

			//Run the game loop
			while(false == SwinGame.WindowCloseRequested())
			{
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.Black);

				//assign random shape to the parent TBlockShape BlockShape
				if (BlockShape == null) { 
					Random Rnd = new Random();
					switch (Rnd.Next(7))
					{
						case 0 : BlockShape = new TBlockShapeA(); break;
						case 1 : BlockShape = new TBlockShapeB(); break;
						case 2 : BlockShape = new TBlockShapeC(); break;
						case 3 : BlockShape = new TBlockShapeD(); break;
						case 4 : BlockShape = new TBlockShapeE(); break;
						case 5 : BlockShape = new TBlockShapeF(); break;
						case 6 : BlockShape = new TBlockShapeG(); break;
					}
				}

				BlockShape.DrawShape ();
				BoardCell.DrawBoard ();
				BlockShape.DropDown();

				//Checks for the condition whether it's ready to land.
				if (BoardCell.CheckLanding (BlockShape.GetBlocks) )
				{
					
					BoardCell.BlockLanding (BlockShape.GetBlocks);
					if (BoardCell.GameEnd == true)
					{
						BoardCell.ClearCell ();
						SwinGame.ClearScreen ();
						SwinGame.LoadBitmapNamed ("gameover", "SwinGameAni.png");
						SwinGame.DrawBitmap ("gameover", 330, 300);
						SwinGame.RefreshScreen ();
						SwinGame.Delay(5000);
						SwinGame.ReleaseAllResources();
						BoardCell.GameEnd = false;
						BoardCell.LineClearCount = 0;
						BoardCell.Score = 0;

					}

					BoardCell.EraseFullLine ();

					BlockShape = null;	
				}

					
				if(	SwinGame.KeyTyped (KeyCode.vk_LEFT))
				{
					BlockShape.MoveLeft();
				}

				if(	SwinGame.KeyTyped (KeyCode.vk_RIGHT))
				{
					BlockShape.MoveRight ();

				}

				if(	SwinGame.KeyTyped (KeyCode.vk_DOWN))
				{
					
					//BlockShape.MoveDown();
				}

				if(	SwinGame.KeyTyped (KeyCode.vk_UP))
				{
					BlockShape.Rotate();
				}



				//SwinGame.DrawFramerate(0,0);
				//Draw onto the screen
				SwinGame.RefreshScreen(20);
			}



		}
	


			

	}
}