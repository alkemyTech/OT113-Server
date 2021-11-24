using System;
using System.ComponentModel.DataAnnotations;


namespace OT113-Server.Entities {

    public class Comment : EntityBase
    {

    [ForeignKey("User")]
    public int userId { get; set; }
    
    [MinLength(1)]
    public string Body { get; set; }

    [ForeignKey("News")]
    public int newsId { get; set; }

    }


}