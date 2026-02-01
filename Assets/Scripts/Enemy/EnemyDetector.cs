using UnityEngine;
using SceneManagement;
public class EnemyDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
