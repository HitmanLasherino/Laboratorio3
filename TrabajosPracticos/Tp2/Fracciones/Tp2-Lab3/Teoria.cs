//using System.Runtime.Intrinsics.X86;
//using System.Security.AccessControl;

//A.) Teoria.NET

//1. ¿Que es Microsoft Visual Studio .Net? 
//Microsoft Visual Studio .NET es un entorno de desarrollo integrado (IDE) que permite a los desarrolladores crear aplicaciones para la plataforma .NET utilizando lenguajes como C#, F#, y Visual Basic. Proporciona herramientas para el desarrollo, depuración y despliegue de aplicaciones web, de escritorio, móviles y en la nube.

//2. ¿Qué es el Framework .Net? 
//El .NET Framework es una plataforma de desarrollo de software creada por Microsoft que proporciona un entorno de ejecución para aplicaciones desarrolladas en varios lenguajes de programación. Incluye una gran biblioteca de clases (BCL) y soporte para interoperabilidad entre lenguajes.

//3. ¿Qué es el CLR? 
//El Common Language Runtime (CLR) es el entorno de ejecución de .NET que maneja la ejecución de programas .NET. Proporciona servicios como la gestión de memoria, la seguridad, el manejo de excepciones y la recolección de basura.

//4. ¿Qué es la BCL? 
//La Base Class Library (BCL) es un conjunto de clases que proporciona funcionalidades básicas y esenciales para el desarrollo de aplicaciones en .NET. Incluye clases para tareas comunes como la manipulación de cadenas, la entrada/salida, la colección de datos y la interacción con el sistema.

//5. Indique y explique el orden que se sigue en el proceso de compilación y ejecución en .net 
//El proceso de compilación y ejecución en .NET sigue estos pasos:
//      1.Compilación del código fuente: El código fuente escrito en un lenguaje .NET (como C#) se compila en Lenguaje Intermedio Común (CIL).
//      2.	Generación del ensamblado: El compilador produce un ensamblado (archivo .dll o .exe) que contiene el CIL y metadatos.
//      3.	Carga del ensamblado: El CLR carga el ensamblado en memoria.
//      4.	Compilación JIT: El compilador Just-In-Time (JIT) convierte el CIL en código nativo específico de la CPU en tiempo de ejecución.
//      5.	Ejecución del código: El CLR ejecuta el código nativo y proporciona servicios como la gestión de memoria y la recolección de basura.


//6.	¿Cuál es la signatura de Main? 
//La signatura del método Main en C# puede ser:

//static void Main(string[] args)
//static int Main(string[] args)

//7.  ¿Qué es un espacio de nombre (namespace)?
//Un espacio de nombre(namespace) es una forma de organizar y agrupar clases y otros tipos en.NET.Ayuda a evitar conflictos de nombres y a estructurar el código de manera lógica.Por ejemplo:

//namespace MiAplicacion
//{
//    class MiClase
//    {
//    }
//}

//8.	¿Cómo se incluye una librería en C#? 
//Para incluir una librería en C#, se utiliza la directiva using seguida del nombre del espacio de nombres de la librería. Por ejemplo:

//using System;
//using System.Collections.Generic;

//9.	¿Qué indica la palabra clave params?
//La palabra clave params permite que un método acepte un número variable de argumentos del mismo tipo.Por ejemplo:

//public void ImprimirMensajes(params string[] mensajes)
//{
//    foreach (string mensaje in mensajes)
//    {
//        Console.WriteLine(mensaje);
//    }
//}

//D) OBJETOS:

//1. ¿Qué es una clase?
//Una clase en C# es una plantilla o modelo que define un conjunto de atributos y métodos que los objetos creados a partir de la clase pueden tener. Es la base de la programación orientada a objetos y permite encapsular datos y funcionalidades relacionadas en una sola entidad1.

//2. ¿Qué es un objeto?
//Un objeto es una instancia de una clase. Es decir, cuando se crea un objeto, se asigna memoria y se configura según la definición de la clase. Los objetos tienen estado (almacenado en atributos) y comportamiento (definido por métodos).

//3. ¿Por qué se caracterizan los objetos?
//Los objetos se caracterizan por tener:
//Estado: Representado por los atributos o campos del objeto.
//Comportamiento: Definido por los métodos del objeto.
//Identidad: Cada objeto es único, incluso si tiene el mismo estado y comportamiento que otro objeto.

//4. ¿Cómo se llama la táctica de obtener la forma mínima y esencial de un objeto?
//La táctica de obtener la forma mínima y esencial de un objeto se llama abstracción. La abstracción permite enfocarse en los aspectos más importantes de un objeto, ignorando los detalles irrelevantes para el contexto específico.
