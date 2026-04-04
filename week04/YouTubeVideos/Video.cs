
// Class for Video
public class Video
{
    public string Title;
    public string Author;
    public int Length; // in seconds

    public List<Comment> Comments = new List<Comment>();

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}
