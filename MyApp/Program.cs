// See https://aka.ms/new-console-template for more information

int hsTrabajadas = 0;
int cont = 0;
List<Tarea> tareasPendientes = new List<Tarea>();

//Creamos aleatoriamente la cantidad de tareas
Random rnd = new Random();
//int cantTareas =rnd.Next(1,5);
int cantTareas = 3;
Console.WriteLine("Cargando las tareas: ");

// Agregar las tareas a la lista
for (int i = 0; i < cantTareas; i++){
    Console.WriteLine("Ingrese descripcion de la tarea: ");
    tareasPendientes.Insert(i, new Tarea() { tareaID = i, descripcion = Console.ReadLine(), duracion = rnd.Next(10,100) });
}

Console.WriteLine("\nTareas pendientes: ");
for (int i = 0; i < cantTareas; i++){
    Console.WriteLine("\nTarea ID: {0}", tareasPendientes[i].tareaID);
    Console.WriteLine("Descripcion: {0}", tareasPendientes[i].descripcion);
    Console.WriteLine("Duracion: {0}", tareasPendientes[i].duracion);
}

List<Tarea> tareasRealizadas = new List<Tarea>();


for (int i = 0; i < cantTareas; i++){
    Console.WriteLine($"La tarea {i} fue realizada? Ingrese 1 para SI o 0 para NO: ");
    int opcion  = Convert.ToInt32(Console.ReadLine());
    
    if(opcion == 1){

        var tarea = tareasPendientes[i-cont];
        tareasRealizadas.Add(tarea);

        tareasPendientes.RemoveAt(i-cont);
        cont++;
    }
}

Console.WriteLine("\n-------------TAREAS SEGUN SU ESTADO-------------");
Console.WriteLine("\nTareas pendientes: ");

//para ambas conviene usar foreach porque no conozco la cantidad de elementos de las listas luego de modificarlas
foreach (Tarea item in tareasPendientes){
    Console.WriteLine("Tarea ID: {0}", item.tareaID);
    Console.WriteLine("Descripcion: {0}", item.descripcion);
    Console.WriteLine("Duracion: {0}\n", item.duracion);
}

Console.WriteLine("\nTareas realizadas: ");
foreach (Tarea item in tareasRealizadas){
    Console.WriteLine("Tarea ID: {0}", item.tareaID);
    Console.WriteLine("Descripcion: {0}", item.descripcion);
    Console.WriteLine("Duracion: {0}\n", item.duracion);
    hsTrabajadas = hsTrabajadas + item.duracion;
}

Console.WriteLine($"\nCantidad de horas trabajadas: {hsTrabajadas}");
Console.WriteLine("\n\nDesea buscar una tarea? Ingrese 1 para si o 0 para no: ");
int opcion2 = Convert.ToInt32(Console.ReadLine());

if(opcion2 == 1){
    Console.WriteLine("\nIngrese descripcion de la tarea pendiente: ");
    string descBusqueda = Console.ReadLine();

    if(tareasPendientes.Exists(x => x.descripcion == descBusqueda)){
        Tarea encontrada = tareasPendientes.Find(y => y.descripcion.Contains(descBusqueda));
        Console.WriteLine("\nTarea buscada: ");

        Console.WriteLine("Tarea ID: {0}", encontrada.tareaID);
        Console.WriteLine("Descripcion: {0}", encontrada.descripcion);
        Console.WriteLine("Duracion: {0}\n", encontrada.duracion);
    }else{
        Console.WriteLine("\nNo existe una tarea con esa descripcion");
    }
    
}

tareasPendientes.Clear();
tareasRealizadas.Clear();