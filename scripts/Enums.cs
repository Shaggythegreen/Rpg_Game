


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum Emotion
{
    neutral, sad, happy, angry, horny
}


[System.Serializable]

public enum Interaction_Type
{
    Dialogue, Action, Event
}


[System.Serializable]

public enum Relationship_Level
{
    stranger, unfamiliar, familiar, acquaintanceship, friendship, love
}
[System.Serializable]

public enum Dialogue_Type
{
    GenericIntroduction
}

[System.Serializable]

public enum Sexual_Orientation
{
    straight, bisexual, gay, pansexual
}
[System.Serializable]

public enum Relationship_Preference
{
    monogamous, polyamorous
}
[System.Serializable]
public enum MaleNameDictionary
{
    Uther,
    Ulric,
    Asose,
    Suembos,
    Anvonl,
    Thuve,
    Ziu,
    Brebridd,
    Muldidran,
    Shie,
    Vohpi,
    Greldun,
    Stokvan,
    Hengedd,
    Liam,
    Hiroshi,
    Oskar,
    Omar,
    Jose,
    Ahmed,
    Kael,
    Fenris,
    Vladimir,
    Noah,
    Arjun,
    Carlos,
    Youssef,
    Sven,
    Alessandro,
    Chang,
    Dravn,
    David,
    Hank,
    Manuel,
    Mikael,
    Leandro,
    Andrei,
    Sean,
    Tenilbis,
    Khuhlem,
    Stoic,
    Eryndor,
    Orvest,
    Eichorst,
    Tolhurst,
    Savioth,
    Thihpi,
    Pizim,
    Merded,
    Sahmar,
    Krudovf,
    Hihmum,
    Krihmdorf,
    Ilba,
    Xaiver,
    Robert,
    Jetson,
    Astro,
    Orion,
    Zedrick,
    Cosmo,
    Vinton,
    Radon,
    Dexal,
    Neon,
    Luxor,
    River,
    Pheonix,
    Ocean,
    Aric,
    Cedar,
    Forest,
    Sage,
    Zen,
    Harmony,
    Jasper,
    Murdock,
    Thalion,
    Kylar,
    Zorin,
    Drex,
    Sylis,
    Tarek,
    Lorx,
    Niven,
    Jorek,
    Thernon,
    PHillesus,
    Cormac,
    Merced,
    Xander,
    Quinto,
    Zephyr,
    Vortan,
    Cyran,
    Zynox,
    Vodien,
    Arction,
    Nexar,
    Rydez,
    Ritter
}
[System.Serializable]
public enum FemaleNameDictionary
{
    Eiola,
    Irara,
    Nal,
    Tsei,
    Liliv,
    Surremza,
    Lai,
    Inna,
    Thevru,
    Emmildruth,
    Setm,
    Hirma,
    Amundas,
    Pui,
    Betham,
    Fondra,
    Nehzire,
    Cehnilith,
    Zihmilla,
    Ainve,
    Hieml,
    Ezeralda,
    Grimeru,
    Elda,
    Ravorihn,
    Suaann,
    Yomila,
    Wanda,
    Leila,
    Emma,
    Aisha,
    Mei,
    Sofia,
    Maria,
    Akiko,
    Fatima,
    Olivia,
    Isabella,
    Yasmin,
    Elena,
    Hanna,
    Ananya,
    Beatriz,
    Chloé,
    Noor,
    Zhen,
    Freya,
    Valentina,
    Amara,
    Zia,
    Asha,
    Lyra,
    Cyra,
    Zynith,
    Noria,
    Elara,
    Rynix,
    Valora,
    Nyx,
    Quorra,
    Alexias,
    Luna,
    Meadow,
    Summer,
    Willow,
    Daisy,
    Aurora,
    Skye,
    Poppy,
    Serenity,
    Love,
    Faelora,
    Elethia,
    Zeliana,
    Seraphine,
    Aeliana,
    Sylwen,
    Sollowen,
    Thalina,
    Muriel,
    Isphodel,
    Voliana,
    Lysara,
    Nylia,
    Kyra,
    Cyrce,
    Aria,
    Zyla,
    Viroa,
    Rynara,
    Zeline,
    Nova,
    Vega,
    Dromida,
    Astra,
    Celest,
    Zenith,
    Matrix,
    Lumina,
    Electra,
    Solaria
}

[System.Serializable]
public enum LastNameDictionary
{
    Rokhon,
    Darkwind,
    Mournaxe,
    Shiradz,
    Bloodheart,
    Chestcleaver,
    Larheon,
    Saldruekt,
    Vrurgabuki,
    Churivzu,
    Miscesqun,
    Azesqe,
    AshQur,
    Nossiur,
    Twotrack,
    Sacredrock,
    Hill,
    Sevng,
    Burningtree,
    Branth,
    Morningshot,
    Myadzarki,
    Qao,
    Pocander,
    Bhinni,
    Ashfall,
    Zhoa,
    Smith,
    Kim,
    Garcia,
    Muller,
    Singh,
    Nguyen,
    Johnson,
    Wong,
    Ivanov,
    Brown,
    Silva,
    OConnor,
    Hassan,
    Yamamoto,
    Lopez,
    Kovae,
    Patel,
    Haddad,
    Baker,
    Meier,
    Wanderlust,
    Steadground,
    Evertt,
    Curtis,
    Duskrot,
    Shadowbane,
    Ravenshadow,
    Stormrider,
    Nightwhisper,
    Moonstrike,
    Thornweaver,
    Emberglow,
    Frostbane,
    Starfall,
    Dragonheart,
    Ironthorn,
    Silverfang,
    Darkmoor,
    Brightflame,
    Whisperwind,
    Oakenshield,
    Duskraven,
    Firesong,
    Wildbrook,
    Moonflower,
    Starshine,
    Sunbeam,
    Willowbrook,
    Skywalker,
    Peacefield,
    Blossom,
    Riverstone,
    Freeheart,
    Mechas,
    Zerath,
    Quarix,
    Vortan,
    Xephar,
    Krynn,
    Nylos,
    Trexar,
    Zorak,
    Sylor,
    Draxen,
    Numias,
    Trallows,
    Evans,
    Alritch,
    Womack,
    Thomlis,
    Poole,
    Thetas,
    Turner,
    Zecks

}

[System.Serializable]
public enum CharacterType
{
    Human,Anthromorph,Ai
}


[System.Serializable]
public enum location_Type
{
    House, Apartment, Resturaunt, Arcade, Beach, Desert, Forest, Arctic, Lake, Farm, Corridor, Market
}

[System.Serializable]

public enum ActionEventType
{
    consumeFood, ConsumeLiquid, Work, Sleep, PlayGame, Gamble, CookFood, PlaceOrder, ExamineRoom
}

[System.Serializable]
public enum Corporation_Type
{
    Energy, Spacecraft, Defense, Mining, Agriculture, Transportaion
}
[System.Serializable]
public enum Character_Occupation
{
    None,Engineer,Educator,Weponeer,Captain,Cook,Farmer,Student,FleshSmith,Escort,Miner
}

[System.Serializable]
public enum Species
{
    Human,Bear,Cat,Dog,Bird,Elephant,Lizard,Cow,Computer,Robot,Android,BrainVat
}

[System.Serializable]
public enum Nation_Size
{
    Micro,small,Medium,Large,Gigantic
}

[System.Serializable]
public enum Biome
{
    Forest, Grass, EasternDesert, WesternDesert, Rainforest, EasternJungle, Arctic
}

public enum Composition
{
    Organic,Inorganic
}
public enum Dice
{
     D4,D6, D8,D10,D12,D20
}
