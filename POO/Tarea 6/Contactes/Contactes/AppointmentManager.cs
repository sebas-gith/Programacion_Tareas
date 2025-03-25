//Name: Sebastian Gonzalo Alvarez Concepcion
//Matricula: 2024-1670
class AppointmentManager
{
    private List<Appointment> appointments = new List<Appointment>();
    private int nextId = 1;

    public void AddAppointment(string title, DateTime date, string location, string purpose)
    {
        Appointment newAppointment = new Appointment(nextId++, title, date, location, purpose);
        appointments.Add(newAppointment);
        Console.WriteLine("Appointment added successfully!");
    }

    public void ViewAppointments()
    {
        if (appointments.Count == 0)
        {
            Console.WriteLine("No appointments found.");
            return;
        }

        Console.WriteLine("Current Appointments:");
        foreach (var appointment in appointments.OrderBy(a => a.Date))
        {
            Console.WriteLine(appointment);
        }
    }

    public Appointment FindAppointmentById(int id)
    {
        return appointments.FirstOrDefault(a => a.Id == id);
    }

    public void EditAppointment(int id, string title = null, DateTime? date = null,
                                string location = null, string purpose = null)
    {
        var appointment = FindAppointmentById(id);
        if (appointment == null)
        {
            Console.WriteLine("Appointment not found.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(title)) appointment.Title = title;
        if (date.HasValue) appointment.Date = date.Value;
        if (!string.IsNullOrWhiteSpace(location)) appointment.Location = location;
        if (!string.IsNullOrWhiteSpace(purpose)) appointment.Purpose = purpose;

        Console.WriteLine("Appointment updated successfully!");
    }

    public void DeleteAppointment(int id)
    {
        var appointment = FindAppointmentById(id);
        if (appointment == null)
        {
            Console.WriteLine("Appointment not found.");
            return;
        }

        appointments.Remove(appointment);
        Console.WriteLine("Appointment deleted successfully!");
    }

    public void SetReminder(int id, TimeSpan reminderTime)
    {
        var appointment = FindAppointmentById(id);
        if (appointment == null)
        {
            Console.WriteLine("Appointment not found.");
            return;
        }

        appointment.IsReminderSet = true;
        appointment.ReminderTime = reminderTime;
        Console.WriteLine($"Reminder set for {reminderTime} before the appointment.");
    }

    public List<Appointment> GetUpcomingAppointments()
    {
        return appointments.Where(a => a.IsUpcoming)
                           .OrderBy(a => a.Date)
                           .ToList();
    }
}