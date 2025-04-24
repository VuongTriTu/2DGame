using UnityEngine;

public class EagleController : Enemy
{
    //Inpector Variable
    [SerializeField] private float speed = 2f;
    [SerializeField] private float leftBound;  
    [SerializeField] private float rightBound; 

    private bool movingRight = true;

    void Update()
    {
        Move();
    }

    //VFX
    private void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x > rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x < leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    //Changes LocalScale
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
