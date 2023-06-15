using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Ŭ���� ī�� ��ȣ
    static public int cardNum;

    // ������ ī�� ��ȣ
    int lastNum = 0;

    // ���������� ��ü ī�� ��
    int cardCnt;

    // ī�� Ŭ�� Ƚ��
    int hitCnt = 0;

    // �������� ��ȣ
    static public int stageNum = 1;

    // �������� ��
    int stageCnt = 6;

    // ī�� �迭 �����
    int[] arCards = new int[50];

    // ���� ���� �ð�
    float startTime;

    // �������� ��� �ð�
    float stageTime;

    // Start is called before the first frame update
    void Start()
    {
        //�ð��ʱ�ȭ
        startTime = stageTime = Time.time;
        //�������� �����
        StartCoroutine(MakeStage());
    }

    void Update()
    {

    }

    IEnumerator MakeStage()
    {
        //����ī���� x��ǥ
        float sx = 0;

        //����ī���� y��ǥ
        float sz = 0;

        SetCardPos(out sx, out sz);

        //����ī���� ��ȣ
        int n = 1;

        //ī�� �迭 �б� �迭�� 1���� �а� ���� t�� �Ҵ��Ѵ�
        string[] str = StageSet.stage[stageNum - 1];

        //�迭�� ���� ����ŭ �ݺ�
        foreach (string t in str)
        {
            //������ ���ڿ��� ���� ���� �迭�� ��ȯ(���ڿ� �¿��� ���� ����), ���� t�� �¿� ������ ����(Trim)�ϰ� ���� ���ڹ迭�� ��ȯ
            char[] ch = t.Trim().ToCharArray();

            //ī���� x�� ��ǥ
            float x = sx;

            //1���� ���ڿ� ���̸�ŭ �ݺ�
            //�迭�� ch�� �ѹ��ڸ� �а� ���� c�� �Ҵ��Ѵ�
            foreach (char c in ch)
            {
                switch (c)
                {
                    // ���� ������ *�̸� �� ��ġ�� ī�� ���� ��ġ
                    case '*':
                        //ī�� �����
                        GameObject card = Instantiate(Resources.Load("Prefab/Card")) as GameObject;

                        // ī�� ��ǥ����
                        card.transform.position = new Vector3(x, 0, sz);

                        // �±� �ޱ�
                        card.tag = "card" + n++;
                        // card.tag = "card" + arCards[n++];
                        x++;
                        break;

                    //��ĭó��
                    case '.':
                        x++;
                        break;

                    //�� ĭ ����ó��
                    case '>':
                        x += 0.5f;
                        break;

                    //�� �� �ణ ó��
                    case '^':
                        sz += 0.5f;
                        break;

                }

                //ī�带 ǥ���� �Ŀ��� �����ð��� �ξ� ī�尡 ��ġ�Ǵ� ������ ���̵��� ��
                if (c == '*')
                {
                    yield return new WaitForSeconds(0.03f);
                }
            }

            //���� �Ʒ��� �̵�
            sz--;
        }
    }

    //ī���� ���� ��ġ ���
    void SetCardPos(out float sx, out float sz)
    {
        //���� ī��� ��ĭ ���� ����
        float x = 0;

        // ���� ��� ���� �ణ ����
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
