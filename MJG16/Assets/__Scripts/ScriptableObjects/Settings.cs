using System;
using System.Collections;
using System.Reflection;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "MJG16/Settings", order = 0)]
public class Settings : ScriptableObject
{
    [field: Header("Volume")]
    [field: SerializeField][field: Range(0.01f, 10)] public float MasterVolume { get; set; } = 0.3f;
}