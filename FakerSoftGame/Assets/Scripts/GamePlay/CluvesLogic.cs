using UnityEngine;
using System.Collections;

public class CluvesLogic : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject _cluve;
    private SpriteRenderer _cluveSprite;
	
	// Update is called once per frame
    void Start()
    {
        _cluveSprite = _cluve.GetComponent<SpriteRenderer>();
    }

	void Update () {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + Time.deltaTime, gameObject.transform.localScale.y + Time.deltaTime);
        _cluveSprite.color = new Color(
            _cluveSprite.color.r,
            _cluveSprite.color.g,
            _cluveSprite.color.b,
            _cluveSprite.color.a - Time.deltaTime * 2
            );
        if (gameObject.transform.localScale.x >= 1.0f || gameObject.transform.localScale.y >= 1.0f)
            Destroy(_cluve);
	}
}
