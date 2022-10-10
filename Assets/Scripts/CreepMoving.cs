using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreepMoving : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    TextMeshProUGUI textScore;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        textScore = GameObject.Find("Text Score").GetComponent<TextMeshProUGUI>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            score = int.Parse(textScore.text);
            score++;
            textScore.text = score.ToString();
        }
    }
}
