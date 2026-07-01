using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{

    public int health = 100;


    public Slider healthSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            health = health - Random.Range(1, 10);
            if (health < 0) health = 0;
            if (health <= 0)
            {
                GetComponent<Animator>().SetBool("dead", true);
            }
        }
    }

}
