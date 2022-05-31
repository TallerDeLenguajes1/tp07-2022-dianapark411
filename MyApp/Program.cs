// See https://aka.ms/new-console-template for more information


List<Tarea> tareasPendientes = new List<Tarea>();

//Creamos aleatoriamente la cantidad de tareas
Random rnd = new Random();
int cantTareas =rnd.Next(1,5);

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

/*
foreach (Tarea item in tareasPendientes){
    Console.WriteLine(item.tareaID);
    Console.WriteLine(item.descripcion);
    Console.WriteLine(item.duracion);
}
*/

List<Tarea> tareasRealizadas = new List<Tarea>();

for (int i = 0; i < cantTareas; i++){
    Console.WriteLine($"La tarea {i} fue realizada? Ingrese 1 para SI o 0 para NO: ");
    int opcion  = Convert.ToInt32(Console.ReadLine());
    if(opcion == 1){
        tareasRealizadas.Add(new Tarea() {tareaID = tareasPendientes[i].tareaID, descripcion = tareasPendientes[i].descripcion , duracion = tareasPendientes[i].duracion });

        tareasPendientes.RemoveAt(i);

        //tareasPendientes.TrimExcess(); ????????
    }
}

Console.WriteLine("\nTareas pendientes: ");
foreach (Tarea item in tareasPendientes){
    Console.WriteLine("\nTarea ID: {0}", item.tareaID);
    Console.WriteLine("Descripcion: {0}", item.descripcion);
    Console.WriteLine("Duracion: {0}", item.duracion);
}

Console.WriteLine("Tareas realizadas: ");
foreach (Tarea item in tareasRealizadas){
     Console.WriteLine("\nTarea ID: {0}", item.tareaID);
    Console.WriteLine("Descripcion: {0}", item.descripcion);
    Console.WriteLine("Duracion: {0}", item.duracion);
}