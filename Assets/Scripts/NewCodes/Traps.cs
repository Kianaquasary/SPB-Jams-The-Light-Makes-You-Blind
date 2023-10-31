using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //PlayerHealth.Death
        if (other.GetComponent<PlayerGhost>() != null)
            if (other.GetComponent<PlayerGhost>().IsGhost == false)
                other.GetComponent<PlayerGhost>().ChangeToGhost();
    }

}
