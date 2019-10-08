using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour {

    public float bounceHeight = 0.2f;
    public float bounceSpeed = 3.5f;

    private Vector2 originalPosition;

    public float coinMoveSpeed = 8f;
    public float coinMoveHeight = 1.5f;
    public float coinFallDistance = 1.2f;

    public Sprite emptyBlockSprite;

    private bool canBounce = true;

    public PlayerHealth m_player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CoinBounce"))
        {
            playerCount();
            QuestionBlockBounce();
        }
    }

    // Use this for initialization
    void Start () {

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
	void Update () {
		
	}

    void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = emptyBlockSprite;
    }

    void PresentCoin()
    {
        GameObject spinningCoin = (GameObject)Instantiate(Resources.Load("Prefabs/Spinning_Coin", typeof(GameObject)));
        spinningCoin.transform.SetParent(this.transform.parent);
        spinningCoin.transform.localPosition = new Vector2(originalPosition.x, originalPosition.y);
        StartCoroutine(MoveCoin(spinningCoin));
    }

    IEnumerator Bounce()
    {
        SoundManager.PlaySound("coin");
        ChangeSprite();
        PresentCoin();
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

            if(transform.localPosition.y <= originalPosition.y)
            {
                transform.localPosition = originalPosition;
                break;
            }
        }
    }

    IEnumerator MoveCoin (GameObject coin)
    {
        while (true){
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x,
                coin.transform.localPosition.y + coinMoveSpeed * Time.deltaTime);

            if (coin.transform.localPosition.y >= originalPosition.y + coinMoveHeight - 1){
                break;
            }
            yield return null;
        }

        while (true){
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x,
                coin.transform.localPosition.y - coinMoveHeight * Time.deltaTime);

            if (coin.transform.localPosition.y <= originalPosition.y + coinFallDistance - 1){
                Destroy(coin.gameObject);
                break;
            }
            yield return null;
        }
    }

    void playerCount()
    {
        m_player.count = m_player.count + 1;
        m_player.countText.text = m_player.count.ToString();
    }
}
