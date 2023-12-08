using G6RXAI_ADT_2023241.Models;
using System;

namespace G6RXAI_ADT_2023241.Client
{     static class Extension
{
    public static void ToProcess<T>(this IEnumerable<T> query, string name)
    {
        Console.WriteLine($"\n:: {name} ::\n");

        foreach (var item in query)
            Console.WriteLine("\t" + item);

        Console.WriteLine("\n\n");
    }
}
    internal class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(5000);
            RestService service = new RestService("http://localhost:61939/api/DoctorController");

            Doctor doctor = new Doctor() { Name = "Abu James", DoctorId = 470,Specialization ="Nursing" };

            service.Post(doctor, "api/Doctor");

            Doctor server_Doctor = service.Get<Doctor>(470, "api/Doctor"); 

            Console.WriteLine(server_Doctor);
            Console.WriteLine("this");

        }
    }
}
