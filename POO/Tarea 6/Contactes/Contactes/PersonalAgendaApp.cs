//Name: Sebastian Gonzalo Alvarez Concepcion
//Matricula: 2024-1670
class PersonalAgendaApp
{
    private ContactManager contactManager;
    private AppointmentManager appointmentManager;

    public PersonalAgendaApp()
    {
        contactManager = new ContactManager();
        appointmentManager = new AppointmentManager();
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            DisplayMainMenu();
            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    ManageContacts();
                    break;
                case 2:
                    ManageAppointments();
                    break;
                case 3:
                    running = false;
                    Console.WriteLine("Gracias por usar Mi Agenda Perrón. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    private void DisplayMainMenu()
    {
        Console.WriteLine("\n--- La mejor Agenda -- by Sebastian Alvarez---");
        Console.WriteLine("1. Gestionar Contactos");
        Console.WriteLine("2. Gestionar Citas");
        Console.WriteLine("3. Salir");
        Console.Write("Elija una opción: ");
    }

    private int GetUserChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Por favor, ingrese un número válido.");
            Console.Write("Elija una opción: ");
        }
        return choice;
    }

    private void ManageContacts()
    {
        bool managing = true;
        while (managing)
        {
            Console.WriteLine("\n--- Gestión de Contactos ---");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Editar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Elija una opción: ");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    AddNewContact();
                    break;
                case 2:
                    contactManager.ViewContacts();
                    break;
                case 3:
                    SearchContacts();
                    break;
                case 4:
                    EditExistingContact();
                    break;
                case 5:
                    DeleteContact();
                    break;
                case 6:
                    managing = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    private void ManageAppointments()
    {
        bool managing = true;
        while (managing)
        {
            Console.WriteLine("\n--- Gestión de Citas ---");
            Console.WriteLine("1. Agregar Cita");
            Console.WriteLine("2. Ver Citas");
            Console.WriteLine("3. Editar Cita");
            Console.WriteLine("4. Eliminar Cita");
            Console.WriteLine("5. Configurar Recordatorio");
            Console.WriteLine("6. Volver al Menú Principal");
            Console.Write("Elija una opción: ");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    AddNewAppointment();
                    break;
                case 2:
                    appointmentManager.ViewAppointments();
                    break;
                case 3:
                    EditExistingAppointment();
                    break;
                case 4:
                    DeleteAppointment();
                    break;
                case 5:
                    SetAppointmentReminder();
                    break;
                case 6:
                    managing = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    private void AddNewContact()
    {
        Console.Write("Ingrese el Nombre: ");
        string name = Console.ReadLine();
        Console.Write("Ingrese el Teléfono: ");
        string phone = Console.ReadLine();
        Console.Write("Ingrese el Email: ");
        string email = Console.ReadLine();
        Console.Write("Ingrese la Dirección: ");
        string address = Console.ReadLine();

        contactManager.AddContact(name, phone, email, address);
    }

    private void SearchContacts()
    {
        Console.Write("Ingrese término de búsqueda: ");
        string searchTerm = Console.ReadLine();
        var results = contactManager.SearchContacts(searchTerm);

        if (results.Count == 0)
        {
            Console.WriteLine("No se encontraron contactos.");
        }
        else
        {
            Console.WriteLine("Resultados de la búsqueda:");
            foreach (var contact in results)
            {
                Console.WriteLine(contact);
            }
        }
    }

    private void EditExistingContact()
    {
        contactManager.ViewContacts();
        Console.Write("Ingrese el ID del contacto a editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Nuevo Nombre (dejar en blanco para no cambiar): ");
            string name = Console.ReadLine();
            Console.Write("Nuevo Teléfono (dejar en blanco para no cambiar): ");
            string phone = Console.ReadLine();
            Console.Write("Nuevo Email (dejar en blanco para no cambiar): ");
            string email = Console.ReadLine();
            Console.Write("Nueva Dirección (dejar en blanco para no cambiar): ");
            string address = Console.ReadLine();

            contactManager.EditContact(id, name, phone, email, address);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void DeleteContact()
    {
        contactManager.ViewContacts();
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            contactManager.DeleteContact(id);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void AddNewAppointment()
    {
        Console.Write("Ingrese el Título de la Cita: ");
        string title = Console.ReadLine();
        Console.Write("Ingrese la Fecha (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.Write("Ingrese el Lugar: ");
            string location = Console.ReadLine();
            Console.Write("Ingrese el Propósito: ");
            string purpose = Console.ReadLine();

            appointmentManager.AddAppointment(title, date, location, purpose);
        }
        else
        {
            Console.WriteLine("Fecha inválida.");
        }
    }

    private void EditExistingAppointment()
    {
        appointmentManager.ViewAppointments();
        Console.Write("Ingrese el ID de la cita a editar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Nuevo Título (dejar en blanco para no cambiar): ");
            string title = Console.ReadLine();
            Console.Write("Nueva Fecha (yyyy-MM-dd HH:mm, dejar en blanco para no cambiar): ");
            DateTime? date = null;
            string dateInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime parsedDate))
            {
                date = parsedDate;
            }
            Console.Write("Nuevo Lugar (dejar en blanco para no cambiar): ");
            string location = Console.ReadLine();
            Console.Write("Nuevo Propósito (dejar en blanco para no cambiar): ");
            string purpose = Console.ReadLine();

            appointmentManager.EditAppointment(id, title, date, location, purpose);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void DeleteAppointment()
    {
        appointmentManager.ViewAppointments();
        Console.Write("Ingrese el ID de la cita a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            appointmentManager.DeleteAppointment(id);
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    private void SetAppointmentReminder()
    {
        appointmentManager.ViewAppointments();
        Console.Write("Ingrese el ID de la cita para configurar recordatorio: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Tiempo de recordatorio (en horas): ");
            if (double.TryParse(Console.ReadLine(), out double hours))
            {
                appointmentManager.SetReminder(id, TimeSpan.FromHours(hours));
            }
            else
            {
                Console.WriteLine("Tiempo inválido.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}