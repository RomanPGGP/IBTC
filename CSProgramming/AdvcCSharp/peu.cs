using System;
					
public class Program
{
	public static void Main()
	{
		int[,] board = {{0,0,0},
						{0,0,0},
						{0,0,0}};
		int r = 0; // Row
		int c = 0; //Column
		bool gc = true;
		bool game=true;
		
		
		while(game){
			
			Console.WriteLine(" ============== Board ===============\n");
			
			for(int i=0; i<3; i++){
				for(int j=0; j<3; j++){
					Console.Write(board[i,j]+" ");
				}
				Console.WriteLine(" ");
			}
			
			if(gc){
				Console.WriteLine("\nPLAYER 1");
			}
			else
			{
				Console.WriteLine("\nPLAYER 2");
			}
			
			Console.WriteLine("Which Row?");
			r = Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine("\nWhich Column?");
			c = Convert.ToInt32(Console.ReadLine());
			
			if(board[r-1,c-1] == 0){
				if(gc)
				{
					board[r-1,c-1] = 1;
				}
				else
				{
					board[r-1,c-1] = 2;
				}
			}
			else
			{
				Console.WriteLine(" ************** Not valid move!! **************");
				Console.WriteLine("Please repeat your move!");
				continue;
			}
			
			gc = !gc;
			
			if(board[2,2] == 1) game = false;
		}
		
	}
}