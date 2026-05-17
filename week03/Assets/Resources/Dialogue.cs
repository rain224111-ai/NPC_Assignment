[System.Serializable]

public class Dialogue {
    public string name; //변수 선언
    public string text;

    public Dialogue (string name, string text)
    {
        this.name=name; //함수에서 입력받은 name변수를 전역변수 name에 저장.
        this.text=text;
    }
}