
using System;

namespace juegoIA
{

	public class DatosJugada
	{
		private int carta;
		private int limiteActual;
		private int cantGanadas;
		private bool esComputer;	
		public DatosJugada(int carta, int limiteActual, int cantGanadas,bool jugadorCp)
		{
			this.carta=carta;
			this.limiteActual=limiteActual;
			this.cantGanadas= cantGanadas;
			this.esComputer = jugadorCp;
		}

		public int Carta {
			get {
				return carta;
			}
			set {
				carta = value;
			}
		}

		public int LimiteActual {
			get {
				return limiteActual;
			}
			set {
				limiteActual = value;
			}
		}

		public int CantGanadas {
			get {
				return cantGanadas;
			}
			set {
				cantGanadas = value;
			}
		}

		public bool JugadorCp {
			get {
				return esComputer;
			}
			set {
				esComputer = value;
			}
		}
	}
}
