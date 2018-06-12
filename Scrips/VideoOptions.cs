using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VideoOptions : BaseMenu
{
	enum OptionsMenuItems
	{
        LanguageDropDown,
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
                        CreateControl(Interface.InterfaceResources.DropdownPrefab,
                        Main.Instance.LangManager.Text("OptionsMenuItems", "Game"));
                        DropdownOptionsItems.Clear();
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "VeryLow"));
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "Low"));
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "Medium"));
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "High"));
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "VeryHigh"));
                        DropdownOptionsItems.Add(Main.Instance.LangManager.Text("QualityNames", "Ultra"));
                        tempControl.GetControl.ClearOptions();
                        tempControl.GetControl.AddOptions(DropdownOptionsItems);


                        tempControl.GetControl.value = DropdownOptionsItems.IndexOf(Main.Instance.LangManager.LanguageCode);
                        tempControl.GetControl.onValueChanged.AddListener(delegate {
                            DropdownValueChanged(tempControl.GetControl);
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
	private void LoadVideoOptions()
	{
		Hide();
		Interface.Execute(InterfaceObject.VideoOptions);
	}
	private void LoadSoundOptions()
	{
		Hide();
		Interface.Execute(InterfaceObject.AudioOptions);
	}
	private void DropdownValueChanged(Dropdown change)
	{
        Debug.Log("Video settings changed");
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
