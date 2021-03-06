﻿using System.Data.Entity;
using styleBarber.Wep.ASP.Entities;

namespace styleBarber.Wep.ASP.EF
{
    public class BarberContext : DbContext
    {
        public BarberContext() : base("name=BarberString") { }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Appointment> Appointments {get;set;}
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<InfoStore> InfoStores { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<StyleHair> StyleHair  { get; set; }
        public DbSet<User> Users  { get; set; }

    }

   
}