using EspacioDistribuidora;


//Ejercicio 1
//Creación de listas
var listaTareasPendientes = new List<Tarea>();
var listaTareasRealizadas = new List<Tarea>();
//Creación de tareas
/*var tareaA = new Tarea(1, "Tarea A", 20);
var tareaB = new Tarea(2, "Tarea B", 25);
var tareaC = new Tarea(3, "Tarea C", 15);
//Tareas Creadas de forma manual
listaTareasPendientes.Add(tareaA);
listaTareasPendientes.Add(tareaB);
listaTareasPendientes.Add(tareaC);*/

//Declaración de Variables
int respuesta;
string ingreso;
string descript;
bool resultado;
int itemRand;
int cantidadTareas;
Tarea Funciones = new Tarea();

//Comienzo del tp


//Creación de N tareas random
Random rand = new Random();



do
{
    Console.WriteLine("Ingrese la cantidad N de tareas que desea trabajar");
    ingreso = Console.ReadLine();
    resultado = int.TryParse(ingreso, out respuesta);
} while (!resultado || respuesta < 0);

cantidadTareas = Enum.GetValues(typeof(RandomTareas)).Length;

for (int i = 0; i < respuesta; i++)
{
    Tarea TareaAgregar = new Tarea();
    itemRand = rand.Next(0, cantidadTareas);
    var variable = (RandomTareas)itemRand;
    TareaAgregar.Id = i;
    TareaAgregar.Descripcion = variable.ToString();
    TareaAgregar.Duracion = rand.Next(1, 101);

    listaTareasPendientes.Add(TareaAgregar);
}
var cantidad = rand.Next(0, 10);




do
{
    //Menú de tareas
    do
    {
        Console.WriteLine("===========MENU DE TAREAS===========");
        Console.WriteLine("1.Pasar una tarea a la lista de Realizadas");
        Console.WriteLine("2.Buscar una tarea en la lista de Pendientes por descripción");
        Console.WriteLine("3.Salir");
        ingreso = Console.ReadLine();
        resultado = int.TryParse(ingreso, out respuesta);
    } while (!resultado || respuesta < 1 || respuesta > 3);

    //TAREAS SEGÚN LA OPCIÓN ELEGIDA
    switch (respuesta)
    {
        case 1: //Mover una tarea de la lista de tareas pendientes a la lista de tareas realizadas
            MostrarListas(listaTareasPendientes, "PENDIENTES");
            do
            {
                Console.WriteLine("Ingrese el id de la tarea que desea marcar como realizada: ");
                ingreso = Console.ReadLine();
                resultado = int.TryParse(ingreso, out respuesta);
            } while (!resultado || respuesta < 0 || respuesta > listaTareasPendientes.Count);
            listaTareasRealizadas.Add(listaTareasPendientes.ElementAt(respuesta));
            listaTareasPendientes.RemoveAt(respuesta);
            break;
        case 2: //Buscar en la lista de tareas pendientes una tarea por descripción
            Console.WriteLine("\nIngrese la descripción a buscar en la lista:");
            descript = Console.ReadLine();
            foreach (var item in listaTareasPendientes) //Recorro la lista para comparar con la descripción ingresada
            {
                if (item.Descripcion == descript)
                {
                    Funciones.MostrarTarea(item);
                }
            }
            break;
        case 3:
            Console.WriteLine("Saliendo del programa...");
            break;
        default:
            Console.WriteLine("Ingresó una opción incorrecta");
            break;
    }


} while (respuesta != 3);
Console.WriteLine("Las listas quedaron de la siguiente manera: ");
MostrarListas(listaTareasPendientes, "PENDIENTES");
MostrarListas(listaTareasRealizadas, "REALIZADAS");



static void MostrarListas(List<Tarea> lista, string titulo)
{
    Console.WriteLine("\nLista de tareas " + titulo);
    foreach (var item in lista)
    {
        Console.WriteLine("**********  Tarea: " + item.Descripcion + "  **********");
        Console.WriteLine("ID ---> " + item.Id);
        Console.WriteLine("Duración ---> " + item.Duracion + "hs");
        Console.WriteLine("*******************************************************");
        Console.WriteLine("\n");
    }
}

