using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class scrptable_interaction : ScriptableObject
{
    public string Interaction, Response;
    public Interaction_Type Interaction_Type;
    public Emotion Em_Type;
    public Relationship_Level Required_Relationship;
    public Sprite img;
}
