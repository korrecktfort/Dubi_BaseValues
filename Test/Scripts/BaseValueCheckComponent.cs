using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dubi.BaseValues;
using UnityEngine.UI;

public class BaseValueCheckComponent : MonoBehaviour
{
#pragma warning disable
    [SerializeField] StringSelection stringSelectionValue = new StringSelection();
    [SerializeField] ColorCollection colorCollection = null;
    [SerializeField] StringCollection stringCollection = null;
#pragma warning restore
}
