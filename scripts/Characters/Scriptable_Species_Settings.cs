using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Scriptable_Species_Settings : ScriptableObject
{
    public Species species;
    public int NumberOfSkinColors,NumberOfBodyTypes, NumberOfGenders;
    public List<SpeciesPicture> BaseCharacterPictureList;
}
[System.Serializable]
public struct SpeciesPicture
{
    public Sprite Image;
    public int Gender, SkinColor, BodyType;
}