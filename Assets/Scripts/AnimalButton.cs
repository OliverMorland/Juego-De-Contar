using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimalButton : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image border;
    [SerializeField] bool isSelected = false;
    [SerializeField] Button button;
    Color selectedBorderColor = Color.yellow;
    Color unselectedBorderColor = Color.cyan;
    AnimalSO currentAnimalData;
    public UnityEvent onButtonClickedEvent;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        SetSelected(isSelected);
    }

    public void ConfigureButtonWithData(AnimalSO animalData)
    {
        image.sprite = animalData.sprite;
        gameObject.name = animalData.animalName;
        currentAnimalData = animalData;
    }

    public void ToggleSelected()
    {
        if (isSelected)
        {
            SetSelected(false);
        }
        else
        {
            SetSelected(true);
        }
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
        UpdateSelectedState(IsSelected);
    }

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }
    }

    void UpdateSelectedState(bool isSelected)
    {
        if (isSelected)
        {
            SetImageAlpha(1f);
            border.color = selectedBorderColor;
        }
        else
        {
            SetImageAlpha(0.5f);
            border.color = unselectedBorderColor;
        }
    }

    void SetImageAlpha(float alphaValue)
    {
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, alphaValue);
    }

    public AnimalSO GetCurrentAnimalData()
    {
        return currentAnimalData;
    }

    void OnButtonClicked()
    {
        if (onButtonClickedEvent != null)
        {
            onButtonClickedEvent.Invoke();
        }
    }

}
