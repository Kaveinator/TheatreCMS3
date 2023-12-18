using System;
using System.ComponentModel.DataAnnotations;

public class CalendarEvent
{
    [Key] // Specify EventID as the primary key
    public int EventID { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? EndDate { get; set; }

    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? StartTime { get; set; }

    [DataType(DataType.Time)]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime? EndTime { get; set; }

    public bool AllDay { get; set; }

    public int TicketsAvailable { get; set; }

    public bool IsProduction { get; set; }

    public string Description { get; set; }
}
