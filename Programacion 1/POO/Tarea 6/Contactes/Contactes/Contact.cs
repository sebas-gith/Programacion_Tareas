//Name: Sebastian Gonzalo Alvarez Concepcion
//Matricula: 2024-1670
using System;
using System.Collections.Generic;
using System.Linq;

public class Contact
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Contact(int id, string name, string phone, string email, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Phone: {Phone}, Email: {Email}, Address: {Address}";
    }
}