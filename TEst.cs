
using UnityEngine;
using UnityEngine.UI;

public class TEst : MonoBehaviour {

	[SerializeField] private Button button;
	void Start () {
		button.onClick.AddListener(Click);
	}
	
	void Click () {
		Debug.Log(1);
	}
}
