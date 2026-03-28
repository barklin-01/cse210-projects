public class Reference
{
    private string _book;
    private int _chapter;
    private string _verse;  // Verse puede ser rango o número simple, por eso string

    public Reference(string book, int chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public string GetDisplay()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}