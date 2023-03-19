internal class Program
{
    private static void Main(string[] args)
    {
        // ürünleri veritabanına kaydeden program
        Database[] databases = { new Sql(), new MySql("veritabanı") };
        Product p1 = new() {Name="test"};
        foreach (var item in databases)
        {
            item.Add(p1);
            item.Update(p1);
            item.Copy("a","b");
            if (item is IPrint)
            {
                 IPrint _ = (IPrint)item;
                 _.Print(p1);
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
    }
}

class Product
{
    public string Name { get; set; }    
}


abstract class Database
{
    private string _db;
    public Database(string db)
    {
        _db = db; // <_db> copied <from> <to>
    }
    public abstract void Add(Product product);
    public abstract void Update(Product product);   

    public  void Copy(string from, string to)
    {
        Console.WriteLine($"{_db} copied from {from} to {to}");
    }
}
interface IPrint
{
    void Print(Product product);
}


class Sql : Database, IPrint
{
    public Sql() : base("Sql") {}
 
    public override void Add(Product product)
    {
        Console.WriteLine($"product {product.Name} Sql add");
    }

    public void Print(Product product)
    {
        Console.WriteLine($"product {product.Name} print");
    }

    public override void Update(Product product)
    {
        Console.WriteLine($"product {product.Name} Sql update");
    }
}



class MySql : Database
{
    public MySql(string db = "MySql") : base(db) {}
    public override void Add(Product product)
    {
        Console.WriteLine($"product {product.Name} MySql add");
    }

    public override void Update(Product product)
    {
        Console.WriteLine($"product {product.Name} MySql update");
    }
}