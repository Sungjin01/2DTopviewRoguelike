using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UIManager uimanger;
    public float moveSpeed;
    public GameObject Body;

    private float h, v;
    private Rigidbody2D rigid2d;
    private Animator anim;
    private Vector3 moment;


    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        anim = Body.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Move();
    }

    private void Move()
    {
        anim.SetBool("isRun", !((h == 0)&&(v == 0)));

        moment = new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed;
        rigid2d.MovePosition(moment + transform.position);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("item"))//tag로 줄일수있다.
        {
            uimanger.SetFillAmount(0.3f);
            coll.gameObject.SetActive(false);
        }
    }
}
