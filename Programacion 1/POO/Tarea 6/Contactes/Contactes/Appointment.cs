//Name: Sebastian Gonzalo Alvarez Concepcion
//Matricula: 2024-1670
class Appointment
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Purpose { get; set; }
    public bool IsReminderSet { get; set; }
    public TimeSpan ReminderTime { get; set; }

    public Appointment(int id, string title, DateTime date, string location, string purpose)
    {
        Id = id;
        Title = title;
        Date = date;
        Location = location;
        Purpose = purpose;
        IsReminderSet = false;
        ReminderTime = TimeSpan.FromHours(1); // Default reminder 1 hour before
    }

    public bool IsUpcoming => Date > DateTime.Now;

    public override string ToString()
    {
        return $"ID: {Id}, Title: {Title}, Date: {Date}, Location: {Location}, Purpose: {Purpose}";
    }
}