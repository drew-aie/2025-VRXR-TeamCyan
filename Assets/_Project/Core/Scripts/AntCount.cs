using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;



public class AntCount : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI AntCountTextBox;
    [SerializeField]
    private AntBehavior Behavior;

    private void Update()
    {
        AntCountTextBox.text = "Ants Exterminated: " + "\n" + Behavior.Extermination.ToString();
    }
}
