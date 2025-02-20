using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Chacater_Generation_Script : MonoBehaviour
{
    public List<Generated_Character> characters = new List<Generated_Character>();
    public List<PersonalityTrait> AvailableTraits;
    public List<Stat> Stats = new List<Stat>();
    public int Specific_Population_Typr = 10;
  
    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < ; i++) 
        //{
        //    Generated_Character NewTeacher = new Generated_Character();

        //    Species CharSpecies = (Species)UnityEngine.Random.Range(1, 9);
        //    NewTeacher = Generate_Specific_Character(Character_Occupation.Educator, CharacterType.Anthromorph, CharSpecies, 1);
        //    Debug.Log(NewTeacher.First_Name + " " + NewTeacher.Last_Name + ": " + NewTeacher.preference);

        //}
    }

    // Update is called once per frame
    public Generated_Character Generate_Random_Character(Biome Biome)
    {
       int RandRange = Random.Range(0, 2);
        Generated_Character character = new Generated_Character();
        if (RandRange == 0)
        {
            character = GenerateMaleCharacter();
        }
        else 
        {
            character = GenerateFemaleCharacter();
        }
        character.occupation = (Character_Occupation)Random.Range(0,9);
        foreach (var item in character.Stats)
        {
            item.Amount = Random.Range(0, 10);
        }
        foreach (var trait in character.PersonalityTraits)
        {
            trait.Amount = Random.Range(-10, 10);
        }
        character.CharacterType = (CharacterType)UnityEngine.Random.Range(0, 3);
        if (character.CharacterType == CharacterType.Human)
        {
            character.species = Species.Human;
        }
        if (character.CharacterType == CharacterType.Anthromorph)
        {
            if (Biome == Biome.Arctic) 
            {
                character.species = (Species)Random.Range(1, 5);
            }
            else
            character.species = (Species)Random.Range(1, 7);
        }
        if (character.CharacterType == CharacterType.Ai)
        {
            character.species = (Species)Random.Range(10, 13);
        }
        if (character.CharacterType == CharacterType.Human && character.Gender == 1)
        {
            Organ Head = new Organ(Organ_Type.Head);
            character.Organs.Add(Head);
            Organ Skull = new Organ(Organ_Type.Skull);
            character.Organs.Add(Head);
            Organ LeftEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Left Eye";
            character.Organs.Add(LeftEye);
            Organ RightEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Right Eye";
            character.Organs.Add(RightEye);

            for (int i = 5; i < 17; i++)
            {
                Organ_Type newtype = (Organ_Type)i;
                Organ Neworgan = new Organ(newtype);
                character.Organs.Add(Neworgan);
            }
            Organ LeftArm = new Organ(Organ_Type.Arm);
            LeftArm.organName = "Left Arm";
            character.Organs.Add(LeftArm);
            Organ RightArm = new Organ(Organ_Type.Arm);
            RightArm.organName = "Right Arm";
            character.Organs.Add(RightArm);
            Organ LeftHand = new Organ(Organ_Type.Hand);
            LeftHand.organName = "Left Hand";
            character.Organs.Add(LeftHand);
            Organ RightHand = new Organ(Organ_Type.Hand);
            RightHand.organName = "Right Hand";
            character.Organs.Add(RightHand);
            Organ LBreast = new Organ(Organ_Type.Breast);
            LBreast.organName = "Left Breast";
            character.Organs.Add(LBreast);
            Organ RBreast = new Organ(Organ_Type.Breast);
            RBreast.organName = "Right Breast";
            character.Organs.Add(RBreast);
            Organ vagina = new Organ(Organ_Type.Vagina);
            character.Organs.Add(vagina);
            Organ Butt = new Organ(Organ_Type.Butt);
            character.Organs.Add(Butt);
            Organ anus = new Organ(Organ_Type.Anus);
            character.Organs.Add(anus);
            Organ LeftLeg = new Organ(Organ_Type.Leg);
            LeftArm.organName = "Left Leg";
            character.Organs.Add(LeftLeg);
            Organ RightLeg = new Organ(Organ_Type.Leg);
            RightArm.organName = "Right Leg";
            character.Organs.Add(RightLeg);
            Organ LeftFoot = new Organ(Organ_Type.Foot);
            LeftFoot.organName = "Left Foot";
            character.Organs.Add(LeftFoot);
            Organ RightFoot = new Organ(Organ_Type.Foot);
            RightFoot.organName = "Right Foot";
            character.Organs.Add(RightFoot);

        }

        if (character.CharacterType == CharacterType.Human && character.Gender == 0)
        {
            Organ Head = new Organ(Organ_Type.Head);
            character.Organs.Add(Head);
            Organ Skull = new Organ(Organ_Type.Skull);
            character.Organs.Add(Head);
            Organ LeftEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Left Eye";
            character.Organs.Add(LeftEye);
            Organ RightEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Right Eye";
            character.Organs.Add(RightEye);

            for (int i = 5; i < 17; i++)
            {
                Organ_Type newtype = (Organ_Type)i;
                Organ Neworgan = new Organ(newtype);
                character.Organs.Add(Neworgan);
            }
            Organ LeftArm = new Organ(Organ_Type.Arm);
            LeftArm.organName = "Left Arm";
            character.Organs.Add(LeftArm);
            Organ RightArm = new Organ(Organ_Type.Arm);
            RightArm.organName = "Right Arm";
            character.Organs.Add(RightArm);
            Organ LeftHand = new Organ(Organ_Type.Hand);
            LeftHand.organName = "Left Hand";
            character.Organs.Add(LeftHand);
            Organ RightHand = new Organ(Organ_Type.Hand);
            RightHand.organName = "Right Hand";
            character.Organs.Add(RightHand);
            Organ Penis = new Organ(Organ_Type.Penis);
            character.Organs.Add(Penis);
            Organ Butt = new Organ(Organ_Type.Butt);
            character.Organs.Add(Butt);
            Organ anus = new Organ(Organ_Type.Anus);
            character.Organs.Add(anus);
            Organ LeftLeg = new Organ(Organ_Type.Leg);
            LeftArm.organName = "Left Leg";
            character.Organs.Add(LeftLeg);
            Organ RightLeg = new Organ(Organ_Type.Leg);
            RightArm.organName = "Right Leg";
            character.Organs.Add(RightLeg);
            Organ LeftFoot = new Organ(Organ_Type.Foot);
            LeftFoot.organName = "Left Foot";
            character.Organs.Add(LeftFoot);
            Organ RightFoot = new Organ(Organ_Type.Foot);
            RightFoot.organName = "Right Foot";
            character.Organs.Add(RightFoot);

        }
        if (character.CharacterType == CharacterType.Anthromorph && character.Gender == 0)
        {
            Organ Head = new Organ(Organ_Type.Head);
            character.Organs.Add(Head);
            Organ Skull = new Organ(Organ_Type.Skull);
            character.Organs.Add(Head);
            Organ LeftEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Left Eye";
            character.Organs.Add(LeftEye);
            Organ RightEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Right Eye";
            character.Organs.Add(RightEye);

            for (int i = 5; i < 17; i++)
            {
                Organ_Type newtype = (Organ_Type)i;
                Organ Neworgan = new Organ(newtype);
                character.Organs.Add(Neworgan);
            }
            Organ LeftArm = new Organ(Organ_Type.Arm);
            LeftArm.organName = "Left Arm";
            character.Organs.Add(LeftArm);
            Organ RightArm = new Organ(Organ_Type.Arm);
            RightArm.organName = "Right Arm";
            character.Organs.Add(RightArm);
            Organ LeftHand = new Organ(Organ_Type.Hand);
            LeftHand.organName = "Left Hand";
            character.Organs.Add(LeftHand);
            Organ RightHand = new Organ(Organ_Type.Hand);
            RightHand.organName = "Right Hand";
            character.Organs.Add(RightHand);
            Organ Penis = new Organ(Organ_Type.Penis);
            character.Organs.Add(Penis);
            Organ Butt = new Organ(Organ_Type.Butt);
            character.Organs.Add(Butt);
            Organ anus = new Organ(Organ_Type.Anus);
            character.Organs.Add(anus);
            Organ Tail = new Organ(Organ_Type.tail);
            character.Organs.Add(Tail);
            Organ LeftLeg = new Organ(Organ_Type.Leg);
            LeftArm.organName = "Left Leg";
            character.Organs.Add(LeftLeg);
            Organ RightLeg = new Organ(Organ_Type.Leg);
            RightArm.organName = "Right Leg";
            character.Organs.Add(RightLeg);
            Organ LeftFoot = new Organ(Organ_Type.Foot);
            LeftFoot.organName = "Left Foot";
            character.Organs.Add(LeftFoot);
            Organ RightFoot = new Organ(Organ_Type.Foot);
            RightFoot.organName = "Right Foot";
            character.Organs.Add(RightFoot);

        }
        if (character.CharacterType == CharacterType.Anthromorph &&  character.Gender == 1)
        {
            Organ Head = new Organ(Organ_Type.Head);
            character.Organs.Add(Head);
            Organ Skull = new Organ(Organ_Type.Skull);
            character.Organs.Add(Skull);
            Organ LeftEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Left Eye";
            character.Organs.Add(LeftEye);
            Organ RightEye = new Organ(Organ_Type.Eye);
            LeftEye.organName = "Right Eye";
            character.Organs.Add(RightEye);

            for (int i = 5; i < 17; i++)
            {
                Organ_Type newtype = (Organ_Type)i;
                Organ Neworgan = new Organ(newtype);
                character.Organs.Add(Neworgan);
            }
            Organ LeftArm = new Organ(Organ_Type.Arm);
            LeftArm.organName = "Left Arm";
            character.Organs.Add(LeftArm);
            Organ RightArm = new Organ(Organ_Type.Arm);
            RightArm.organName = "Right Arm";
            character.Organs.Add(RightArm);
            Organ LeftHand = new Organ(Organ_Type.Hand);
            LeftHand.organName = "Left Hand";
            character.Organs.Add(LeftHand);
            Organ RightHand = new Organ(Organ_Type.Hand);
            RightHand.organName = "Right Hand";
            character.Organs.Add(RightHand);
            Organ LBreast = new Organ(Organ_Type.Breast);
            LBreast.organName = "Left Breast";
            character.Organs.Add(LBreast);
            Organ RBreast = new Organ(Organ_Type.Breast);
            RBreast.organName = "Right Breast";
            character.Organs.Add(RBreast);
            Organ vagina = new Organ(Organ_Type.Vagina);
            character.Organs.Add(vagina);
            Organ Butt = new Organ(Organ_Type.Butt);
            Organ Tail = new Organ(Organ_Type.tail);
            character.Organs.Add(Tail);
            character.Organs.Add(Butt);
            Organ anus = new Organ(Organ_Type.Anus);
            character.Organs.Add(anus);
            Organ LeftLeg = new Organ(Organ_Type.Leg);
            LeftArm.organName = "Left Leg";
            character.Organs.Add(LeftLeg);
            Organ RightLeg = new Organ(Organ_Type.Leg);
            RightArm.organName = "Right Leg";
            character.Organs.Add(RightLeg);
            Organ LeftFoot = new Organ(Organ_Type.Foot);
            LeftFoot.organName = "Left Foot";
            character.Organs.Add(LeftFoot);
            Organ RightFoot = new Organ(Organ_Type.Foot);
            RightFoot.organName = "Right Foot";
            character.Organs.Add(RightFoot);
        }
        if(character.CharacterType == CharacterType.Ai)
        {
            for (int i = 30; i < 48; i++)
            {
                Organ_Type newtype = (Organ_Type)i;
                Organ Neworgan = new Organ(newtype);
                character.Organs.Add(Neworgan);
            }
        }
        return character;
    }
    public Generated_Character Generate_Specific_Character(Character_Occupation occupation,CharacterType type, Species species,int gender)
    {
        
        Generated_Character character = new Generated_Character();
     
        if (gender == 0)
        {
            character = GenerateMaleCharacter();
            if (type == CharacterType.Human)
            {
                Organ Head = new Organ(Organ_Type.Head);
                character.Organs.Add(Head);
                Organ Skull = new Organ(Organ_Type.Skull);
                character.Organs.Add(Skull);
                Organ LeftEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Left Eye";
                character.Organs.Add(LeftEye);
                Organ RightEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Right Eye";
                character.Organs.Add(RightEye);

                for (int i = 5; i < 17; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);
                }
                Organ LeftArm = new Organ(Organ_Type.Arm);
                LeftArm.organName = "Left Arm";
                character.Organs.Add(LeftArm);
                Organ RightArm = new Organ(Organ_Type.Arm);
                RightArm.organName = "Right Arm";
                character.Organs.Add(RightArm);
                Organ LeftHand = new Organ(Organ_Type.Hand);
                LeftHand.organName = "Left Hand";
                character.Organs.Add(LeftHand);
                Organ RightHand = new Organ(Organ_Type.Hand);
                RightHand.organName = "Right Hand";
                character.Organs.Add(RightHand);
                Organ Penis = new Organ(Organ_Type.Penis);
                character.Organs.Add(Penis);
                Organ Butt = new Organ(Organ_Type.Butt);
                character.Organs.Add(Butt);
                Organ anus = new Organ(Organ_Type.Anus);
                character.Organs.Add(anus);
                Organ LeftLeg = new Organ(Organ_Type.Leg);
                LeftArm.organName = "Left Leg";
                character.Organs.Add(LeftLeg);
                Organ RightLeg = new Organ(Organ_Type.Leg);
                RightArm.organName = "Right Leg";
                character.Organs.Add(RightLeg);
                Organ LeftFoot = new Organ(Organ_Type.Foot);
                LeftFoot.organName = "Left Foot";
                character.Organs.Add(LeftFoot);
                Organ RightFoot = new Organ(Organ_Type.Foot);
                RightFoot.organName = "Right Foot";
                character.Organs.Add(RightFoot);
            }
            if (type == CharacterType.Anthromorph)
            {
                Organ Head = new Organ(Organ_Type.Head);
                character.Organs.Add(Head);
                Organ Skull = new Organ(Organ_Type.Skull);
                character.Organs.Add(Head);
                Organ LeftEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Left Eye";
                character.Organs.Add(LeftEye);
                Organ RightEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Right Eye";
                character.Organs.Add(RightEye);

                for (int i = 5; i < 17; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);
                }
                Organ LeftArm = new Organ(Organ_Type.Arm);
                LeftArm.organName = "Left Arm";
                character.Organs.Add(LeftArm);
                Organ RightArm = new Organ(Organ_Type.Arm);
                RightArm.organName = "Right Arm";
                character.Organs.Add(RightArm);
                Organ LeftHand = new Organ(Organ_Type.Hand);
                LeftHand.organName = "Left Hand";
                character.Organs.Add(LeftHand);
                Organ RightHand = new Organ(Organ_Type.Hand);
                RightHand.organName = "Right Hand";
                character.Organs.Add(RightHand);
                Organ Penis = new Organ(Organ_Type.Penis);
                character.Organs.Add(Penis);

                Organ Butt = new Organ(Organ_Type.Butt);
                character.Organs.Add(Butt);
                Organ Tail = new Organ(Organ_Type.tail);
                character.Organs.Add(Tail);
                Organ anus = new Organ(Organ_Type.Anus);
                character.Organs.Add(anus);
                Organ LeftLeg = new Organ(Organ_Type.Leg);
                LeftArm.organName = "Left Leg";
                character.Organs.Add(LeftLeg);
                Organ RightLeg = new Organ(Organ_Type.Leg);
                RightArm.organName = "Right Leg";
                character.Organs.Add(RightLeg);
                Organ LeftFoot = new Organ(Organ_Type.Foot);
                LeftFoot.organName = "Left Foot";
                character.Organs.Add(LeftFoot);
                Organ RightFoot = new Organ(Organ_Type.Foot);
                RightFoot.organName = "Right Foot";
                character.Organs.Add(RightFoot);
            }
            if (type == CharacterType.Ai)
            {
                for (int i = 30; i < 48; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);
                }
            }
        }
        else
        {
            character = GenerateFemaleCharacter();
            if (type == CharacterType.Human)
            {
                Organ Head = new Organ(Organ_Type.Head);
                character.Organs.Add(Head);
                Organ Skull = new Organ(Organ_Type.Skull);
                character.Organs.Add(Skull);
                Organ LeftEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Left Eye";
                character.Organs.Add(LeftEye);
                Organ RightEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Right Eye";
                character.Organs.Add(RightEye);

                for (int i = 5; i < 17; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);
                }
                Organ LeftArm = new Organ(Organ_Type.Arm);
                LeftArm.organName = "Left Arm";
                character.Organs.Add(LeftArm);
                Organ RightArm = new Organ(Organ_Type.Arm);
                RightArm.organName = "Right Arm";
                character.Organs.Add(RightArm);
                Organ LeftHand = new Organ(Organ_Type.Hand);
                LeftHand.organName = "Left Hand";
                character.Organs.Add(LeftHand);
                Organ RightHand = new Organ(Organ_Type.Hand);
                RightHand.organName = "Right Hand";
                character.Organs.Add(RightHand);
                Organ LBreast = new Organ(Organ_Type.Breast);
                LBreast.organName = "Left Breast";
                character.Organs.Add(LBreast);
                Organ RBreast = new Organ(Organ_Type.Breast);
                RBreast.organName = "Right Breast";
                character.Organs.Add(RBreast);
                Organ vagina = new Organ(Organ_Type.Vagina);
                character.Organs.Add(vagina);
                Organ Butt = new Organ(Organ_Type.Butt);
                character.Organs.Add(Butt);
                Organ anus = new Organ(Organ_Type.Anus);
                character.Organs.Add(anus);
                Organ LeftLeg = new Organ(Organ_Type.Leg);
                LeftArm.organName = "Left Leg";
                character.Organs.Add(LeftLeg);
                Organ RightLeg = new Organ(Organ_Type.Leg);
                RightArm.organName = "Right Leg";
                character.Organs.Add(RightLeg);
                Organ LeftFoot = new Organ(Organ_Type.Foot);
                LeftFoot.organName = "Left Foot";
                character.Organs.Add(LeftFoot);
                Organ RightFoot = new Organ(Organ_Type.Foot);
                RightFoot.organName = "Right Foot";
                character.Organs.Add(RightFoot);

            }
            if (type == CharacterType.Anthromorph)
            {
                Organ Head = new Organ(Organ_Type.Head);
                character.Organs.Add(Head);
                Organ Skull = new Organ(Organ_Type.Skull);
                character.Organs.Add(Skull);
                Organ LeftEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Left Eye";
                character.Organs.Add(LeftEye);
                Organ RightEye = new Organ(Organ_Type.Eye);
                LeftEye.organName = "Right Eye";
                character.Organs.Add(RightEye);

                for (int i = 5; i < 17; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);

                }
                Organ LeftArm = new Organ(Organ_Type.Arm);
                LeftArm.organName = "Left Arm";
                character.Organs.Add(LeftArm);
                Organ RightArm = new Organ(Organ_Type.Arm);
                RightArm.organName = "Right Arm";
                character.Organs.Add(RightArm);
                Organ LeftHand = new Organ(Organ_Type.Hand);
                LeftHand.organName = "Left Hand";
                character.Organs.Add(LeftHand);
                Organ RightHand = new Organ(Organ_Type.Hand);
                RightHand.organName = "Right Hand";
                character.Organs.Add(RightHand);
                Organ LBreast = new Organ(Organ_Type.Breast);
                LBreast.organName = "Left Breast";
                character.Organs.Add(LBreast);
                Organ RBreast = new Organ(Organ_Type.Breast);
                RBreast.organName = "Right Breast";
                character.Organs.Add(RBreast);
                Organ vagina = new Organ(Organ_Type.Vagina);
                character.Organs.Add(vagina);
                Organ Butt = new Organ(Organ_Type.Butt);
                Butt.organName = "Butt";
                Organ Tail = new Organ(Organ_Type.tail);
                Tail.organName = "Tail";
                character.Organs.Add(Tail);

                character.Organs.Add(Butt);
                Organ anus = new Organ(Organ_Type.Anus);
                character.Organs.Add(anus);
                Organ LeftLeg = new Organ(Organ_Type.Leg);
                LeftArm.organName = "Left Leg";
                character.Organs.Add(LeftLeg);
                Organ RightLeg = new Organ(Organ_Type.Leg);
                RightArm.organName = "Right Leg";
                character.Organs.Add(RightLeg);
                Organ LeftFoot = new Organ(Organ_Type.Foot);
                LeftFoot.organName = "Left Foot";
                character.Organs.Add(LeftFoot);
                Organ RightFoot = new Organ(Organ_Type.Foot);
                RightFoot.organName = "Right Foot";
                character.Organs.Add(RightFoot);

            }
            if (type == CharacterType.Ai)
            {
                for (int i = 30; i < 48; i++)
                {
                    Organ_Type newtype = (Organ_Type)i;
                    Organ Neworgan = new Organ(newtype);
                    character.Organs.Add(Neworgan);
                }
            }

        }
        character.CharacterType = type;
        character.species = species;
        character.occupation = occupation;
        
        characters.Add(character);
        return character;
    }
    public Generated_Character GenerateFemaleCharacter()
    {
        string newName = new string("");
        Generated_Character character = new Generated_Character();

  

    
        newName = GenerateNewName(1);
        character.Gender = 1;
        string[] splitName = newName.Split(' ');
        character.First_Name = splitName[0];
        character.Last_Name = splitName[1];
        string fname = GenerateNewName(0);
        string[] fsplit = fname.Split(" ");
        fname = fsplit[0] + " " + splitName[1];
        character.Father = fname;
        string mname = GenerateNewName(1);
        string[] msplit = mname.Split(" ");
        mname = msplit[0] + " " + splitName[1];
        character.Mother = mname;
        character.orientation = (Sexual_Orientation)UnityEngine.Random.Range(0, 3);
        character.preference = Relationship_Preference.polyamorous;
        character.Stats = Stats;
        character.PersonalityTraits = AvailableTraits;

        return character;
    }
    public Generated_Character GenerateMaleCharacter()
    {

        string newName = new string("");
        Generated_Character character = new Generated_Character();
        int newGen = Random.Range(0, 2);
        if (newGen == 0)
        {
            newName = GenerateNewName(newGen);
            character.Gender = 0;
        }
        else
        {
            newName = GenerateNewName(newGen);
            character.Gender = 1;
        }
        string[] splitName = newName.Split(' ');
        character.First_Name = splitName[0];
        character.Last_Name = splitName[1];
        string fname = GenerateNewName(0);
        string[] fsplit = fname.Split(" ");
        fname = fsplit[0] + " " + splitName[1];
        character.Father = fname;
        string mname = GenerateNewName(1);
        string[] msplit = mname.Split(" ");
        mname = msplit[0] + " " + splitName[1];
        character.Mother = mname;
        character.orientation = (Sexual_Orientation)UnityEngine.Random.Range(0, 3);
        character.preference = Relationship_Preference.polyamorous;
        character.Stats = Stats;
        character.PersonalityTraits = AvailableTraits;

        return character;
    }

    public string GenerateNewName(int MOrF)
    {
        string newName = new string("");

        if (MOrF == 0)
        {
            MaleNameDictionary nameDictionary = (MaleNameDictionary)Random.Range(0, 100);
            LastNameDictionary lastnameDictionary = (LastNameDictionary)Random.Range(0, 100);
            newName = nameDictionary + " " + lastnameDictionary;


        }
        else
        {
            FemaleNameDictionary nameDictionary = (FemaleNameDictionary)Random.Range(0, 100);
            LastNameDictionary lastnameDictionary = (LastNameDictionary)Random.Range(0, 100);
            newName = nameDictionary + " " + lastnameDictionary;
        }
        return newName;
    }
}
[System.Serializable]
public class PersonalityTrait
{
    public string name;
    public string description;
    [Range(-10, 10)]
    public int Amount;
}
[System.Serializable]
public class Stat
{
    public string name;
    public string description;
    [Range(0, 10)]
    public int Amount;
}



