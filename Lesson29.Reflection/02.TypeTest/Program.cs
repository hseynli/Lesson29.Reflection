using _02.TypeTest;
using System.Reflection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Class1 myClass = new Class1();

#region Вывод информации о типе

ListVariosStats(myClass); // Class1 haqqında müxtəlif məlumatlar əldə edirik.
ListMethods(myClass); // Class1-in bütün metodlarının adları haqqında məlumatları əldə edirik.
ListFields(myClass); // Class1-in bütün sahələri.
ListProps(myClass); // Class1-in bütün xassələri.
ListInterfaces(myClass); // Class1-in dəstəklədiyi bütün interfeyslər haqqında məlumat əldə edirik.
ListConstructors(myClass); // Class1-in bütün konstruktorları.

#endregion

#region Qabapalı üzvlərə müraciət etmək (İnkapsulyasiya... İnkapsulyasiya nədir?)

Console.WriteLine(new string('-', 60));
Type type = myClass.GetType();

// private metodun çağırılması
MethodInfo methodC = type.GetMethod("MethodC", BindingFlags.Instance | BindingFlags.NonPublic);
methodC.Invoke(myClass, new object[] { "Hello", " world!" });

// private sahəyə dəyərin yazılması
FieldInfo mystring = type.GetField("mystring", BindingFlags.Instance | BindingFlags.NonPublic);
mystring.SetValue(myClass, "Hello, World!");

Console.WriteLine(myClass.MyString);

#endregion

// Delay.
Console.ReadKey();


// Class1 haqqında müxtəlif məlumatlar əldə edirik.
static void ListVariosStats(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 haqqında informasiyalar" + "\n");
    Type t = cl.GetType();

    Console.WriteLine("Tam ad:             {0}", t.FullName);
    Console.WriteLine("Base klas:          {0}", t.BaseType);
    Console.WriteLine("Abstraktdı?:            {0}", t.IsAbstract);
    Console.WriteLine("COM obyektdir?:         {0}", t.IsCOMObject);
    Console.WriteLine("Törəmək qadağan olunub?: {0}", t.IsSealed);
    Console.WriteLine("Klasdır?:              {0}", t.IsClass);
}

// Class1 klasının bütün metodları haqqında məlumat əldə edirik.
static void ListMethods(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 klasının metodları" + "\n");

    Type t = cl.GetType();
    MethodInfo[] mi = t.GetMethods(BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.Public
            | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

    foreach (MethodInfo m in mi)
        Console.WriteLine("Method: {0}", m.Name);
}

// Class1 klasının sahələri haqqında məlumat əldə edirik.
static void ListFields(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 klasının sahələri" + "\n");

    Type t = cl.GetType();
    FieldInfo[] fi =
        t.GetFields(BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.Public
            | BindingFlags.NonPublic);

    foreach (FieldInfo f in fi)
        Console.WriteLine("Field: {0}", f.Name);
}

// Class1 klasının xassələri haqqında məlumat əldə edirik.
static void ListProps(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 klasının xassələri" + "\n");

    Type t = cl.GetType();
    PropertyInfo[] pi = t.GetProperties();

    foreach (PropertyInfo p in pi)
        Console.WriteLine("Xassə: {0}", p.Name);
}

// Class1 klasının realizasiya elədiyi bütün interfeyslər.
static void ListInterfaces(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 klasının interfeysfləri" + "\n");

    Type t = cl.GetType();

    Type[] it = t.GetInterfaces();

    foreach (Type i in it)
        Console.WriteLine("İnterfeys: {0}", i.Name);
}

// Class1 klasının bütün konstruktorları haqqında məlumat əldə edirik.
static void ListConstructors(Class1 cl)
{
    Console.WriteLine(new string('_', 30) + " Class1 klasının konstruktorları" + "\n");

    Type t = cl.GetType();
    ConstructorInfo[] ci = t.GetConstructors();

    foreach (ConstructorInfo m in ci)
        Console.WriteLine("Constructor: {0}", m.Name);
}