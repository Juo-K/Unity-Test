public interface IAction
{
    //interface  - 모든 게 publilc
    //object  최상위 클라스 
    //Dynamic cast - virtual  가상합수가 있어야 가능;
    //다운 캐스트 의 정보는 부모클래스에 남아있음
    void Beging(object initValue);
    void End();
}