using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    
    [SerializeField]
    private TextMeshProUGUI description;

    public void UpdateText(string desc){
    
        description.text = desc;

    }

}
