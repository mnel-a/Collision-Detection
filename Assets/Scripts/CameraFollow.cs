using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float yPosition = 2f;
    public float zPosition = -10f;

    private void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = new Vector3(
            player.position.x,
            yPosition,
            zPosition
        );
    }
}