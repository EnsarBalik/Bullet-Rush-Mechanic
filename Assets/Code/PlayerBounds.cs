using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public Transform VectorRight;
    public Transform VectorLeft;
    public Transform VectorBack;
    public Transform VectorForward;

    public void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, VectorBack.transform.position.z, VectorForward.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, VectorLeft.transform.position.x, VectorRight.transform.position.x);
        transform.position = viewPos;
    }
}
