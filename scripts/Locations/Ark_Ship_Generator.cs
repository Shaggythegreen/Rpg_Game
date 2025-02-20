using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Ark_Ship_Generator : MonoBehaviour
{

   
    public int width, height, cave_amount = 0;
    public int MaximumPopulation = 55, numberOfLocations = 4, buildingsPerLocation = 6, HouseSize = 7, ApartmentSize = 2, OfficeSize = 10, SchoolSize = 4, ShopSize = 5, outdoorSpotsPerLocation = 2, numberOfNations = 5;
    public Tilemap Map;
    public Tile ocean, forest, grass, eastern, western, arctic, jungle, rainforest, fMountain, gMountain, eMountain, wMountain, aMountain, rMountain,jMountain, fCity, gCity, eCity, wCity, jCity, aCity, rCity, fCap, gCap, eCap, wCap, jCap, aCap, rCap,fCave,gCave,eCave,wCave,aCave,rCave,jCave;
    [Range(0, 100)]
    public int randomFillPercent;
    public string seed;
    public bool useRandomSeed;
    int[,] map, biomeGrid;
    System.Random pseudoRandom;
    public Chacater_Generation_Script Chacater_Generation_Script;
    public Biome currentActiveBiome;
    public Vector2 origin;
    public float Threshold = .55f,SecondaryThreshold = .45f,tertiaryThreshold = .35f;
    public List<City> cities = new List<City>();
    public List<Location> NonCityLocations = new List<Location>();

    public string[] locationNames = { "Vendor District", "Residental district", "Recreation District", "Educational District" }
   , building_Types = { "Apartment", "Office", "Shop", "House", "School" ,"Tavern"}
   , School_Room_Types = { "Dorm_Room", "Office Space", "Storage", "Lobby", "Kitchen", "Classroom", "Bathroom", "Teachers_Lounge" }
   , House_Room_Types = { "Living Room", "Office Space", "Closet", "Bedroom", "Kitchen", "Garage", "Game Room", "Bathroom" }
   , Apartment_Room_Types = { "Living Room", "Office Space", "Closet", "Bedroom", "Kitchen", "Garage", "Game Room", "Bathroom" }
   , Tavern_Room_Types = { "Bar Room", "Private Room", "Closet", "Back Office", "Game Room", "Bathroom" ,"Storage Room"}
   , Office_Room_Types = { "Lunch Room", "Office Space", "Closet", "Cubical Space", "Bathroom" }
   , Shop_Room_Types = { "Break Room", "Office", "Closet", "Lobby", "Bathroom" }
   , Apartment_Outdoor_Types = { "Patio", "Porch", "Communal Space" }
   , Home_Outdoor_Types = { "Backyard", "FrontYard", "Garden" }
   , Public_Outdoor_Types = { "Park", "Beach", "Outdoor Market", "Plaza", "Public Garden" }
   , School_Outdoor_Types = { "Park", "Football Field", "Quad", "Plaza", "Public Garden" }
   , Tavern_Outdoor_Types = {"Parking Lot" }
   , Forest_Prefixes = { "Sylvan", "Rose", "Verden", "Fae", "Fungi", "Wind", "Oaken", "Moss", "Deepwood" }
   , Forest_Suffixes = { "airis", "grove", "home", " Hollow", " Wood", "rest", " Garden", "wick", "vale", "mere" }
   , Grass_Prefixes = { "Clover", "Daffodil", "Grass", "Lily", "Garden", "Wind", "Sun", "Meadow" }
   , Grass_Suffixes = { "haven", "thorn", "reach", "vale", "gove", "watch", "stead", "brook" }
   , Eastern_Desert_Prefixes = { "Dune", "Dust", "Ashri", "Qamar", "Xuin", "Sahris", "Dry", "Xian" }
   , Eastern_Desert_Suffixes = { "dahar", "ruin", "'Akhet", "ymira", "'Xin", "abahd", "aruhn", "heir" }
   , Western_Desert_Prefixes = { "Cacti", "Xotlh", "Solam", "Mesas", "Koatl", "Sun", "Ember" }
   , Western_Desert_Suffixes = { " Spire", " Sands", " Cliffs", "karas", "quetzus", "Mekal" }
   , Rain_Forest_Prefixes = { "Tlape", "Xocatl", "Tapanari", "Umbras", "Koatl", "Kapu", "Yawa" }
   , Rain_Forest_Suffixes = { " Canopy", "Xotl", "locan", "Umbras", " Falls", "torse", "michos" }
   , Eastern_Jungle_Prefixes = { "Ipnam", "Varesh", "Khalor", "Pakal", "Yanx", "Xuan", "Chaktu", "Vishna" }
   , Eastern_Jungle_Suffixes = { "pishnu", "nua", "'Khalak", "xu", "xin", "fend", " Stronghold", "talak" }
   , Arctic_Prefixes = { "Vana", "Snow", "Rune", "Glaciv", "Norva", "North", "Ice", "Frost", "Iron", "Svart", "Rune", "Misty", "Thunder", "Gold", }
   , Arctic_Suffixes = { "hiem", "hold", "mist", "realm", "stad", "run", "foot", "home", "hearth", "vein", "peak", "spire", "crag" }
   , NationPrefixes = { "Nova", "Aero", "Hyper", "Mega", "Terra", "Neo", "Vita", "Astro", "Chrono", "Cosmo" }
   , NationSuffixes = { "sto", "topia", "land", "ia", "dom", "realm", "ia", "ton", "on", "sphere", "versa", "roma" };
    public List<Generated_Character> AreaPopulation = new List<Generated_Character>();


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MaximumPopulation; i++)
        {

        }
        origin = transform.position;
        biomeGrid = new int[width, height];
        map = new int[width, height];
        pseudoRandom = new System.Random(seed.GetHashCode());
        if (useRandomSeed)
        {
            seed = UnityEngine.Random.Range(1, 10000).ToString();
        }

        if (seed != null)
        {
            UnityEngine.Random.InitState(seed.GetHashCode());
        }
        RandomFillMap(width, height);
        SmoothMap(map, width, height);
        UsePerlinNoise();
        PlaceCities();
        renderMap();

    }
    void RandomFillMap(int mapWidth, int mapHeight)
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                {
                    map[x, y] = 0;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }
    void SmoothMap(int[,] mapToSmooth, int mapWidth, int mapHeight)
    {
        for (int x = 1; x < mapWidth - 1; x++)
        {
            for (int y = 1; y < mapHeight - 1; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(mapToSmooth, x, y, mapWidth, mapHeight);

                if (neighbourWallTiles > 4)
                    mapToSmooth[x, y] = 1;
                else if (neighbourWallTiles < 4)
                    mapToSmooth[x, y] = 0;
            }
        }
    }



    int GetSurroundingWallCount(int[,] mapToCheck, int gridX, int gridY, int mapWidth, int mapHeight)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += mapToCheck[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }


   
    // Update is called once per frame
    void UsePerlinNoise()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float noise = Mathf.PerlinNoise(x * 0.05f, y * 0.05f);
                if (noise >+ Threshold)
                    biomeGrid[x, y] = 1;
                else if (noise < Threshold)
                {
                    biomeGrid[x,y] = 0;
                }
                if (noise < SecondaryThreshold && noise > tertiaryThreshold) 
                {
                    biomeGrid[x, y] = 2;
                }
            }
        } 
    }

    public void PlaceCities()
    {
        int cityamt = 0;

        // Continue until we've placed the required number of cities
        while (cityamt < numberOfNations)
        {
            // Generate random coordinates
            int x = UnityEngine.Random.Range(0, width);
            int y = UnityEngine.Random.Range(0, height);

            // Check if the spot is valid
            if (biomeGrid[x, y] == 0 && map[x, y] == 1)
            {
                int ranrange = UnityEngine.Random.Range(0, 10);
                // Place the city if the random condition is met
                if (ranrange > 5)
                {
                    biomeGrid[x, y] = 3;
                    City newcity = GenerateNewCity(x, y);

                    cities.Add(newcity);
                    cityamt++;
                }
            }
            // If not valid, the loop iterates again and retries.
        }
    }
    public City GenerateNewCity(int x, int y)
    {
        City NewGeneratedCity = new City(Generate_CIty_Name());
        Debug.Log(NewGeneratedCity.cityName);
        NewGeneratedCity.BiomeCulture = currentActiveBiome;
        NewGeneratedCity.x = x;
        NewGeneratedCity.y = y;
       
        for (int i = 0; i < numberOfLocations; i++)
        {
            Location NewLocation = new Location("District" + i.ToString());
            NewGeneratedCity.Locations.Add(NewLocation);
        }


        return NewGeneratedCity;

    }
    public string Generate_CIty_Name()
    {
        string Cityname = "string.Empty";
        string NamePre = "string.Empty";
        string Namesuff = "string.Empty";
        switch (currentActiveBiome)
        {
            case Biome.Forest:
                NamePre = Forest_Prefixes[UnityEngine.Random.Range(0, Forest_Prefixes.Length)];
                Namesuff = Forest_Suffixes[UnityEngine.Random.Range(0, Forest_Suffixes.Length)];
                Cityname = NamePre + Namesuff;
                break;
            case Biome.Grass:
                NamePre = Grass_Prefixes[UnityEngine.Random.Range(0, Grass_Prefixes.Length)];
                Namesuff = Grass_Suffixes[UnityEngine.Random.Range(0, Grass_Suffixes.Length)];
                Cityname = NamePre + Namesuff;
                break;
            case Biome.EasternDesert:
                NamePre = Eastern_Desert_Prefixes[UnityEngine.Random.Range(0, Eastern_Desert_Prefixes.Length)];
                Namesuff = Eastern_Desert_Suffixes[UnityEngine.Random.Range(0, Eastern_Desert_Suffixes.Length)];
                Cityname = NamePre + Namesuff;
                break;
            case Biome.WesternDesert:
                NamePre = Western_Desert_Prefixes[UnityEngine.Random.Range(0, Western_Desert_Prefixes.Length)];
                Namesuff = Western_Desert_Suffixes[UnityEngine.Random.Range(0, Western_Desert_Suffixes.Length)];
                Cityname = NamePre + Namesuff; break;
            case Biome.Rainforest:
                NamePre = Rain_Forest_Prefixes[UnityEngine.Random.Range(0, Rain_Forest_Prefixes.Length)];
                Namesuff = Rain_Forest_Suffixes[UnityEngine.Random.Range(0, Rain_Forest_Suffixes.Length)];
                Cityname = NamePre + Namesuff; break;
            case Biome.EasternJungle:
                NamePre = Eastern_Jungle_Prefixes[UnityEngine.Random.Range(0, Eastern_Jungle_Prefixes.Length)];
                Namesuff = Eastern_Jungle_Suffixes[UnityEngine.Random.Range(0, Eastern_Jungle_Suffixes.Length)];
                Cityname = NamePre + Namesuff; break;
            case Biome.Arctic:
                NamePre = Arctic_Prefixes[UnityEngine.Random.Range(0, Arctic_Prefixes.Length)];
                Namesuff = Arctic_Suffixes[UnityEngine.Random.Range(0, Arctic_Suffixes.Length)];
                Cityname = NamePre + Namesuff; break;

        }
        return Cityname;

    }



    public Building Generate_Specific_School_Building(string SchoolName, List<Generated_Character> Teachers)
    {
        Building NewSchool = new Building(SchoolName);

        for (int j = 0; j < Teachers.Count; j++)
        {
            Room Class = new Room(Teachers[j].First_Name + "'s Class");
            NewSchool.AddRoom(Class);
        }
        Room Bathroom = new Room("Womens Bathroom");
        NewSchool.AddRoom(Bathroom);
        Room Bathroom2 = new Room("Mens Bathroom");
        NewSchool.AddRoom(Bathroom2);
        return NewSchool;
    }
    public Building Generate_Specific_House_Building(string CharacterName, List<Generated_Character> Occupants)
    {
        Building NewHouse = new Building(CharacterName + "'s House");
        Room MBedroom = new Room(CharacterName + "'s Bedroom");
        NewHouse.AddRoom(MBedroom);
        Room Bathroom = new Room("Bathroom");
        NewHouse.AddRoom(Bathroom);
        Room Livingroom = new Room("Livingroom");
        NewHouse.AddRoom(Livingroom);
        return NewHouse;
    }
    public Building Generate_Specific_Office_Building(string OfficeName)
    {
        Building NewOffice = new Building(OfficeName);
        Room cubicle01 = new Room("Cubicle Space 01");
        NewOffice.AddRoom(cubicle01);
        Room cubicle02 = new Room("Cubical space 02");
        NewOffice.AddRoom(cubicle02);
        Room cubicle03 = new Room("Cubical space 03");
        NewOffice.AddRoom(cubicle03);
        Room cubicle04 = new Room("Cubical space 04");
        NewOffice.AddRoom(cubicle04);
        Room Closet = new Room("Closet");
        NewOffice.AddRoom(Closet);
        for (int i = 0; i < 5; i++)
        {
            Room Office = new Room("Office");
            NewOffice.AddRoom(Office);
        }
        Room Bathroom = new Room("Bathroom");
        NewOffice.AddRoom(Bathroom);
        return NewOffice;
    }
    public Building Generate_Specific_Shop_Building(string ShopName)
    {
        Building NewShop = new Building(ShopName);
        Room Lobby = new Room("Lobby");
        NewShop.AddRoom(Lobby);
        Room Office = new Room("Office");
        NewShop.AddRoom(Office);
        Room Bathroom = new Room("Bathroom");
        NewShop.AddRoom(Bathroom);
        return NewShop;
    }
    public Building Generate_Specific_Tavern_Building(string TavernName)
    {
        Building NewShop = new Building(TavernName);
        Room Lobby = new Room("Lobby");
        NewShop.AddRoom(Lobby);
        Room Office = new Room("Back Office");
        NewShop.AddRoom(Office);
        Room Closet = new Room("Closet");
        NewShop.AddRoom(Closet);
        Room PrvtRoom1 = new Room("Private Room 1");
        NewShop.AddRoom(PrvtRoom1);
        Room PrvtRoom2 = new Room("Private Room 2");
        NewShop.AddRoom(PrvtRoom2);
        Room Bathroom = new Room("Bathroom");
        NewShop.AddRoom(Bathroom);
        return NewShop;
    }
    public Building GenerateNewGenericBuilding(string BuildingType)
    {
        Building NewBuilding = new Building("new");
        switch (BuildingType)
        {
            case "Tavern":
                NewBuilding.Name = "Bar";
                if (NewBuilding.Rooms.Count == 0)
                {
                    Room Lobby = new Room("Lobby");
                    NewBuilding.AddRoom(Lobby);
                    Room Office = new Room("Back Office");
                    NewBuilding.AddRoom(Office);
                    Room Closet = new Room("Closet");
                    NewBuilding.AddRoom(Closet);
                    Room PrvtRoom1 = new Room("Private Room 1");
                    NewBuilding.AddRoom(PrvtRoom1);
                    Room PrvtRoom2 = new Room("Private Room 2");
                    NewBuilding.AddRoom(PrvtRoom2);
                    Room Bathroom = new Room("Bathroom");
                    NewBuilding.AddRoom(Bathroom);
                }
                break;
            case "Apartment":
                NewBuilding.Name = "Apartment";
                if (NewBuilding.Rooms.Count == 0)
                {
                    Room Bedroom = new Room("Bedroom");
                    NewBuilding.AddRoom(Bedroom);
                    Room Bathroom = new Room("Bathroom");
                    NewBuilding.AddRoom(Bathroom);
                    Room Livingroom = new Room("Livingroom");
                    NewBuilding.AddRoom(Livingroom);
                }
                break;
            case "House":
                NewBuilding.Name = "House";
                if (NewBuilding.Rooms.Count == 0)
                {
                    Room Bedroom = new Room("Bedroom");
                    NewBuilding.AddRoom(Bedroom);
                    Room MBedroom = new Room("Master Bedroom");
                    NewBuilding.AddRoom(Bedroom);
                    Room Bathroom = new Room("Bathroom");
                    NewBuilding.AddRoom(Bathroom);
                    Room Livingroom = new Room("Livingroom");
                    NewBuilding.AddRoom(Livingroom);
                    Room Garage = new Room("Garage");
                    NewBuilding.AddRoom(Garage);
                }
                break;
            case "Office":
                NewBuilding.Name = "Office";
                if (NewBuilding.Rooms.Count == 0)
                {
                    Room cubicle01 = new Room("Cubicle Space");
                    NewBuilding.AddRoom(cubicle01);
                    Room cubicle02 = new Room("Cubical space");
                    NewBuilding.AddRoom(cubicle02);
                    Room Closet = new Room("Closet");
                    NewBuilding.AddRoom(Closet);
                    Room Office = new Room("Office");
                    NewBuilding.AddRoom(Office);
                    Room BreakRoom = new Room("Lunch Room");
                    NewBuilding.AddRoom(BreakRoom);
                    Room Bathroom = new Room("Bathroom");
                    NewBuilding.AddRoom(Bathroom);
                }
                break;
            case "Shop":
                NewBuilding.Name = "Shop";
                if (NewBuilding.Rooms.Count == 0)
                {
                    Room Lobby = new Room("Lobby");
                    NewBuilding.AddRoom(Lobby);
                    Room Office = new Room("Office");
                    NewBuilding.AddRoom(Office);
                    Room Closet = new Room("Closet");
                    NewBuilding.AddRoom(Closet);
                    Room BreakRoom = new Room("Break Room");
                    NewBuilding.AddRoom(BreakRoom);
                    Room Bathroom = new Room("Bathroom");
                    NewBuilding.AddRoom(Bathroom);
                }
                break;
        }
        return NewBuilding;
    }

   
    public void renderMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile selectedTile = DetermineTile(x, y);
                Map.SetTile(new Vector3Int(x + Mathf.FloorToInt(origin.x), y + Mathf.FloorToInt(origin.y), 0), selectedTile);
            }
        }
    }
    Tile DetermineTile(int x, int y)
    {


        if (biomeGrid[x, y] == 1 && map[x, y] == 1)
        {
            switch (currentActiveBiome)
            {
                case Biome.Forest: return fMountain;
                case Biome.Grass: return gMountain;
                case Biome.EasternDesert: return eMountain;
                case Biome.WesternDesert: return wMountain;
                case Biome.Rainforest: return rMountain;
                case Biome.EasternJungle: return jMountain;
                case Biome.Arctic: return aMountain;
                default: return gMountain;
            }
        }
        else if (biomeGrid[x, y] == 1 && map[x, y] == 0)
        {
            return ocean;
        }

        else if (biomeGrid[x, y] == 0 && map[x, y] == 1)
        {
            switch (currentActiveBiome)
            {
                case Biome.Forest: return forest;
                case Biome.Grass: return grass;
                case Biome.EasternDesert: return eastern;
                case Biome.WesternDesert: return western;
                case Biome.Rainforest: return rainforest;
                case Biome.EasternJungle: return jungle;
                case Biome.Arctic: return arctic;
                default: return grass;
            }
        }
        else if (biomeGrid[x, y] == 0 && map[x, y] == 0)
        {
            return ocean;
        }
        else if (biomeGrid[x, y] == 2 && map[x, y] == 1)
        {
            switch (currentActiveBiome)
            {
                case Biome.Forest: return fCave;
            case Biome.Grass: return gCave;
            case Biome.EasternDesert: return eCave;
            case Biome.WesternDesert: return wCave;
            case Biome.Rainforest: return rCave;
            case Biome.EasternJungle: return jCave;
            case Biome.Arctic: return aCave;
            default: return gCave;
            } 
        }
        else if (biomeGrid[x, y] == 3 && map[x, y] == 1)
        {
            switch (currentActiveBiome)
            {
                case Biome.Forest: return fCity;
                case Biome.Grass: return gCity;
                case Biome.EasternDesert: return eCity;
                case Biome.WesternDesert: return wCity;
                case Biome.Rainforest: return rCity;
                case Biome.EasternJungle: return jCity;
                case Biome.Arctic: return aCity;
                default: return gCity;
            }
        }
        else
        {
            return ocean;
        }
    }

 
}
[System.Serializable]
public class City
{
    public string cityName { get; set; }
    public Biome BiomeCulture { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public List<Location> Locations { get; set; }
    public City(string name)
    {
        Locations = new List<Location>();
        cityName = name;
    }

}
[System.Serializable]
public class Location
{
    public string Name { get; set; }
    public List<Building> Buildings { get; set; }
    public List<OutdoorSpot> OutdoorSpots { get; set; }

