using UnityEngine;

public class CreateInterface : MonoBehaviour
{
	#region Editor
	public void CreateMainMenu()
	{
		CreateComponent();
		gameObject.AddComponent<MainMenu>();
		gameObject.AddComponent<OptionsMenu>();
	}

	public void CreateMenuPause()
	{
		CreateComponent();
	}

	public void Clear()
	{
		DestroyImmediate(this);
	}

	private void CreateComponent()
	{
		gameObject.AddComponent<Interface>();
		gameObject.AddComponent<InterfaceResources>();
	}
	#endregion
}
