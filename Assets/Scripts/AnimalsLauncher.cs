using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsLauncher : MonoBehaviour
{
    [SerializeField] int maxAnimalsToSpawn = 5;
    [SerializeField] float x_spacing = 2f;
    [SerializeField] float y_spacing = 2f;
    [SerializeField] TMPro.TMP_Text countLabel;
    [SerializeField] List<GameObject> animalPrefabs;
    [SerializeField] Animal animalPrefab;
    [SerializeField] Transform animalsParent;
    [SerializeField] List<AnimalSO> animalsToChooseFrom;
    [SerializeField] List<GameObject> currentAnimals;

    public void SpawnRandomNumberOfAnimals()
    {
        ClearList();
        animalsParent.transform.localScale = new Vector3(0, 0, 0);
        countLabel.transform.localScale = new Vector3(0, 0, 0);
        int numberToSpawn = Random.Range(3, maxAnimalsToSpawn + 1);
        Debug.Log($"Spawning {numberToSpawn} animals...");
        SpawnAnimals(numberToSpawn);
        LeanTween.scale(animalsParent.gameObject, new Vector3(1,1,1), 1.5f).setEaseOutElastic();
    }

    void ClearList()
    {
        for (int i = currentAnimals.Count - 1; i >= 0; i--)
        {
            Destroy(currentAnimals[i]);
            currentAnimals.RemoveAt(i);
        }
    }

    void SpawnAnimals(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            AnimalSO animalData = GetRandomAnimalData();
            Animal newAnimal = Instantiate(animalPrefab, animalsParent);
            newAnimal.ConfigureAnimalWithData(animalData);
            currentAnimals.Add(newAnimal.gameObject);
            float xCoord = (float)i * x_spacing;
            float yCoord = (float)(i % 3) * y_spacing;
            newAnimal.transform.localPosition = new Vector3(xCoord, yCoord, 0);
        }
    }

    AnimalSO GetRandomAnimalData()
    {
        int randomIndex = Random.Range(0, animalsToChooseFrom.Count);
        return animalsToChooseFrom[randomIndex];
    }

    public void SetMaximumAnimalsTo(float maxAnimals)
    {
        maxAnimalsToSpawn = (int)maxAnimals;
    }

    public void ShowAnimalsCount()
    {
        countLabel.text = $"{currentAnimals.Count}";
        LeanTween.scale(countLabel.gameObject, new Vector3(1, 1, 1), 1.5f).setEaseOutElastic();
    }

    public void SetAnimalsToChooseFrom(List<AnimalSO> animals)
    {
        animalsToChooseFrom = animals;
    }
}
