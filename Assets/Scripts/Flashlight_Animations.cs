using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Flashlight_Animations : MonoBehaviour
{
    public Animator anim;
    public float chargingControlWeight = 1f;
    public Material chargeMaterial;
    public float Charge;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Charge_Settings();
        Animations();
    }

    void Charge_Settings()
    {
        chargeMaterial.mainTextureOffset = new Vector2(0, 1.5f - (Charge / 10 * 0.05f));
    }

    void Animations()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("chr_walk", true);

        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("chr_walk", false);
            anim.SetBool("chr_lookCharge", false);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("chr_run", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("chr_run", false);
        }
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!anim.GetBool("chr_lookCharge"))
            {
                anim.SetLayerWeight(1, chargingControlWeight);
                anim.SetBool("chr_lookCharge", true);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("chr_lookCharge", false);
        }
    }
}
