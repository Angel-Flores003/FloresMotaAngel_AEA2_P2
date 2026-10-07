using UnityEngine;
// TODO: crea el ScriptableObject [CreateAssetsMenu...] recorda que no ha d'heretar de MonoBehaviour
[CreateAssetMenu(fileName = "NewAsteroidData", menuName = "Scriptable Objects/Asteroid Data")]//Asteroids
public class AsteroidData : ScriptableObject
{
	//TODO: introdueix les dades necesaties
	public string asteroidName;
	public int maxHealth;
	public int damage;
	public float speed;
	public Color color;
}