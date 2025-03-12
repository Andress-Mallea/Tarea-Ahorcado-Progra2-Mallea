using System;
using System.Collections.Generic;

class Ahorcado
{
    static void Main()
    {
        Game game1 = new Game(4);
        game1.Menu();
        
    }
    public class Game{
        public int Intentos = 5;
        private List<string> PalabrasSelecionables = new List<string> { "programacion", "computadora", "ahorcado", "inteligencia", "robot", "semilla", "collar", "mueble", "nuemros", "docente", "letras", "crimen", "espada", "veintiuno", "generaciones", "dragon", "departamento" };
        public Dibujo dibujo;
        public Game(int intentos){
            if(intentos >= 5 && intentos<=7 ){
                Intentos = intentos;
                dibujo = new Dibujo(intentos);
            }       
            else{
                Console.WriteLine("Valor no Valido");
                Console.WriteLine("Se Establecera el numero de vidas estandar");
                Intentos = 5;
                dibujo = new Dibujo(5);
            }
        }

        public void IniciarElJUego(){
            int Vidas = Intentos;
            Random rand = new Random();
            string PalabraRandom = PalabrasSelecionables[rand.Next(PalabrasSelecionables.Count)];
            List<string> LetrasYaIntentadas = new List<string>();
            List<string> LetrasJugador = new List<string>();
            string PalabraJugador= "";
            string DibujoAhorcado1 = dibujo.DibujoAhorcado(0);
            for(int i = 0; i < PalabraRandom.Length; i++){
                LetrasJugador.Add("_");
                PalabraJugador += "_";
            }
            Console.WriteLine("########################################################################");
            Console.WriteLine("========================================================================");
            Console.WriteLine("|| Bienvenido al juego del ahorcado                             ||");
            Console.WriteLine(@"|| El juego funciona ingresando una letra para ver si esta esta ||
|| dentro de la palabra, si lo esta en la palabra se mostrara y ||
|| se mostrara un mensaje indicando que esa letra esta en la    ||
|| palabra caso contario se le quitara una vida a el jugador    ||
|| si numero de vidas llega acero pierdes y el juego se termina.||");
            Console.WriteLine("========================================================================");
            Console.WriteLine("########################################################################");
            while (Vidas > 0 && PalabraJugador != PalabraRandom)
        {
            Console.WriteLine("########################################################################");
            Console.WriteLine("========================================================================");
            Console.WriteLine($"Palabra: {PalabraJugador}");
            Console.WriteLine($"Intentos restantes: {Vidas}      {DibujoAhorcado1}");
            Console.Write("Ingresa una letra: ");
            string letra = Console.ReadLine();
            Console.WriteLine();
            if(letra.Length == 1){
                if(letra[0] < 97 || letra[0] > 122){
                    if(letra[0] != 'ñ'){
                    Console.WriteLine("Charcter invalido solo introdusca letras minusculas");
                    Console.WriteLine("########################################################################");
                    Console.WriteLine("========================================================================");
                    continue;
                    }
                    
                }
                if (LetrasYaIntentadas.Contains(letra)){
                    Console.WriteLine("Ya haz introducido esa Letra antes");
                    Console.WriteLine("########################################################################");
                    Console.WriteLine("========================================================================");
                    continue;
                }
                LetrasYaIntentadas.Add(letra);
                if (PalabraRandom.Contains(letra))
                {
                    Console.WriteLine("**** Esta letra se encuentra en la palabra ****");
                    Console.WriteLine("########################################################################");
                    Console.WriteLine("========================================================================");
                    for (int i = 0; i < PalabraRandom.Length; i++)
                    {
                        if (PalabraRandom[i] == letra[0]){
                            string letra2 = "";
                            letra2 += letra[0];
                            LetrasJugador[i] = letra2;
                        }
                    }
                }
                else
                {
                    DibujoAhorcado1 = dibujo.DibujoAhorcado(1);
                    Console.WriteLine("La Palabra no Contiene esa letra");
                    Console.WriteLine("########################################################################");
                    Console.WriteLine("========================================================================");
                    Vidas--;
                }
                PalabraJugador = "";
                for(int i = 0; i < PalabraRandom.Length; i++){
                    PalabraJugador += LetrasJugador[i];
                }
            }
            else if(letra.Length == 0){
                Console.Write("Ingresa una letra porfavor");
                Console.WriteLine("########################################################################");
                Console.WriteLine("========================================================================");
                continue;
            }
            else{
                Console.WriteLine("Ingresa solo una letra porfavor");
                Console.WriteLine("########################################################################");
                Console.WriteLine("========================================================================");
                continue;
            }
            
        }

        if (PalabraJugador == PalabraRandom){
            Console.WriteLine("========================================================================");
            Console.WriteLine("########################################################################");
            Console.WriteLine($"|| Felicidades ganaste el juego la palabra es: {PalabraRandom}  ||  {DibujoAhorcado1}");
            Console.WriteLine("########################################################################");
            Console.WriteLine("========================================================================");
        }
        else{
            Console.WriteLine("==========================================================================");
            Console.WriteLine("##########################################################################");
            Console.WriteLine($"|| Has acabado con todas tus vidas Perdiste La palabra era: {PalabraRandom} || {DibujoAhorcado1}");
            Console.WriteLine("##########################################################################");
            Console.WriteLine("==========================================================================");
        }
        }
        public bool Menu(){
                string Opcion;
                Console.WriteLine("########################################################################");
                Console.WriteLine("================ Bienvenido a el juego del ahorcado ====================");
                Console.WriteLine("1. Empezar el juego ");
                Console.WriteLine($"2. Cambiar numero de intentos   Numero de intentos actual: {Intentos}");
                Console.WriteLine("3. Salir ");
                Console.WriteLine("========================================================================");
                Console.WriteLine("########################################################################");
                Console.WriteLine("Introdusca que quiere hacer");
                Opcion = Console.ReadLine();
                if(Opcion == "1"){
                    IniciarElJUego();
                    return true;
                }
                else if(Opcion == "2"){
                    Console.WriteLine("#############################################################################################################");
                    Console.WriteLine("=============================================================================================================");
                    Console.WriteLine("Introdusca de numero intentos quiere, teneindo en cuenta que no puede haber mas de 7 intentos o menos que 5");
                    Console.WriteLine("Introdusca NO para cancelar");
                    Console.WriteLine("=============================================================================================================");
                    Console.WriteLine("#############################################################################################################");
                    String Num2 = Console.ReadLine();
                    if(Num2 == "No"){
                        return Menu();
                    }
                    else if(Num2.Length == 1){
                        int Num3 = Num2[0] -'0';
                        if(Num3 >= 5 && Num3<=7 ){
                            Intentos = Num3;
                            dibujo.partes = Num3;
                            dibujo.Vidas = Num3;
                            Console.WriteLine("########################################################################");
                            Console.WriteLine("========================================================================");
                            Console.WriteLine($"Se a cambiado el nuemro de intentos a: {Intentos}");
                            Console.WriteLine("========================================================================");
                            Console.WriteLine("########################################################################");
                            return Menu();
                        }
                        else{
                        Console.WriteLine("########################################################################");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("Introdusca un numero valido");
                        Console.WriteLine("Se Establecera el numerod e vidas estandar");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("########################################################################");
                        return Menu();
                        }
                    }
                    else{
                        Console.WriteLine("########################################################################");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("Introdusca un numero valido");
                        Console.WriteLine("Se Establecera el numerod e vidas estandar");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("########################################################################");
                        return Menu();
                    }
                }
                else if(Opcion == "3"){
                    return false;
                }
                else{
                    Console.WriteLine("########################################################################");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("Introdusca una opcion valida");
                        Console.WriteLine("========================================================================");
                        Console.WriteLine("########################################################################");
                    return Menu();
                }
            }
    }
    public class Dibujo{
        public int partes;
        public int Vidas;
        public string ahorcado = @"
            _____________        
            ||/          
            ||          
            ||         
            ||         
        ___/__\___
                ";
        public Dibujo(int vidas){
            partes = vidas;
            Vidas = vidas;
        }
        public string DibujoAhorcado(int i){
            if(i == 0){
                return ahorcado;
            }
            else{
                if(partes == 5){
                    Vidas -= 1;
                    if(Vidas == 4){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 3){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 2){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||          |
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 1){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 0){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         / \
        ___/__\___
                ";
                return ahorcado;
                    }
                }
                else if(partes == 6){
                    Vidas -= 1;
                    if(Vidas == 5){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 4){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 3){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||          |
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 2){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 1){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 0){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         / \
        ___/__\___
                ";
                return ahorcado;
                    }
                }
                else if(partes == 7){
                    Vidas -= 1;
                    if(Vidas == 6){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 5){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 4){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||          |
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 3){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 2){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 1){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         /
        ___/__\___
                ";
                return ahorcado;
                    }
                    else if(Vidas == 0){
                        ahorcado = @"
            _____________        
            ||/         | 
            ||          O
            ||         /|\
            ||         / \
        ___/__\___
                ";
                return ahorcado;
                    }
                }
            return ahorcado;
            }
        }
    }
}
