using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsLauncher : MonoBehaviour
{
    [SerializeField] int maxAnimalsToSpawn = 5;
    [SerializeField] float x_spacing = 2f;
    [SerializeField] float y_spacing = 2f;
    [SerializeField] float radius = 3f;
    [SerializeField] Animal animalPrefab;
    [SerializeField] Transform animalsParent;
    [SerializeField] List<AnimalSO> animalsToChooseFrom;
    [SerializeField] List<GameObject> currentAnimals;

    public void SpawnRandomNumberOfAnimals()
    {
        ClearList();
        animalsParent.transform.localScale = new Vector3(0, 0, 0);
        int numberToSpawn = Random.Range(3, maxAnimalsToSpawn + 1);
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
            if (animalData != null)
            {
                Animal newAnimal = Instantiate(animalPrefab, animalsParent);
                newAnimal.ConfigureAnimalWithData(animalData);
                currentAnimals.Add(newAnimal.gameObject);
                float xCoord = (float)i * x_spacing;
                float yCoord = (float)(i % 3) * y_spacing;
                //newAnimal.transform.localPosition = new Vector3(xCoord, yCoord, 0);

                float anglePerAnimal = (2f * Mathf.PI) / numberToSpawn;
                float angle = anglePerAnimal * i;
                float x_pos = radius * Mathf.Cos(angle);
                float y_pos = radius * Mathf.Sin(angle);
                Vector3 dir = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0).normalized;
                Vector3 pos = dir * radius;
                newAnimal.transform.localPosition = pos;

            }
        }
    }

    AnimalSO GetRandomAnimalData()
    {
        if (animalsToChooseFrom.Count > 0)
        {
            int randomIndex = Random.Range(0, animalsToChooseFrom.Count);
            return animalsToChooseFrom[randomIndex];
        }
        else
        {
            return null;
        }
    }

    public void SetMaximumAnimalsTo(float maxAnimals)
    {
        maxAnimalsToSpawn = (int)maxAnimals;
    }

    public void ShowAnimalsCount()
    {
        //Do something
    }

    public void SetAnimalsToChooseFrom(List<AnimalSO> animals)
    {
        animalsToChooseFrom = animals;
    }
}
