
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		
		private ArbolGeneral<DatosJugada> arbol;
		private DatosJugada datosIniciales = new DatosJugada(-1,0,0);
		
		public ComputerPlayer()
		{
			this.arbol= new ArbolGeneral<DatosJugada>(datosIniciales);
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			//Implementar
		}
		
		
		public override int descartarUnaCarta()
		{
			//Implementar
			return 0;
		}
		
		public override void cartaDelOponente(int carta)
		{
			//implementar
			
		}
		
	}
}
