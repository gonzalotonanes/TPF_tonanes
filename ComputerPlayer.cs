
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		
		private ArbolGeneral<DatosJugada> arbol;
		private DatosJugada datosIniciales;
		private List<int> cartas;
		private ArbolGeneral<DatosJugada> arbolEntero;
		
		public ComputerPlayer()
		{
			
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			this.cartas= cartasPropias;
			this.datosIniciales= new DatosJugada(0,limite,0, true);
			this.arbol= new ArbolGeneral<DatosJugada>(datosIniciales);
			//this.arbolEntero= new ArbolGeneral<DatosJugada>(datosIniciales);
			crearArbol(arbol,cartasPropias,cartasOponente);
			//crearArbol(arbolEntero,cartasPropias,cartasOponente);
	
		}
		
		public override void consultarJugadas(){
			Console.WriteLine("1) Imprimir posibles resultados");
			Console.WriteLine("2) Imprimir Jugadas en dicha produndidad");
			
			int opcion=int.Parse(Console.ReadLine());
			switch (opcion) {
				case 1:
					posiblesResultados();
					break;
				case 2:
					//;
					break;
				default:
					Console.WriteLine("Opcion invalida");
					consultarJugadas();
					break;
					
			}
				
			Console.WriteLine();
			Console.WriteLine("Presione una tecla para continuar.....");
			Console.ReadKey();
			
		}
		
		private void posiblesResultados(){
			
			
			Cola<NodoGeneral<DatosJugada>> cola= new Cola<NodoGeneral<DatosJugada>>();
			NodoGeneral<DatosJugada> nd= this.arbol.getRaiz();
			nd.getDato().Carta=0;
			cola.encolar(nd);
			Console.Write("Posibles resultados: ");
			while (!cola.esVacia()) {
				
			
				NodoGeneral<DatosJugada> nodo=cola.desencolar();
				
				
				if (nodo.getDato().Carta!=0) {
					Console.Write(" "+nodo.getDato().Carta+",");
				}
				
				foreach (NodoGeneral<DatosJugada> element in nodo.getHijos()) {
					cola.encolar(element);
				}
			}
		}
		private void imprimirProdundidad(int profundidad){
			
			
		}
		
		public override ArbolGeneral<DatosJugada> getArbol{
			get{return this.arbol;}
		}
		
		
		public override int descartarUnaCarta()
		{
			
			Console.ForegroundColor= ConsoleColor.Red;
			
			Console.WriteLine("Naipes disponibles (Computer):");
			for (int i = 0; i < cartas.Count; i++) {
				Console.Write(cartas[i].ToString());
				if (i<cartas.Count-1) {
					Console.Write(", ");
				}
			}
			Console.WriteLine();
			int maxGanadas= -99;
			
			ArbolGeneral<DatosJugada> mejorEleccion = new ArbolGeneral<DatosJugada>(null);
			foreach (ArbolGeneral<DatosJugada> hijo in this.arbol.getHijos()) {
				if (hijo.getDatoRaiz().CantGanadas >maxGanadas) {
					maxGanadas = hijo.getDatoRaiz().CantGanadas;
					mejorEleccion= hijo;
				}
			}
			
			this.arbol= mejorEleccion;
			
			
			Console.WriteLine("La computadora eligio la carta: "+mejorEleccion.getDatoRaiz().Carta);
			
			
			
			return mejorEleccion.getDatoRaiz().Carta;
		}
		
		public override void cartaDelOponente(int carta)
		{
			
			foreach (ArbolGeneral<DatosJugada> hijo in this.arbol.getHijos()) {
				if (hijo.getDatoRaiz().Carta== carta) {
					this.arbol= hijo;
					return;
				}
			}
			
			
			
		}
		
		
		private void crearArbol(ArbolGeneral<DatosJugada> nodo, List<int> cartasN, List<int> cartasO){
			List<int> cartasSinJugar = new List<int>(cartasN);
			
			cartasSinJugar.Remove(nodo.getDatoRaiz().Carta);

			int lim = nodo.getDatoRaiz().LimiteActual;
	
			if (lim < 0) {
				nodo.getDatoRaiz().CantGanadas=-1;
			}else{
				
				foreach (int  cartaOponente in cartasO) {
				
				
					DatosJugada datosOponente = new DatosJugada(cartaOponente, (lim-cartaOponente),0,!nodo.getDatoRaiz().JugadorCp);
					ArbolGeneral<DatosJugada> nodoOponente= new ArbolGeneral<DatosJugada>(datosOponente);
					crearArbol(nodoOponente, cartasO, cartasSinJugar);
					nodo.agregarHijo(nodoOponente);
					if (nodoOponente.getDatoRaiz().CantGanadas == -1 && datosOponente.JugadorCp==true) {
					
						nodo.getDatoRaiz().CantGanadas =0;	
					}else{
						if (nodoOponente.getDatoRaiz().CantGanadas == -1 && datosOponente.JugadorCp==false) {
							nodo.getDatoRaiz().CantGanadas +=1;
						}else{
							nodo.getDatoRaiz().CantGanadas += nodoOponente.getDatoRaiz().CantGanadas;
						}
						
					}
				
				}
			}
			
			
			
		}
/*
		public ArbolGeneral<DatosJugada> Arbol {
			get {
				return arbol;
			}
			set {
				arbol = value;
			}
		}
		
		*/
		
	}
}

