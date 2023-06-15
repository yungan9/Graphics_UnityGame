using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 클릭한 카드 번호
    static public int cardNum;

    // 직전의 카드 번호
    int lastNum = 0;

    // 스테이지의 전체 카드 수
    int cardCnt;

    // 카드 클릭 횟수
    int hitCnt = 0;

    // 스테이지 번호
    static public int stageNum = 1;

    // 스테이지 수
    int stageCnt = 6;

    // 카드 배열 섞기용
    int[] arCards = new int[50];

    // 게임 시작 시간
    float startTime;

    // 스테이지 경과 시간
    float stageTime;

    // Start is called before the first frame update
    void Start()
    {
        //시간초기화
        startTime = stageTime = Time.time;
        //스테이지 만들기
        StartCoroutine(MakeStage());
    }

    void Update()
    {

    }

    IEnumerator MakeStage()
    {
        //시작카드의 x좌표
        float sx = 0;

        //시작카드의 y좌표
        float sz = 0;

        SetCardPos(out sx, out sz);

        //시작카드의 번호
        int n = 1;

        //카드 배열 읽기 배열의 1행을 읽고 변수 t에 할당한다
        string[] str = StageSet.stage[stageNum - 1];

        //배열의 행의 수만큼 반복
        foreach (string t in str)
        {
            //각행의 문자열을 단일 문자 배열로 변환(문자열 좌우의 공백 제거), 변수 t의 좌우 공백을 제거(Trim)하고 단일 문자배열로 변환
            char[] ch = t.Trim().ToCharArray();

            //카드의 x축 좌표
            float x = sx;

            //1행의 문자열 길이만큼 반복
            //배열의 ch의 한문자를 읽고 변수 c에 할당한다
            foreach (char c in ch)
            {
                switch (c)
                {
                    // 맵의 내용이 *이면 그 위치에 카드 만들어서 배치
                    case '*':
                        //카드 만들기
                        GameObject card = Instantiate(Resources.Load("Prefab/Card")) as GameObject;

                        // 카드 좌표설정
                        card.transform.position = new Vector3(x, 0, sz);

                        // 태그 달기
                        card.tag = "card" + n++;
                        // card.tag = "card" + arCards[n++];
                        x++;
                        break;

                    //빈칸처리
                    case '.':
                        x++;
                        break;

                    //반 칸 공백처리
                    case '>':
                        x += 0.5f;
                        break;

                    //반 줄 행간 처리
                    case '^':
                        sz += 0.5f;
                        break;

                }

                //카드를 표시한 후에는 지연시간을 두어 카드가 배치되는 과정이 보이도록 함
                if (c == '*')
                {
                    yield return new WaitForSeconds(0.03f);
                }
            }

            //한줄 아래로 이동
            sz--;
        }
    }

    //카드의 시작 위치 계산
    void SetCardPos(out float sx, out float sz)
    {
        //가로 카드수 반칸 공백 포함
        float x = 0;

        // 세로 행수 반줄 행간 포함
        float z = 0;

        float maxX = 0;

        cardCnt = 0;

        string[] str = StageSet.stage[stageNum - 1];

        for (int i = 0; i < str.Length; i++)
        {
            string t = str[i].Trim();

            x = 0;

            for (int j = 0; j < t.Length; j++)
            {
                switch (t[j])
                {
                    case '.':
                    case '*':

                        x++;
                        if (t[j] == '*')
                        {
                            cardCnt++;
                        }
                        break;
                    case '>':
                        x += 0.5f;
                        break;
                    case '^':
                        z -= 0.5f;
                        break;
                }
            }

            if (x > maxX)
            {
                maxX = x;
            }
            z++;
        }

        sx = -maxX / 2;
        sz = (z - 1) / 2;

        // StartCoroutine(CardOpen(cardCnt));
    }
}
