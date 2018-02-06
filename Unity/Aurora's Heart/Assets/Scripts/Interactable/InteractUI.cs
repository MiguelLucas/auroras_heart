using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour {

	[SerializeField]
	private Text interactionText;

    public void Awake()
    {
        this.interactionText.text = "";
    }

    public void SetText(string text)
    {
        this.interactionText.text = text;
    }
	

}
