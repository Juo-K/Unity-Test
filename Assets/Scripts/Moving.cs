using UnityEngine;
using UnityEngine.AI;

public class Moving : MonoBehaviour
{
    //목적지를 찍어야줘얌

    private NavMeshAgent _navMeshAgent = null;
    private Vector3 _destination;
    private Vector3 _thisPosition;
    private NavMeshPath _path = null;
    private Vector3[] _corners = null;

    private void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//화면좌표계 상의 좌표를 반직선으로 바꿈; 바꾸고 싶은 값을 안에 집어넣음;

            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, 500))//물체의 좌표까지 무조건감;
            {
                _navMeshAgent.destination = hit.point; //충돌된 위치까지가 목적지;
                _destination = hit.point; //누른 위치가 목적지;

                _path = _navMeshAgent.path;
                _corners = _navMeshAgent.path.corners;
                _thisPosition = this.transform.position;
                
            }
        }
        //_thisPosition = this.transform.position;
        //foreach (Vector3 v in _corners)
        //{
        //}
        //Debug.DrawLine(_thisPosition, _destination); // 
        //실제로 찍을 경우는 네비게이션 값을 받아와서 받아옴;
        if (_corners.Length != 0)
        {
            for (int i = 1; i < _corners.Length; i++)
            {
                //Vector3 nextPos = _corners[Mathf.Min(i, _corners.Length - 1)];
                Debug.DrawLine(_corners[i - 1], _corners[i]);
            }
        }

    }

    private int GetNextIndex(int index)
    {
        return (index + 1) % _corners.Length;
    }
}
