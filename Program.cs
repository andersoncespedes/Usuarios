using System.Collections;
// See https://aka.ms/new-console-template for more information
public class Usuario{
    public string? Nombre {get; set;}
    public int?    Edad {get; set;}
    public List<string?>? Hobbies {get; set;}
    public Usuario(string? nombre, int? edad, List<string?>? hobbies){
        this.Nombre=nombre;
        this.Edad=edad;
        this.Hobbies=hobbies;
    }

}
public class Programa
{
    public static Dictionary<int, Usuario> Usuarios = new();
    static void Main(string[] args){
        int input = 1;
        do{
            Console.Clear();
            Menu();
            input = Opcion();
            switch(input){
                case 1:
                    MostratLista();
                    Console.Write("Presione Enter Para Continuar->");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.Clear();
                    AgregarUsuario();
                    break;
                case 3:
                    MostrarUsuario();
                    break;
                case 5:
                    Console.WriteLine("Hasta Luego");
                    break;
                default:
                    Console.WriteLine("Input invalido vuelva a intentarlo");
                    break;
            }
                
        }while(input != 5);
    }
      public static void Menu(){
        Console.WriteLine("Bienvenido Usuario Que Desea Realizar");
        Console.WriteLine("1. Mostrar Lista");
        Console.WriteLine("2. Agregar Usuario ");
        Console.WriteLine("3. Mostrar Usuario");
        Console.WriteLine("4. Eliminar Usuario");
        Console.WriteLine("5. Salir");
    }
    public static int Opcion(){
        Console.WriteLine("Ingrese una Opcion");
        return int.Parse(Console.ReadLine());
    }
    public static void AgregarUsuario(){
        Console.Write("Ingrese el Nombre Del Usuario-> ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese La Edad Del Usuario-> ");
        int edad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese La Cedula Del Usuario-> ");
        int cedula = int.Parse(Console.ReadLine());
        List<string?> hobbies = new();
        bool seguir = true;
        while(seguir){
            Console.Write("Agregue un Hobbie-> ");
            string hobie = Console.ReadLine();
            hobbies.Add(hobie);
            Console.Write("Desea Continuar-> ");
            seguir = Console.ReadLine() == "s" ? true : false;
        }
        Usuarios.Add(cedula,new Usuario(nombre, edad, hobbies));
    }
    public static void MostratLista(){
        Console.WriteLine("Cedula  |  Nombre  |  Edad   |  hobbies");
        foreach(KeyValuePair<int, Usuario> arr in Usuarios){
            string hob = String.Join(", ", arr.Value.Hobbies.ToArray());
            Console.WriteLine($"{arr.Key}    {arr.Value.Nombre}    {arr.Value.Edad}   {hob}");
        }
    }
    public static void MostrarUsuario(){
        Console.Write("Ingrese La Cedula Del Usuario-> ");
        int cedula = int.Parse(Console.ReadLine());
        if(Usuarios.ContainsKey(cedula)){
            Usuario usuario = Usuarios[cedula];
            Console.WriteLine($"Nombre ->{usuario.Nombre}");
            Console.WriteLine($"Edad ->{usuario.Edad}");
            Console.WriteLine($"Cedula ->{cedula}");
        }
        Console.Write("Presione Enter Para Continuar->");
        Console.ReadLine();
    }
    public static void EliminarUsuario(){
        Console.Write("Ingrese La Cedula Del Usuario-> ");
        int cedula = int.Parse(Console.ReadLine());
        if(Usuarios.ContainsKey(cedula)){
            Usuarios.Remove(cedula);
        }
    }
}
