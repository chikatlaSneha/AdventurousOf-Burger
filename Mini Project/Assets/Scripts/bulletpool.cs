using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletpool : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>();

    public GameObject bulletprefab;

    public int bulletscount = 10;

    public Transform instantPosition;
    // Start is called before the first frame update
    void Start()
    {
        createBullet(bulletprefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createBullet(GameObject Bulletobj)
    {
        for(int i =0;i<bulletscount;i++)
        {
            var Gameobj = Instantiate(Bulletobj, gameObject.transform.position, Quaternion.identity);
            Gameobj.SetActive(false);
            bullets.Add(Gameobj);
        }
    }

    public void shootbullets()
    {
        int frombulletlist = (bullets.Count - 1);
        var bulletsobj = bullets[frombulletlist];
        bullets.RemoveAt(frombulletlist);

        bulletsobj.transform.position = new Vector2(instantPosition.transform.position.x, instantPosition.transform.position.y);
        bulletsobj.transform.eulerAngles = new Vector2(instantPosition.transform.eulerAngles.x, instantPosition.transform.eulerAngles.y);
        bulletsobj.GetComponent<Rigidbody2D>().velocity = bulletsobj.transform.right * 100f;
        bulletsobj.SetActive(true);
    }

    public void bulletsadd(GameObject bull)
    {
        bullets.Add(bull);
    }
}
