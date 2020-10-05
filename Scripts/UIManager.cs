using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider FatSlider;
    [SerializeField]
    private FatScript FS;
    [SerializeField]
    private TextMeshProUGUI FatText;
    int FoodLeft = 100;
    [SerializeField]
    private TextMeshProUGUI FoodCounter;

    private void Awake()
    {
        InvokeRepeating("UpdateFatValue", 0, 0.5f);
    }


    void UpdateFatValue()
    {
        FatSlider.value = FS.GetFatValue();
        FatText.text = "Fat Level: " + (FatSlider.value * 100).ToString("F0") + "%";
    }

    public void AteFood()
    {
        FoodLeft--;
        FoodCounter.text = FoodLeft + "/100 food left";
        if (FoodLeft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
