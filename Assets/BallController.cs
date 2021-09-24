using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ő�l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    //�_����\������e�L�X�g
    private GameObject score;

    //�_�����i�[����ϐ�
    static int currentScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");
        //�V�[������Score�I�u�W�F�N�g���擾
        this.score = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //�_����\������
        ShowScore();

    }

    //�Փˎ��ɌĂ΂��֐�
    private void OnCollisionEnter(Collision other)
    {
        //�^�O�����ʂ��Ă��ꂼ��̓_�������Z����
        if(other.gameObject.tag == "SmallStarTag")
        {
            currentScore += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            currentScore += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            currentScore += 15;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            currentScore += 30;
        }
        
    }

    //�_����\������֐�
    private void ShowScore()
    {
        // ���l�𕶎���ɕϊ�
        string s = currentScore.ToString();
        //Score�ɓ_����\��
        this.score.GetComponent<Text>().text = s;
    }
}
