using UnityEngine;
using UnityEngine.UI;

public class DropdownUi : MonoBehaviour, IControl {

	private Text _text;
	private Dropdown _control;
	private void Awake()
	{
		_control = transform.GetComponent<Dropdown>();
		_text = transform.GetComponentInChildren<Text>();
	}
	public Text GetText
	{
		get { return _text; }
	}
	public Dropdown GetControl
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
