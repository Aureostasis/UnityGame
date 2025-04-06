using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class attackPattern : MonoBehaviour
{
    // combat variables
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    private int i = 0;
    float attackCD = 0.1f;
    float lastClicked;
    float lastComboEnd;

    public UnityEvent meleeAttack;


    void Start()
    {
        attack1.SetActive(false);
        attack2.SetActive(false);
        attack3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            i = 0;
            for (int i = 0; i < 9000; i++) 
            {
                if (i >= 1 & i < 3000) {
                    attack1.SetActive(true);
                    if ((i % 1000) == 0) Debug.Log("Attack1 " + "frame: " + i);
                }
                if (i >= 3000 & i < 6000) {
                    attack1.SetActive(false);
                    attack2.SetActive(true);
                    if ((i % 1000) == 0) Debug.Log("Attack2 " + "frame: " + i);
                }
                if (i >= 6000 & i < 9000) {
                    attack2.SetActive(false);
                    attack3.SetActive(true);
                    if ((i % 1000) == 0) Debug.Log("Attack3 " + "frame: " + i);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            attack1.SetActive(false);
            attack2.SetActive(false);
            attack3.SetActive(false);
        }
    }

    void OnClick() {
        
    }
}
