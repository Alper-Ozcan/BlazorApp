public static class EventUserData
{
    public static List<UserEvent> UserEvents = new List<UserEvent>
        {
            new UserEvent
            {
                UEId= 1,
                UserID= 1,
                UserName= "Admin",
                EventId= 1,
                EventName= "Müzik Festivali",
                EventDate= DateTime.Parse("2023-05-20"),
                EventLocation= "İstanbul"
            },
            new UserEvent
            {
                UEId= 2,
                UserID= 1,
                UserName= "Admin",
                EventId= 2,
                EventName= "Tiyatro Gösterisi",
                EventDate= DateTime.Parse("2023-06-15"),
                EventLocation= "Ankara"
            }
        };
}
