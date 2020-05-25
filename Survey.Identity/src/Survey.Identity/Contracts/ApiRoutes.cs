namespace Survey.Identity.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "survey/identity";

        public const string Version = "v1";

        public const string Base = Root+"/"+Version ;

        public static class Entities
        {
            public const string QueryAll = Base + "/entities";
            public const string QueryById = Base + "/entities/{id:Guid}";


            public const string EditeInfo = Base + "/entities/{id:Guid}";
            public const string Create = Base + "/entities";
            public const string Delete = Base + "/entities/{id:Guid}/delete";
        }
        public static class EntitiyLevels
        {
            public const string QueryAll = Base + "/entityLevels";
            public const string QueryById = Base + "/entityLevels/{id:Guid}";


            public const string EditeInfo = Base + "/entityLevels/{id:Guid}";
            public const string Create = Base + "/entityLevels";
            public const string Delete = Base + "/entityLevels/{id:Guid}/delete";
        }


        public static class Users
        {
            public const string QueryAll = Base + "/users";
            public const string QueryById = Base + "/users/{id:Guid}";


            public const string EditeInfo = Base + "/users/{id:Guid}";
            public const string Unregister = Base + "/users/{id:Guid}/unregister";
            public const string Register = Base + "/users";
            public const string ChangeEmail = Base + "/users/{id:Guid}/change_email";
        }

        public static class Identity
        {
            public const string SignIn = Base + "/authentication/signin";

            public const string Refresh = Base + "/authentication/refresh";

            public const string SignOut = Base + "/authentication/{id:Guid}/signout";

            public const string ChangePassword = Base + "/authentication/{id:Guid}/change_password";
        }
        public static class Features
        {
            public const string QueryAll = Base + "/features";

            public const string EditInfo = Base + "/features/{id:Guid}";

            public const string Remove = Base + "/features/{id:Guid}/remove";

            public const string QueryById = Base + "/features/{id:Guid}";

            public const string Create = Base + "/features";

            public const string Deactivate = Base + "/features/{id:Guid}/deactivate";

            public const string Activate = Base + "/features/{id:Guid}/activate";

        }
        public static class Roles
        {
            public const string QueryAll = Base + "/roles";

            public const string Edit = Base + "/roles/{id:Guid}";

            public const string UpdateFeatures = Base + "/roles/{id:Guid}/features";

            public const string Remove = Base + "/roles/{id:Guid}/remove";

            public const string QueryById = Base + "/roles/{id:Guid}";

            public const string Create = Base + "/roles";

            public const string Deactivate = Base + "/roles/{id:Guid}/deactivate";

            public const string Activate = Base + "/roles/{id:Guid}/activate";

        }


    }
}
