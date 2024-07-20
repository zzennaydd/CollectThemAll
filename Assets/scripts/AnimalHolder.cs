using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalHolder : MonoBehaviour
{
    public AnimalScript animal;
    public AnimalData defaultAnimalData;

    
    protected virtual void Start()
    {
        animal.SetAnimal(defaultAnimalData);
    }
}
