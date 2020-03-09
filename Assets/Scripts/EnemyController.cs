using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public GameObject shot;
    public Text winText;
    public float fireRate = 0.99f;
    // Start is called before the first frame update
    void Start()
    {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();


    }
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        foreach (Transform Enemy in enemyHolder)
        {
            
            if(Enemy.position.x < -10.5 || Enemy.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if(Random.value > fireRate)
            {
                Instantiate(shot, Enemy.position, Enemy.rotation);
            }

            if (enemyHolder.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if (enemyHolder.childCount == 0)
        {
            winText.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }

        else if (other.tag == "Base")
        {
            Destroy(other.gameObject);
        }
    }
}
