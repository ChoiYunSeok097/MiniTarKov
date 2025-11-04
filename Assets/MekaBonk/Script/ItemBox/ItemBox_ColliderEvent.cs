using UnityEngine;

public class ItemBox_ColliderEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            //Debug.Log("dd");
        }
    }
}
