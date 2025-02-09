Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption;
    try
    {
        typeOption = Convert.ToInt32(Console.ReadLine());
    }
    catch (FormatException)
    {
        Console.Clear();
        continue;
    }

    switch (typeOption)
    {
        case 1:
            {
                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                SeeContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 3: //search
            {
                SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 4: //modify
            {
                EditContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            {
                DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
    Console.Write("\n\nPresione cualquier letra para continuar");
    Console.ReadKey(true);
    Console.Clear();
}

static void EditContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Write("Digite el numero de telefono del contacto: ");
    string telefono = Console.ReadLine();
    bool wasFound = false;
    int id = -1;
    foreach(var phone in telephones)
    {
        if (phone.Value == telefono)
        {
            Console.WriteLine("Usuario encontrado: ");
            id = phone.Key;
            wasFound = true;
        }
    }
    if (!wasFound) Console.WriteLine("El telefono no se encuentra en la lista de contactos");
    else
    {
        Console.WriteLine("Si no desea modificar el dato entonces dejelo vacio ");

        Console.WriteLine($"Modificar nombres ({names[id]}): ");
        string NewName = Console.ReadLine();
        if (!string.IsNullOrEmpty(NewName)) {
            names[id] = NewName;
        }

        Console.WriteLine($"Modificar apellidos ({lastnames[id]}): ");
        string NewLastname = Console.ReadLine();
        if (!string.IsNullOrEmpty(NewLastname))
        {
            lastnames[id] = NewLastname;
        }

        Console.WriteLine($"Modificar direccion ({addresses[id]}): ");
        string NewAddress = Console.ReadLine();
        if (!string.IsNullOrEmpty(NewAddress))
        {
            addresses[id] = NewAddress;
        }

        Console.WriteLine($"Modificar telefono ({telephones[id]}): ");
        string NewPhone = Console.ReadLine();
        if (!string.IsNullOrEmpty(NewPhone))
        {
            telephones[id] = NewPhone;
        }

        Console.WriteLine($"Modificar email ({emails[id]}): ");
        string NewEmail = Console.ReadLine();
        if (!string.IsNullOrEmpty(NewEmail))
        {
            emails[id] = NewEmail;
        }

        Console.WriteLine($"Modificar edad ({ages[id]}): ");
        try
        {
            int NewAge = Convert.ToInt32(Console.ReadLine());
            ages[id] = NewAge;

        }
        catch (FormatException) { Console.WriteLine("La edad no sigue el formato correcto, no fue modificada"); }

        Console.WriteLine($"Modifique si es mejor amigo ({(bestFriends[id] ? "Yes" : "No")}) 1. Si, 2. No");
        bool input = (Console.ReadLine() == "1" ? true : false);
        bestFriends[id] = input;

    }

}
static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}

static void SeeContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");
    foreach (var id in ids)
    {
        var isBestFriend = bestFriends[id];
        string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }

}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Write("Digite el nombre: ");

    string nombre = Console.ReadLine();
    bool wasFound = false;

    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");

    foreach (var name  in names)
    {
        if (name.Value.StartsWith(nombre))
        {
            int id = name.Key;;
            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {(bestFriends[id] ? "Yes" : "No")}");
            wasFound = true;
        }
    }
    if (!wasFound) Console.WriteLine("El nombre no se encuentra en la lista de contactos");
    
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends) 
{
    Console.Write("Digite el telefono del contacto: ");
    string typedPhone = Console.ReadLine();

    int id = -1;
    bool wasFound = false;
    foreach(var phone in telephones)
    {
        if(phone.Value == typedPhone)
        {
            Console.Write("¿Estas seguro que quieres eliminar el contacto? (y/n) ");
            char select = Convert.ToChar(Console.ReadLine());
            if (select == 'n') break;
            id = phone.Key;
            wasFound = true;
            break;
        }
    }

    if (!wasFound) Console.WriteLine("El nombre no se encuentra en la lista de contactos o decidio no eliminarlo");
    else {
        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);   
        telephones.Remove(id);  
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto Elminado Exitosamente");
    }
}