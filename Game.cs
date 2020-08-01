
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{

	public class Game
	{
		public static int WIDTH = 12;
		public static int UPPER = 35;
		public static int LOWER = 25;
		
		private Jugador player1 = new ComputerPlayer();
		private Jugador player2 = new HumanPlayer();
		private List<int> naipesHuman = new List<int>();
		private List<int> naipesComputer = new List<int>();
		private int limite;
		private bool juegaHumano = false;
	
		public Game()
		{
			var rnd = new Random();
			//limite = rnd.Next(LOWER, UPPER);
			
			limite = 11;
		/*	
			naipesHuman = Enumerable.Range(1, WIDTH).OrderBy(x => rnd.Next()).Take(WIDTH / 2).ToList();
			
			
			for (int i = 1; i <= WIDTH; i++) {
				if (!naipesHuman.Contains(i)) {
					naipesComputer.Add(i);
				}
			}
		*/	
			
			naipesHuman= new List<int>(){1,3,6};
			naipesComputer= new List<int>(){2,4,5};
			
			
			player1.incializar(naipesComputer, naipesHuman, limite);
			player2.incializar(naipesHuman, naipesComputer, limite);
			
		
			//player1.incializar(naipesComputer, naipesHuman, limite);
			//player2.incializar(naipesHuman, naipesComputer, limite);
			
			
		}
		
		
		private void printScreen()
		{
			Console.WriteLine();
			Console.WriteLine("Limite:" + limite.ToString());
		}
		
		private void turn(Jugador jugador, Jugador oponente, List<int> naipes)
		{
			int carta = jugador.descartarUnaCarta();
			naipes.Remove(carta);
			limite -= carta;
			oponente.cartaDelOponente(carta);
			juegaHumano = !juegaHumano;	
			
				Console.WriteLine("Presione p para opciones");
			string consulta= Console.ReadLine();
			if (consulta=="p") {
				player1.consultarJugadas();
			}
		}
		
		
		
		private void printWinner()
		{
			
			
			if (!juegaHumano) {
				Console.WriteLine("Eres el ganador");
			} else {
				Console.WriteLine("Gano la computadora");
			}
			
		}
		
		private bool fin()
		{
			return limite < 0;
		}
		
		public void play()
		{
			while (!this.fin()) {
				this.printScreen();
				this.turn(player2, player1, naipesHuman); // Juega el usuario
				if (!this.fin()) {
					this.printScreen();
					this.turn(player1, player2, naipesComputer); // Juega la IA
				}
				
				
		
			}
			this.printWinner();
			
		
		}
		
		
	}
}
