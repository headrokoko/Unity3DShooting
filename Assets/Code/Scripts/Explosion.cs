using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
	public GameObject explosion; // Prehab/VFX/Explosions/explosion をドラッグ
	public GameObject playerExplosion; //Prehab/VFX/Explosions/　フォルダ内のプレハブを適当にドラッグ
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}