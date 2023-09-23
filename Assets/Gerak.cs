using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerak : MonoBehaviour
{
    // Use this for initialization
    public int kecepatan,kekuatanlompat;
    
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;
    Animator anim;

    void Start()
    {
        lompat = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input. GetKey (KeyCode.D)) {
            anim.SetBool ("lari", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah=-1;
        } 
        if (Input. GetKey (KeyCode.A)) {
            anim.SetBool ("lari", true);
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah=1;
        }else {
            anim.SetBool ("lari", false);
        }

        if (Input. GetKey (KeyCode.W)) {
            anim.SetBool ("lompat", true);
            lompat.AddForce (new Vector2(0,kekuatanlompat));
        }else{
            anim.SetBool ("lompat", false);
        }
        {
            if (pindah > 0 && !balik){
                balikbadan();
            }else if(pindah < 0 && balik){
                balikbadan();
            }
        } 
    }
    void balikbadan()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }   
}
