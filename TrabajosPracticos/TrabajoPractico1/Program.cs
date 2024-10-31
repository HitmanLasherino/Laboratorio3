internal class Program{
    private static void Main(string[] args){
        //PUNTO1
        Console.WriteLine("Punto 1");
        for (int i = 1; i < 101; i++)
        {
            if (i % 2 == 0 && i % 5 == 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("-----------------");

        int contador = 1;

        while (contador < 101)
        {
            if (contador % 2 == 0 && contador % 5 == 0)
            {
                Console.WriteLine(contador);
            }
            contador++;
        }
        Console.WriteLine("-----------------");

        int contador2 = 1;
        do
        {
            if (contador2 % 2 == 0 && contador2 % 5 == 0)
            {
                Console.WriteLine(contador2);
            }
            contador2++;
        } while (contador2 < 101);
    
        //PUNTO2
        Console.WriteLine("Punto 2");
        Random random = new Random();
        int numeroAleatorio = random.Next(0, 101);
        Console.WriteLine(numeroAleatorio);

        Console.WriteLine("Bienvenido, el juego comienza");
        int numeroAdivina = 101;
        Console.WriteLine("Ingrese un numero entre 0 y 100");
        
        while (true)
        {
            numeroAdivina = int.Parse(Console.ReadLine());

            if (numeroAleatorio == numeroAdivina)
            {
                Console.WriteLine("¡Felicidades! Adivinaste el número.");
                break;
            }
            else if (numeroAdivina > numeroAleatorio)
            {
                Console.WriteLine("El numero a adivinar es menor");
            }
            else if (numeroAdivina < numeroAleatorio)
            {
                Console.WriteLine("El numero a adivinar es mayor");
            }
        }

        //PUNTO3
        Console.WriteLine("Punto 3");
        Console.WriteLine("Ingrese un numero para saber si es par o no");
        int numeroPar = int.Parse(Console.ReadLine());
        bool resultadoPar = esPar(numeroPar);
        Console.WriteLine(resultadoPar);

        //PUNTO4
        Console.WriteLine("Punto 4");
        double numeroA;
        double numeroB;
        while(true){
            //Menu
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicacion");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Resto division");
            int eleccion = int.Parse(Console.ReadLine());
            //Verificacion eleccion
            if (eleccion > 5  || eleccion <= 0){
                Console.WriteLine("La opción ingresada no es válida");
                continue;
            }
            //verificar numeros ingresados doubles
            while(true){
                Console.WriteLine("Ingrese el primer número decimal:");
                if (!double.TryParse(Console.ReadLine(), out numeroA)){
                    Console.WriteLine("No es un número decimal válido.");
                    continue; 
                }
                Console.WriteLine("Ingrese el segundo número decimal:");
                if (!double.TryParse(Console.ReadLine(), out numeroB))
                {
                    Console.WriteLine("No es un número decimal válido.");
                    continue;
                }
                Console.WriteLine("Número A: " + numeroA + ", " + "Número B: " + numeroB);
                break;
            }
            //switch case para eleccion
            switch(eleccion){
                case 1:
                    Console.WriteLine(suma(numeroA, numeroB));
                    break;
                case 2:
                    Console.WriteLine(resta(numeroA, numeroB));
                    break;
                case 3:
                    Console.WriteLine(multiplicacion(numeroA, numeroB));
                    break;
                case 4:
                    if (numeroB == 0){
                        Console.WriteLine("No se puede dividir entre 0");
                        break;
                    }else{
                        Console.WriteLine(division(numeroA, numeroB));
                        break;
                    }
                    break;
                case 5:
                    if (numeroB == 0){
                        Console.WriteLine("No se puede calcular el modulo entre 0");
                        break;
                    }else{
                        Console.WriteLine(modulo(numeroA, numeroB));
                        break;
                    }
            }
            Console.WriteLine("¿Desea realizar otra operación? (s/n)");
            string salida = Console.ReadLine().ToLower();
            if (salida != "s"){
                break;
            }
        }
        //PUNTO5
        Console.WriteLine("Punto 5"); 

        Console.WriteLine("Ingrese la hora de ingreso: ");
        int horaIngreso = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el minuto de ingreso: ");
        int minutoIngreso = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la hora de salira: ");
        int horaSalida = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el minuto de salida: ");
        int minutoSalida = int.Parse(Console.ReadLine());

        //Convertir minutos
        int ingresoMinutos = horaIngreso* 60 + minutoIngreso;
        int salidaMinutos = horaIngreso * 60 + minutoSalida;

        //validar hora ingreso no mayor a la salida
        if (ingresoMinutos >= salidaMinutos){
            Console.WriteLine("Error: la hora de ingreso no puede ser mayor o igual a la hora de salida");
            return;
        }

        //calcular cantidad total minutos trabajados
        int minutosDiurnos = 0;
        int minutosNocturnos = 0;

        //verificar y calcular los minutos diurnos y nocturnos
        for (int i = ingresoMinutos; i < salidaMinutos; i++){
            int horaActual = (i / 60) % 24; 

            if (horaActual >= 8 && horaActual < 20){
                minutosDiurnos++;
            }
            else{
                minutosNocturnos++;
            }
        }
        //cacular sueldo
        double salario = minutosDiurnos * (10.0 / 60.0);
        double salarioNocturno = minutosNocturnos * (10.0 / 60.0);
        double salarioTotal = salario + salarioNocturno;

        //resultados
        Console.WriteLine("Minutos trabajados en horario diurno: " + minutosDiurnos);
        Console.WriteLine("Minutos trabajados en horario nocturno: " + minutosNocturnos);
        Console.WriteLine("Sueldo total: $" + salarioTotal.ToString("0.00"));

        //PUNTO6
        Console.WriteLine("Punto 6");

        Console.WriteLine("Ingrese un numero mayor a 1: ");
        int numeroRecursivo;
        if(!int.TryParse(Console.ReadLine(), out numeroRecursivo) || numeroRecursivo <= 1){
            Console.WriteLine("El numero ingresado no es valido.");
            return;
        }        
        
        multiplicarRecursivo(numeroRecursivo, 1);
        //PUNTO7

        /*
        En C#, se usan varios métodos para manejar cadenas:
        Length: Obtiene la longitud de la cadena. Ejemplo: "Hola".Length devuelve 4.
        Contains: Verifica si una subcadena está presente. Ejemplo: "Hola Mundo".Contains("Mundo") devuelve true.
        IndexOf: Devuelve el índice de la primera aparición de un carácter o subcadena. Ejemplo: "Hola".IndexOf('a') devuelve 3.
        Remove: Elimina una parte de la cadena. Ejemplo: "Hola".Remove(2) devuelve "Ho".
        Replace: Reemplaza todas las apariciones de una subcadena. Ejemplo: "Hola".Replace("o", "a") devuelve "Hala".
        Substring: Extrae una parte de la cadena. Ejemplo: "Hola Mundo".Substring(5, 5) devuelve "Mundo".
        Append: Se usa con StringBuilder para añadir texto. Ejemplo: sb.Append("Hola").
        ToUpper: Convierte la cadena a mayúsculas. Ejemplo: "Hola".ToUpper() devuelve "HOLA".
        ToLower: Convierte la cadena a minúsculas. Ejemplo: "Hola".ToLower() devuelve "hola".
        */
    }
  
    //Funcion del punto 3
    static bool esPar(int numero){
            return numero % 2 == 0;
        }
    //Funciones del punto 4
    static double suma(double a, double b){
        double resultado = (a + b);
        return resultado;
    }
    static double resta(double a, double b){
        double resultado = (a - b);
        return + resultado;
    }       
    static double multiplicacion(double a, double b){
        double resultado = (a * b);
        return resultado;
    }
    static double division(double a, double b){
        double resultado = (a / b);
        return resultado;
    }
    static double modulo(double a, double b){
        double resultado = (a % b);
        return resultado;
    }
    //Funcion del punto 6
    static void multiplicarRecursivo(long numero, int iterador){
        long resultado = numero * numero;
        Console.WriteLine("Iterador: " + iterador);
        Console.WriteLine(numero + " * " + numero + " = " + resultado);

        if (resultado > 100000000){
            Console.WriteLine("Fin recursion");
            return;
        }

        multiplicarRecursivo(resultado, iterador + 1);
    }

}
