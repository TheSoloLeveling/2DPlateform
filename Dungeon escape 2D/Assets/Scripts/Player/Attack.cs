using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool isAttacking = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (!isAttacking)
            {
                hit.damage();
                isAttacking = true;
                StartCoroutine(ResetAttackRoutine());
            }          
        }
    }


    IEnumerator ResetAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
