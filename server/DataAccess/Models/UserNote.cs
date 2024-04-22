using System.ComponentModel.DataAnnotations;

namespace server.DataAccess.Models;

public class UserNote
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }

    [MaxLength(1000)] public string NoteContent { get; set; }
}
