using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator animatorr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorr = GameObject.Find("Stable Sword Inward Slash").GetComponent<Animator>();
    }
    public static bool IsAtacking;
    // Update is called once per frame
    void Update()
    {
        IsAtacking = IsPlaying("Atack");
    }


    bool IsPlaying(string stateName)
    {
        var stateInfo = animatorr.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime < 1f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (IsPlaying("Atack"))
            {


                collision.gameObject.GetComponent<skeletonMove>().health -= 1;
                print(collision.gameObject.GetComponent<skeletonMove>().health);

                if (collision.gameObject.GetComponent<skeletonMove>().health <= 0)
                {
                    collision.gameObject.GetComponent<Animator>().SetBool("dead", true);
                    collision.gameObject.GetComponent<skeletonMove>().IsLive = false;
                    Destroy(collision.gameObject, 4);
                }

            }
        }


    }

}
