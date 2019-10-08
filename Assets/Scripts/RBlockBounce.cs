using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBlockBounce : MonoBehaviour {

    public float bounceHeight = 0.1f;
    public float bounceSpeed = 2.0f;
    public PlayerHealth m_player;

    private Vector2 originalPosition;

    private bool canBounce = true;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CoinBounce"))
        {
            RegularBlockBounce();
        }
    }

    // Use this for initialization
    void Start () {
        originalPosition = transform.localPosition;
    }

    public void RegularBlockBounce()
    {
        if (canBounce)
        {
            canBounce = true;
            StartCoroutine(Bounce());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator Bounce()
    {
        SoundManager.PlaySound("bump");
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);

            if (transform.localPosition.y >= originalPosition.y + bounceHeight)
                break;

            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);

            if (transform.localPosition.y <= originalPosition.y)
            {
                transform.localPosition = originalPosition;
                break;
            }
        }
    }
}
