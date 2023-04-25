using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.ProjectFramework
{

    public class Interaction : IBaseManager
    {
        [SerializeField] private Vector3 targetPos;
        private Vector3 localTargetPos;

        private Camera mainCam;


        //×´Ì¬±äÁ¿
        private bool StartMove = false;
        private bool BackMove = false;

        public void Init()
        {
            targetPos = GameObject.Find("Square").transform.position;
            mainCam = Camera.main;
            localTargetPos = mainCam.transform.position + targetPos;
            localTargetPos = new Vector3(localTargetPos.x, localTargetPos.y, 0);
        }

        Transform selectedCard;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                RaycastHit hit;
                Ray ray = mainCam.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Card"))
                    {
                        Debug.Log("¹þ¹þ");
                        StartMove = true;
                        selectedCard = hit.transform;
                    }
                    
                }
                else
                {
                    Debug.Log("ºÇºÇ");
                    BackMove = true;
                }

            }

            if (selectedCard != null && StartMove && !BackMove)
            {
                selectedCard.position = Vector3.Lerp(selectedCard.position, localTargetPos, Time.deltaTime * 5);
                if (Vector3.SqrMagnitude(selectedCard.position - localTargetPos) <= 0.1f)
                {
                    StartMove = false;
                    BackMove = false;
                }
            }

            if (selectedCard != null && BackMove )
            {
                Vector3 camPos = new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 0);
                selectedCard.position = Vector3.Lerp(selectedCard.position, camPos, Time.deltaTime * 5);
                if (Vector3.SqrMagnitude(selectedCard.position - camPos) <= 0.1f)
                {
                    BackMove = false;
                    selectedCard = null;
                    StartMove = false;
                }
            }
        }
    }

}