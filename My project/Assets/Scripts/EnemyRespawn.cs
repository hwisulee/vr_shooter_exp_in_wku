using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyRespawn : MonoBehaviour
{
    public Text remain, score;
    public GameObject rangeObject;
    public GameObject capsul;
    BoxCollider rangeCollider;
    public bool EnemyGen = false;
    public int ScoreNow = 0;
    public int EnemyNow = 0;
    public int EnemyMax = 500;

    private void Awake()
    {
        remain = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Text>();
        score = GameObject.FindGameObjectWithTag("VRUIText").GetComponent<Text>();
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
        EnemyGen = true;
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    private void Update()
    {
        score.text = "SCORE : " + ScoreNow;
        remain.text = "ENEMY REMAIN : " + EnemyNow;
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while(EnemyGen != false)
        {
            yield return new WaitForSeconds(0.1f);

            GameObject instantCapsul = Instantiate(capsul, Return_RandomPosition(), Quaternion.identity);
            EnemyNow += 1;

            if (EnemyNow == EnemyMax)
            {
                EnemyGen = false;
            }
        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPosition = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPosition;
        return respawnPosition;
    }
}
