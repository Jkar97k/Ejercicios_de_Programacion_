// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;


Console.WriteLine("Hello, World!");

/* #1
* Escribe un programa que muestre por consola (con un print) los
 * números de 1 a 100 (ambos incluidos y con un salto de línea entre
 * cada impresión), sustituyendo los siguientes:
 * - Múltiplos de 3 por la palabra "fizz".
 * - Múltiplos de 5 por la palabra "buzz".
 * - Múltiplos de 3 y de 5 a la vez por la palabra "fizzbuzz".
 */
void Ejercicio1()
{
    for (int i = 1; i <= 100; i++)
    {
        switch (i)
        {
            case int n when n % 3 == 0 && n % 5 == 0:
                Console.WriteLine("fizzbuzz");
                break;
            case int n when n % 3 == 0:
                Console.WriteLine("fizz");
                break;
            case int n when n % 5 == 0:
                Console.WriteLine("buzz");
                break;
            default:
                Console.WriteLine(i);
                break;
        }
    }
}

/*
 * Escribe una función que reciba dos palabras (String) y retorne
 * verdadero o falso (Bool) según sean o no anagramas.
 * - Un Anagrama consiste en formar una palabra reordenando TODAS
 *   las letras de otra palabra inicial.
 * - NO hace falta comprobar que ambas palabras existan.
 * - Dos palabras exactamente iguales no son anagrama.
 */
void Ejercicio2(string palabra1, string palabra2)
{
    // Normalizar: Convertir a minúsculas y eliminar espacios
    palabra1 = palabra1.ToLower().Replace(" ", "");
    palabra2 = palabra2.ToLower().Replace(" ", "");

    // Verificar longitudes
    if (palabra1.Length != palabra2.Length)
    {
        Console.WriteLine("No son anagramas");
        return;
    }

    // Diccionarios para contar frecuencias de caracteres
    var frecuencia1 = new Dictionary<char, int>();
    var frecuencia2 = new Dictionary<char, int>();

    foreach (var c in palabra1)
    {
        if (frecuencia1.ContainsKey(c))
            frecuencia1[c]++;
        else
            frecuencia1[c] = 1;
    }

    foreach (var c in palabra2)
    {
        if (frecuencia2.ContainsKey(c))
            frecuencia2[c]++;
        else
            frecuencia2[c] = 1;
    }

    // Comparar frecuencias 

    if (SonDiccionariosIguales(frecuencia1, frecuencia2))
        Console.WriteLine("Si son anagramas");
    else
        Console.WriteLine("No son anagramas");

}

bool SonDiccionariosIguales<TKey, TValue>(
    Dictionary<TKey, TValue> dict1,
    Dictionary<TKey, TValue> dict2)
{
    return dict1.Count == dict2.Count &&
           dict1.Keys.All(k => dict2.ContainsKey(k) &&
                               Equals(dict1[k], dict2[k]));
}


/*
 * Escribe un programa que imprima los 50 primeros números de la sucesión
 * de Fibonacci empezando en 0.
 * - La serie Fibonacci se compone por una sucesión de números en
 *   la que el siguiente siempre es la suma de los dos anteriores.
 *   0, 1, 1, 2, 3, 5, 8, 13...
 */

void Ejercicio3()
{
    int a = 0;
    int b = 1;
    int c = 0;

    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine(a);
        c = a + b;
        a = b;
        b = c;
    }

}

/*
 * Escribe un programa que se encargue de comprobar si un número es o no primo.
 * Hecho esto, imprime los números primos entre 1 y 100.
 */
void ejercicio4()
{
    for (int i = 1; i <= 100; i++)
    {
        int contador = 0;
        for (int j = 1; j <= i; j++)
        {
            if (i % j == 0)
                contador++;
        }
        if (contador == 2)
            Console.WriteLine(i);

    }
}


/*
 * Crea una única función (importante que sólo sea una) que sea capaz
 * de calcular y retornar el área de un polígono.
 * - La función recibirá por parámetro sólo UN polígono a la vez.
 * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
 * - Imprime el cálculo del área de un polígono de cada tipo.
 */

