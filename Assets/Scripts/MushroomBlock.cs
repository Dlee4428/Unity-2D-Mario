using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBlock : MonoBehaviour {

    public float bounceHeight = 0.2f;
    public float bounceSpeed = 3.5f;

    private Vector2 originalPosition;

    public float mushMoveSpeed = 8f;
    public float mushMoveHeight = 1.5f;
    public float mushFallDistance = 1.2f;

    public Sprite emptyBlockSprite;

    private bool canBounce = true;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CoinBounce"))
        {
            QuestionBlockBounce();
        }
    }

    // Use this for initialization
    void Start()
    {

        originalPosition = transform.localPosition;
    }

    public void QuestionBlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;
            StartCoroutine(Bounce());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }

    void PresentMushroom()
    {
        GameObject mushroom = (GameObject)Instantiate(Resources.Load("Prefabs/Mushroom", typeof(GameObject)));
        mushroom.transform.SetParent(this.transform.parent);
        mushroom.transform.localPosition = new Vector2(originalPosition.x, originalPosition.y);
        StartCoroutine(MoveCoin(mushroom));
    }

    IEnumerator Bounce()
    {
        SoundManager.PlaySound("mushroom");
        ChangeSprite();
        PresentMushroom();
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

    IEnumerator MoveCoin(GameObject coin)
    {
        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x,
                coin.transform.localPosition.y + mushMoveSpeed * Time.deltaTime);

            if (coin.transform.localPosition.y >= originalPosition.y + mushMoveHeight - 1)
            {
                break;
            }
            yield return null;
        }

        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x,
                coin.transform.localPosition.y - mushMoveHeight * Time.deltaTime);

            if (coin.transform.localPosition.y <= originalPosition.y + mushFallDistance - 1)
            {
                break;
            }
            yield return null;
        }
    }
}
