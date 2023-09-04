using Dubi.BaseValues;
using UnityEditor;

[CustomPropertyDrawer(typeof(ActionValue))]
public class ActionValueDrawer : BaseValueDrawer<ActionObject>
{
    public override float ValueFieldWidth()
    {
        return 0.0f;
    }
}
