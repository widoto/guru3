using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TextMesh Pro 관련 컴포넌트에 접근하기 위해 선언
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // 몬스터가 출현할 위치를 저장할 List 타입 변수
    public List<Transform> points = new List<Transform>();

    // 몬스터를 미리 생성해 저장할 리스트 자료형
    public List<GameObject> monsterPool = new List<GameObject>();

    // 오브젝트 풀(Object Pool)에 생성할 몬스터의 최대 개수
    public int maxMonsters = 10;

    // 몬스터 프리팹을 연결할 변수
    public GameObject monster;

    // 몬스터의 생성 간격
    public float createTime = 3.0f;

    // 게임의 종료 여부를 저장할 멤버 변수
    private bool isGameOver;

    // 게임의 종료 여부를 저장할 프로퍼티
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                CancelInvoke("CreateMonster");
            }
        }
    }

    // 싱글턴 인스턴스 선언
    public static GameManager instance = null;

    // 스코어 텍스트를 연결할 변수
    public TMP_Text scoreText;
    // 누적 점수를 기록하기 위한 변수
    private int totScore = 0;

    // 스크립트가 실행되면 가장 먼저 호출되는 유니티 이벤트 함수
    //////////////////////////////

    //UI 텍스트 변수
    public Text stateLabel;
    
    //게임 상태 변수
    public GameState gState;

    //플레이어 게임 오브젝트 변수
    GameObject player;

    //플레이어 무브 컴포넌트 변수
    PlayerCtrl playerM;

    //옵션 메뉴 UI오브젝트
    public GameObject optionUI;

    public enum GameState
    {
      Ready,
      Run,
      Pause,
      GameOver,
      

    }

    //////////////////////////////

    void Awake()
    {
        // instance가 할당되지 않았을 경우
        if (instance == null)
        {
            instance = this;
        }
        // instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미함
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        // 다른 씬으로 넘어가더라도 삭제하지 않고 유지함
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

      ////////////////////

        //초기 게임상태는 준비 상태로 설정한다.
        gState = GameState.Ready;

        //게임 시작 코루틴 함수를 실행한다.
        StartCoroutine(GameStart());

        //플레이어 오브젝트를 검색
        player = GameObject.Find("Player");

        playerM = player.GetComponent<PlayerCtrl>();

      ////////////////////
        // 몬스터 오브젝트 풀 생성
        CreateMonsterPool();

        // SpawnPointGroup 게임오브젝트의 Transform 컴포넌트 추출
        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;

        // // SpawnPointGroup 하위에 있는 모든 차일드 게임오브젝트의 Transform 컴포넌트 추출
        // spawnPointGroup?.GetComponentsInChildren<Transform>(points);

        // SpawnPointGroup 하위에 있는 모든 차일드 게임오브젝트의 Transform 컴포넌트 추출
        foreach (Transform point in spawnPointGroup)
        {
            points.Add(point);
        }

        // 일정한 시간 간격으로 함수를 호출
        InvokeRepeating("CreateMonster", 2.0f, createTime);

        // 스코어 점수 출력
        //totScore = PlayerPrefs.GetInt("TOT_SCORE", 0);
        DisplayScore(0);

        
    }

    void Update()
    {
      if(playerM.currHp <= 0 )
      {
        stateLabel.text = "GameOver ....";

        //게임오버 문구의 색상은 붉은색으로 설정한다.
        stateLabel.color = new Color(255,0,0,255);

        //게임 상태를 게임 오버상태로 전환한다.
        gState = GameState.GameOver;
      }


    }

    ////////////////////////////
    IEnumerator GameStart(){
      //Ready라는 문구를 표시한다.
      stateLabel.text = "Ready....";
      //Ready 문구의 색상을 주황색으로 표시한다.
      stateLabel.color = new Color32(233,182, 12, 255);
      //2초간 대기한다.
      yield return new WaitForSeconds(2.0f);
      //Go!라는 문구로 변경한다.
      stateLabel.text = "Go!";
      //0.5초간 대기한다.
      yield return new WaitForSeconds(0.5f);
      // Go 문구를 지운다.
      stateLabel.text = "";
      // 게임의 상태를 준비상태에서 실행상태로 전환한다.
      gState = GameState.Run;
    }


    
    ////////////////////////////

    void CreateMonster()
    {
        // 몬스터의 불규칙한 생성 위치 산출
        int idx = Random.Range(0, points.Count);

        // 몬스터 프리팹 생성
        //Instantiate(monster, points[idx].position, points[idx].rotation);

        // 오브젝트 풀에서 몬스터 추출
        GameObject _monster = GetMonsterInPool();
        // 추출한 몬스터의 위치와 회전을 설정
        _monster?.transform.SetPositionAndRotation(points[idx].position,
                                                   points[idx].rotation);

        // 추출한 몬스터를 활성화
        _monster?.SetActive(true);
    }

    // 오브젝트 풀에 몬스터 생성
    void CreateMonsterPool()
    {
        for (int i = 0; i < maxMonsters; i++)
        {
            // 몬스터 생성
            var _monster = Instantiate<GameObject>(monster);
            // 몬스터의 이름을 지정
            _monster.name = $"Monster_{i:00}";
            // 몬스터 비활성화
            _monster.SetActive(false);

            // 생성한 몬스터를 오브젝트 풀에 추가
            monsterPool.Add(_monster);
        }
    }

    // 오브젝트 풀에서 사용 가능한 몬스터를 추출해 반환하는 함수
    public GameObject GetMonsterInPool()
    {
        // 오브젝트 풀의 처음부터 끝까지 순회
        foreach (var _monster in monsterPool)
        {
            // 비활성화 여부로 사용 가능한 몬스터를 판단
            if (_monster.activeSelf == false)
            {
                // 몬스터 반환
                return _monster;
            }
        }
        return null;
    }

    // 점수를 누적하고 출력하는 함수
    public void DisplayScore(int score)
    {
        totScore += score;
        scoreText.text = $"<color=#00ff00>SCORE :</color> <color=#ff0000>{totScore:#,##0}</color>";
        // 스코어 저장
        //PlayerPrefs.SetInt("TOT_SCORE", totScore);
    }

    //옵션 메뉴 켜기//////////////////////////
    public void OpenOptionWindow()
    {
      //게임 상태를 pause로 바꾼다.
      gState = GameState.Pause;
      //시간을 멈춘다.
      Time.timeScale = 0;
      //옵션 메뉴 창을 활성화한다.
      optionUI.SetActive(true);


    }
    //옵션 메뉴 끄기(계속하기)
    public void CloseOptionWindow()
    {
      //게임 상태를 run 상태로변경한다.
      gState = GameState.Run;
      //시간을 1배로 되돌린다.
      Time.timeScale = 1.0f;
      //옵션메뉴 창을 비활성화 한다.
      optionUI.SetActive(false);
    }

   //게임 재시작하기(현재 씬 다시 로드)
    public void GameReStart()
    {
      
      //시간을 1배로 되돌린다.
      Time.timeScale = 1.0f;

      //현재 씬을 다시 로드한다.
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    //게임을 종료하기
    public void GameQuit()
    {
      //어플리케이션을 종료한다.
      Application.Quit();

    }
}
