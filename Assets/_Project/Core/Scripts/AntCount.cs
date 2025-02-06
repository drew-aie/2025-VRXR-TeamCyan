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

    [SerializeField]
    private GameTimerManager Manager;

    private void Update()
    {
        if (Manager.allowTimer == false)
        {
            AntCountTextBox.text = "Game Over" + "\n" + "Total: " + "\n" + Behavior.Extermination.ToString();

        }
        else
        {
            AntCountTextBox.text = "Ants Exterminated: " + "\n" + Behavior.Extermination.ToString();
        }
    }
}
