﻿namespace Storybase.Core.Models;

public class Writer
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string? UserName { get; set; }
    public string? Bio { get; set; }
    public string? ContactInfo { get; set; }

    public ICollection<LiteraryWork> LiteraryWorks { get; set; } = new List<LiteraryWork>();
}

