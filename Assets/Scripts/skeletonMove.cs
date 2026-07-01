using UnityEngine;
using UnityEngine.AI;

public class skeletonMove : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject hedef;
    public int health = 10;
    public bool IsLive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLive == true)
        {
            agent.SetDestination(hedef.transform.position);
        }

        float distance = Vector3.Distance(this.transform.position, hedef.transform.position);
        if (distance < 2)
        {
            GetComponent<Animator>().SetBool("attack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("attack", false);
        }
        if (hedef.gameObject.GetComponent<CharacterHealth>().health <= 0)
        {
            GetComponent<Animator>().Play("root_combat idle");
        }

    }
}
