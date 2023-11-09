using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Animal", order = 1)]
public class AnimalSO : ScriptableObject
{
    public Sprite sprite;
    public string animalName;

}
