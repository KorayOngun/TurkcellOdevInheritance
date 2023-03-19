internal class Program
{
    private static void Main(string[] args)
    {
        // işçilerin ne kadar doğum izni alacağını gösteren program
        Employee[] employees = {new Employee(1,"ahmet"),new DadEmployee(2,"ali") ,new MomEmployee(3,"oya")};
        foreach (var item in employees)
        {
            item.GetSalary();
            item.HealthInsurance();
            item.MaternityLeave();
            if (item is IMaternety)
            {
                var _item=(IMaternety)item;
                _item.MaternityInsurance();
            }
            Console.WriteLine("-------------------------------------------------------------------");
        }

    }
}

interface IMaternety
{
    void MaternityInsurance();
}

class  Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void GetSalary()
    {
        Console.WriteLine($"{Id} : {Name} paid salary ");
    }
    public void HealthInsurance()
    {
        Console.WriteLine($"{Id} : {Name} health insurance made ");
    }
    public virtual void MaternityLeave() 
    {
        Console.WriteLine($"no maternety leave");
    }
}

class DadEmployee : Employee
{
    public DadEmployee(int id, string name) : base(id, name) { }

    public override void MaternityLeave()
    {
        Console.WriteLine("10 days maternity leave");
    }
}

class MomEmployee : Employee, IMaternety
{
    public MomEmployee(int id, string name) : base(id, name) { }

    public void MaternityInsurance()
    {
        Console.WriteLine("Maternity insurance");
    }

    public override void MaternityLeave() 
    {
        Console.WriteLine("112 days maternity leave");    
    }
}