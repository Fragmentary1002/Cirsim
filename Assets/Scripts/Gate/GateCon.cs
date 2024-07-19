using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum GateType { NULL, NOT, AND, OR, NAND, NOR, XOR, XNOR }
public enum GateType { NULL, NOT, AND, OR }

public class GateCon : MonoBehaviour
{    //第二版代码
    public GateType gateType;
    public bool isRadBallFrist = false;
    public bool isRadBallSecond = false;
    public int BallCnt = 0;
    //第一版代码
    // public int RedBallCnt=0;//0->- 1->+ ==> 00:0 01:1 11:2
    // public int BallCnt=0;
    // public string gateType

    // private bool isDispose=false;

    public GameObject mySphereRed;
    public GameObject mySphereBlue;
    public Transform start;
    public Transform target;

    // private Vector3 depth;
    // private Vector3 offset;
    // private Rigidbody rd;
    void Start()
    {
        // rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((gateType == GateType.NOT && BallCnt == 1) || BallCnt >= 2)
        {
            DisposeBall();
            BallCnt = 0;
        }
    }
    private void CreateBallRed()
    {
        Debug.Log("生成RedBall");
        Vector3 startPos = start.position;//实例化预制体的position，可自定义 
        Quaternion startRot = new Quaternion(0, 0, 0, 0);//实例化预制体的rotation，可自定义
        GameObject Sphere = GameObject.Instantiate(mySphereRed, startPos, startRot) as GameObject;
        Sphere.GetComponent<Move>().Shoot(target);
    }
    private void CreateBallBlue()
    {
        Debug.Log("生成BlueBall");
        Vector3 startPos = start.position;//实例化预制体的position，可自定义   
        Quaternion startRot = new Quaternion(0, 0, 0, 0);//实例化预制体的rotation，可自定义
        GameObject Sphere = GameObject.Instantiate(mySphereBlue, startPos, startRot) as GameObject;
        Sphere.GetComponent<Move>().Shoot(target);
    }


    // //第二版plus
    //    private void OnTriggerStay(Collider other){
    //     if(other.gameObject.tag == "RedBall" ||other.gameObject.tag == "BlueBall"){

    //     Debug.Log("发生碰撞了"+other.gameObject.tag);      
    //     if (other.gameObject.tag == "RedBall")//识别标签
    //     {
    //         if(isRadBallFrist)
    //         {
    //             isRadBallSecond=true;
    //         }
    //             isRadBallFrist=true;
    //     }
    //     Destroy(other.gameObject);//销毁
    //     BallCnt++;
    //    }
    // }

    // 第二版
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "RedBall" || collision.gameObject.tag == "BlueBall")
        {

            Debug.Log("发生碰撞了" + collision.gameObject.tag);
            if (collision.gameObject.tag == "RedBall")//识别标签
            {
                if (isRadBallFrist)
                {
                    isRadBallSecond = true;
                }
                isRadBallFrist = true;

            }
            Destroy(collision.gameObject);//销毁
            BallCnt++;
        }

    }

    //决策树，位运算级别
    private void DisposeBall()
    {
        if (isCreateRad())
            CreateBallRed();
        else
            CreateBallBlue();
        //清0操作
        if (isRadBallFrist) isRadBallFrist = false;
        if (isRadBallSecond) isRadBallSecond = false;
        return;
    }
    private bool isCreateRad()
    {
        switch (gateType)
        {
            case GateType.NOT:
                return !isRadBallFrist;
            case GateType.AND:
                return isRadBallFrist & isRadBallSecond;
            case GateType.OR:
                return isRadBallFrist | isRadBallSecond;
                // case GateType.XOR:
                //     return isRadBallFrist ^ isRadBallSecond;
                // case GateType.NAND:
                //     return !(isRadBallFrist & isRadBallSecond);
                // case GateType.NOR:
                //     return !(isRadBallFrist | isRadBallSecond);
                // case GateType.XNOR:
                //     return !(isRadBallFrist ^ isRadBallSecond);
        }
        return false;
    }

    // 点击替换
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mousedown left");
            GateChanger.Instance.ChangetoNext(transform, gateType);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mousedown right");
            GateChanger.Instance.ChangetoPrevious(transform, gateType);
        }
    }
}

// void OnCollisionEnter(Collision collision){
//      Debug.Log("发生碰撞了");

//     if(gateType=="not" && BallCnt==1) return; //计算球个数若大于2(not 为 1 )则不处理
//     if(BallCnt==2) return;

//     if (collision.gameObject.tag == "RedBall")//识别标签
//     {

//         BallCnt++;
//         RedBallCnt++;
//     }
//     else if (collision.gameObject.tag == "BlueBall")//识别标签
//     {
//         BallCnt++;
//     }
//     Destroy(collision.gameObject);//销毁
// }
//决策树 暴力
// void DisposeBall(){
//     Debug.Log("开始运行决策");
//     if(gateType=="and"){
//         switch (RedBallCnt){
//             case 0:
//                 CreateBallBlue();
//                 break;
//             case 1:
//                 CreateBallBlue();
//                 break;
//             case 2:
//                 CreateBallRed();
//                 break;
//         }
//     }else if(gateType=="or"){
//         switch (RedBallCnt){
//             case 0:
//                 CreateBallBlue();
//                 break;
//             case 1:
//                 CreateBallRed();
//                 break;
//             case 2:
//                 CreateBallRed();
//                 break;
//         }
//     }else if(gateType=="not"){
//         switch (RedBallCnt){
//             case 0:
//                 CreateBallRed();                 
//                 break;
//             case 1:            
//                 CreateBallBlue();      
//                 break;
//             case 2://not
//                 break;
//         }
//     }else if(gateType=="nand"){ 
//         switch (RedBallCnt){
//             case 0:   
//                 CreateBallRed();              
//                 break;
//             case 1:             
//                 CreateBallRed();     
//                 break;
//             case 2:
//                 CreateBallBlue();
//                 break;
//         }
//     }else if(gateType=="nor"){ 
//         switch (RedBallCnt){
//             case 0:     
//                 CreateBallRed();            
//                 break;
//             case 1:             
//                 CreateBallBlue();     
//                 break;
//             case 2:
//                 CreateBallBlue();
//                 break;
//         }}
//     else if(gateType=="xor"){ 
//         switch (RedBallCnt){
//             case 0:              
//                 CreateBallBlue();   
//                 break;
//             case 1:              
//                 CreateBallRed();    
//                 break;
//             case 2:
//                 CreateBallBlue();
//                 break;
//         }
//     }else if(gateType=="xnor"){ 
//         switch (RedBallCnt){
//             case 0:     
//                 CreateBallRed();            
//                 break;
//             case 1:             
//                 CreateBallBlue();     
//                 break;
//             case 2:
//                 CreateBallRed();
//                 break;
//         }
//     }
//     isDispose=true;
// }


