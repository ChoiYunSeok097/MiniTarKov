using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ItemBasic : ScriptableObject
{
    public int ID;
    public string Name;
    public int Count;
    public Sprite sprite;
}

