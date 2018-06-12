using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioOptions : BaseMenu
{
	enum OptionsMenuItems
	{
        LanguageDropDown,
        SoundVolume,
		Back
	}
    private List<string> DropdownOptionsItems = new List<string>();

    private void CreateMenu(string[] menuItems)
	{
		_elementsOfInterface = new IControl[menuItems.Length];
		for (var index = 0; index < menuItems.Length; index++)
		{
			switch (index)
			{
                case (int)OptionsMenuItems.LanguageDropDown:
                    {
                        var tempControl =
                        CreateControl(Interface.InterfaceResources.TogglePrefab,
                        Main.Instance.LangManager.Text("AudioMenuItems", "Background"));
                        tempControl.GetControl.onValueChanged.AddListener(delegate {
                            ToggleValueChanged(tempControl.GetControl);
                        });
                        _elementsOfInterface[index] = tempControl;
                        break;
                    }
                case (int)OptionsMenuItems.SoundVolume:
                    {
                        var tempControl =
                        CreateControl(Interface.InterfaceResources.SliderPrefab,
                        Main.Instance.LangManager.Text("AudioMenuItems", "SoundVolume"));
                        tempControl.GetControl.onValueChanged.AddListener(delegate {
                            SliderValueChanged(tempControl.GetControl);
                        });
                        _elementsOfInterface[index] = tempControl;
                        break;
                    }
                case (int)OptionsMenuItems.Back:
					{
						var tempControl =
						CreateControl(Interface.InterfaceResources.ButtonPrefab,
						Main.Instance.LangManager.Text("GameOptions", "SaveAndBack"));
						tempControl.GetControl.onClick.AddListener(Back);
						_elementsOfInterface[index] = tempControl;
						break;
					}
			}
		}
		if (_elementsOfInterface.Length < 0) return;
		_elementsOfInterface[0].Control.Select();
		_elementsOfInterface[0].Control.OnSelect(new
		BaseEventData(EventSystem.current));
	}
    private void SliderValueChanged(Slider slider)
    {
        Debug.Log("Audio settings changed");
    }
    private void ToggleValueChanged(Toggle change)
	{
        Debug.Log("Audio settings changed");
	}
	private void Back()
	{
		Hide();
		Interface.Execute(InterfaceObject.OptionsMenu);
	}
	public override void Hide()
	{
		if (!IsShow) return;
		Clear(_elementsOfInterface);
		IsShow = false;
	}
	public override void Show()
	{
		if (IsShow) return;
		var tempMenuItems = System.Enum.GetNames(typeof(OptionsMenuItems));
		CreateMenu(tempMenuItems);
		IsShow = true;
	}
}
