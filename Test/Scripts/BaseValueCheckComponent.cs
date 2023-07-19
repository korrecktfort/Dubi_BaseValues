using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rubi.BaseValues;
using UnityEngine.UI;

public class BaseValueCheckComponent : MonoBehaviour
{
//    #region Check Property Drawers
//#pragma warning disable
//    [SerializeField] BoolValue boolValue01 = null;
//    [SerializeField] BoolValue boolValue02 = null;

//    [SerializeField] AnimationCurveValue animCurve = null;
//    [SerializeField] BoolValue boolValue = null;
//    [SerializeField] ColorValue colorValue = null;
//    [SerializeField] FloatValue floatValue = null;
//    [SerializeField] GameObjectReference goValue = null;
//    [SerializeField] GradientValue gradientValue = null;
//    [SerializeField] IntValue intValue = null;
//    // [SerializeField] MonoReference<BaseValueCheckComponent> monoValue = null;
//    [SerializeField] RectValue rectValue = null;
//    [SerializeField] ScriptableObjectReference soValue = null;
//    [SerializeField] SpriteReference spriteValue = null;
//    [SerializeField] StringValue stringValue = null;
//    [SerializeField] Texture2DReference texValue = null;
//    [SerializeField] TransformValue transValue = null;
//    [SerializeField] Vector2Value vector2Value = null;
//    [SerializeField] Vector3Value vector3Value = null;
//    [SerializeField] Vector4Value vector4Value = null;
//#pragma warning enable;

//    [System.Serializable]
//    struct HUIBUI
//    {
//        [SerializeField] FloatValue floatValue;
//    }

//    [SerializeField] HUIBUI huibui;
//    [SerializeField] HUIBUI[] huibuiArray;
//    #endregion

//    public Image image;
//    [SerializeField] ColorValue imgColor = null;

    [SerializeField] StringSelectionValue stringSelectionValue = null;

    private void OnEnable()
    { 
        //this.imgColor.RegisterCallbackLate(OnColorChanged);
    }

    private void OnDisable()
    {
        //this.imgColor.DeregisterCallback(OnColorChanged);
    }

    //void OnColorChanged(Color color)
    //{
    //    this.image.color = color;
    //} 
}
