using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface MainEventOnGrid
{
    void didPlayerCollided(string objectName);
    void didPlayerStillInCollide(string objectName);
}
public class MainGrid : MonoBehaviour, MainEventOnGrid
{
    [SerializeField] GameObject enemiesPrefabs;
    [SerializeField] LandSquare mainCharacter;
    private List<LandSquareChild> landSquares = new List<LandSquareChild>();
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter.mainSceneDelegate = this;

        int i = 0;
        while (i < 25)
        {
            // creat rectangle 2d 
            LandSquareChild obj = Instantiate(enemiesPrefabs, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity).GetComponent<LandSquareChild>();
            obj.mainCharacter = mainCharacter;
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            // obj set collision component
            BoxCollider2D boxCollider = obj.gameObject.AddComponent<BoxCollider2D>();
            boxCollider.edgeRadius = 1f;
            boxCollider.name = "DYNAMIC_ENEMIES_" + i;

            landSquares.Add(obj);

            i++;
        }

    }

    public void didPlayerCollided(string objectName)
    {
        Debug.Log("Player Collided to " + objectName);
    }

    public void didPlayerStillInCollide(string objectName)
    {
        // Debug.Log("Player Collided to " + tagName);
        LandSquareChild obj = landSquares.Find(x => x.gameObject.name == objectName);
        if (obj != null)
        {
            obj.giveMovemenTowardsMain();
            if (obj.prepareToDestroy)
            {
                Debug.Log("Removed Object " + objectName);
                Destroy(obj.gameObject);
                landSquares.Remove(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
