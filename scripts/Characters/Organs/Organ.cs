using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public class Organ 
{
    public Organ_Type organType;
    public string organName;
    [Range(0, 10)]
    public int HealthStatus = 10;

    public Organ(Organ_Type Type)
    {
        
        this.organType = Type;
        organName = organType.ToString();
    }
}


[System.Serializable]
public enum Organ_Type
{
    none,Head,Skull,Brain,Eye,Mouth,Neck,Torso, Ribs, Spine, Heart, Spleen, Stomahch, pancreas, Liver, Kidney, Large_Intestine, Small_Intestine,
    Arm ,Leg ,Hand ,Foot ,Breast , Penis, Vagina, Butt , Anus, tail, horns, antlers, Processor, Hard_drive, Motor , Battery_Cell, Energy_Core,  Sensor_Array,
    Optical_Sensor, Infrared_Sensor, Lidar_Scanner, Circuit_Board, Cooling_System, Memory_Module, Antenna, Gyroscope,
    Hydraulic_Pump, Actuator, Servo_Motor, Manipulator_Arm, Wiring,
}