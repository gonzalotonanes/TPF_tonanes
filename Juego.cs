
using System;

namespace juegoIA
{
	class Juego
	{
		public static void Main(string[] args)
		{
			
			string continuar="n";
			do{
				
				iniciarJuego();
				continuar=seleccionarOpcion();
			}while(continuar!="n");
			
			
				
			Console.ReadKey();
		}
		
		public static void iniciarJuego(){
				
			Game game = new Game();
			game.play();
		}
		
		public static string seleccionarOpcion(){
			
			
			Console.WriteLine("¿Desea seguir jugando? Y/N");
			string opcion = Console.ReadLine();
			opcion.ToLower();
			
			
			while (opcion!="n" && opcion !="y") {
				
				Console.WriteLine("Opcion invalida");
				Console.WriteLine("Vuelva a ingresar la opcion Y/N");
				opcion = Console.ReadLine();
				opcion.ToLower();
			}
			Console.Clear();
			return opcion;
		}
		
	}
}