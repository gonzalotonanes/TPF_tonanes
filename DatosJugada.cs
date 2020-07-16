
using System;

namespace juegoIA
{

	public class DatosJugada
	{
		int carta;
		int limiteActual;
		int cantGanadas;
		
		
		public DatosJugada(int carta, int limiteActual, int cantGanadas)
		{
			this.carta=carta;
			this.limiteActual=limiteActual;
			this.cantGanadas= cantGanadas;
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
	}
}
