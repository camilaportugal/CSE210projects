using System;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("Learn Python", "Camila Portugal", 120);
        Video v2 = new Video("Learn C#", "Aldana Andrea", 350);
        Video v3 = new Video("HTML", "Karina Rios", 560);


        v1.AddComment( new Comment("Ariana", "Amazing tutorial, I finally understand it!"));
        v1.AddComment(new Comment("Pedro", "Thank you, this was very helpful!"));
        v1.AddComment(new Comment("Laura", "Looking forward to the next part."));

        v2.AddComment(new Comment("Mayra", "Super clear and easy to follow!"));
        v2.AddComment(new Comment("Adrian", "This saved me hours of confusion, great job."));
        v2.AddComment(new Comment("Noah", "I love this tutorial!"));
        
        v3.AddComment(new Comment("Carlos", "Great explanation of HTML tags! Now I understand how to structure a webpage."));
        v3.AddComment(new Comment("Natividad", "Can you make a video about forms in HTML next?"));
        v3.AddComment(new Comment("Marta", "This was so helpful! Now I can build my first website."));


        List<Video> videos = new List<Video>
        {
            v1, v2, v3
        };

        foreach(Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}