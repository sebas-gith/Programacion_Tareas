//Name: Sebastian Gonzalo Alvarez Concepcion
//Matricula: 2024-1670
class ContactManager
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1;

    public void AddContact(string name, string phone, string email, string address)
    {
        Contact newContact = new Contact(nextId++, name, phone, email, address);
        contacts.Add(newContact);
        Console.WriteLine("Contact added successfully!");
    }

    public void ViewContacts()
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }

        Console.WriteLine("Current Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public Contact FindContactById(int id)
    {
        return contacts.FirstOrDefault(c => c.Id == id);
    }

    public void EditContact(int id, string name = null, string phone = null, string email = null, string address = null)
    {
        var contact = FindContactById(id);
        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(name)) contact.Name = name;
        if (!string.IsNullOrWhiteSpace(phone)) contact.Phone = phone;
        if (!string.IsNullOrWhiteSpace(email)) contact.Email = email;
        if (!string.IsNullOrWhiteSpace(address)) contact.Address = address;

        Console.WriteLine("Contact updated successfully!");
    }

    public void DeleteContact(int id)
    {
        var contact = FindContactById(id);
        if (contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        contacts.Remove(contact);
        Console.WriteLine("Contact deleted successfully!");
    }

    public List<Contact> SearchContacts(string searchTerm)
    {
        return contacts.Where(c =>
            c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Phone.Contains(searchTerm) ||
            c.Email.Contains(searchTerm) ||
            c.Address.Contains(searchTerm)
        ).ToList();
    }
}