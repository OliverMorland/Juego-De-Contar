using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public void ConfigureAnimalWithData(AnimalSO animalData)
    {
        spriteRenderer.sprite = animalData.sprite;
    }
}
