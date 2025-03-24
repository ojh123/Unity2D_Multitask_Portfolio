using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleColor : MonoBehaviour
{
    [SerializeField]
    private Text titleText;
    void Start()
    {
        titleText.text =
            "<color=#FF5733>M</color>" +       
            "<color=#33FF57>U</color>" +       
            "<color=#3357FF>L</color>" +       
            "<color=#FF5733>T</color>" +       
            "<color=#33FF57>I</color>" +       
            "<color=#FFFF00>T</color>" +       
            "<color=#FF5733>A</color>" +       
            "<color=#33FF57>S</color>" +       
            "<color=#3357FF>K</color>";       
    }

}
