using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class ButtonStyle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public Text theText;
	Color highlighted = new Color(1,1,0); //Or however you do your color
	Color other = new Color(0.8f,0.8f,0); //Or however you do your color
	void Start(){
		theText = this.GetComponentInChildren<Text> ();
		theText.color = other;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = highlighted;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = other;
	}

	void Continue(){
		
	}

	void GotoMenu(){
		//TODO
	}
	void Quit (){

	}
}
