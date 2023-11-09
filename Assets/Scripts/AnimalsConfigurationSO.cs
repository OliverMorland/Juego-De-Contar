using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animals Configuration", menuName = "ScriptableObjects/AnimalsConfiguration", order = 1)]
public class AnimalsConfigurationSO : ScriptableObject
{
    public List<AnimalSO> animalsList;

    public List<AnimalSO> GetAnimals()
    {
        return animalsList;
    }
}
