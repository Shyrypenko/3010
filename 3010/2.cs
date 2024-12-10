using System;

public class City
{
    private string name;
    private string country;
    private int population;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("City name cannot be empty.");
            name = value;
        }
    }

    public int Population
    {
        get => population;
        set
        {
            if (value < 0)
                throw new ArgumentException("Population cannot be negative.");
            population = value;
        }
    }
    public City(string name, string country, int population)
    {
        Name = name;
        this.country = country;
        Population = population;
    }

    public static City operator +(City city, int amount)
    {
        city.Population += amount;
        return city;
    }

    public static City operator -(City city, int amount)
    {
        city.Population -= amount;
        return city;
    }

    public static bool operator ==(City city1, City city2) => city1.Population == city2.Population;
    public static bool operator !=(City city1, City city2) => city1.Population != city2.Population;
    public static bool operator <(City city1, City city2) => city1.Population < city2.Population;
    public static bool operator >(City city1, City city2) => city1.Population > city2.Population;

    public override bool Equals(object obj) => obj is City city && this == city;
    public override int GetHashCode() => Population.GetHashCode();

    public override string ToString()
    {
        return $"City: {Name}, Country: {country}, Population: {Population}";
    }
}