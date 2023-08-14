using System.Reflection;

static class Program
{
    static void Main()
    {
        Type personType = typeof(Person);

        TypeInfo personInfo = personType.GetTypeInfo();

        IEnumerable<PropertyInfo> declaredProperties = personInfo.DeclaredProperties;
        declaredProperties.PrintValues();

        IEnumerable<MethodInfo> declaredMethods = personInfo.DeclaredMethods;
        declaredMethods.PrintValues();

        IEnumerable<EventInfo> declaredEvents = personInfo.DeclaredEvents;
        declaredEvents.PrintValues();
    }

    private static void PrintValues(this IEnumerable<MemberInfo> members)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(members.GetType().GetElementType().Name);
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var member in members)
        {
            Console.WriteLine(member);
        }
        Console.WriteLine(new string('-', 20));
    }
}

public sealed class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public event EventHandler Modified;

    private void OnModified()
    {
        var handler = Modified;
        if (handler != null) handler.Invoke(this, EventArgs.Empty);
    }

    public void Save()
    {
        // Obyekti repositoy-də yadda saxlayırıq...
    }
}