//AreaCuadrado cuadrado = new AreaCuadrado(5);
//var rectangulo = new AreaRectangulo(6, 7);
//var triangulo = new AreaTriangulo(6, 7);

//ejercicio5(triangulo);
//ejercicio5(cuadrado);
//ejercicio5(rectangulo);

//void ejercicio5(Poligono poligono)
//{
//    Console.WriteLine(poligono.printArea());
//}



//abstract class Poligono
//{
//    public abstract string printArea();
//    public abstract double Area();
//}

//class AreaTriangulo : Poligono
//{
//    private double Base;
//    private double Altura;
//    public AreaTriangulo(double Base, double Altura)
//    {
//        this.Base = Base;
//        this.Altura = Altura;
//    }

//    override public double Area()
//    {
//        return (Base * Altura) / 2;
//    }
//    override public string printArea()
//    {
//        return "El area del triangulo es: " + Area();
//    }
//}

//class AreaCuadrado : Poligono
//{
//    private double Lado;
//    public AreaCuadrado(double Lado)
//    {
//        this.Lado = Lado;
//    }
//    override public double Area()
//    {
//        return Lado * Lado;
//    }
//    override public string printArea()
//    {
//        return "El area del cuadrado es: " + Area();
//    }
//}

//class AreaRectangulo : Poligono
//{
//    private double Base;
//    private double Altura;
//    public AreaRectangulo(double Base, double Altura)
//    {
//        this.Base = Base;
//        this.Altura = Altura;
//    }
//    override public double Area()
//    {
//        return Base * Altura;
//    }
//    override public string printArea()
//    {
//        return "El area del rectangulo es: " + Area();
//    }
//}

/*
 * Crea un programa que se encargue de calcular el aspect ratio de una
 * imagen a partir de una url.
 * - Url de ejemplo:
 *   https://opgg-static.akamaized.net/meta/images/lol/latest/champion/Ziggs.png?image=e_upscale,c_crop,h_103,w_103,x_9,y_9/q_auto:good,f_webp,w_160,h_160&v=1736426255
 * - Por ratio hacemos referencia por ejemplo a los "16:9" de una
 *   imagen de 1920*1080px.
 */

string url = "https://opgg-static.akamaized.net/meta/images/lol/latest/champion/Ziggs.png?image=e_upscale,c_crop,h_103,w_103,x_9,y_9/q_auto:good,f_webp,w_160,h_160&v=1736426255";

async Task ejercicio6(string url) 
{
    HttpClient client = new();

    byte[] imageData = await client.GetByteArrayAsync(url);

    // Cargar la imagen usando ImageSharp
    var image = SixLabors.ImageSharp.Image.Load(imageData);

    // Obtener las dimensiones de la imagen
    int width = image.Width;
    int height = image.Height;

    int gcd = GreatestCommonDivisor(width, height);
    int aspectWidth = width / gcd;
    int aspectHeight = height / gcd;

    Console.WriteLine($"Dimensiones de la imagen: {width}x{height}");
    Console.WriteLine($"Aspect Ratio: {aspectWidth}:{aspectHeight}");
}

static int GreatestCommonDivisor(int a, int b)
{
    while (b != 0)
    {
        (a, b) = (b, a % b); // Usando una tupla para simplificar el intercambio
    }
    return a;
}


/*
 * Crea un programa que invierta el orden de una cadena de texto
 * sin usar funciones propias del lenguaje que lo hagan de forma automática.
 * - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
 */

void ejercicio7(string cadena) 
{
    string cadenaInvertida = "";

    for (int i = cadena.Length - 1; i >= 0; i--)
    {
        cadenaInvertida += cadena[i];
    }
    Console.WriteLine(cadenaInvertida);
}

/*
 * Crea un programa que cuente cuantas veces se repite cada palabra
 * y que muestre el recuento final de todas ellas.
 * - Los signos de puntuación no forman parte de la palabra.
 * - Una palabra es la misma aunque aparezca en mayúsculas y minúsculas.
 * - No se pueden utilizar funciones propias del lenguaje que
 *   lo resuelvan automáticamente.
 */

