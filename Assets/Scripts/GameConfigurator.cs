using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigurator : MonoBehaviour
{
    [SerializeField] AnimalsConfigurationSO animalsConfiguration;
    [SerializeField] AnimalButton animalButtonPrefab;
    [SerializeField] Transform animalButtonsParent;
    [SerializeField] List<AnimalButton> animalButtons = new List<AnimalButton>();
    [SerializeField] List<AnimalSO> selectedAnimals = new List<AnimalSO>();
    [SerializeField] AnimalsLauncher animalsLauncher;

    // Start is called before the first frame update
    void Start()
    {
        CreateButtons();
        RegisterOnAnimalSelectedUpdate();
        SelectFirstAnimalButton();
    }

    void SelectFirstAnimalButton()
    {
        if (animalButtons.Count > 0)
        {
            animalButtons[0].SetSelected(true);
            UpdateSelectedAnimals();
        }
    }

    void CreateButtons()
    {
        animalButtons.Clear();
        foreach (AnimalSO animal in animalsConfiguration.animalsList)
        {
            CreateButtonFromData(animal);
        }
    }

    void CreateButtonFromData(AnimalSO animalData)
    {
        AnimalButton newButton = Instantiate(animalButtonPrefab, animalButtonsParent);
        newButton.ConfigureButtonWithData(animalData);
        animalButtons.Add(newButton);
    }

    void RegisterOnAnimalSelectedUpdate()
    {
        foreach (var button in animalButtons)
        {
            button.onButtonClickedEvent.AddListener(UpdateSelectedAnimals);
        }
    }

    void UpdateSelectedAnimals()
    {
        selectedAnimals.Clear();
        foreach (var button in animalButtons)
        {
            if (button.IsSelected)
            {
                AnimalSO animalData = button.GetCurrentAnimalData();
                selectedAnimals.Add(animalData);
                animalsLauncher.SetAnimalsToChooseFrom(selectedAnimals);
            }
        }
    }

}
