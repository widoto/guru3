using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    // 컴포넌트를 캐시 처리할 변수
    private Transform tr;
    // Animation 컴포넌트를 저장할 변수 
    private Animation anim;

    // 이동 속력 변수 (public으로 선언되어 인스펙터 뷰에 노출됨)
    public float moveSpeed = 10.0f;
    // 회전 속도 변수
    public float turnSpeed = 80.0f;

    // 초기 생명 값
    private readonly float initHp = 100.0f;
    // 현재 생명 값
    public float currHp;
    // Hpbar 연결할 변수
    private Image hpBar;

    // 델리게이트 선언
    public delegate void PlayerDieHandler();
    // 이벤트 선언
    public static event PlayerDieHandler OnPlayerDie;

    ////////////////////////////////////////
    //스테이지 투내용
    //코인
    [SerializeField]
    private GameController gameController;



    ///////////////////////////////////////

    //////////////////////////////제발 되라제발
    // 폭발 효과 프리팹 변수
    public GameObject explosion;
    ///////////////////////////////
    public string sceneName = "CLEAR";
    public string sceneNametwo = "ClearSine2";
    public string sceneNamethree = "DEAD";

    IEnumerator Start()
    {
        // Hpbar 연결
        hpBar = GameObject.FindGameObjectWithTag("HP_BAR")?.GetComponent<Image>();
        // HP 초기화
        currHp = initHp;
        DisplayHealth();

        // 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        // 애니메이션 실행
        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;
    }

    void Update()
    {

        /////
        //게임 상태가 게임 중 상태가아니면 업데이트 함수를 종료
        if(GameManager.instance.gState != GameManager.GameState.Run)
        {
          return;
        }


        /////
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // Debug.Log("h=" + h);
        // Debug.Log("v=" + v);

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        // Translate(이동 방향 * 속력 * Time.deltaTime)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        // Vector3.up 축을 기준으로 turnSpeed만큼의 속도로 회전
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);

        // 주인공 캐릭터의 애니메이션 설정
        PlayerAnim(h, v);

        if(Input.GetMouseButtonDown(2))
        {
            currHp += 10.0f;
            DisplayHealth();
            Sfx2.SoundPlay();
        }
        
      
    }

    void PlayerAnim(float h, float v)
    {
        // 키보드 입력값을 기준으로 동작할 애니메이션 수행
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);  // 전진 애니메이션 실행
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);  // 후진 애니메이션 실행
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);  // 오른쪽 이동 애니메이션 실행
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);  // 왼쪽 이동 애니메이션 실행
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);   // 정지 시 Idle 애니메이션 실행
        }
    }

    // 충돌한 Collider의 IsTrigger 옵션이 체크됐을 때 발생
    public void OnTriggerEnter(Collider coll)
    {
        // 충돌한 Collider가 몬스터의 PUNCH이면 Player의 HP 차감
        if (currHp >= 0.0f && coll.CompareTag("PUNCH"))
        {
            currHp -= 10.0f;
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }
        }
        /////////////////////
        if (currHp >= 0.0f && coll.CompareTag("PUNCH2"))
        {
            currHp -= 30.0f;
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }

            // 만일 충돌한다면 폭발효과 이펙트를 생성한다.
          GameObject go = Instantiate(explosion);
          go.transform.position = transform.position;
        }
        /////////////////////
        if (currHp >= 0.0f && coll.CompareTag("MEDICINE"))
        {
            currHp += 20.0f;
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }
        }

        if (currHp >= 0.0f && coll.CompareTag("Finish"))
        {
            
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }

            SceneManager.LoadScene(sceneName);
        }
        if (currHp >= 0.0f && coll.CompareTag("Finish2"))
        {
            
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }

            SceneManager.LoadScene(sceneNametwo);
        }

        ////////////////////////////////////
        else if(coll.CompareTag("COIN"))
        {
          gameController.IncreaseCoinCount();
        }

        if (currHp >= 0.0f && coll.CompareTag("PUNCH3"))
        {
            currHp -= 20.0f;
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }
        }

        if (currHp >= 0.0f && coll.CompareTag("PUNCH4"))
        {
            currHp -= 70.0f;
            DisplayHealth();

            Debug.Log($"Player hp = {currHp / initHp}");
            // Player의 생명이 0 이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
                SceneManager.LoadScene(sceneNamethree);
            }
        }
        ////////////////////////////////////////

        
    }

    // Player의 사망 처리
    void PlayerDie()
    {
        Debug.Log("Player Die !");

        // // MONSTER 태그를 가진 모든 게임오브젝트를 찾아옴
        // GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");

        // // 모든 몬스터의 OnPlayerDie 함수를 순차적으로 호출
        // foreach (GameObject monster in monsters)
        // {
        //     monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        // }

        // 주인공 사망 이벤트 호출(발생)
        OnPlayerDie();

        GameObject.Find("GameMgr").GetComponent<GameManager>().IsGameOver = true;
    }

    void DisplayHealth()
    {
        hpBar.fillAmount = currHp / initHp;
    }
}