    public static class MenuData
    {
        public static List<Menu> Menus = new List<Menu>
        {
            new Menu {Title= "Ana Sayfa",Url= "/",IsAuthorized= false,IsAdminOnly= false},
            new Menu {Title= "Yeni Kullanıcı",Url= "/Register",IsAuthorized= true,IsAdminOnly= true},
            new Menu {Title= "Kullanıcı Listesi",Url= "/userlist",IsAuthorized= true,IsAdminOnly= true},
            new Menu {Title= "Yeni Event",Url= "/newevent",IsAuthorized= true,IsAdminOnly= true},
            new Menu {Title= "Event Listesi",Url= "/eventlist",IsAuthorized= true,IsAdminOnly= true},
            new Menu {Title= "Evente Katıl",Url= "/eventsignup",IsAuthorized= false,IsAdminOnly= false},
            new Menu {Title= "Katılım Listesi",Url= "/participants",IsAuthorized= false,IsAdminOnly= false},
            new Menu {Title= "Hakkında",Url= "/about",IsAuthorized= false,IsAdminOnly= false},
            new Menu {Title= "İletişim",Url= "/contact",IsAuthorized= false,IsAdminOnly= false},
        };
    }
