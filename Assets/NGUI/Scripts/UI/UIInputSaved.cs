//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Editable text input field that automatically saves its data to PlayerPrefs.
/// </summary>

[AddComponentMenu("NGUI/UI/Input (Saved)")]
public class UIInputSaved : UIInput
{
	public string playerPrefsField;

	void Awake ()
	{
		onSubmit = SaveToPlayerPrefs;

		if (!string.IsNullOrEmpty(playerPrefsField) && PlayerPrefs.HasKey(playerPrefsField))
		{
			text = PlayerPrefs.GetString(playerPrefsField);
		}
	}

	private void SaveToPlayerPrefs (string val)
	{
		if (!string.IsNullOrEmpty(playerPrefsField))
		{
			PlayerPrefs.SetString(playerPrefsField, val);
		}
	}

	void OnApplicationQuit ()
	{
		SaveToPlayerPrefs(text);
	}
}
