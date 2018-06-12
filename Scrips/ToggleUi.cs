using UnityEngine;
using UnityEngine.UI;

public class ToggleUi : MonoBehaviour, IControl {

	private Text _text;
	private Toggle _control;
	private void Awake()
	{
		_control = transform.GetComponent<Toggle>();
		_text = transform.GetComponentInChildren<Text>();
	}
	public Text GetText
	{
		get { return _text; }
	}
	public Toggle GetControl
	{
		get { return _control; }
	}
	public void Interactable(bool value)
	{
		GetControl.interactable = value;
	}
	public GameObject Instance { get { return gameObject; } }
	public Selectable Control { get { return GetControl; } }
}
