using System;
					
public class Program
{
	public static void Main()
	{
		int userOption = 0;
		int computerOption = 0;
		var rand = new Random();
		
		while(true){
		
			Console.WriteLine("Choose 1-Rock 2-Paper 3-Scissors 4-Exit");
			
			Int32.TryParse(Console.ReadLine(), out userOption);
			
			if(userOption == 4) break;
			else if(userOption > 4){
				Console.WriteLine("Not a valid option, play again!");
				continue;
			}
			
			computerOption = rand.Next(1,3);
			
			if(computerOption == userOption){
				Console.WriteLine("Tied! Play again");
				continue;
			}
			
			switch(computerOption){
				case 1:
					Console.WriteLine("\nComputer chose: Rock");
					if(userOption == 2){
						Console.WriteLine("You Win!\n");
					}
					else
					{
						Console.WriteLine("You lose!\n");
					}
					break;
				case 2:
					Console.WriteLine("Computer chose: Paper");
					
					if(userOption == 3){
						Console.WriteLine("You Win!\n");
					}
					else
					{
						Console.WriteLine("You lose!\n");
					}
					break;
				case 3:
					Console.WriteLine("Computer chose: Scissors");
					if(userOption == 1){
						Console.WriteLine("You Win!\n");
					}
					else
					{
						Console.WriteLine("You lose!\n");
					}
					break;
			}
			
		}
		
		Console.WriteLine("Bye!");
		
	}
}