    public Location(string name)
    {
        Name = name;
        Buildings = new List<Building>();
        OutdoorSpots = new List<OutdoorSpot>();
    }

    public void AddBuilding(Building building)
    {
        Buildings.Add(building);
    }

    public void AddOutdoorSpot(OutdoorSpot outdoorSpot)
    {
        OutdoorSpots.Add(outdoorSpot);
    }
}
[System.Serializable]
public class Building
{
    public string Name { get; set; }
    public List<Room> Rooms { get; set; }
    public List<OutdoorSpot> OutdoorSpots { get; set; }
    public int currentNumberOfOccupants;
    public Building(string name)
    {
        Name = name;
        Rooms = new List<Room>();
        OutdoorSpots = new List<OutdoorSpot>();
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }
}
[System.Serializable]


public class Room
{
    public string Name { get; set; }
    public List<Generated_Character> Current_Occupants { get; set; }
    public Room(string name)
    {
        Name = name;
        Current_Occupants = new List<Generated_Character>();
    }
}


[System.Serializable]
public class OutdoorSpot
{
    public string Name { get; set; }
    public List<Generated_Character> Current_Occupants { get; set; }
    public OutdoorSpot(string name)
    {
        Current_Occupants = new List<Generated_Character>();
        Name = name;
    }
}
