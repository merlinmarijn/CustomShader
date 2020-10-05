using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatScript : MonoBehaviour
{
    public Material FatShader;
    public UIManager UIM;

    private void Start()
    {
        SetFatValue(0f);
        InvokeRepeating("LoseFat",10,5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            if (FatShader != null)
            {
                AddFatValue(0.1f);
            }
        }
    }

    IEnumerator LoseFat()
    {
        AddFatValue(-0.05f);
        return null;
    }

    public void AddFatValue(float Value)
    {
        if (GetFatValue() + Value <= 1)
        {
            FatShader.SetFloat("_Fat", FatShader.GetFloat("_Fat") + Value);
        }
        else
        {
            SetFatValue(1);
        }
    }

    public void SetFatValue(float Value)
    {
        FatShader.SetFloat("_Fat", Value);
    }

    public float GetFatValue()
    {
        return FatShader.GetFloat("_Fat");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED TRIGGER");
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            AddFatValue(0.1f);
            UIM.AteFood();
        }
    }
}
