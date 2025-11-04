using UnityEngine;

public class SearchItem : MonoBehaviour
{
    public Material outline;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        TryGetComponent(out meshRenderer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SetOutline(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SetOutline(false);
        }
    }

    public void SetOutline(bool _onoff)
    {
        if(outline == null || meshRenderer == null) return;

        if(_onoff)
        {
            meshRenderer.materials = AddMaterial(meshRenderer.materials, outline);
        }
        else
        {
            meshRenderer.materials = SubMaterial(meshRenderer.materials);
        }
    }

    private Material[] AddMaterial(Material[] _materials, Material _newMaterial)
    {
        Material[] newMats = new Material[_materials.Length + 1];

        for (int i = 0; i < _materials.Length; i++)
        {
            newMats[i] = _materials[i];
        }

        newMats[_materials.Length] = _newMaterial;

        return newMats;
    }

    private Material[] SubMaterial(Material[] _materials)
    {
        Material[] newMats = new Material[_materials.Length - 1];

        for (int i = 0; i < _materials.Length - 1; i++)
        {
            newMats[i] = _materials[i];
        }

        return newMats;
    }
}
