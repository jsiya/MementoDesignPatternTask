using static System.Net.Mime.MediaTypeNames;

namespace Memento
{

    public class MementoEmployee //employeenin deyisen datalarini saxlayan memento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MementoEmployee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee(int id, string name)
        {
            Id= id;
            Name = name;
        }
        public MementoEmployee CreateMemento() //deyisen datalar ucun memento saxlanmasi
        {
            return new MementoEmployee(this);
        }
        public void RestoreToMemento(MementoEmployee memento) //evvelki mementonun yeniden verilmesi
        {
            Id = memento.Id;
            Name = memento.Name;
        }
        public void PrintEmp()
        {
            Console.WriteLine($"Name: {Name},\n ID: {Id}");
        }
    }

    public class CareTaker //mementolarin saxlandigi list
    {
        public List<MementoEmployee> mementoEmployeeList { get; set; } = new();

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CareTaker careTaker = new();
            Employee emp = new(1, "Sia Jabbar");
            emp.PrintEmp();
            careTaker.mementoEmployeeList.Add(emp.CreateMemento()); //yaradilan employeenin bir mementosu yaradilib liste elave olundu

            emp.Name = "Siya Cabbarova";
            emp.PrintEmp() ;
            careTaker.mementoEmployeeList.Add(emp.CreateMemento()); 

            emp.RestoreToMemento(careTaker.mementoEmployeeList[0]); //ilk vezziyete restore olundu

            Console.WriteLine("\nAfter Restore");
            emp.PrintEmp();

        }
    }
}