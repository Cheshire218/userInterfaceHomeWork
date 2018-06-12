using UnityEngine.UI;
using UnityEngine;

public class SliderUI : MonoBehaviour, IControl
{
	private Text _text;
	private Slider _control;

	private void Awake()
	{
		_control = transform.GetComponentInChildren<Slider>();
		_text = transform.GetComponentInChildren<Text>();
	}

	public Text GetText
	{
		get { return _text; }
	}

	public Slider GetControl
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
