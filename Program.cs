using LinQ_HW15;

var countries = new List<Country>
{
    new Country { Name = "Ukraine", Continents = new Continent { Name = "Europe" }, Capital = new City { Name = "Kyiv", Population = 2952000, CityFounded = new DateTime(482) } },
    new Country { Name = "Australia", Continents = new Continent { Name = "Australia and Oceania" }, Capital = new City { Name = "Sidney", Population = 2148000, CityFounded = new DateTime(52) } },
    new Country { Name = "China", Continents = new Continent { Name = "Asia" }, Capital = new City { Name = "Beijing", Population = 21540000, CityFounded = new DateTime(1045) } },
    new Country { Name = "Mexico", Continents = new Continent { Name = "North America" }, Capital = new City { Name = "Mexico City", Population = 8918653, CityFounded = new DateTime(1325) } },
};

// кількість країн по континентах
Console.WriteLine("Count Countries of Continent:");
var countriesByContinent = countries.GroupBy(c => c.Continents)
                                    .Select(g => new { Continent = g.Key, Count = g.Count() });

foreach (var group in countriesByContinent)
{
    Console.WriteLine($"Continent: {group.Continent.Name}, CountryCount: - {group.Count}");
}
Console.WriteLine("---------");

var Cities = countries.Select(c => c.Capital)
               .Where(city => city.CityFounded.Year < 1200)
               .OrderByDescending(city => city.Population)
               .Take(3);
//  топ-3 міст за населенням без урахування тих, що були засновані після 1200 року
Console.WriteLine("Top 3 cities with population, without before 1200 year:");
foreach (var city in Cities)
{
    Console.WriteLine($"Country Name: - {city.Name}, Population: -  {city.Population}");
}
Console.WriteLine("---------");

// країнa з найбільшим населенням і її столиця
var largestCountry = countries.OrderByDescending(c => c.Capital.Population).First();
Console.WriteLine($"Country with biggest of population: - {largestCountry.Name}, Capital: - {largestCountry.Capital.Name}");


//населення в містах більше 1 мільйона
Console.WriteLine("---------");
var result = countries
    .Select(c => c.Continents)
    .Distinct()
    .Select(continent => new
    {
        ContinentName = continent.Name,
        CitiesCount = countries
            .Where(c => c.Continents == continent)
            .Select(c => c.Capital) 
            .Count(city => city.Population > 1000000)
    });
Console.WriteLine("Continent, with population in the City, over 1 Milion:");
foreach (var item in result) 
{
    Console.WriteLine($"Continent: {item.ContinentName}.");
}
