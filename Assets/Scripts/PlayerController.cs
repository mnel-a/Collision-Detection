using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : AABB
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f;

    private float verticalVelocity;
    private bool isGrounded;

    void LateUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.position +=
            Vector3.right * h * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }

        verticalVelocity -= gravity * Time.deltaTime;

        transform.position +=
            Vector3.up * verticalVelocity * Time.deltaTime;
    }

    public override void NotifyCollision(AABB other)
    {
        if (other.CompareTag("Ground"))
        {
            if (verticalVelocity <= 0)
            {
                isGrounded = true;
                verticalVelocity = 0;

                float groundTop =
                    other.transform.position.y +
                    other.height / 2;

                transform.position = new Vector3(
                    transform.position.x,
                    groundTop + height / 2,
                    transform.position.z
                );
            }
        }

        if (other.CompareTag("Obstacle"))
        {
            UIManager.Instance.ShowGameOver();
        }

        if (other.CompareTag("FallCollider"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (other.CompareTag("Finish"))
        {
            UIManager.Instance.ShowWin();
        }
    }
    
}
