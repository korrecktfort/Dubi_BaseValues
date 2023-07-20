using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
[InitializeOnLoad]
public class BaseValueOptions : MonoBehaviour
{
    //[InitializeOnLoad]
    //public static class SimulateLive
    //{
    //    public const string menuName = "Dubi/BaseValues/Simulate Live";
    //    public const string settingName = "Value";
      
    //    public static bool IsEnabled
    //    {
    //        get => EditorPrefs.GetBool(settingName, true);
    //        set => EditorPrefs.SetBool(settingName, value);
    //    }

    //    [MenuItem(menuName)]
    //    static void ToggleAction()
    //    {
    //        IsEnabled = !IsEnabled;
    //    }

    //    [MenuItem(menuName, true)]
    //    static bool ToggleActionValidate()
    //    {
    //        Menu.SetChecked(menuName, IsEnabled);
    //        return true;
    //    }
    //}
}
#endif
