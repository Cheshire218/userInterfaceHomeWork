using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceResources : MonoBehaviour {

	public ButtonUi ButtonPrefab { get; private set; }
    public DropdownUi DropdownPrefab { get; private set; }
    public ToggleUi TogglePrefab { get; private set; }
    public SliderUI SliderPrefab { get; private set; }
    public Canvas MainCanvas { get; private set; }
	public LayoutGroup MainPanel { get; private set; }
	public SliderUI ProgressbarPrefab { get; private set; }
    private void Awake()
	{
		ButtonPrefab = Resources.Load<ButtonUi>("Button");
        DropdownPrefab = Resources.Load<DropdownUi>("Dropdown");
        TogglePrefab = Resources.Load<ToggleUi>("Toggle");
        SliderPrefab = Resources.Load<SliderUI>("Slider");
        MainCanvas = FindObjectOfType<Canvas>();
		ProgressbarPrefab = Resources.Load<SliderUI>("Progressbar");
		MainPanel = MainCanvas.GetComponentInChildren<LayoutGroup>();
	}
}