void ejercicio8(string text) 
{ 
    Dictionary<string,int> dict = new Dictionary<string,int>();

    text = Regex.Replace(text, "[^a-zA-Z]", " ");

    string[] palabras = text.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

    foreach (string palabra in palabras) 
    {
        if (!dict.ContainsKey(palabra)) 
        {
            dict.Add(palabra, 1);
        }
        else 
        {
            dict[palabra]++;
        }
    }

    int count = 0;

    foreach(var result in dict) 
    {
        count += result.Value;

        Console.WriteLine($"palabra:{result.Key}--- Repeticiones {result.Value}");
    }
    Console.WriteLine($"Total de palabra:{count}");
}

string text = "Hola, mi nombre es brais. Mi nombre completo es Brais Moure (MoureDev).";


/*
 * Crea un programa se encargue de transformar un número
 * decimal a binario sin utilizar funciones propias del lenguaje que lo hagan directamente.
 */
void Ejercicio9(int number)
{
    if (number == 0)
    {
        Console.WriteLine("0");
        return;
    }

    string binario = "";

    while (number > 0)
    {
        int residuo = number % 2;
        binario += residuo ;
        number = number / 2;
    }

    Console.WriteLine(binario);
}

/*
 * Crea un programa que sea capaz de transformar texto natural a código
 * morse y viceversa.
 * - Debe detectar automáticamente de qué tipo se trata y realizar
 *   la conversión.
 * - En morse se soporta raya "—", punto ".", un espacio " " entre letras
 *   o símbolos y dos espacios entre palabras "  ".
 * - El alfabeto morse soportado será el mostrado en
 *   https://es.wikipedia.org/wiki/Código_morse.
 */

