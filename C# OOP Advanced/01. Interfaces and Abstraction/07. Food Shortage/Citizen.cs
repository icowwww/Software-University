﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen:IInfo,IBuyer
{
    public string Name { get; private set; }
    public string Id { get; private set; }
    public int Age { get; private set; }
    public string Birthdate { get; private set; }
    public int Food { get; private set; }

    public void BuyFood()
    {
        Food += 10;
    }
    public Citizen(string name, int age, string id,string birthdate)
    {
        this.Name = name;
        this.Id = id;
        this.Age = age;
        this.Birthdate = birthdate;
        this.Food = 0;
    }
}