// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

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
 *   https://raw.githubusercontent.com/mouredevmouredev/master/mouredev_github_profile.png
 * - Por ratio hacemos referencia por ejemplo a los "16:9" de una
 *   imagen de 1920*1080px.
 */

//ejercicio6("https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png"); /// penndiente


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
 */void Ejercicio14(int n)
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

Ejercicio14(7);

/*
 * Escribe una función que calcule si un número dado es un número de Armstrong
 * (o también llamado narcisista).
 * Si no conoces qué es un número de Armstrong, debes buscar información
 * al respecto.
 */

/*
 * Crea una función que calcule y retorne cuántos días hay entre dos cadenas
 * de texto que representen fechas.
 * - Una cadena de texto que representa una fecha tiene el formato "dd/MM/yyyy".
 * - La función recibirá dos String y retornará un Int.
 * - La diferencia en días será absoluta (no importa el orden de las fechas).
 * - Si una de las dos cadenas de texto no representa una fecha correcta se
 *   lanzará una excepción.
 */

/*
 * Crea una función que reciba un String de cualquier tipo y se encargue de
 * poner en mayúscula la primera letra de cada palabra.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */
