using System;

namespace _DiceBattle
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			Console.SetWindowSize(82, 21);
			Console.SetBufferSize(82, 21);

			//Random alea = new Random();
			Random alea = new ChargedDie();

			String leftPlayer, rightPlayer;
			int die1Left, die2Left, die1Right, die2Right;
			int leftPoints, rightPoints;
			bool rightHasDouble, leftHasDouble;
			bool onlyOneHasDouble;
			bool wannaPlay;
			int battleNumber;
			int throwNumber;
			char answer;

			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("****************************");
			Console.WriteLine("        DICE WAR         ");
			Console.WriteLine("****************************");
			Console.WriteLine();
			Console.ResetColor();

			Console.WriteLine("In dice war two players compete against each other");
			Console.WriteLine("A war may have one or more battles");
			Console.WriteLine("In each battle the players throw their dice ");
			Console.WriteLine("until one gets a double and the other doesn't");
			Console.WriteLine("The player who gets a double is awarded one point");
			Console.WriteLine("The winner of the war is the player who has won more battles");
			Console.WriteLine();

			Console.Write("Left player, please enter your name ");
			Console.ForegroundColor = ConsoleColor.Green;
			leftPlayer = Console.ReadLine();
			Console.ResetColor();

			Console.Write("Right player, please enter your name ");
			Console.ForegroundColor = ConsoleColor.Green;
			rightPlayer = Console.ReadLine();
			Console.ResetColor();

			/* TODO 1 COMPLETE */

			Console.Clear();		// clean the console

			wannaPlay = true;       // we make sure that there wil be at least one battle
			rightHasDouble = false;
			leftHasDouble = false;
			onlyOneHasDouble = false;

			battleNumber = 1;
			throwNumber = 1;

			leftPoints = 0;
			rightPoints = 0;

			answer = 'o';

			while ( wannaPlay )			// if we say yes to play again
			{
				/* TODO 3 COMPLETE */
				while ( onlyOneHasDouble == false )				// if there is no double yet		
				{

					// show the current status of the game
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.WriteLine("\t\t\tNow playing: ");
					Console.WriteLine("\t\t\t     {0} with {1} points", leftPlayer, leftPoints);
					Console.WriteLine("\t\t\t     {0} with {1} points", rightPlayer, rightPoints);
					Console.WriteLine("\t\t\tBattle number: " + battleNumber);
					Console.WriteLine("\t\t\tThrow number: " + throwNumber);

					Console.ResetColor();       
					// the players throws the dices

					// the left player throw the dices
					Console.WriteLine("\n{0} press A to throw your dices",leftPlayer);
					while (Console.ReadKey(true).Key != ConsoleKey.A) { }

					die1Left = alea.Next(1, 7);
					die2Left = alea.Next(1, 7);

					Console.WriteLine();
					Console.Write("\tDie 1");
					Console.Write("\tDie 2");
					Console.Write("\n\t-----");
					Console.Write("\t-----");

					Console.ForegroundColor = ConsoleColor.Magenta;     // temporal because I don't kinow how to make pink colour
					Console.WriteLine();
					Console.Write("\t  {0}", die1Left);
					Console.Write("\t  {0}", die2Left);
					Console.ResetColor();


					// the right player throw the dices
					Console.WriteLine("\n\n\t\t\t\t{0} press L to throw your dices", rightPlayer);
					while (Console.ReadKey(true).Key != ConsoleKey.L) { }

					die1Right = alea.Next(1, 7);
					die2Right = alea.Next(1, 7);

					Console.WriteLine("\n\n");
					Console.Write("\t\t\t\t\t\t\tDie 1");
					Console.Write("\tDie 2");
					Console.Write("\n\t\t\t\t\t\t\t-----");
					Console.Write("\t-----");

					Console.ForegroundColor = ConsoleColor.Magenta;     // temporal because I don't kinow how to make pink colour
					Console.WriteLine();
					Console.Write("\t\t\t\t\t\t\t  {0}", die1Right);
					Console.Write("\t  {0}", die2Right);
					Console.ResetColor();

					// check if any of the players have a double
					// player left
					if (die1Left == die2Left)
					{
						leftHasDouble = true;
					}
					else {
						leftHasDouble = false;
					}

					// player right
					if (die1Right == die2Right)
					{
						rightHasDouble = true;
					}
					else {
						rightHasDouble = false;
					}

					// check if only one of them have a double
					onlyOneHasDouble = (leftHasDouble == true && rightHasDouble == false) || (leftHasDouble == false && rightHasDouble == true);


					// check if someone won
					if (onlyOneHasDouble && leftHasDouble)
					{
						leftPoints++;

						Console.SetCursorPosition(0, Console.WindowHeight - 2);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\t\t   {0} (left) has won this battle",leftPlayer);
						Console.ResetColor();
						Console.Write("\t\t   Press the SPACE BAR to continue");
						while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

					}
					else if (onlyOneHasDouble && rightHasDouble)
					{
						rightPoints++;

						Console.SetCursorPosition(0, Console.WindowHeight - 2);
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine("\t\t   {0} (right) has won this battle", rightPlayer);
						Console.ResetColor();
						Console.Write("\t\t   Press the SPACE BAR to continue");
						while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

					}
					else {      // nadie tiene un doble o ambos lo tienen
						
						Console.SetCursorPosition(0, Console.WindowHeight -1);
						Console.Write("\t   No winner yet. Get ready to throw again. Press SPACE BAR");
						while (Console.ReadKey(true).Key != ConsoleKey.Spacebar) { }

					}

					// add a throw 
					throwNumber++;

					Console.Clear();

				}// here just only one has a double so one of both players has won

				battleNumber++;

				// once one of them win a battle we ask if they want to continue
				while (!(answer == 'y' || answer == 'Y' || answer == 'n' || answer == 'N'))
				{
					Console.Write("Do you wan to play again? (enter y or Y or n or N) " );
					answer = Convert.ToChar(Console.ReadLine());
					if (answer == 'y' || answer == 'Y')
					{
						wannaPlay = true;
						onlyOneHasDouble = false;       // we reset the variable to make the while loop able to loop again
						Console.Clear();
					}
					else if (answer == 'n' || answer == 'N')
					{
						wannaPlay = false;
						onlyOneHasDouble = false;
						Console.Clear();
					}
					else {
						Console.WriteLine("{0} is not a correct answer", answer);
					}

					throwNumber = 1;
				}

				answer = 'o';	// reset the anser variable to make the loop able to work again

			}// when here players have decided not to play again so we present the end resoults


			// ANNOUNCE OUTCOME OF WAR and terminate
			Console.Clear();
			Console.WriteLine("Goodbye " + leftPlayer + " and " + rightPlayer);
			Console.WriteLine();
			if (leftPoints == rightPoints)
			{
				Console.WriteLine("None has won. You have the same number of points");
			}
			else {
				String winner;
				int points;
				if (leftPoints > rightPoints)
				{
					winner = leftPlayer;
					points = leftPoints;
				}
				else {
					winner = rightPlayer;
					points = rightPoints;
				}
				Console.WriteLine(winner + " has won this dice war with " + points + " points");
			}
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.Write("Press any key to exit");
			Console.ReadKey(true);

		}
	}



	// tampered with random generator: generates a predictable sequence.
	class ChargedDie : Random
	{
		private int[] seq = { 2, 3, 5, 1, 3, 3, 2, 2, 6, 1, 4, 4, 6, 6, 6, 1, 2, 3, 3, 6, 4, 2, 5, 5, 6, 1, 3, 3 };

		private int next;

		public ChargedDie() { next = 0; }
		public override int Next(int lower, int upper)
		{
			int value = seq[next];
			next = (next + 1) % seq.Length;
			return value;
		}
	}

}
