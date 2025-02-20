using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Generated_Character
{
    public string First_Name;
    public string Last_Name;
    public string _description;
    public Character_Occupation occupation;
    public Sexual_Orientation orientation;
    public Relationship_Preference preference;
    public string Father, Mother;
    public CharacterType CharacterType;
    public Species species;
    public int Body_Type, Skin_Color,Gender;
    public List<PersonalityTrait> PersonalityTraits = new List<PersonalityTrait>();
    public List<Stat> Stats = new List<Stat>();
    [Range(0, 10)]
    public int relationLevel;
    public List<Organ> Organs = new List<Organ>();
}



