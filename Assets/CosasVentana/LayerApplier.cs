using Meta.XR.MRUtilityKit;
using UnityEngine;

public class LayerApplier : MonoBehaviour
{
    public void GetRoomObjectAndApplyLayer()
    {
        MRUKRoom mrukComponen = FindObjectOfType<MRUKRoom>();
        GameObject mrukObject = mrukComponen.gameObject;

        ApplyLayer(mrukObject, "Wall");
    }

    private void ApplyLayer(GameObject obj, string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        obj.layer = layer;

        if(obj.name == "WALL_FACE_EffectMesh")
        {
            MeshCollider mesCollider = obj.AddComponent<MeshCollider>();
            mesCollider.convex = true;
        }

        foreach (Transform child in obj.transform) ApplyLayer(child.gameObject, layerName);
    }
}
