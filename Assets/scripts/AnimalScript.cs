using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void SetAnimal(AnimalData data)
    {
        spriteRenderer.sprite = data.sprite;
    }
}

