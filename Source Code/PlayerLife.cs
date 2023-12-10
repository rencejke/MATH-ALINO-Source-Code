using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private List<Image> playerLife;
    [SerializeField] private Color lifeColor;

    public int lifeLeft = 3;

    public void LifeReduce(int index)
    {
        playerLife[index].color = lifeColor;
    }
}

