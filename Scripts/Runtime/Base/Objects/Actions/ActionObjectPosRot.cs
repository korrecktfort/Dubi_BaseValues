using UnityEngine;

namespace Dubi.BaseValues
{
    [CreateAssetMenu(menuName ="Dubi/Base Values/Base/Actions/Action Pos Rot", order =9)]
    public class ActionObjectPosRot : ActionObject<(Vector3, Quaternion)>
    {
    }
}