Dictionary<string, string> textoAMorse = new Dictionary<string, string>()
{
    {"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"D", "-.."}, {"E", "."},
    {"F", "..-."}, {"G", "--."}, {"H", "...."}, {"I", ".."}, {"J", ".---"},
    {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"O", "---"},
    {"P", ".--."}, {"Q", "--.-"}, {"R", ".-."}, {"S", "..."}, {"T", "-"},
    {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"},
    {"Z", "--.."}, {"0", "-----"}, {"1", ".----"}, {"2", "..---"}, {"3", "...--"},
    {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."},
    {"9", "----."}, {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"'", ".----."},
    {"!", "-.-.--"}, {"/", "-..-."}, {"(", "-.--."}, {")", "-.--.-"}, {"&", ".-..."},
    {":", "---..."}, {";", "-.-.-."}, {"=", "-...-"}, {"+", ".-.-."}, {"-", "-....-"},
    {"_", "..--.-"}, {"\"", ".-..-."}, {"$", "...-..-"}, {"@", ".--.-."}, {" ", " "}
};

void ejercicio10(string text) 
{
    var textoDescifrado = "";

    if (text.Contains(".") && text.Contains("-")) 
    {
        var textsplit = text.Split(' ');

        foreach(var code in textsplit) 
        {
            foreach (var dic in textoAMorse)
            {
                if (dic.Value == code)
                {
                    textoDescifrado += dic.Value + " ";
                    break;
                }
            }
        }

        Console.WriteLine($"Texto original: {text}  texto Transformado:{textoDescifrado}");
        return;
    }

    var textAjustado = text.ToUpper().Split(' ');

    foreach(string palabra in textAjustado) 
    {
        for (int i=0; i < palabra.Length; i++) 
        {
            var letra = palabra[i];

            foreach (var dic in textoAMorse)
            {
                if (dic.Key == letra.ToString())
                {
                    textoDescifrado += dic.Key + " ";
                    break;
                }
            }
        }
    }
    Console.WriteLine($"Texto original: {text}  texto Transformado:{textoDescifrado}");
    return;

}
string textoEjemplo = "Hola Mundo.";
string morseEjemplo = ".... --- .-.. .-  -- ..- -. -.. ---";

//ejercicio10(textoEjemplo);
//ejercicio10(morseEjemplo);

/*
 * Crea un programa que comprueba si los paréntesis, llaves y corchetes
 * de una expresión están equilibrados.
 * - Equilibrado significa que estos delimitadores se abren y cieran
 *   en orden y de forma correcta.
 * - Paréntesis, llaves y corchetes son igual de prioritarios.
 *   No hay uno más importante que otro.
 * - Expresión balanceada: { [ a * ( c + d ) ] - 5 }
 * - Expresión no balanceada: { a * ( c + d ) ] - 5 }
 */

bool EstaEquilibrado(string expresion)
{
    Stack<char> stack = new Stack<char>();

    foreach (char c in expresion)
    {
        if (c == '(' || c == '{' || c == '[')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == '}' || c == ']')
        {
            if (stack.Count == 0)
            {
                return false;
            }

            char top = stack.Pop();

            if ((c == ')' && top != '(') ||
                (c == '}' && top != '{') ||
                (c == ']' && top != '['))
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

// Ejemplos de uso
string expresion1 = "{ [ a * ( c + d ) ] - 5 }";
string expresion2 = "{ a * ( c + d ) ] - 5 }";

//Console.WriteLine(EstaEquilibrado(expresion1)); // Salida: True
//Console.WriteLine(EstaEquilibrado(expresion2)); // Salida: False

/*
 * Crea una función que reciba dos cadenas como parámetro (str1, str2)
 * e imprima otras dos cadenas como salida (out1, out2).
 * - out1 contendrá todos los caracteres presentes en la str1 pero NO
 *   estén presentes en str2.
 * - out2 contendrá todos los caracteres presentes en la str2 pero NO
 *   estén presentes en str1.
 */

void ejercicio12(string str1, string str2)
{
    string out1 = "";
    string out2 = "";

    foreach (char c in str1)
    {
        if (!str2.Contains(c))
        {
            out1 += c;
        }
    }

    foreach (char c in str2)
    {
        if (!str1.Contains(c))
        {
            out2 += c;
        }
    }

    Console.WriteLine(out1);
    Console.WriteLine(out2);
}

string str1 = "Hola Mundo";
string str2 = "Mundo Feliz";
ejercicio12(str1, str2);

/*
 * Escribe una función que reciba un texto y retorne verdadero o
 * falso (Boolean) según sean o no palíndromos.
 * Un Palíndromo es una palabra o expresión que es igual si se lee
  * de izquierda a derecha que de derecha a izquierda.
 * NO se tienen en cuenta los espacios, signos de puntuación y tildes.
 * Ejemplo: Ana lleva al oso la avellana.
 */
 void Ejercicio13(string texto)
 {
        texto = Regex.Replace(texto, "[^a-zA-Z]", "").ToLower();
    
        for (int i = 0; i < texto.Length / 2; i++)
        {
            if (texto[i] != texto[texto.Length - 1 - i])
            {
                Console.WriteLine("No es palindromo");
                return;
            }
        }
    
        Console.WriteLine("Es palindromo");
 }



/*
 * Escribe una función que calcule y retorne el factorial de un número dado
 * de forma recursiva.
 */
 void Ejercicio14(int n)
 {
    if(n == 0 || n == 1)
    {
        Console.WriteLine("El factorial de " + n + " es 1");
        return;
    }

    long resultado = 1;

    for(int i = 2 ; i < n ; i++)
    {
        resultado *= i;
    }
    Console.WriteLine("El factorial de " + n + " es " + resultado);
 }



/*
 * Escribe una función que calcule si un número dado es un número de Armstrong
 * (o también llamado narcisista).
 * Si no conoces qué es un número de Armstrong, debes buscar información
 * al respecto.
 */
void Ejercicio15(int number)
{
    string numberString = number.ToString();
    int suma = 0;
    int digit = 0;

    foreach (char c in numberString)
    {
        digit = c - '0';

        suma += (int)Math.Pow(digit, numberString.Length);
    }

    if (suma == number)
    {
        Console.WriteLine("Es un número de Armstrong");
    }
    else
    {
        Console.WriteLine("No es un número de Armstrong");
    }
}
/*
 * Crea una función que calcule y retorne cuántos días hay entre dos cadenas
 * de texto que representen fechas.
 * - Una cadena de texto que representa una fecha tiene el formato "dd/MM/yyyy".
 * - La función recibirá dos String y retornará un Int.
 * - La diferencia en días será absoluta (no importa el orden de las fechas).
 * - Si una de las dos cadenas de texto no representa una fecha correcta se
 *   lanzará una excepción.
 */
void Ejercicio16(string fecha1, string fecha2)
{
    DateTime date1;
    DateTime date2;

    if (!DateTime.TryParseExact(fecha1, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date1))
    {
        throw new Exception("La fecha 1 no es válida");
    }

    if (!DateTime.TryParseExact(fecha2, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
    {
        throw new Exception("La fecha 2 no es válida");
    }

    TimeSpan diff = date1 - date2;

    Console.WriteLine(Math.Abs(diff.Days));
}

/*
 * Crea una función que reciba un String de cualquier tipo y se encargue de
 * poner en mayúscula la primera letra de cada palabra.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */

 void Ejercicio17(string texto)
 {
    string[] palabras = texto.Split(' ');

    string resultado = "";

    foreach (string palabra in palabras)
    {
        resultado += char.ToUpper(palabra[0]) + palabra.Substring(1) + " ";
    }

    Console.WriteLine(resultado);
 }

/*
 * Crea una función que evalúe si un/a atleta ha superado correctamente una
 * carrera de obstáculos.
 * - La función recibirá dos parámetros:
 *      - Un array que sólo puede contener String con las palabras
 *        "run" o "jump"
 *      - Un String que represente la pista y sólo puede contener "_" (suelo)
 *        o "|" (valla)
 * - La función imprimirá cómo ha finalizado la carrera:
 *      - Si el/a atleta hace "run" en "_" (suelo) y "jump" en "|" (valla)
 *        será correcto y no variará el símbolo de esa parte de la pista.
 *      - Si hace "jump" en "_" (suelo), se variará la pista por "x".
 *      - Si hace "run" en "|" (valla), se variará la pista por "/".
 * - La función retornará un Boolean que indique si ha superado la carrera.
 * Para ello tiene que realizar la opción correcta en cada tramo de la pista.
 */

Boolean Ejercicio18(string[] acciones, string pista)
{
    if(!acciones.All(palabras => palabras.ToLower() == "run" || palabras.ToLower() == "jump"))
    {
        Console.WriteLine("acciones incorrectas");
        return false;

    }

    for(int i = 0; i < acciones.Length; i++)
    {
        acciones[i] = acciones[i].ToLower();
    }

    char[] pistaArray = pista.ToCharArray();

    for (int i = 0; i < acciones.Length; i++)
    {
        
        if (
            acciones[i] == "run" && pistaArray[i] == '_' ||
            acciones[i] == "jump" && pistaArray[i] == '|'
            ) 
        {
            continue;
        }
        if (acciones[i] == "jump" &&  pistaArray[i] != '|') 
        {
            pistaArray[i] = 'x';
        }
        if (acciones[i] == "run" && pistaArray[i] != '_')
        {
            pistaArray[i] = '/';
        }
        else
        {
            Console.WriteLine("No paso");
            return false;
        }

    }
    Console.WriteLine(new string(pistaArray));

    return true;
}


/*
 * Crea una función que analice una matriz 3x3 compuesta por "X" y "O"
 * y retorne lo siguiente:
 * - "X" si han ganado las "X"
 * - "O" si han ganado los "O"
 * - "Empate" si ha habido un empate
 * - "Nulo" si la proporción de "X", de "O", o de la matriz no es correcta.
 *   O si han ganado los 2.
 * Nota: La matriz puede no estar totalmente cubierta.
 * Se podría representar con un vacío "", por ejemplo.
 */

char[,] juego = new char[3, 3]
{
    { 'X', 'X', 'O' },
    { 'O', 'X', 'X' },
    { 'X', 'O', 'O' }
};

void Ejercicio19(char[,] juego) 
{
    if (tableroJugadores(juego, 'X'))
    {
        Console.WriteLine("Gano X");
        return;
    }

    if (tableroJugadores(juego, 'O'))
    {
        Console.WriteLine("Gano O");
        return;
    }
    Console.WriteLine("Empate");
    return;
    
}

Boolean tableroJugadores(char[,] matriz, char jugador) 
{
    if (matriz[0, 0] == jugador && matriz[1, 1] == jugador && matriz[2, 2] == jugador) return true;
    if (matriz[0, 2] == jugador && matriz[1, 1] == jugador && matriz[2, 0] == jugador) return true;

    for (int i = 0; i < 3; i++)
    {
        if (matriz[i, 0] == jugador && matriz[i, 1] == jugador && matriz[i, 2] == jugador) return true;
        if (matriz[0, i] == jugador && matriz[1, i] == jugador && matriz[2, i] == jugador) return true;
    }
    return false;
}

Ejercicio19(juego);

/*
 * Crea una función que reciba días, horas, minutos y segundos (como enteros)
 * y retorne su resultado en milisegundos.
 */
void Ejercicio20(int dias = 0 , int horas = 0, int minutos = 0, int segundos = 0)
{
    long milisegundos = dias * 24L * 3600 * 1000 +
                            horas * 3600L * 1000 +
                            minutos * 60L * 1000 +
                            segundos * 1000L;

    Console.WriteLine($"Total {milisegundos} milisegundos");
}

/*
 * Crea una función que sume 2 números y retorne su resultado pasados
 * unos segundos.
 * - Recibirá por parámetros los 2 números a sumar y los segundos que
 *   debe tardar en finalizar su ejecución.
 * - Si el lenguaje lo soporta, deberá retornar el resultado de forma
 *   asíncrona, es decir, sin detener la ejecución del programa principal.
 *   Se podría ejecutar varias veces al mismo tiempo.
 */

 async Task Ejercicio21(int n1,int n2, int seg)
 {
    var task1 = new Task(() =>
    {
        Thread.Sleep(seg * 1000);
        Console.WriteLine($"Suma Asincrona {n1 + n2}");
    });

    task1.Start();

    Console.WriteLine("Hice algo....");

    //await task1;

    Console.WriteLine("Ya acabe");
 }

/*
 * Lee el fichero "Challenge21.txt" incluido en el proyecto, calcula su
 * resultado e imprímelo.
 * - El .txt se corresponde con las entradas de una calculadora.
 * - Cada línea tendrá un número o una operación representada por un
 *   símbolo (alternando ambos).
 * - Soporta números enteros y decimales.
 * - Soporta las operaciones suma "+", resta "-", multiplicación "*"
 *   y división "/".
 * - El resultado se muestra al finalizar la lectura de la última
 *   línea (si el .txt es correcto).
 * - Si el formato del .txt no es correcto, se indicará que no se han
 *   podido resolver las operaciones.
 */

/*
 * Crea una función que reciba dos array, un booleano y retorne un array.
 * - Si el booleano es verdadero buscará y retornará los elementos comunes
 *   de los dos array.
 * - Si el booleano es falso buscará y retornará los elementos no comunes
 *   de los dos array.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */

/*
 * Crea dos funciones, una que calcule el máximo común divisor (MCD) y otra
 * que calcule el mínimo común múltiplo (mcm) de dos números enteros.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */

/*
 * Quiero contar del 1 al 100 de uno en uno (imprimiendo cada uno).
 * ¿De cuántas maneras eres capaz de hacerlo?
 * Crea el código para cada una de ellas.
 */

/*
 * Crea un programa que calcule quien gana más partidas al piedra,
 * papel, tijera.
 * - El resultado puede ser: "Player 1", "Player 2", "Tie" (empate)
 * - La función recibe un listado que contiene pares, representando cada jugada.
 * - El par puede contener combinaciones de "R" (piedra), "P" (papel)
 *   o "S" (tijera).
 * - Ejemplo. Entrada: [("R","S"), ("S","R"), ("P","S")]. Resultado: "Player 2".
 */

/*
 * Crea un programa que dibuje un cuadrado o un triángulo con asteriscos "*".
 * - Indicaremos el tamaño del lado y si la figura a dibujar es una u otra.
 * - EXTRA: ¿Eres capaz de dibujar más figuras?
 */